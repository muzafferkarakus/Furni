using Furni.DataAccessLayer.Abstract;
using Furni.DataAccessLayer.Concrete;
using Furni.DataAccessLayer.Repositories;
using Furni.DtoLayer.Dtos.ProductDtos;
using Furni.EntityLayer.Concrete;

namespace Furni.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public List<ResultProductDto> Get3ProductList()
        {
            var context = new Context();
            var values = context.Products.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductImage = x.ProductImage,
                ProductPrice = x.ProductPrice
            }).Take(3).ToList();
            return values;
        }
    }
}
