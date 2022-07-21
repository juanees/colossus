using Colossus.Domain.Model;

namespace Colossus.Infrastructure.Api.Endpoint.SpareParts.GetAll
{
    public class Mapper : Mapper<Request, Response, IEnumerable<SparePart>>
    {        
        public override Response FromEntity(IEnumerable<SparePart> spareParts)
        {
            return new Response
            {
                SpareParts = spareParts.Select(x => new Response.SparePart
                {
                    Id = x.Id.ToString(),
                    Description = x.Description,
                })
            };
        }
    }
}