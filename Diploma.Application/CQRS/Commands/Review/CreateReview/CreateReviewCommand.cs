using MediatR;

namespace Diploma.Application.CQRS.Commands.Review.CreateReview
{
    public class CreateReviewCommand : IRequest<bool>
    {
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}
