namespace shopGuru_ws.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("shopping.Price")]
    public partial class Price
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string shop { get; set; }

        [Column("price")]
        public decimal price1 { get; set; }

        public int item { get; set; }

        public virtual Item Item1 { get; set; }
    }
}
