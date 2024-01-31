using SoftAllianceAssesment.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftAllianceAssesment.DBModels
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }


        [StringLength(100)]
        public string Name { get; set; }


        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        [StringLength(1)]
        public int Rating { get; set; }

        [StringLength(3000)]
        public string Photo { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TicketPrice { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
