namespace shopGuru_ws.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account.Users")]
    public partial class User
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(30)]
        public string password { get; set; }

        public int user_info { get; set; }

        public virtual User_info User_info1 { get; set; }
    }
}
