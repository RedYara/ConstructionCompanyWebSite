using MediatR;

namespace Diploma.Application.CQRS.Commands.GroupType.DeleteGroupType
{
    public class DeleteGroupTypeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
