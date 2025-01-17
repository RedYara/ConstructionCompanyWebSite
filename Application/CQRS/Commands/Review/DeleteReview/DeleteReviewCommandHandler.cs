using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Review.DeleteReview
{
    public class DeleteReviewCommandHandler(IWebDbContext dbContext) : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Reviews.Remove(await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
