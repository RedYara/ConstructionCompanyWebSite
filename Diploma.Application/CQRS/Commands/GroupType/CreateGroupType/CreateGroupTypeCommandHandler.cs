﻿using Diploma.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.GroupType.CreateGroupType
{
    public class CreateGroupTypeCommandHandler : IRequestHandler<CreateGroupTypeCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public CreateGroupTypeCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(CreateGroupTypeCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.GroupTypes.AddAsync(new Domain.GroupType
            {
                Name = request.Name,
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
