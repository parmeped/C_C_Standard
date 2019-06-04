using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Member.Queries.GetMemberDetail
{
    public interface IGetMemberDetailQuery
    {
        MemberDetailModel Execute(int Id);
    }
}
