namespace shopGuru_ws.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        public int user_statistics { get; set; }

        public virtual User_info User_info1 { get; set; }

        public virtual User_statistics User_statistics1 { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
