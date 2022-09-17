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
            var response = patientRepository.GetRecords();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = patientRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Patient entity)
        {
            var response = patientRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Patient entity)
        {
            var response = patientRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = patientRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}
