using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Member.Commands.Factory
{
    public class MemberFactory : IMemberFactory
    {
        public Domain.Member Create(string name, Domain.Category category, DateTime birthDate)
        {
            Domain.Member member = new Domain.Member
            {
                Name = name,
                Category = category,
                BirthDate = birthDate
            };

            return member;
        }
    }
}
