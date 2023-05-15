using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Review.CreateReview
{
    public class CreateReviewCommand : IRequest<bool>
    {
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}
