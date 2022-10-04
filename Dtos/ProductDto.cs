using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FreshMarket.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FreshMarket.Dtos
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(.01, double.PositiveInfinity)]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        public ProductDto()
        {
            Name = "";
            Description = "";
            ImgUrl = "";
        }

        public static ProductDto valueOf(Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImgUrl = product.ImgUrl
            };
        }

        public Product ToProduct()
        {
            return new Product()
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Description = this.Description,
                ImgUrl = this.ImgUrl
            };
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(Description)}: {Description}, {nameof(ImgUrl)}: {ImgUrl}";
        }
    }
}
