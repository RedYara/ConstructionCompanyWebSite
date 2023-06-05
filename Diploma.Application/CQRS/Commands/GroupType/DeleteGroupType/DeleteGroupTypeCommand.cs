using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.GroupType.DeleteGroupType
{
    public class DeleteGroupTypeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
