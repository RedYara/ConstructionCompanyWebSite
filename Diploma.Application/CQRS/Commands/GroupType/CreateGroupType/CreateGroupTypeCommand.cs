using MediatR;

namespace Diploma.Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class CreateGroupTypeCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
