using webapi.Models;

namespace webapi.DataAccess
{
    public interface IRepository
    {
        IEnumerable<User> getUsers { get; }
        void addUser(User user);
        void updateUser(string id);
        void deleteUser(string id);

        IEnumerable<Product> getProducts { get; }
        public IEnumerable<Product> getProductsByCategory(string category);
        void addProduct(Product product);
        void updateProduct(Product product);
        void deleteProduct(string id);

        IEnumerable<Category> getCategories {  get; }
        public IEnumerable<Category> GetCategoriesByType(string type);
        void addCategory(Category category);
        void updateCategory(Category category);
        void deleteCategory(string id);

    }
}
