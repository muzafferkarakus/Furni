using Furni.DtoLayer.Dtos.ProductDtos;
using Furni.EntityLayer.Concrete;

namespace Furni.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<ResultProductDto> Get3ProductList();
    }
}
