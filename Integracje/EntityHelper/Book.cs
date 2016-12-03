namespace EntityHelper
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Book
    {
        #region Properties

        [Required]
        [StringLength(250)]
        public string authors_email { get; set; }

        [Required]
        [StringLength(250)]
        public string authors_first_name { get; set; }

        [Required]
        [StringLength(250)]
        public string authors_gender { get; set; }

        [Required]
        [StringLength(250)]
        public string authors_last_name { get; set; }

        public int fact_based { get; set; }

        [Required]
        [StringLength(250)]
        public string genre { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string isbn { get; set; }

        [Required]
        [StringLength(250)]
        public string original_lanuguage { get; set; }

        public int pages { get; set; }

        [Required]
        [StringLength(250)]
        public string price { get; set; }

        [Required]
        [StringLength(250)]
        public string title { get; set; }

        public int toms_quantity { get; set; }
        public int translated_languages_quantity { get; set; }
        public int year { get; set; }

        #endregion Properties
    }
}