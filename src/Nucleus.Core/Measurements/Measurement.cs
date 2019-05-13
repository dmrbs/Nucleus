using System.Collections.Generic;
using Nucleus.Core.Roles;

namespace Nucleus.Core.Measurements
{
    public class Measurement : BaseEntity
    {
        public string Degree { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string FlyNumber { get; set; }
        public string Container { get; set; }
    }
}