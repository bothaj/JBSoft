using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Dal.Models;

namespace JBSoft.Bll
{
    public interface IPersonBll
    {
        IResult Delete(Guid id, Guid userId);

        IResult DeleteUpdate(Guid id, Guid userId);

        IResult Insert(Person item, Guid userId);

        IResult Update(Person item, Guid userId);

        List<Person> SelectAll(Guid userId);

        Person SelectById(Guid id, Guid userId);

        List<Person> SelectByUserGroupId(Guid userGroupId, Guid userId);

        Person SelectByMobileNo(string mobileNo, Guid userId);

        //Person SelectByEmailAddress(string emailAddress, Guid userId);

        Person SelectByName(string name, Guid userId);
    }
}
