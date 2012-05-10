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
using System.Web.Mail;

namespace JBSoft.Bll
{
    public class EmailBll : IEmailBll
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

        public bool SendSingeEmail(string subject, string message, string emailAddress, List<string> attachmentPaths, Guid currentUserId)
        {
            return this.WsSendSimpleEmail(subject, message, emailAddress, attachmentPaths, currentUserId);
        }

        public bool SendMultipleEmail(string subject, string message, List<string> attachmentPaths, List<string> targetEmailAddresses, Guid currentUserId)
        {
            return this.WsSendSimpleBatch(subject, message, attachmentPaths, targetEmailAddresses, currentUserId);
        }

        public bool SendEmailToUserGroups(string subject, string message, List<string> attachmentPaths, List<Guid> userGroupIds, Guid currentUserId)
        {
            return this.DoSendEmailToUserGroups(subject, message, null, userGroupIds, currentUserId);
        }

        private bool WsSendSimpleBatch(string subject, string message, List<string> attachmentPaths, List<string> targetEmailAddresses, Guid currentUserId)
        {
            return true;
        }        

        public bool SendEmailToSubEventGroups(string subject, string message, List<string> attachmentPaths, List<Guid> subEventGroupIds, Guid currentUserId)
        {
            return this.DoSendEmailToSubEventGroups(subject, message, attachmentPaths, subEventGroupIds, currentUserId);
        }

        public bool SendEmailToAttendeeTypes(string subject, string message, List<string> attachmentPaths, List<string> attendeeGuestTypeIds, Guid currentUserId)
        {
            return this.DoSendEmailToAttendeeTypes(subject, message, null, attendeeGuestTypeIds, currentUserId);
        }        

        public bool SendEmailToAllUsers(string subject, string message, List<string> attachmentPaths, Guid currentUserId)
        {
            return this.DoSendEmailToAllUsers(subject, message, attachmentPaths, currentUserId);
        }
        
        #endregion

        #region Private Methods

        private bool WsSendSimpleEmail(string subject, string message, string emailAddress, List<string> attachmentPaths, Guid currentUserId)
        {
            try
            {
                System.Web.Mail.MailFormat format = new System.Web.Mail.MailFormat();

                string FromEmail = "onemobile1@gmail.com";
                string Password = "1mobile1";

                System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();

                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                //sendusing: cdoSendUsingPort, value 2, for sending the message using 
                //the network.

                //smtpauthenticate: Specifies the mechanism used when authenticating 
                //to an SMTP 
                //service over the network. Possible values are:
                //- cdoAnonymous, value 0. Do not authenticate.
                //- cdoBasic, value 1. Use basic clear-text authentication. 
                //When using this option you have to provide the user name and password 
                //through the sendusername and sendpassword fields.
                //- cdoNTLM, value 2. The current process security context is used to 
                // authenticate with the service.
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //Use 0 for anonymous
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", FromEmail);
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Password);
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                myMail.From = FromEmail;

                myMail.Subject = subject;
                myMail.BodyFormat = format;
                myMail.Body = message;

                foreach (string path in attachmentPaths)
                {
                    if (path.Trim() != "")
                    {
                        MailAttachment MyAttachment = new MailAttachment(path);
                        myMail.Attachments.Add(MyAttachment);
                    }
                }

                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com:465";

                myMail.To = emailAddress;

                System.Web.Mail.SmtpMail.Send(myMail);
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }    

        private bool DoSendEmailToUserGroups(string subject, string message, List<string> attachmentPaths, List<Guid> userGroupIds, Guid currentUserId)
        {
            List<User> recipients = new List<User>();

            //Get all the users to send the Email to.
            foreach (var userGroupId in userGroupIds)
                recipients.AddRange(this.UserBll.SelectByUserGroupId(userGroupId, currentUserId));

            //Create the ftp file and send to the file location
            return SendToUsers(recipients, subject, message, attachmentPaths);
        }

        private bool DoSendEmailToSubEventGroups(string subject, string message, List<string> attachmentPaths, List<Guid> subEventGroupIds, Guid currentUserId)
        {
            List<User> recipients = new List<User>();

            //Get all the users to send the Email to.
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
            return SendToUsers(recipients, subject, message, attachmentPaths);
        }

