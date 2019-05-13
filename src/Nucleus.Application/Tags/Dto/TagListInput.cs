using Nucleus.Application.Dto;

namespace Nucleus.Application.Tags.Dto
{
    public class TagListInput : PagedListInput
    {
        public TagListInput()
        {
            SortBy = "Name";
        }
    }
}