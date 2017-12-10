namespace shopGuru_ws.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account.User_statistics")]
    public partial class User_statistics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_statistics()
        {
            User_info = new HashSet<User_info>();
        }

        public int id { get; set; }

        public int items_uploaded { get; set; }

        public int receipts_uploaded { get; set; }

        public int lottery_uploaded { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_info> User_info { get; set; }
    }
}
