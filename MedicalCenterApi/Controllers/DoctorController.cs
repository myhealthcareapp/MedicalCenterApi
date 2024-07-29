using MedicalCenterApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using MedicalCenterApi.Data;
using Microsoft.AspNetCore.Authorization;
using Application.Services.Doctors;
namespace MedicalCenterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DoctorController(IDoctorService doctorService) : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await doctorService.GetAllDoctors();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await doctorService.GetDoctorsById(id);   
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
      /*  private readonly ILogger<Doctor> _logger;
        private readonly ApplicationDbContext _db;
        public DoctorController(ILogger<Doctor> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetDoctors()
        {
         //   _logger.LogInformation("Getting All Villas");
            return Ok(_db.Doctors.ToList()); 
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
            var doctor = _db.Doctors.FirstOrDefault(x => x.Id == id);
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
            if (_db.Doctors.FirstOrDefault(x=> x.Name.ToLower() == doctor.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Alrady Exist", "Doctor already in the system");
                return BadRequest(ModelState);
            }
          
            _db.Doctors.AddAsync(doctor);
            _db.SaveChangesAsync();
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
            var doctor = _db.Doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null) 
            {
                return NotFound();
            }
            _db.Doctors.Remove(doctor);
            _db.SaveChangesAsync();
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
            var doctorDB = _db.Doctors.FirstOrDefault(x => x.Id == id);
            if (doctorDB == null)
            {
                return NotFound();
            }
            doctorDB.Name = doctor.Name;
            doctor.Description = doctor.Description;
            _db.Update(doctorDB);
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
        */
    }
}
