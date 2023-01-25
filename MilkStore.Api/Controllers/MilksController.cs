using Microsoft.AspNetCore.Mvc;
using MilkStore.Api.Models;
using MilkStore.Api.Services;

namespace MilkStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MilksController: ControllerBase
{
   private readonly IMilkService _dbMilkService;

   public MilksController(IMilkService dbMilkService)
   {
      _dbMilkService = dbMilkService;
   }

   [HttpGet]
   public async Task<IActionResult> GetAllMilks()
   {
      try
      {
         return Ok(await _dbMilkService.GetAllMilks());
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<Milk>> GetMilkById(Guid id)
   {
      try
      {
        
         return Ok(await _dbMilkService.GetMilkById(id));
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
   }

   [HttpPost]
   public async Task<IActionResult> AddMilk([FromBody]MilkDto milkDto)
   {
      try
      {
         var newMilk = await _dbMilkService.AddMilk(milkDto);
         return CreatedAtAction(nameof(GetAllMilks), new { milkId = newMilk.Id }, newMilk);
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> RemoveMilk(Guid id)
   {
      try
      {
         await _dbMilkService.RemoveMilkById(id);
         return NoContent();
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
   }

   [HttpPut("{id}")]
   public async Task<IActionResult>UpdateMilk([FromRoute]Guid id, [FromBody] MilkDto milkDto)
   {
      try
      {  
         await _dbMilkService.UpdateMilk(id, milkDto);
         return NoContent();
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
   }

   [HttpGet("alltypes")]
   public  List<string> GetMilkTypes()
   {
      try
      {
         var list =  _dbMilkService.GetMilkTypes();
         return (list);
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
   }
}