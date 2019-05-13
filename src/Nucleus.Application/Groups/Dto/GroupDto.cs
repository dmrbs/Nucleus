using Nucleus.Application.Dto;

namespace Nucleus.Application.Groups.Dto
{
    public class GroupDto : EntityDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}