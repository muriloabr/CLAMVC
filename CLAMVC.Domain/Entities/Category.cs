using CLAMVC.Domain.Validation;
using System.Collections.Generic;

namespace CLAMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        #region Propriedades Públicas
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }
        #endregion

        #region Contrutores
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            this.Id = id;
            ValidateDomain(name);
        }
        #endregion

        #region Métodos Privados
        public void Update(string name)
        {
            ValidateDomain(name);
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "The name cannot be null.");
            DomainExceptionValidation.When(name?.Length < 3, "The name cannot be less than 3 characters.");
            this.Name = name;
        }
        #endregion
    }
}