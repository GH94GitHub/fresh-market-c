using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshMarket.Models
{
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

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
