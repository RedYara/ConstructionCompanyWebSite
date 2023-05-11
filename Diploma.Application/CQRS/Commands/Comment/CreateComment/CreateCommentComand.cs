using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Comment.AddCommentComand
{
    public class CreateCommentComand : IRequest<bool>
    {
        public Guid BuildingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public string BuildingType { get; set; }
    }
}
