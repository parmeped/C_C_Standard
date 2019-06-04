namespace Application.Member.Commands
{
    public interface ICreateMemberCommand
    {
        void Execute(CreateMemberModel model);
    }
}
