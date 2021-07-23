using Core.Entities;

namespace Entities.Concrete
{
    public class Word : IEntity
    {
        public int WordId { get; set; }
        public string WordName { get; set; }
        public string WordUseArea { get; set; }
        public string WordDescription { get; set; }
    }
}