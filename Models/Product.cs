using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Models
{
    [Index("Name", IsUnique = true)]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        [Range(.01, double.PositiveInfinity)]
        public double Price { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("imgUrl")]
        public string ImgUrl { get; set; }

        public Product()
        {
            Description = "";
            ImgUrl = "#";
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(Description)}: {Description}, {nameof(ImgUrl)}: {ImgUrl}";
        }
    }
}
