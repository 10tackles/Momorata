using Momorata.Core.Models;
using System.Collections.Generic;

namespace Momorata.Core.ViewModels
{
    public class ProductManagerViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
