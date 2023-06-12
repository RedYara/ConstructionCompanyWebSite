using MediatR;

namespace Diploma.Application.CQRS.Commands.Review.DeleteReview
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
