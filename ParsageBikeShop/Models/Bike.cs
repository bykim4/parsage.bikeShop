using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parsage.BikeShop.Models
{
    [Table("Bikes")]
    public class Bike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }

        public string Model { get; set; }

        public int FrameSize { get; set; }

        public decimal Price { get; set; }
    }
}
