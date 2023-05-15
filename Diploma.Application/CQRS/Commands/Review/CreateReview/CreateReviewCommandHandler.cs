using Diploma.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Review.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public CreateReviewCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle (CreateReviewCommand request, CancellationToken cancellationToken)
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
