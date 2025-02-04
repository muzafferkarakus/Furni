using Furni.DtoLayer.Dtos.ProductDtos;
using Furni.EntityLayer.Concrete;

namespace Furni.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<ResultProductDto> TGet3ProductList();
    }
}
