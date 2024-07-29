using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Abstractions
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ISender Sender;

        protected BaseController(ISender sender)
        {
            Sender = sender;
        }
    }
}
