using Diploma.Application.CQRS.Commands.Comment.AddCommentComand;
using Diploma.Application.Interfaces;
using MediatR;

namespace Diploma.Application.CQRS.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentComand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public CreateCommentCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(CreateCommentComand request, CancellationToken cancellationToken)
        {
            var building = _dbContext.Buildings.FirstOrDefault(x => x.Id == request.BuildingId);
            if (building.Comments == null)
            {
                building.Comments = new List<Domain.Comment>();
            }
            building.Comments.Add(new Domain.Comment
            {
                BuildingId = request.BuildingId,
                Content = request.Content,
                Email = request.Email,
                Name = request.Name,
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
