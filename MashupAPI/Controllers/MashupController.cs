using MashupAPI.Entities.Mashup;
using MashupAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MashupAPI.Controllers;

[ApiController]
[Route("api/v1.0/[controller]")]
public class MashupController(ILogger<MashupController> logger, IMashup mashup): ControllerBase
{
    [HttpGet(Name = "GetArtistByMBID")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(MashupResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get([FromQuery]Guid mbid)
    {
        if(mbid == Guid.Empty)
        {
            return BadRequest("Invalid MBID");
        }
        
        var result = await mashup.GetMashupByMbid(mbid.ToString());
        
        return result != null ? Ok(result): NotFound();
    }
}

