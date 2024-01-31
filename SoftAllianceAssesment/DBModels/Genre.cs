using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace SoftAllianceAssesment.DBModels
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
