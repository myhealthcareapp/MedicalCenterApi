using MedicalCenterApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace MedicalCenterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        static List<Doctor> doctors = new List<Doctor> { new Doctor { Id = 1, Name = "Naila Furqan", Description = "Family Doctor" },
             new Doctor { Id = 2, Name = "Dr Shahab", Description = "Family DOctor" },
             new Doctor { Id = 3, Name = "Dr Dianna", Description = "Family Doctor" }
            
        };
        private readonly ILogger<Doctor> _logger;
        public DoctorController(ILogger<Doctor> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetDoctors()
        {
            _logger.LogInformation("Getting All Villas");
            return Ok(doctors); 
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Doctor> GetDoctor(int id)
        {
            if (id <= 0)
            {
                _logger.LogError("Get Villa Error with Id" + id);
                return BadRequest();
            }
            var doctor = doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public ActionResult<Doctor> CreatetDoctor([FromBody]Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest(doctor);
            }
            if (doctors.FirstOrDefault(x=> x.Name.ToLower() == doctor.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Alrady Exist", "Doctor already in the system");
                return BadRequest(ModelState);
            }
            int id = doctors.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            doctor.Id = id;
            doctors.Add(doctor);
            return Ok(doctor);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (id <= 0) 
            { 
                 return BadRequest();
            }
            var doctor = doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null) 
            {
                return NotFound();
            }
            doctors.Remove(doctor);
            return NoContent();

        }


        [HttpPut("{id:int}", Name = "UpdteDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult updteDoctor(int id, [FromBody] Doctor doctor)
        {
            if (doctor == null || id != doctor.Id) 
            {
                return BadRequest();
            }
            var doctorDB = doctors.FirstOrDefault(x => x.Id == id);
            doctorDB.Name = doctor.Name;
            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdtePrtialDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateDoctor(int id, JsonPatchDocument<Doctor> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var doctor = doctors.FirstOrDefault<Doctor>(x => x.Id == id);
            if (doctor == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(doctor, ModelState);
            if(!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}
