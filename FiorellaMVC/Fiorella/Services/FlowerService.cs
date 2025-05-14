using Fiorella.Contexts;
using Fiorella.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Services;

public class FlowerService
{

    private readonly AppDbContext _context;

    public FlowerService()
    {
        _context = new AppDbContext();
    }
    #region Create
    public void CreateFlower(Flower flower)
    {
        _context.Flowers.Add(flower);
        _context.SaveChanges();
    }

    #endregion

    #region Read

    public Flower GetFlowerById(int id)

    {
        Flower flower = _context.Flowers.Find(id);
            if (flower is null)
        {
            throw new Exception($"Bu {id}-a sahib data tapılmadı!");
        }
        return flower;
    }

    public List<Flower> GetAllFlowers()
    {
        List<Flower> flowers = _context.Flowers.ToList();
        return flowers;
    }
    #endregion

    #region Delete 

    public void DeleteFlower(int id)
    {
        Flower? flower = _context.Flowers.Find(id);
        if (flower is null)
        {
            throw new Exception("Tapilmadi");
        }
        _context.Flowers.Remove(flower);
        _context.SaveChanges();
    }

    #endregion

}
