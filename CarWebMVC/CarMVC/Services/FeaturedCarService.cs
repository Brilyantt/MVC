using CarMVC.Contexts;
using CarMVC.Exceptions;
using CarMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMVC.Services;

public class FeaturedCarService
{
    private readonly  AppDbContext _context;
    public FeaturedCarService()
    {
        _context = new AppDbContext();
    }


    #region Create

    public void CreateFeaturedcar(FeaturedCar featuredCar)
    {
        _context.FeaturedCars.Add(featuredCar);
        _context.SaveChanges();
    }

    #endregion

    #region Read

    public FeaturedCar GetFeaturedCarById(int id)
    {
        FeaturedCar? featuredCar = _context.FeaturedCars.Find(id);
        if (featuredCar is not null)
        {
            return featuredCar;
        }
        throw new FeaturedCarException($"database-de {id}-e sahib data tapilmadi");
        }
    public List<FeaturedCar> GetAllFeaturedCars()
    {
        List<FeaturedCar> featuredCars = _context.FeaturedCars.ToList();
        return featuredCars;
    }

    #endregion

    #region Update
    public void UpdateFeaturedCar(int id, FeaturedCar updatedfeaturedCar)
    {
        if(id != updatedfeaturedCar.Id)
        {
            throw new FeaturedCarException("Gelen id-ler eyni olmamalidir");
        }

      FeaturedCar baseFeaturedCar =  _context.FeaturedCars.AsNoTracking().SingleOrDefault(fC => fC.Id == id);
        if(baseFeaturedCar is not null)
        {
            throw new FeaturedCarException($"database-de {id}-e sahib data tapilmadi");
        }
        _context.FeaturedCars.Update(updatedfeaturedCar);
        _context.SaveChanges();
    }
    #endregion

    #region Delete
    public void DeleteFeaturedCar(int id)
    {
        FeaturedCar? featuredCar = _context.FeaturedCars.Find(id);
        if (featuredCar is not null)
        {
            _context.FeaturedCars.Remove(featuredCar);
            _context.SaveChanges();
        }
        else
        {
            throw new FeaturedCarException($"database-de {id}-e sahib data tapilmadi");

        }

    }
    #endregion
}
