using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Member.Queries.GetMembersList
{
    public interface IGetMembersListQuery
    {
        List<MembersListItemModel> Execute();
    }
}
