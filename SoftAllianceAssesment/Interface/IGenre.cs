using SoftAllianceAssesment.DBModels;
using SoftAllianceAssesment.Models.RequestModels;
using SoftAllianceAssesment.Models.ResponseModels;

namespace SoftAllianceAssesment.Interface
{
    public interface IGenre
    {
        List<Genre> GetAll();
        Genre GetById(int id);
        GenericResponseModel Create(CreateGenreRequestModel movie);
        GenericResponseModel Update(UpdateGenreRequestModel movie);
    }
}
