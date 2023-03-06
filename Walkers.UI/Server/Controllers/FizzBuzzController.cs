using Microsoft.AspNetCore.Mvc;
using Walkers.UI.Server.Services;
using Walkers.UI.Shared;

namespace Walkers.UI.Server.Controllers;

[ApiController]
[Route("[controller]",Name ="FizzBuzz")]
public class FizzBuzzController : ControllerBase
{
   
    public FizzBuzzController()
    {
     
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get(int number, int size=20,int current=0)
    {
        if(size<0 || size < 0)
        {
            return BadRequest("limit or size should be greater than 0");
        }
        if (number > 0 && number <=200 ) // would put these into a constants file
        {
                return Ok(FizzBuzzService.GetFizzBuzzValues(number,current,size));
        }

        return BadRequest("Number should be greater than 0");//would put this into a constants file
    }

    
}

