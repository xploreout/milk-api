using Microsoft.AspNetCore.Mvc;
using MilkStore.Api.Models;

namespace MilkStore.Api.Services;

public interface IMilkService
{
    Task<List<Milk>> GetAllMilks();
    Task<Milk> GetMilkById(Guid id);
    Task<Milk> AddMilk(MilkDto milkDto);
    Task RemoveMilkById(Guid id);
    Task UpdateMilk(Guid id, MilkDto milkDto);
    List<string> GetMilkTypes();
}