using Nucleus.Application.Dto;

namespace Nucleus.Application.Measurements.Dto
{
    public class MeasurementListInput : PagedListInput
    {
        public MeasurementListInput()
        {
            SortBy = "Name";
        }
    }
}