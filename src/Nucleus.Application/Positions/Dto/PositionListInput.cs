using Nucleus.Application.Dto;

namespace Nucleus.Application.Positions.Dto
{
    public class PositionListInput : PagedListInput
    {
        public PositionListInput()
        {
            SortBy = "Name";
        }
    }
}