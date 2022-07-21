using ValueOf;

namespace Colossus.Domain.Model
{
    public class Id : ValueOf<Guid, Id>
    {
        protected override void Validate()
        {
            if (Value == Guid.Empty)
            {
                throw new ArgumentException("Id cannot be empty", nameof(Id));
            }
        }
    }
}
