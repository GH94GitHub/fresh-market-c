using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FreshMarket.Models;

public class Allergy
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [JsonIgnore]
    public ICollection<User>? Users { get; set; }
    [JsonIgnore]
    public ICollection<Dish>? Dishes { get; set; }
}