        private bool DoSendEmailToAttendeeTypes(string subject, string message, List<string> attachmentPaths, List<string> attendeeGuestTypeIds, Guid currentUserId)
        {
            List<User> recipients = new List<User>();

            //Get all the users to send the Email to.
            foreach (var attendeeGuestTypeId in attendeeGuestTypeIds)
            {
            //    EventManagement.Bll.AttendeeBll attendeeBll = new EventManagement.Bll.AttendeeBll();
            //    EventManagement.Models.Attendee attendee = new EventManagement.Models.Attendee();

                string[] attendeeGuestTypes = attendeeGuestTypeId.Split("|".ToCharArray());

                //Guid attendeeTypeId = new Guid(attendeeGuestTypes[0]);
                //Guid guestTypeId = new Guid(attendeeGuestTypes[1]);

                recipients.AddRange(this.UserBll.SelectByAttendeeGuestTypeId((attendeeGuestTypes[0] == "0" ? null : (int?)Convert.ToInt32(attendeeGuestTypes[0])), (attendeeGuestTypes[1] == "0" ? null : (int?)Convert.ToInt32(attendeeGuestTypes[1])), currentUserId));
            }

            //Create the ftp file and send to the file location
            return SendToUsers(recipients, subject, message, attachmentPaths);
        }

        private bool DoSendEmailToAllUsers(string subject, string message, List<string> attachmentPaths, Guid currentUserId)
        {
            //Get all the users to send the Email to.
            var users = this.UserBll.SelectAll(currentUserId);

            //Create the ftp file and send to the file location
            return SendToUsers(users.ToList(), subject, message, attachmentPaths);
        }

        private bool SendToUsers(List<User> recipients, string subject, string message, List<string> attachmentPaths)
        {
            System.Web.Mail.MailFormat format = new System.Web.Mail.MailFormat();

            string FromEmail = "onemobile1@gmail.com";
            string Password = "1mobile1";
            //string FromEmail = "johnny.botha@gmail.com";
            //string Password = "Midlands2252";
        
            try
            {
                System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();

                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                //sendusing: cdoSendUsingPort, value 2, for sending the message using 
                //the network.

                //smtpauthenticate: Specifies the mechanism used when authenticating 
                //to an SMTP 
                //service over the network. Possible values are:
                //- cdoAnonymous, value 0. Do not authenticate.
                //- cdoBasic, value 1. Use basic clear-text authentication. 
                //When using this option you have to provide the user name and password 
                //through the sendusername and sendpassword fields.
                //- cdoNTLM, value 2. The current process security context is used to 
                // authenticate with the service.
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //Use 0 for anonymous
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", FromEmail);
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Password);
                myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");

                myMail.From = FromEmail;
                myMail.Subject = subject;
                myMail.BodyFormat = format;
                myMail.Body = message;

                //System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage("onemobile1@gmail.com", "johnny.botha@gmail.com");

                //MailMessage message = new MailMessage("from@foo.com", "to@foo.com");
                MemoryStream stream = new MemoryStream(new byte[64000]);
               // System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(stream, attachmentPaths[0]);
                //myMail.Attachments.Add(attachment);
                //myMail.Body = "This is an async test.";
                //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com 465");
                //smtp.Credentials = new NetworkCredential("login", "password");
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com 465";

                foreach (var user in recipients)
                {
                    //myMail.To = user.EmailAddress;

                    System.Web.Mail.SmtpMail.Send(myMail);
                } 

                

                //if (attachmentPaths != null && attachmentPaths.Count > 0 && attachmentPaths[0] != null)
                //{
                //    foreach (string path in attachmentPaths)
                //    {
                //        if (path.Trim() != "")
                //        {
                //            MailAttachment MyAttachment = new MailAttachment(path);
                //            myMail.Attachments.Add(MyAttachment);
                //        }
                //    }
                //}

                //System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com 465";

                //foreach (var user in recipients)
                //{
                //    myMail.To = user.EmailAddress;

                //    System.Web.Mail.SmtpMail.Send(myMail);
                //} 

                
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;

        
        }

        #endregion
    }
}
