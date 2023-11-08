using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
//SOLID
//Open Closed Principle
//Data Transformation Object=DTO
ProductManager productManager = new ProductManager(new EfProductDal());
foreach (var product in productManager.GetProductDetail())
{
    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
}
Console.WriteLine("----------");
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
foreach (var category in categoryManager.GetAll())
{
    Console.WriteLine(category.CategoryName);
}
Console.WriteLine("-----------------------");
foreach (var product in productManager.GetAll())    
{
    Console.WriteLine(product.ProductName);
}
Console.WriteLine("----------");
foreach(var product in productManager.GetAllByCategoryId(5))
{
    Console.WriteLine(product.ProductName);
}
Console.WriteLine("----------");
foreach (var product in productManager.GetByUnitPrice(50,100))
{
    Console.WriteLine(product.ProductName);
}
Console.ReadLine();