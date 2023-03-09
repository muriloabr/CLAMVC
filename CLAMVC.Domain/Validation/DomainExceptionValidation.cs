using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAMVC.Domain.Validation
{
    public sealed class DomainExceptionValidation : Exception
    {
        #region Contrutores
        public DomainExceptionValidation(string error) : base(error) { }
        #endregion

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
