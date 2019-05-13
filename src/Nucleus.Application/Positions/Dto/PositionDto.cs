using Nucleus.Application.Dto;

namespace Nucleus.Application.Positions.Dto
{
    public class PositionDto : EntityDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}