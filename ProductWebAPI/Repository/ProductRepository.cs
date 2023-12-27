using ProductWebAPI.Model;

namespace ProductWebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();

        public ProductRepository()
        {
            // Initialize some sample data
            products.Add(new Product { ProductId = 1, ProductName = "Watch", ProductBrand = "Rolex", ProductQuantity = 3, ProductPrice = 1145688 });
            products.Add(new Product { ProductId = 2, ProductName = "Sneakers", ProductBrand = "Nike", ProductQuantity = 5, ProductPrice = 3765432 });
            products.Add(new Product { ProductId = 3, ProductName = "Laptop", ProductBrand = "Microsoft", ProductQuantity = 12, ProductPrice =  6790011});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.Find(p => p.ProductId == id);
        }

        public Product GetProductByName(string name)
        {
            return products.Find(p => p.ProductName == name);
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            // Generate a new id
            product.ProductId = products.Max(p => p.ProductId) + 1;

            products.Add(product);
        }

        public void UpdateProduct(Product product)

        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            int index = products.FindIndex(p => p.ProductId == product.ProductId);

            if (index == -1)
            {
                throw new KeyNotFoundException("product");
            }

            products[index] = product;
        }

        public void DeleteProduct(int id)
        {
            products.RemoveAll(p => p.ProductId == id);
        }
    }
}
