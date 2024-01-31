using Microsoft.EntityFrameworkCore;
using SoftAllianceAssesment.DB_Context;
using SoftAllianceAssesment.DBModels;
using SoftAllianceAssesment.Interface;
using SoftAllianceAssesment.Models.RequestModels;
using SoftAllianceAssesment.Models.ResponseModels;
using System;
using System.Xml.Linq;

namespace SoftAllianceAssesment.Services
{
    public class GenreService : IGenre
    {
        private MovieContext _context;
        public GenreService(MovieContext context)
        {
            _context = context;
        }
        public List<Genre> GetAll()
        {
            List<Genre> list;
            try
            {
                list = _context.Set<Genre>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public GenericResponseModel Create(CreateGenreRequestModel data)
        {
            GenericResponseModel model = new GenericResponseModel();
            try
            {
                var checkdata = GetGenreByName(data.Name);
                if (checkdata != null)
                {
                    model.isSuccess = false;
                    model.message = "Genre name already exist";
                }
                else
                {
                    var createData = new Genre();
                    createData.Name = data.Name;
                    _context.Add<Genre>(createData);
                    _context.SaveChanges();
                    model.message = "Genre created successfully";
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
        public GenericResponseModel Update(UpdateGenreRequestModel data)
        {
            GenericResponseModel model = new GenericResponseModel();
            try
            {
                Genre _data = GetGenreByIdAndName(data.Id, data.Name);
                if (_data == null)
                {
                    model.isSuccess = false;
                    model.message = "Genre does not exist";
                }
                else if (_data != null && data.Id == _data.Id)
                {
                    _data.Name = data.Name;
                    _context.Update<Genre>(_data);
                    _context.SaveChanges();
                    model.message = "Genre updated successfully";
                    model.isSuccess = true;
                }
                else
                {
                    model.isSuccess = false;
                    model.message = "Genre already exist";
                }
            }
            catch (Exception ex)
            {
                model.isSuccess = false;
                model.message = "An error occurred, please try again";
            }
            return model;
        }

        public Genre GetById(int id)
        {
            Genre data;
            try
            {
                data = _context.Find<Genre>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }
     
        public Genre GetGenreByIdAndName(int id, string name)
        {
            Genre data;
            try
            {
                data = _context.Find<Genre>(id);
                if (data != null)
                {
                    var checkNamedata = _context.Genres.FirstOrDefault<Genre>(p => p.Name.ToLower() == name.ToLower() && p.Id != id);
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

        public Genre GetGenreByName(string name)
        {
            Genre data;
            try
            {
                data = _context.Genres.FirstOrDefault<Genre>(p => p.Name.ToLower() == name.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

    }
}
