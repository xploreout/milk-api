using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.Api.Data;
using MilkStore.Api.Models;

namespace MilkStore.Api.Services;

public class MilkService : IMilkService
{
    private readonly DataContext _dbContext;

    public MilkService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Milk>> GetAllMilks()
    {
        return await _dbContext.Milks.ToListAsync();
    }

    public async Task<Milk> GetMilkById(Guid id)
    {
        var milk = await _dbContext.Milks.FindAsync(id);
        if (milk == null)
            throw new Exception("No Record Found");
        return milk;
    }
    public async Task<Milk> AddMilk(MilkDto milkDto)
    {
        var milk = new Milk
        {
            Name = milkDto.Name,
            Storage = milkDto.Storage,
            Type = milkDto.Type,
            Id = new Guid()
        };
        await _dbContext.Milks.AddAsync(milk);
        await _dbContext.SaveChangesAsync();
        return milk;
    }

    public async Task RemoveMilkById(Guid id)
    {
        var milk = await _dbContext.Milks.FindAsync(id);
        if (milk == null) throw new Exception("No record found with this id");

        _dbContext.Milks.Remove(milk);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateMilk(Guid id, MilkDto milkDto)
    {
        var newMilk = await _dbContext.Milks.FindAsync(id);
        if (newMilk == null) throw new Exception("No Milk found with this Id");
        newMilk.Name = milkDto.Name;
        newMilk.Storage = milkDto.Storage;
        newMilk.Type = milkDto.Type;
        
        await _dbContext.SaveChangesAsync();
    }

    public List<string> GetMilkTypes()
    {
        var unique =  _dbContext.Milks.GroupBy(x => x.Type).Select(x => x.FirstOrDefault());
        Console.WriteLine(unique.ToList());
        return (new List<string>() {"almond", "soy"});
    }
}