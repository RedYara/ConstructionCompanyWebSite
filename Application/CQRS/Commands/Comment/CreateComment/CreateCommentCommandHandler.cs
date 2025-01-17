using Application.CQRS.Commands.Comment.AddCommentComand;
using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler(IWebDbContext dbContext) : IRequestHandler<CreateCommentComand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(CreateCommentComand request, CancellationToken cancellationToken)
        {
            var building = _dbContext.Buildings.FirstOrDefault(x => x.Id == request.BuildingId);
            building.Comments ??= [];
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
