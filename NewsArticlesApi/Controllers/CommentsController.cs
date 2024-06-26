using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticlesApi.Commands.CommentCommands;
using NewsArticlesApi.Commands.NewsArticleCommands;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Models;
using NewsArticlesApi.Queries.CommentQueries;
using NewsArticlesApi.Services.IRepository;

namespace NewsArticlesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly IMediator _mediater;


        public CommentsController(ICommentService commentService, IMediator mediater)
        {
            _mediater = mediater;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllComments()
        //{
        //    var commentquery = new GetAllCommentQuery();
        //    var resalt = await _mediater.Send(commentquery);
        //    return Ok(resalt);
           
        //}

    
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {

            var comment = await _mediater.Send(command);
            if(comment==null)
                return BadRequest("This News Article does not exist ");

            return Ok(comment);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentCommand command)
        {
            if (id != command.Id)
                return BadRequest("The Comment ID must be equal to the entered ID");

            var comment = await _mediater.Send(command);
            if (comment == null)
                return BadRequest("This News Article does not exist Or your Comment does not exist");
            return Ok(comment);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _mediater.Send(new DeleteCommentCommand { id = id });
            if (comment == null)
            {
                return BadRequest($"This Comment with this Id : {id} does  not exist ");

            }
            return Ok(comment);
        }

    }
}
