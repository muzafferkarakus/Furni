using Furni.DataAccessLayer.Abstract;
using Furni.DataAccessLayer.Concrete;
using Furni.DataAccessLayer.Repositories;
using Furni.EntityLayer.Concrete;

namespace Furni.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }
    }
}
