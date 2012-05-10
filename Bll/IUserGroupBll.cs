using System;
using System.Collections.Generic;
using JBSoft.Dal.Models;
using JBSoft.Dal.ResultHelpers;
namespace JBSoft.Bll
{
    public interface IUserGroupBll
    {
        IResult Delete(Guid id, Guid userId);

        InsertResult Insert(UserGroup userGroup, Guid userId);

        IEnumerable<UserGroup> SelectAll(Guid userId);

        IEnumerable<UserGroup> SelectAllLike(string description, Guid userId);

        UserGroup SelectOneLike(string description, Guid userId);

        UserGroup SelectById(Guid id, Guid userId);

        UpdateResult Update(UserGroup userGroup, Guid userId);

        InsertResult AddModule(Guid userGroupId, Guid moduleId, Guid userId);

        InsertResult RemoveModule(Guid userGroupId, Guid moduleId, Guid userId);
    }
}
