using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.Activities;
using MediatR;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities(){
        return await Mediator.Send(new List.Query());//Mediator from BaseApicontroller
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id){
        return await Mediator.Send(new Details.Query{Id = id});
    }
}
