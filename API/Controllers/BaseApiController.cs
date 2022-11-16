using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Core;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] //api/activities
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;

    //if we have it available assign _mediator to Mediator and if _mediator is null ad the service
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if(result == null) return NotFound();
        if (result.IsSuccess && result.Value != null)
            return Ok(result.Value);
        if (result.IsSuccess && result.Value == null)
            return NotFound();
        return BadRequest(result.Error);
    }
}



