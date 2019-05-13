using Nucleus.Application.Dto;

namespace Nucleus.Application.Measurements.Dto
{
    public class MeasurementDto : EntityDto
    {
        public string Degree { get; set; }

        public string Description { get; set; }

        public string StartTime { get; set; }
        public string FinisTime { get; set; }
        public string FlyNumber { get; set; }
        public string Container { get; set; }

    }
}