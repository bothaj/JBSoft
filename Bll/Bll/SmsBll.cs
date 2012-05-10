using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web.Mvc;
using JBSoft.Dal.Models;
using System.IO;
using Tangent.Logging;
using System.Configuration;
using System.Net;

namespace JBSoft.Bll
{
    public class SmsBll : ISmsBll
    {
        #region Members

        private IUserBll userBll;
        private IUserGroupBll userGroupBll;

        #endregion

        #region Properties

        private IUserGroupBll UserGroupBll
        {
            get
            {
                if (this.userGroupBll == null)
                    this.userGroupBll = new UserGroupBll();

                return userGroupBll;
            }
        }

        private IUserBll UserBll
        {
            get
            {
                if (this.userBll == null)
                    this.userBll = new UserBll();

                return userBll;
            }
        }

        #endregion

        #region Public Methods

        public void Login(string userName, string password, string apiID)
        {
            throw new NotImplementedException();
        }

        public string SendSingeSms(string message, string targetNumber, Guid currentUserId)
        { 
            return this.WsSendSimpleSms(message, targetNumber);
        }

        public string SendMultipleSms(string message, List<string> targetNumbers, Guid currentUserId)
        {
            return this.WsSendSimpleBatch(message, targetNumbers);
        }

        public bool SendMultipleSms(string message, List<string> targetNumbers, Guid currentUserId, DateTime sendDateTime, bool scheduled)
        {
            List<User> user = new List<User>();
            foreach (var number in targetNumbers)
            {
                User U = new User();
                U.PhoneMobile = number;
                user.Add(U);
            }
            if (scheduled)
            {
                TimeSpan timeDifference = sendDateTime - DateTime.Now;
                var minutes = Convert.ToInt32(timeDifference.TotalMinutes);

                if (minutes > 10070)
                    throw new Exception("Please note the SMS can only be scheduled less the 7 days from this point i.e. less than 10080 minutes");
                if (minutes <= 10)
                    throw new Exception("Please note the SMS cannot be scheduled for less than 10 minutes from the current datetime");
                return SendToNumbers(user, message, minutes);
            }
            return SendToNumbers(user, message, null);

        }

        public bool SendSmsToUserGroups(string message, List<Guid> userGroupIds, Guid currentUserId)
        {
            return this.DoSendSmsToUserGroups(message, null, userGroupIds, currentUserId);
        }

        public bool SendSmsToUserGroups(string message, DateTime sendDateTime, List<Guid> userGroupIds, Guid currentUserId)
        {
            // Find time difference between two dates
            TimeSpan timeDifference = sendDateTime - DateTime.Now;
            var minutes = Convert.ToInt32(timeDifference.TotalMinutes);

            if (minutes > 10070)
                throw new Exception("Please note the SMS can only be scheduled less the 7 days from this point i.e. less than 10080 minutes");
            if (minutes <= 10)
                throw new Exception("Please note the SMS cannot be scheduled for less than 10 minutes from the current datetime");

            return this.DoSendSmsToUserGroups(message, minutes, userGroupIds, currentUserId);
        }

        public bool SendSmsToSubEventGroups(string message, List<Guid> subEventGroupIds, Guid currentUserId)
        {
            return this.DoSendSmsToSubEventGroups(message, null, subEventGroupIds, currentUserId);
        }

        public bool SendSmsToSubEventGroups(string message, DateTime sendDateTime, List<Guid> subEventGroupIds, Guid currentUserId)
        {
            // Find time difference between two dates
            TimeSpan timeDifference = sendDateTime - DateTime.Now;
            var minutes = Convert.ToInt32(timeDifference.TotalMinutes);

            if (minutes > 10070)
                throw new Exception("Please note the SMS can only be scheduled less the 7 days from this point i.e. less than 10080 minutes");
            if (minutes <= 10)
                throw new Exception("Please note the SMS cannot be scheduled for less than 10 minutes from the current datetime");

            return this.DoSendSmsToSubEventGroups(message, minutes, subEventGroupIds, currentUserId);
        }

        public bool SendSmsToAttendeeTypes(string message, List<string> attendeeGuestTypeIds, Guid currentUserId)
        {
            return this.DoSendSmsToAttendeeTypes(message, null, attendeeGuestTypeIds, currentUserId);
        }

