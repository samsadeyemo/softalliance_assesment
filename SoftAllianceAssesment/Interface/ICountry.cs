

using SoftAllianceAssesment.DBModels;
using SoftAllianceAssesment.Models.RequestModels;
using SoftAllianceAssesment.Models.ResponseModels;

namespace SoftAllianceAssesment.Interface
{
    public interface ICountry
    {
        List<Country> GetAll();
        Country GetById(int id);
        GenericResponseModel Create(CreateCountryRequestModel movie);
        GenericResponseModel Update(UpdateCountryRequestModel movie);
    }
}
