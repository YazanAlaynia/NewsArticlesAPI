using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsArticlesApi.DtoHelper;
using NewsArticlesApi.Models;
using NewsArticlesApi.Services.IRepository;
using MediatR;
using NewsArticlesApi.Queries;
using NewsArticlesApi.Commands.NewsArticleCommands;
using NewsArticlesApi.Queries.NewsArticleQueries;


namespace NewsArticlesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticleController : ControllerBase
    {
        private readonly IMediator _mediater;

        public NewsArticleController(IMediator mediater, INewsArticleService newsArticleService)
        {
            _mediater = mediater;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllNewsArticales()
        {
            var queryNewsArticle = new GetallNewsArticleQuery();
            var resalt =await _mediater.Send(queryNewsArticle);
            return Ok(resalt);
         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsArticleById(int id)
        {
            var queryNewsArticle = new GetNewsArticleByIdQuery(id);
            var resalt = await _mediater.Send(queryNewsArticle);
            if (resalt == null)
                return NotFound($"This article with this id ={id} does not exist");
            return Ok(resalt);

        }



        [HttpPost]
        public async Task<IActionResult> AddNewaArticle([FromForm] CreateNewsArticleCommand command)
        {

            var result = await _mediater.Send(command);
            return Ok(result);

       
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Updatenews(int id,[FromForm] UpdateNewArticleCommand command)
        {
            if(id!=command.Id)
                return BadRequest("The News Article ID must be equal to the entered ID");
            var updateNews = await _mediater.Send(command);
            if (updateNews == null)
                return BadRequest("This News Article does not exist");
            return Ok(updateNews);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsArticle(int id)
        {
            
            var news = await _mediater.Send(new DeleteNewsArticleCommand { id=id});
            if (news==null)
            {
                return BadRequest($"This newsArticle with this Id : {id} does  not exist ");

            }
            return Ok(news);
        }


        [HttpGet("Search")]
        public async Task<ActionResult<List<NewsArticle>>> SearctNewsArticle([FromQuery] SearchForNewsArticleQuery query)
        {
            var articles=await _mediater.Send(query);
            if (articles==null)
                return BadRequest("This News Aricle does not exist");
            return Ok(articles);

           


        }
    }
}
