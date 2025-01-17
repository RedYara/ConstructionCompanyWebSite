﻿using MediatR;

namespace Application.CQRS.Commands.Building.DeleteBuilding
{
    public class DeleteBuildingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
