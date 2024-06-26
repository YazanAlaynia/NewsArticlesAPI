using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticlesApi.Commands.LikeCommends;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;
using System.Net.WebSockets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NewsArticlesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LikeController(IMediator mediator, ILikeService likeService)
        {
            _mediator = mediator;
        }


   

        [HttpPost]
        public async Task<IActionResult> CreateLike([FromBody]CreateLikeCommed commend)
        {
            var like = await _mediator.Send(commend);
            if (like == null)
                return BadRequest("This News Article does not exist ");

            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {

            var likecommed =await _mediator.Send(new DeleteLikeCommend { id = id });
            if (likecommed == null)
                return BadRequest($"This Like with this Id ={id} does not exist ");
            return Ok(likecommed);

        }
    }
}
