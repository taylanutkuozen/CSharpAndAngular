using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
//SOLID
//Open Closed Principle 
ProductManager productManager = new ProductManager(new EfProductDal());
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