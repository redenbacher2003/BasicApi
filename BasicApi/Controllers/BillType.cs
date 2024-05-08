using Microsoft.AspNetCore.Mvc;
using BackEnd.DataObject;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillTypeController : ControllerBase
    {
        static IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);
        public static IConfigurationRoot Configuration = builder.Build();
        public string conn = Configuration.GetConnectionString("DbConnection");

        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetAsync()
        {
            BackEnd.BackEnd backEnd = new BackEnd.BackEnd();
            var connection = backEnd.SqlConnection(conn);
            var result = backEnd.jsonBillType_Get_AllAsync(connection);
            return await result;
             

           // return new string[] { "value1", "value2" };

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string>GetAsync(int id)

        {
            BackEnd.BackEnd backEnd = new BackEnd.BackEnd();

            var connection = backEnd.SqlConnection(conn);
            var result = backEnd.jsonBillPayment_Get_ByBillTypeIDAsync(connection, id, false);
         
            return await result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        [EnableCors("OpenCORSPolicy")]
        public async Task<IActionResult> Post([FromBody] BillType billType)
        {
            BackEnd.BackEnd backEnd = new BackEnd.BackEnd();
             
            if (billType is null || billType.GetType() != typeof(BillType))
            {
                //ah no good!
                return BadRequest();
            }
            else
            {
                //any data validation?
                var connection = backEnd.SqlConnection(conn);
                try
                {
                    return Ok(await backEnd.jsonBillType_InsertAsync(connection, billType));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
               
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [EnableCors("OpenCORSPolicy")]
        public void Put(int id, [FromBody] string value)
        {
           throw new NotImplementedException();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [EnableCors("OpenCORSPolicy")]
        public void Delete(int id)
        {
        }

        // POST api/<ValuesController>
        [HttpPost("PostPaymentAsync")]
        [EnableCors("OpenCORSPolicy")]
        public IActionResult Post([FromBody] BillPayment billPayment)
        {
            BackEnd.BackEnd backEnd = new BackEnd.BackEnd();

            if (billPayment is null || billPayment.GetType() != typeof(BillPayment))
            {
                //ah no good!
                return BadRequest();
            }
            else
            {
                //any data validation?
                
                return Ok();
            }
        }
    }
}
