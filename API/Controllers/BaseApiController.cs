using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] //api/activities
public class BaseApiController : ControllerBase
{
        private IMediator _mediator;

        //if we have it available assign _mediator to Mediator and if _mediator is null ad the service
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();
}



