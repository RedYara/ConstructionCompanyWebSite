using Diploma.Application.CQRS.Commands.Comment.AddCommentComand;
using Diploma.Application.CQRS.Commands.Comment.DeleteComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class CommentController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateComment(Guid BuildingId, string Name, string Email, string Content, string BuildingType)
        {
            var command = new CreateCommentComand()
            {
                BuildingId = BuildingId,
                Content = Content,
                Email = Email,
                Name = Name,
                BuildingType = BuildingType
            };
            await Mediator.Send(command);
            string urlReferrer = Request.Headers["Referer"].ToString();

            return Redirect(urlReferrer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(Guid Id)
        {
            var command = new DeleteCommentCommand()
            {
                Id = Id
            };
            await Mediator.Send(command);
            string urlReferrer = Request.Headers["Referer"].ToString();

            return Redirect(urlReferrer);
        }


    }
}
