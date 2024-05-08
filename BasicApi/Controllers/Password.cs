using BackendPw;
using BasicApi.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly PWDbContext _pwdb;
        private static PwManager _manager = new BackendPw.PwManager();

        public PasswordController(PWDbContext pwdb)
        {
            _pwdb = pwdb;
        }

        // GET: api/<ValuesController>
        [HttpGet("GetAllPasswordAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetAllPasswordAsync()
        {        
            var result = _manager.PwGetAll_Async();

            return await result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetPasswordAsync")]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetPasswordAsync(int Id)

        {
            var result = _manager.pwType_get_Async(Id);

            return await result;
        }

        // POST api/<ValuesController>
        [HttpPost("PostNewPasswordTypeAsync")]
        public async Task<IActionResult> PostNewPasswordTypeAsync([FromBody] PWType pWType)
        {
            return Ok(await _manager.AddPW_Async(pWType.For, pWType.Description, pWType.AddedBy));
        }

        // POST api/<ValuesController>
        [HttpPost("PostNewPasswordForTypeAsync")]
        public async Task<IActionResult> PostNewPasswordForTypeAsync([FromBody] BackendPw.CustomObject.PwObject.PwTypeDetail pwTypeDetail)
        {         
            return Ok(await _manager.AddPwForType_Async(pwTypeDetail.Id, pwTypeDetail.Pw, pwTypeDetail.AddedBy));
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
