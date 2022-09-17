using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MBHospital.Controllers
{
    
    [ApiController]
    [Route("patient")]
    public class PatientController : ControllerBase
    {
        private readonly IServiceRepository<Patient, int> patientRepository;

        public PatientController(IServiceRepository<Patient, int> patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = patientRepository.GetRecords();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
