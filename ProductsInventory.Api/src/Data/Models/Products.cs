

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
namespace ProductInventory.Api.Models;  

   [Table("Products")]

  public class Products
  {
     [Key]
     public Guid Id { get; set; }

     [MaxLength(50)]
     public required string Name { get; set; }


     public int? Quantity { get; set; }

     [Precision(6, 2)]
     public double? Price { get; set; }

     public Products()
     {
        // Id = "0000";
        // Name = "UNKNOWN";
     }
     [JsonConverter(typeof(JsonStringEnumConverter))]
     public List<Category>? Categories { get; set; }

     [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

     public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;

     public Products(Guid id, string name, int quantity, double price)
       {
          Id = id;
          Name = name;
          Quantity = quantity;
          Price = price;

        }
    }
