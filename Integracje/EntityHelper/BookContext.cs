namespace EntityHelper
{
    using System.Data.Entity;
    using System.Linq;

    public partial class BookContext : DbContext
    {
        #region Constructors

        public BookContext()
            : base("name=BookContext")
        {
        }

        #endregion Constructors

        #region Properties

        public virtual DbSet<Book> Books { get; set; }

        #endregion Properties

        #region Methods

        public Book CreateDefaultBook()
        {
            return new Book()
            {
                id = Books.Count() + 1,
                title = "title",
                pages = 1,
                year = 1990,
                isbn = "isbn",
                genre = "genre",
                price = "$1.00",
                authors_first_name = "joe",
                authors_last_name = "doe",
                fact_based = 0,
                toms_quantity = 1,
                authors_email = "mail@mail.com",
                authors_gender = "Female",
                original_lanuguage = "English",
                translated_languages_quantity = 0
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.isbn)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.genre)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.authors_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.authors_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.authors_email)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.authors_gender)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.original_lanuguage)
                .IsUnicode(false);
        }

        #endregion Methods
    }
}