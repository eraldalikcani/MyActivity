using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class FruitsController : BaseApiController
{
    private readonly DataContext _context;
    public FruitsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Fruit>>> GetFruits(){
        return await _context.Fruits.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Fruit>> GetFruit(Guid id){
        return await _context.Fruits.FindAsync(id);
    }
}
