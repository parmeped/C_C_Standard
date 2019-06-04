using System;

namespace Application.Member.Commands.Factory
{
    public interface IMemberFactory
    {
        Domain.Member Create(string name, Domain.Category category, DateTime birthDate);
    }
}
