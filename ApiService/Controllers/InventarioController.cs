using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventarioController(
        IMapper mapper
        ) : ControllerBase
{
}
