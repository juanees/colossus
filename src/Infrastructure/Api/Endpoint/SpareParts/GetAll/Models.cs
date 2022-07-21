namespace Colossus.Infrastructure.Api.Endpoint.SpareParts.GetAll
{
    public class Request
    {
        // No need for request model
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            // No need for fluent validation for this request (as it is empty)
        }
    }

    public class Response
    {
        public IEnumerable<SparePart> SpareParts { get; set; }        

        public class SparePart
        {
            public string Id { get; set; }
            public string Description { get; set; }           
        }
    }
}