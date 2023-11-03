using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.DataAccess
{
    public class Repository : IRepository
    {
        private DatabaseContext context;
        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> getUsers => context.Users;

        public IEnumerable<Product> getProducts => context.Products.Include(cate => cate.Category);

        public IEnumerable<Product> getProductsByCategory(string category)
        {
            return context.Products.Where(p => p.Category.CategoryId == category);
        }

        public IEnumerable<Category> getCategories => context.Categories;

        public IEnumerable<Category> GetCategoriesByType(string categoryName)
        {
            return context.Categories.Where(c => c.CategoryId.StartsWith(categoryName));
        }

        public void addCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void addProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void addUser(User user)
        {
            context.Users.Add(user);   
            context.SaveChanges();
        }

        public void deleteCategory(string id)
        {
        }

        public void deleteProduct(string id)
        {
        }

        public void deleteUser(string id)
        {
        }

        public void updateCategory(Category category)
        {
        }

        public void updateProduct(Product product)
        {
        }

        public void updateUser(string id)
        {
        }

       
    }
}
