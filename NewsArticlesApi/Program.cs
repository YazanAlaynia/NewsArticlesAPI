using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsArticlesApi.Commands;
using NewsArticlesApi.Handlers;
using NewsArticlesApi.Models;
using NewsArticlesApi.Queries;
using NewsArticlesApi.Services.IRepository;
using NewsArticlesApi.Services.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(option => option.UseSqlServer(connection));



builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INewsArticleService,NewsArticleService>();
builder.Services.AddScoped<ICommentService,CommentsService>();
builder.Services.AddScoped<ILikeService,LikeService>();
builder.Services.AddScoped<IImageService,ImageService>();
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
 });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
