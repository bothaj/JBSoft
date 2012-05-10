using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JBSoft.Bll
{
    public interface IEmailBll
    {
        /// <summary>
        /// Logs into the Email service provider to allow the sending of Email via COM
        /// </summary>
        void Login(string userName, string password, string apiID);

        //bool SendSingeEmail(string subject, string message, string emailAddress, System.Net.Mail.Attachment File, Guid currentUserId);

        //bool SendMultipleEmail(string subject, string message, System.Net.Mail.Attachment File, List<string> targetEmailAddresses, Guid currentUserId);

        //bool SendEmailToUserGroups(string subject, string message, System.Net.Mail.Attachment File, List<Guid> userGroupIds, Guid currentUserId);

        //bool SendEmailToSubEventGroups(string subject, string message, System.Net.Mail.Attachment File, List<Guid> subEventGroupIds, Guid currentUserId);

        //bool SendEmailToAttendeeTypes(string subject, string message, System.Net.Mail.Attachment File, List<string> attendeeTypeIds, Guid currentUserId);

        //bool SendEmailToAllUsers(string subject, string message, System.Net.Mail.Attachment File, Guid currentUserId);
    }
}
