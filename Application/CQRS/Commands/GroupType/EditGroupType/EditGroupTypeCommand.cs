using MediatR;

namespace Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class EditGroupTypeCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
