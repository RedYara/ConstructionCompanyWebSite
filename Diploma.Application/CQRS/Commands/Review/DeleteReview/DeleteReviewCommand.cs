using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Review.DeleteReview
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
