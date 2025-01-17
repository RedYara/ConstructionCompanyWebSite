using MediatR;

namespace Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class CreateGroupTypeCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
