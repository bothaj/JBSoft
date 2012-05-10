using System;
using System.Collections.Generic;
using JBSoft.Dal.Models;
using JBSoft.Dal.ResultHelpers;
namespace JBSoft.Bll
{
    public interface IModuleBll
    {
        IEnumerable<Module> SelectAll(Guid userId, string languageCode);

        Module SelectById(Guid id, Guid userId, string languageCode);

        IEnumerable<Module> SelectByUserGroupId(Guid userGroupId, Guid userId, string languageCode);

        IEnumerable<Module> SelectByUserId(Guid userId, string languageCode);

        Module SelectByUserGroupIdAndModuleId(Guid userGroupId, Guid moduleId, Guid userId, string languageCode);
    }
}
