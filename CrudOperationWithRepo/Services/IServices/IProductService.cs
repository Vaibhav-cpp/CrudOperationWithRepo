using CrudOperationWithRepo.Models;

namespace CrudOperationWithRepo.Services.IServices
{
    /// <summary>
    /// We can achieve abstraction by using interfaces. 
    /// An interface is a contract that defines a set of methods and properties that a class must implement. 
    /// It allows us to define the behavior of a class without specifying how that behavior is implemented.
    /// 
    /// Abstraction is achieved by using interfaces because it allows us to define a set of methods and properties that a class must implement, without specifying how those methods and properties are implemented.
    /// </summary>
    public interface IProductService
    {   //Get all the Products
        IEnumerable<Product> GetAllProducts();
        //Get a product by id
        Product GetById(int id);
        //Create a new product
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
