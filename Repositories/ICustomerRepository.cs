public interface ICustomerRepository {
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}


// What is the Repository Pattern?
// The Repository Pattern is a design pattern that provides a clean abstraction layer between the data access layer (EF Core) and the business logic layer.

// ✅ Why we use it in ERP systems:
// Keeps your code decoupled from how data is stored or retrieved.

// Makes it easier to unit test logic without hitting a real database.

// Encourages Single Responsibility Principle (SRP) from SOLID.

// ✅ Real-world ERP benefit:
// Imagine needing to change the data store from SQL to an API or caching system. With repositories, you only change the repository implementation, not the rest of your code.