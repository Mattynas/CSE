namespace shopGuru_ws.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    [Table("account.User_statistics")]
    public partial class User_statistics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_statistics()
        {
            items_uploaded = 0;
            receipts_uploaded = 0;
            lottery_uploaded = 0;
            Users = new HashSet<User>();
        }

        public int id { get; set; }

        public int items_uploaded { get; set; }

        public int receipts_uploaded { get; set; }

        public int lottery_uploaded { get; set; }

        [XmlIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
