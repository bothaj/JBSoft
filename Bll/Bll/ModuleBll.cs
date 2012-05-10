using JBSoft.Dal.ResultHelpers;
using JBSoft.Dal.Models;
using System;
using System.Collections.Generic;
using JBSoft.Dal;
using System.Data.SqlClient;
using JBSoft.Dal.Helpers;
using Tangent.Logging;

namespace JBSoft.Bll
{
    public class ModuleBll : IModuleBll
    {
        public IEnumerable<Module> SelectAll(Guid userId, string languageCode)
        {
            using (var dr = ModuleDb.SelectAll(languageCode))
                return dr.TranslateMany<Module>();
        }

        public Module SelectById(Guid id, Guid userId, string languageCode)
        {
            using (var dr = ModuleDb.SelectById(id, languageCode))
                return dr.TranslateSingle<Module>();
        }

        public IEnumerable<Module> SelectByUserGroupId(Guid userGroupId, Guid userId, string languageCode)
        {
            using (var dr = ModuleDb.SelectByUserGroupId(userGroupId, languageCode))
                return dr.TranslateMany<Module>();
        }

        public IEnumerable<Module> SelectByUserId(Guid userId, string languageCode)
        {
            using (var dr = ModuleDb.SelectByUserId(userId, languageCode))
                return dr.TranslateMany<Module>();
        }

        public Module SelectByUserGroupIdAndModuleId(Guid userGroupId, Guid moduleId, Guid userId, string languageCode)
        {
            using (var dr = ModuleDb.SelectByUserGroupIdAndModuleId(userGroupId, moduleId, languageCode))
                return dr.TranslateSingle<Module>();
        }
    }
}
