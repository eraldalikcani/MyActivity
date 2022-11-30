using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.Activities;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetActivities(){
        return HandleResult(await Mediator.Send(new List.Query()));//Mediator from BaseApicontroller
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id){
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));   
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Activity activity){
        return HandleResult(await Mediator.Send(new Create.Command {Activity = activity}));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Activity activity){
        activity.Id = id;
        return HandleResult(await Mediator.Send(new Edit.Command{Activity = activity}));
    }

    [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteActivity(Guid id){
        return HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
    }
}
