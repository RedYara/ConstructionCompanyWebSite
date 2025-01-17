using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandHandler(IWebDbContext dbContext) : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Comments.Remove(_dbContext.Comments.FirstOrDefault(x => x.Id == request.Id));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
