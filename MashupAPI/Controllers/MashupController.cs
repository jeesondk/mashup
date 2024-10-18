using MashupAPI.Entities.Mashup;
using MashupAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MashupAPI.Controllers;

[ApiController]
[Route("api/v1.0/[controller]")]
public class MashupController(IMashup mashup): ControllerBase
{
    [HttpGet(Name = "GetMashupByMBID")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(MashupResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get([FromQuery]string mbid)
    {
        var result = await mashup.GetMashupByMbid(mbid.ToString());
        return result != null ? Ok(result): NotFound();
    }
}

