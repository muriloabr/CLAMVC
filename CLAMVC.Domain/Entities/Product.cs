using CLAMVC.Domain.Validation;

namespace CLAMVC.Domain.Entities
{
    public sealed class Product: Entity
    {
        #region Propriedades Públicas
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

        #region Contrutores
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "The id cannot be less than 0.");
            this.Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        #endregion

        #region Métodos Privados
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "The name cannot be null.");
            DomainExceptionValidation.When(name.Length < 3, "The name cannot be less than 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "The description cannot be null.");
            DomainExceptionValidation.When(description.Length < 3, "The description cannot be less than 5 characters.");

            DomainExceptionValidation.When(price < 0, "The price cannot be less than 0.");

            DomainExceptionValidation.When(stock < 0, "The stock cannot be less than 0.");

            DomainExceptionValidation.When(image?.Length > 250, "The image name cannot be more than 250 characters.");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
        #endregion
    }
}
