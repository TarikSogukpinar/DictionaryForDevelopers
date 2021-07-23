using Core.Entities;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
    }
}