using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.DTOs
{
    public class ImportCategoryDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public List<Product> Products { get; set; } = new();
    }
}
