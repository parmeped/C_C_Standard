using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Member.Queries.GetMembersList
{
    public class GetMembersListQuery : IGetMembersListQuery
    {
        private readonly IDatabaseService _database;

        public GetMembersListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<MembersListItemModel> Execute()
        {
            var members = _database.Members
                .Select(x => new MembersListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name                    
                });

            return members.ToList();
        }

    }
}
