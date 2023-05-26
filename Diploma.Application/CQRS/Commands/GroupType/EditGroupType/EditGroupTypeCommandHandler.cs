using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class EditGroupTypeCommandHandler : IRequestHandler<EditGroupTypeCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public EditGroupTypeCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(EditGroupTypeCommand request, CancellationToken cancellationToken)
        {
            var groupToEdit = await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Name == request.Name);
            if (groupToEdit.Name != request.Name) 
                groupToEdit.Name = request.Name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
