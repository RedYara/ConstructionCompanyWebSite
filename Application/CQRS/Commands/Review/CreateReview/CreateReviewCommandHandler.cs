using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Commands.Review.CreateReview
{
    public class CreateReviewCommandHandler(IWebDbContext dbContext) : IRequestHandler<CreateReviewCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Reviews.AddAsync(new Domain.Review()
            {
                Date = DateTime.Now,
                Rating = request.Rating,
                Text = request.Text,
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
