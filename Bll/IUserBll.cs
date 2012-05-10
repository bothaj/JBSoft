using System;
using System.Collections.Generic;
using JBSoft.Dal.Models;
using JBSoft.Dal.ResultHelpers;

namespace JBSoft.Bll
{
    public interface IUserBll
    {
        IResult Delete(Guid Id, Guid userId);

        /// <summary>
        /// Selects a user from the db using the username as the search criteria.
        /// </summary>
        User SelectUserByUserName(string userName);

        /// <summary>
        /// Selects a user from the db using the username as the search criteria.
        /// </summary>
        //User SelectBackOfficeUserByUserName(string userName);

        /// <summary>
        /// Inserts the user into the db.
        /// </summary>
        IResult Insert(User user, Guid userId);
        
        /// <summary>
        /// Selects all users that belong to the user group admin.
        /// This group is configured in the config file.
        /// </summary>
        IEnumerable<User> SelectAdminUsers(Guid adminGroupId, Guid userId);

        IEnumerable<User> SelectAll(Guid userId);

        User SelectById(Guid id, Guid userId);

        User SelectLikeId(string likeUserId, Guid userId);

        IEnumerable<User> SelectByUserGroupId(Guid id, Guid userId);

        IEnumerable<User> SelectBySubEventId(Guid? subEventIds, Guid userId);

        IEnumerable<User> SelectByGroupingId(Guid? groupingIds, Guid userId);

        IEnumerable<User> SelectByAttendeeGuestTypeId(int? attendeeTypeId, int? guestTypeId, Guid userId);

        IEnumerable<User> Search(string name, string email, string username, Guid userId);

        IResult Update(User user, Guid userId);
    }
}
