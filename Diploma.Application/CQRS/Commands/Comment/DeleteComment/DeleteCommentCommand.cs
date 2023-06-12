﻿using MediatR;

namespace Diploma.Application.CQRS.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
