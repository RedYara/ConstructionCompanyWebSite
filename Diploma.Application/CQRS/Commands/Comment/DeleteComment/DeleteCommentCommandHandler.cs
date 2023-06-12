using Diploma.Application.Interfaces;
using MediatR;

namespace Diploma.Application.CQRS.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public DeleteCommentCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Comments.Remove(_dbContext.Comments.FirstOrDefault(x => x.Id == request.Id));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
