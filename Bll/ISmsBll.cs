using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Bll
{
    public interface ISmsBll
    {
        /// <summary>
        /// Logs into the sms service provider to allow the sending of sms via COM
        /// </summary>
        void Login(string userName, string password, string apiID);

        string SendSingeSms(string messsage, string targetNumber, Guid currentUserId);

        string SendMultipleSms(string messsage, List<string> targetNumbers, Guid currentUserId);

        bool SendMultipleSms(string messsage, List<string> targetNumbers, Guid currentUserId, DateTime sendDateTime, bool scheduled);

        bool SendSmsToUserGroups(string message, List<Guid> userGroupIds, Guid currentUserId);

        bool SendSmsToUserGroups(string message, DateTime sendDateTime, List<Guid> userGroupIds, Guid currentUserId);

        bool SendSmsToSubEventGroups(string message, List<Guid> subEventGroupIds, Guid currentUserId);

        bool SendSmsToSubEventGroups(string message, DateTime sendDateTime, List<Guid> subEventGroupIds, Guid currentUserId);

        bool SendSmsToAttendeeTypes(string message, List<string> attendeeTypeIds, Guid currentUserId);

        bool SendSmsToAttendeeTypes(string message, DateTime sendDateTime, List<string> attendeeTypeIds, Guid currentUserId);

        bool SendSmsToAllUsers(string message, Guid currentUserId);

        bool SendSmsToAllUsers(string message, DateTime sendDateTime, Guid currentUserId);
    }
}
