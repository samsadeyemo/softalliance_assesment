using Microsoft.EntityFrameworkCore;
using SoftAllianceAssesment.DB_Context;
using SoftAllianceAssesment.DBModels;
using SoftAllianceAssesment.Interface;
using SoftAllianceAssesment.Models.RequestModels;
using SoftAllianceAssesment.Models.ResponseModels;

namespace SoftAllianceAssesment.Services
{
    public class CountryService:ICountry
    {
        private MovieContext _context;
        public CountryService(MovieContext context)
        {
            _context = context;
        }
        public List<Country> GetAll()
        {
            List<Country> list;
            try
            {
                list = _context.Set<Country>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public GenericResponseModel Create(CreateCountryRequestModel data)
        {
            GenericResponseModel model = new GenericResponseModel();
            try
            {
                var checkdata = GetCountryByName(data.Name);
                if (checkdata != null)
                {
                    model.isSuccess = false;
                    model.message = "Country name already exist";
                }
                else
                {
                    var createData = new Country();
                    createData.Name = data.Name;
                    _context.Add<Country>(createData);
                    _context.SaveChanges();
                    model.message = "Country created successfully";
                    model.isSuccess = true;
                }
             
             
            }
            catch (Exception ex)
            {
                model.isSuccess = false;
                model.message = "An error occurred, please try again";
            }
            return model;
        }
        public GenericResponseModel Update(UpdateCountryRequestModel data)
        {
            GenericResponseModel model = new GenericResponseModel();
            try
            {
                Country _data = GetCountryByIdAndName(data.Id,data.Name);
                if (_data == null)
                {
                    model.isSuccess = false;
                    model.message = "Country does not exist";
                }
                else if (_data != null && data.Id == _data.Id)
                {
                    _data.Name = data.Name;        
                    _context.Update<Country>(_data);
                    _context.SaveChanges();
                    model.message = "Country updated successfully";
                    model.isSuccess = true;
                }
                else
                {
                    model.isSuccess = false;
                    model.message = "Country already exist";
                }
            }
            catch (Exception ex)
            {
                model.isSuccess = false;
                model.message = "An error occurred, please try again";
            }
            return model;
        }

        public Country GetById(int id)
        {
            Country data;
            try
            {
                data = _context.Find<Country>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }
      
        public Country GetCountryByIdAndName(int id, string name)
        {
            Country data;
            try
            {
                data = _context.Find<Country>(id);
                if (data != null)
                {
                  var  checkNamedata = _context.Countries.FirstOrDefault<Country>(p => p.Name.ToLower() == name.ToLower() && p.Id != id);
                    if (checkNamedata == null)
                    {
                        return data;
                    }
                    else
                    {
                        data = checkNamedata;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        public Country GetCountryByName(string name)
        {
            Country data;
            try
            {
                data = _context.Countries.FirstOrDefault<Country>(p=>p.Name.ToLower() == name.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

      
    }
}