        public bool SendSmsToAttendeeTypes(string message, DateTime sendDateTime, List<string> attendeeGuestTypeIds, Guid currentUserId)
        {
            // Find time difference between two dates
            TimeSpan timeDifference = sendDateTime - DateTime.Now;
            var minutes = Convert.ToInt32(timeDifference.TotalMinutes);

            if (minutes > 10070)
                throw new Exception("Please note the SMS can only be scheduled less the 7 days from this point i.e. less than 10080 minutes");
            if (minutes <= 10)
                throw new Exception("Please note the SMS cannot be scheduled for less than 10 minutes from the current datetime");

            return this.DoSendSmsToAttendeeTypes(message, minutes, attendeeGuestTypeIds, currentUserId);
        }

        public bool SendSmsToAllUsers(string message, Guid currentUserId)
        {
            return this.DoSendSmsToAllUsers(message, null, currentUserId);
        }

        public bool SendSmsToAllUsers(string message, DateTime sendDateTime, Guid currentUserId)
        {
            // Find time difference between two dates
            TimeSpan timeDifference = sendDateTime - DateTime.Now;
            var minutes = Convert.ToInt32(timeDifference.TotalMinutes);

            if (minutes > 10070)
                throw new Exception("Please note the SMS can only be scheduled less the 7 days from this point i.e. less than 10080 minutes");
            if (minutes <= 10)
                throw new Exception("Please note the SMS cannot be scheduled for less than 10 minutes from the current datetime");

            return this.DoSendSmsToAllUsers(message, minutes, currentUserId);
        }

        #endregion

        #region Private Methods

        private string WsSendSimpleSms(string message, string targetNumber)
        {
            var smsWS = new JBSoft.Bll.Clickatell.PushServerWSPortTypeClient();

            try
            {
                var sessionId = smsWS.auth(Convert.ToInt32(ConfigurationManager.AppSettings["ClickatellApi"]),
                    ConfigurationManager.AppSettings["ClickatellUser"],
                    ConfigurationManager.AppSettings["ClickatellPassword"]);

                if (sessionId.Contains("OK"))
                {
                    sessionId = sessionId.Substring(sessionId.IndexOf(":") + 2);

                    targetNumber = targetNumber.Substring(0, 1) == "0"
                                       ? "27" + targetNumber.Substring(1, targetNumber.Length - 1)
                                       : targetNumber;

                    if (targetNumber.Length == 9)
                        targetNumber = "27" + targetNumber;

                    int noSmses = 1;
                    if (message.Length > 320)
                    {
                        noSmses = 3;
                    }
                    else if (message.Length > 160)
                        noSmses = 2;

                    if (ConfigurationManager.AppSettings["ProcessSmsButDontSend"] == "0")
                    {
                        var result = smsWS.sendmsg(sessionId, Convert.ToInt32(ConfigurationManager.AppSettings["ClickatellApi"]),
                        ConfigurationManager.AppSettings["ClickatellUser"], ConfigurationManager.AppSettings["ClickatellPassword"],
                        new string[] { targetNumber }, ConfigurationManager.AppSettings["ClickatellFromNumber"], message,
                        noSmses, 0, 0, 0, 0, 0, 0, 0, 1, null, 0, null, null, null, 0);

                        if (result.Length > 0 && result[0].Substring(0, 2).ToLower() == "id")
                            return result[0];
                        else
                            throw new Exception("Sms sending failed with Error number:" + result);
                    }
                    else
                        return "";
                }
                else
                {
                    throw new Exception("Sms sending failed. Failed to authenticate");
                }
            }
            finally
            {
                smsWS.Close();
            }
            
        }

