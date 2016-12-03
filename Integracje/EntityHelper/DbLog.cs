namespace EntityHelper
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DbLog
    {
        #region Properties

        public DateTime data { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(45)]
        public string ip { get; set; }

        [StringLength(100)]
        public string procedure_name { get; set; }

        #endregion Properties
    }
}