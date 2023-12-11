using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal=productDal;
        }
        public IResult Add(Product product)
        {
            //business codes
            if(product.ProductName.Length<2)
            {
                //magic strings
                //return new ErrorResult("Ürün ismi en az 2 karakter olmalıdır");
                return new ErrorResult(Messages.ProductNameInValid);
            }
           _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            //return new SuccessResult();
        }
        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            return _productDal.GetAll();
        }
        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id).ToList();
        }

        public Product GetByID(int productID)
        {
            return _productDal.Get(p => p.ProductId == productID);
        }

        public List<Product> GetByUnitPrice(decimal minValue, decimal maxValue)
        {
            return _productDal.GetAll(p => p.UnitPrice >= minValue && p.UnitPrice <= maxValue);
        }
        public List<ProductDetailDTO> GetProductDetail()
        {
            return _productDal.GetProductDetail(); ;
        }
    }
}