        private string WsSendSimpleBatch(string message, List<string> targetNumbers)
        {
            var smsWS = new JBSoft.Bll.Clickatell.PushServerWSPortTypeClient();

            try
            {
                var sessionId = smsWS.auth(3322948, "TangentRoadtrip", "abc123");

                if (sessionId.Contains("OK"))
                {
                    sessionId = sessionId.Substring(sessionId.IndexOf(":") + 2);

                    var result = smsWS.sendmsg(sessionId, 3322948, "davidfnel", "yamaha1", targetNumbers.ToArray(), "41561", message,
                        1, 0, 0, 0, 0, 0, 0, 0, 0, null, 0, null, null, null, 0);

                    if (result.Length > 0 && result[0].Substring(0, 2).ToLower() == "id")
                        return result[0];
                    else
                        throw new Exception("Sms sending failed with Error number:" + result);

                }
                else
                {
                    throw new Exception("Sms sending failed. Failed to authenticate");
                }
            }
            finally
            {
                smsWS.Close();
            }
        }

        private bool DoSendSmsToUserGroups(string message, int? numOfMinutes, List<Guid> userGroupIds, Guid currentUserId)
        {
            List<User> recipients = new List<User>();

            //Get all the users to send the sms to.
            foreach (var userGroupId in userGroupIds)
                recipients.AddRange(this.UserBll.SelectByUserGroupId(userGroupId, currentUserId));

            //Create the ftp file and send to the file location
            return SendToUsers(recipients, message, numOfMinutes);
        }

        private bool DoSendSmsToSubEventGroups(string message, int? numOfMinutes, List<Guid> subEventGroupIds, Guid currentUserId)
        {
            List<User> recipients = new List<User>();

            //Get all the users to send the sms to.
            foreach (var subEventGroupId in subEventGroupIds)
            {
                //EventManagement.Bll.GroupingBll groupingBll = new EventManagement.Bll.GroupingBll();
                //EventManagement.Models.Grouping grouping = new EventManagement.Models.Grouping();

                //EventManagement.Bll.SubEventBll subEventBll = new EventManagement.Bll.SubEventBll();
                //EventManagement.Models.SubEvent subEvent = subEventBll.SelectById(subEventGroupId, currentUserId);

                //if (subEvent == null)
                //{
                //    grouping = groupingBll.SelectById(subEventGroupId, currentUserId);

                //    if (grouping != null)
                //    {
                //        recipients.AddRange(this.UserBll.SelectByGroupingId((Guid?)subEventGroupId, currentUserId));
                //    }
                //}
                //else
                //{
                //    recipients.AddRange(this.UserBll.SelectBySubEventId((Guid?)subEventGroupId, currentUserId));
                //}
            }

            //Create the ftp file and send to the file location
            return SendToUsers(recipients, message, numOfMinutes);
        }

        private bool DoSendSmsToAttendeeTypes(string message, int? numOfMinutes, List<string> attendeeGuestTypeIds, Guid currentUserId)
        {
            List<User> recipients = new List<User>();

            //Get all the users to send the sms to.
            foreach (var attendeeGuestTypeId in attendeeGuestTypeIds)
            {
                //EventManagement.Bll.AttendeeBll attendeeBll = new EventManagement.Bll.AttendeeBll();
                //EventManagement.Models.Attendee attendee = new EventManagement.Models.Attendee();

                string[] attendeeGuestTypes = attendeeGuestTypeId.Split("|".ToCharArray());

                //Guid attendeeTypeId = new Guid(attendeeGuestTypes[0]);
                //Guid guestTypeId = new Guid(attendeeGuestTypes[1]);

                recipients.AddRange(this.UserBll.SelectByAttendeeGuestTypeId((attendeeGuestTypes[0] == "0" ? null : (int?)Convert.ToInt32(attendeeGuestTypes[0])), (attendeeGuestTypes[1] == "0" ? null : (int?)Convert.ToInt32(attendeeGuestTypes[1])), currentUserId));
            }

            //Create the ftp file and send to the file location
            return SendToUsers(recipients, message, numOfMinutes);
        }

        private bool DoSendSmsToAllUsers(string message, int? numOfMinutes, Guid currentUserId)
        {
            //Get all the users to send the sms to.
            var users = this.UserBll.SelectAll(currentUserId);

            //Create the ftp file and send to the file location
            return SendToUsers(users.ToList(), message, numOfMinutes);
        }


        private bool SendToNumbers(List<User> recipients, string message, int? numOfMinutes)
        {
            var name = "SMS_" + DateTime.Now.ToString("yyyy/MM/dd_/HH/mm/ss").Replace("/", "");
            var filename = name + ".txt";
            return UploadToFTP(filename, recipients, message, numOfMinutes);
        }

