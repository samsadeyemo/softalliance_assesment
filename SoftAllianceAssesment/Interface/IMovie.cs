
using SoftAllianceAssesment.DBModels;
using SoftAllianceAssesment.Models.RequestModels;
using SoftAllianceAssesment.Models.ResponseModels;

namespace SoftAllianceAssesment.Interface
{
    public interface IMovie
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        GenericResponseModel Create(CreateMovieRequestModel movie);
        GenericResponseModel Update(UpdateMovieRequestModel movie);
        GenericResponseModel Delete(int id);
    }
}
