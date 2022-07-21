using Colossus.Domain.Model;
using Colossus.Domain.Service;
using Microsoft.AspNetCore.Authorization;

namespace Colossus.Infrastructure.Api.Handler.SpareParts.GetAll
{
    [HttpGet("spareparts"), AllowAnonymous]
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        private readonly IService<SparePart> service;

        public Endpoint(IService<SparePart> _service)
        {
            service = _service;
        }
        
        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var list = service.GetQueryable().ToList();

            await SendAsync(Map.FromEntity(list), 200, c);
        }
    }
}