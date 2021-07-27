using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, PostgreDbContext>, IContactDal
    {
        public EfContactDal(PostgreDbContext context) : base(context)
        {
        }
    }
}