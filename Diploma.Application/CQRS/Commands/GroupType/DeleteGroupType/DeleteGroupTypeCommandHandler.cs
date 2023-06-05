using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.GroupType.DeleteGroupType
{
    public class DeleteGroupTypeCommandHandler : IRequestHandler<DeleteGroupTypeCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public DeleteGroupTypeCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteGroupTypeCommand request, CancellationToken cancellationToken)
        {
            _dbContext.GroupTypes.Remove(await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Id == request.Id));
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
