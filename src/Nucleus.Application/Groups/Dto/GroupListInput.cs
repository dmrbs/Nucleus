using Nucleus.Application.Dto;

namespace Nucleus.Application.Groups.Dto
{
    public class GroupListInput : PagedListInput
    {
        public GroupListInput()
        {
            SortBy = "Name";
        }
    }
}