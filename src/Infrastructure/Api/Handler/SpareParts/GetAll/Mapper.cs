using Colossus.Domain.Model;

namespace Colossus.Infrastructure.Api.Handler.SpareParts.GetAll
{
    public class Mapper : Mapper<Request, Response, IEnumerable<SparePart>>
    {        
        public override Response FromEntity(IEnumerable<SparePart> spareParts)
        {
            return new Response
            {
                SpareParts = spareParts.Select(x => new Response.SparePart
                {
                    Id = x.ExternalId.ToString(),
                    Description = x.Description,
                })
            };
        }
    }
}