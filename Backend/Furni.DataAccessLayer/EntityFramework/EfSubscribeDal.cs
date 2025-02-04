using Furni.DataAccessLayer.Abstract;
using Furni.DataAccessLayer.Concrete;
using Furni.DataAccessLayer.Repositories;
using Furni.EntityLayer.Concrete;

namespace Furni.DataAccessLayer.EntityFramework
{
    public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
    {
        public EfSubscribeDal(Context context) : base(context)
        {
        }
    }
}
