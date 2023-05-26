using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class EditGroupTypeCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
