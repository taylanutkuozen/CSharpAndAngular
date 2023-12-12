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
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id).ToList());
        }

        public IDataResult<Product> GetByID(int productID)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productID));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal minValue, decimal maxValue)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= minValue && p.UnitPrice <= maxValue));
        }
        public IDataResult<List<ProductDetailDTO>> GetProductDetail()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<ProductDetailDTO>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetail());
        }
    }
}