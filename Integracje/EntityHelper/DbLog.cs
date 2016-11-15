namespace EntityHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DbLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public DateTime data { get; set; }

        [Required]
        [StringLength(45)]
        public string ip { get; set; }

        [StringLength(100)]
        public string procedure_name { get; set; }
    }
}
