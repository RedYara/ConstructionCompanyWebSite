﻿using Diploma.Application.CQRS.Commands.Comment.AddCommentComand;
using Diploma.Application.Interfaces;
using Diploma.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentComand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public CreateCommentCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(CreateCommentComand request, CancellationToken cancellationToken)
        {
            if (request.BuildingType == "House")
            {
                var house = _dbContext.Houses.FirstOrDefault(x => x.Id == request.BuildingId);
                if (house.Comments == null)
                {
                    house.Comments = new List<Domain.Comment>();
                }
                house.Comments.Add(new Domain.Comment
                {
                    BuildingId = request.BuildingId,
                    Content = request.Content,
                    Email = request.Email,
                    Name = request.Name,
                });
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                var bath = _dbContext.Baths.FirstOrDefault(x => x.Id == request.BuildingId);
                if (bath.Comments == null)
                {
                    bath.Comments = new List<Domain.Comment>();
                }
                bath.Comments.Add(new Domain.Comment
                {
                    BuildingId = request.BuildingId,
                    Content = request.Content,
                    Email = request.Email,
                    Name = request.Name,
                });
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            return true;
        }
    }
}