        private bool SendToUsers(List<User> recipients, string message, int? numOfMinutes)
        {
            //var fileLocation = CreateFTPFile(recipients, message, numOfMinutes);

            var name = "SMS_" + DateTime.Now.ToString("yyyy/MM/dd_/HH/mm/ss").Replace("/", "");
            var filename = name + ".txt";
            return UploadToFTP(filename, recipients, message, numOfMinutes);

            //if (fileLocation != null)
            //{
            //    return this.UploadToFTP(fileLocation);
            //}
            //else
            //{
            //    return false;

        }

        private string CreateFTPFile(List<User> recipients, string message, int? minutes)
        {
            TextWriter tw = null;

            try
            {
                var fileCreationPath = (string)ConfigurationManager.AppSettings["SmsFileCreationPath"];
                var fileName = "SMS_" + DateTime.Now.ToString("yyyy/MM/dd_/HH/mm/ss").Replace("/", "");
                var fullFileName = fileCreationPath + "/" + fileName + ".txt";

                tw = new StreamWriter(fullFileName);

                tw.WriteLine("user:davidfnel");
                tw.WriteLine("password:yamaha1");
                tw.WriteLine("api_id:3268472");
                tw.Write("text:");
                tw.WriteLine(message);

                if (minutes.HasValue)
                {
                    tw.Write("deliv_time:");
                    tw.WriteLine(minutes.Value.ToString());
                }

                foreach (var user in recipients)
                {
                    tw.Write("to:");
                    tw.WriteLine(user.PhoneMobile);
                }

                return fullFileName;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log.ErrorException("Error creating FTP file", ex);
                return null;
            }
            finally
            {
                if (tw != null)
                {
                    tw.Close();
                    tw.Dispose();
                }

                tw = null;
            }
        }

        private bool UploadToFTP(string filePath, List<User> recipients, string message, int? minutes)
        {
            Stream rs = null;
            MemoryStream ms = new MemoryStream();
            try
            {
                var ftpAddress = (string)ConfigurationManager.AppSettings["SmsFTPAddress"];
                var username = (string)ConfigurationManager.AppSettings["SmsFTPUserName"];
                var password =  (string)ConfigurationManager.AppSettings["SmsFTPPassword"];
                var clickatelUserName = (string)ConfigurationManager.AppSettings["ClickatelUserName"];
                var clickatelPassword = (string)ConfigurationManager.AppSettings["ClickatelPassword"];
                var clickatelAPI = (string)ConfigurationManager.AppSettings["ClickatelAPI"];

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + ftpAddress + "/" + Path.GetFileName(filePath));

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                byte[] buffer = null;
                StreamWriter sw = new StreamWriter(ms);


                sw.WriteLine(string.Concat("user:", clickatelUserName));
                sw.WriteLine(string.Concat("password:", clickatelPassword));
                sw.WriteLine(string.Concat("api_id:", clickatelAPI));
                sw.Write("text:");
                sw.WriteLine(message);

                if (minutes.HasValue)
                {
                    sw.Write("deliv_time:");
                    sw.WriteLine(minutes.Value.ToString());
                }

                foreach (var user in recipients)
                {
                    sw.Write("to:");
                    var targetNumber = user.PhoneMobile;
                    targetNumber = targetNumber.Substring(0, 1) == "0"
                                       ? "27" + targetNumber.Substring(1, targetNumber.Length - 1)
                                       : targetNumber;

                    if (targetNumber.Length == 9)
                        targetNumber = "27" + targetNumber;

                    sw.WriteLine(targetNumber);
                } 

                sw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                buffer = ms.ToArray();
                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                string myString = enc.GetString(buffer);
                rs = request.GetRequestStream();
                rs.Write(buffer, 0, buffer.Length);
                rs.Close();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log.ErrorException("Error uploading FTP file", ex);
                return false;

            }
            finally
            {
                if (ms != null)
                {
                    ms.Close();
                    ms.Dispose();
                }
                ms = null;

                if (rs != null)
                {
                    rs.Close();
                    rs.Dispose();
                }

                rs = null;
            }
        }

        #endregion
    }
}
