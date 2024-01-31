using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftAllianceAssesment.Models.RequestModels
{
    public class UpdateCountryRequestModel
    {
        [Required(ErrorMessage = "Movie to update is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
