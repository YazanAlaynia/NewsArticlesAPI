using MediatR;
using NewsArticlesApi.Models;

namespace NewsArticlesApi.Queries.ImagesQueries
{
    public class GetAllImagesQueries:IRequest<List<Image>>
    {
    }
}
