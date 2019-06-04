using Application.Member.Commands;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Presentation.Member.Models
{
    public class CreateMemberViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public CreateMemberModel Member { get; set; }
    }
}