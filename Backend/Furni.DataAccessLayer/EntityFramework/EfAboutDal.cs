using Furni.DataAccessLayer.Abstract;
using Furni.DataAccessLayer.Concrete;
using Furni.DataAccessLayer.Repositories;
using Furni.EntityLayer.Concrete;

namespace Furni.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {
        }
    }
}
