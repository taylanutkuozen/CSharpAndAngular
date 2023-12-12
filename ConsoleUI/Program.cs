using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
//SOLID
//Open Closed Principle
//Data Transformation Object=DTO
ProductManager productManager = new ProductManager(new EfProductDal());
var result = productManager.GetProductDetail();
if(result.Success==true)
{
    foreach (var product in result.Data)
    {
        Console.WriteLine(product.ProductName + " / " + product.CategoryName);
    }
}
else
{
    Console.WriteLine(result.Message);
}
Console.WriteLine("----------");
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
foreach (var category in categoryManager.GetAll())
{
    Console.WriteLine(category.CategoryName);
}
Console.WriteLine("-----------------------");
foreach (var product in productManager.GetAll().Data)    
{
    Console.WriteLine(product.ProductName);
}
Console.WriteLine("----------");
foreach(var product in productManager.GetAllByCategoryId(5).Data)
{
    Console.WriteLine(product.ProductName);
}
Console.WriteLine("----------");
foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
{
    Console.WriteLine(product.ProductName);
}
Console.ReadLine();