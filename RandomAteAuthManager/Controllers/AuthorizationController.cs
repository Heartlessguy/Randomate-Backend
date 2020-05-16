using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RandomAteAuthManager.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
    }
}