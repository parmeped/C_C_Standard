using Application.Member.Commands;
using Application.Member.Queries.GetMemberDetail;
using Application.Member.Queries.GetMembersList;
using Application.Member.Commands.Factory;
using Persistance;
using System.Web.Mvc;
using Presentation.Member.Models;
using Application.Category.Queries.GetCategoriesList;

namespace Presentation.Member
{
    [RoutePrefix("members")]
    public class MemberController : Controller
    {
        private readonly IGetMembersListQuery _membersListQuery;
        private readonly IGetMemberDetailQuery _memberDetailQuery;
        private readonly ICreateMemberViewModelFactory _factory;
        private readonly ICreateMemberCommand _createMemberCommand;
        
        public MemberController()
        {
            DatabaseService database = new DatabaseService();
            GetMembersListQuery membersListQuery = new GetMembersListQuery(database);
            GetMemberDetailQuery memberDetailQuery = new GetMemberDetailQuery(database);
            CreateMemberViewModelFactory factory = new CreateMemberViewModelFactory(new GetCategoriesListQuery(database));
            CreateMemberCommand createMemberCommand = new CreateMemberCommand(database, new MemberFactory());

            _membersListQuery = membersListQuery;
            _memberDetailQuery = memberDetailQuery;
            _factory = factory;
            _createMemberCommand = createMemberCommand;
        }
        

        [Route("")]
        public ViewResult Index()
        {
            var members = _membersListQuery.Execute();

            return View(members);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var member = _memberDetailQuery.Execute(id);

            return View(member);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public RedirectToRouteResult Create(CreateMemberViewModel viewModel)
        {
            var model = viewModel.Member;

            _createMemberCommand.Execute(model);

            return RedirectToAction("index", "Member");
        }

    }
}