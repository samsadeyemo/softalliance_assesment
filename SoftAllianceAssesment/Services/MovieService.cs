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
    public class MovieService : IMovie
    {
        private MovieContext _context;
        public MovieService(MovieContext context)
        {
            _context = context;
        }
        public List<Movie> GetAll()
        {
            List<Movie> list;
            try
            {
                list = _context.Set<Movie>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public GenericResponseModel Create(CreateMovieRequestModel data)
        {
            GenericResponseModel model = new GenericResponseModel();
            try
            {
                var checkdata = GetMovieByName(data.Name);
                if (checkdata != null)
                {
                    model.isSuccess = false;
                    model.message = "Movie name already exist";
                }
                else
                {
                    var createData = new Movie();
                    createData.Name = data.Name;
                    createData.Description = data.Description;
                    createData.ReleaseDate = data.ReleaseDate;
                    createData.Rating = data.Rating;
                    createData.TicketPrice = data.TicketPrice;
                    createData.CountryId = data.CountryId;
                    createData.GenreId = data.GenreId;
                    createData.Photo = data.Base64Photo;
                    _context.Add<Movie>(createData);
                    _context.SaveChanges();
                    model.message = "Movie created successfully";
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
        public GenericResponseModel Update(UpdateMovieRequestModel data)
        {
            GenericResponseModel model = new GenericResponseModel();
            try
            {
                Movie updateData = GetMovieByIdAndName(data.Id, data.Name);
                if (updateData == null)
                {
                    model.isSuccess = false;
                    model.message = "Movie does not exist";
                }
                else if (updateData != null && data.Id == updateData.Id)
                {
                    updateData.Name = data.Name;
                    updateData.Description = data.Description;
                    updateData.ReleaseDate = data.ReleaseDate;
                    updateData.Rating = data.Rating;
                    updateData.TicketPrice = data.TicketPrice;
                    updateData.CountryId = data.CountryId;
                    updateData.GenreId = data.GenreId;
                    updateData.Photo = data.Base64Photo;
                    _context.Update<Movie>(updateData);
                    _context.SaveChanges();
                    model.message = "Movie updated successfully";
                    model.isSuccess = true;
                }
                else
                {
                    model.isSuccess = false;
                    model.message = "Movie already exist";
                }
            }
            catch (Exception ex)
            {
                model.isSuccess = false;
                model.message = "An error occurred, please try again";
            }
            return model;
        }

        public Movie GetById(int id)
        {
            Movie data;
            try
            {
                data = _context.Find<Movie>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }
        public GenericResponseModel Delete(int id)
        {
            GenericResponseModel model = new GenericResponseModel();
            try
            {
                Movie data = GetById(id);
                if (data != null)
                {
                    _context.Remove<Movie>(data);
                    _context.SaveChanges();
                    model.isSuccess = true;
                    model.message = "Movie deleted successfully";
                }
                else
                {
                    model.isSuccess = false;
                    model.message = "Movie not found";
                }
            }
            catch (Exception ex)
            {
                model.isSuccess = false;
                model.message = "Error : " + ex.Message;
            }
            return model;
        }

        public Movie GetMovieByIdAndName(int id, string name)
        {
            Movie data;
            try
            {
                data = _context.Find<Movie>(id);
                if (data != null)
                {
                    var checkNamedata = _context.Movies.FirstOrDefault<Movie>(p => p.Name.ToLower() == name.ToLower() && p.Id != id);
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

        public Movie GetMovieByName(string name)
        {
            Movie data;
            try
            {
                data = _context.Movies.FirstOrDefault<Movie>(p => p.Name.ToLower() == name.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

    }
}
