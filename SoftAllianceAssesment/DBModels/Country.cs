using System.ComponentModel.DataAnnotations;

namespace SoftAllianceAssesment.DBModels
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
