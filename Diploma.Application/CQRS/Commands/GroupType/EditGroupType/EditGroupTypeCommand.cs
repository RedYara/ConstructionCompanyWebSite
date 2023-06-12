using MediatR;

namespace Diploma.Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class EditGroupTypeCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
