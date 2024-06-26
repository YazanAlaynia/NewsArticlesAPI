using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsArticlesApi.Commands.ImageCommand;
using NewsArticlesApi.Commands.ImageCommands;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Queries.CommentQueries;
using NewsArticlesApi.Queries.ImagesQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NewsArticlesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLike()
        {
            var queryImage = new GetAllImagesQueries();
            var image = await _mediator.Send(queryImage);
            return Ok(image);
        }


        [HttpPost]
        public async Task<IActionResult> CreateImage([FromForm] CreateImageCommand command)
        {
            var image = await _mediator.Send(command);
            if (image == null)
                return BadRequest("This News Article does not exist ");
            return Ok(command);

        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateImage(int id,[FromForm] UpdateImageCommand command)
        //{
        //    if (id != command.Id)
        //        return BadRequest("The image ID must be equal to the entered ID");

        //    var image = await _mediator.Send(command);
        //    if (image == null)
        //        return BadRequest("This Image ID does not exist");
        //    return Ok(image);
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var imagecommad=await _mediator.Send(new DeleteImageCommand { id=id});
            if (imagecommad == null)
                return BadRequest($"This Image does not exist ");
            return Ok(imagecommad);
        }
    }
}
