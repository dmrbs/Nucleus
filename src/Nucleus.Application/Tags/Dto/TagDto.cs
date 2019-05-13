using Nucleus.Application.Dto;

namespace Nucleus.Application.Tags.Dto
{
    public class TagDto : EntityDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}