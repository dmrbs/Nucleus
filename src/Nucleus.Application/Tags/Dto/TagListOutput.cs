using Nucleus.Application.Dto;

namespace Nucleus.Application.Tags.Dto
{
    public class TagListOutput: PagedListOutput
    {
        public string Description { get; set; }
        public string SerialNumber { get; set; }



    }
}