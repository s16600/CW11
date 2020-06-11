using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CW11a.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CW11a.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly PrescriptionDbContext _context;

        public DoctorController(PrescriptionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DoctorShow()
        {
            //var db = new PrescriptionDbContext();
            //var res = db.Prescription.ToList();
            //var res = _context.Doctor.ToList();

            var res = _context.Doctor.ToList();
            return Ok(res);
        }

        [HttpGet("{IdDoctor}")]
        public IActionResult DoctorShow(string IdDoctor)
        {
            var res = _context.Doctor.Where(d => d.IdDoctor.Equals( Int32.Parse(IdDoctor) ));
            return Ok(res);
        }

        [HttpDelete("{IdDoctor}")]
        public IActionResult DoctorAdd(string IdDoctor)
        {

            /*
             *   var x = (from y in ctx.Table
             where ofetch.FILEDNAME == ID
             select y).FirstOrDefault();
        ctx.Employees.Remove(x);
        ctx.SaveChanges();
             */

            //var res = _context.Doctor.ToList();

            //var res = (from d in _context.Doctor where IdDoctor.Equals(Int32.Parse(IdDoctor)) select d).First();
            //var s = _context.Doctors.Where(s => s.IdDoctor == id).First();
            var res = _context.Doctor.Where(d => d.IdDoctor.Equals(Int32.Parse(IdDoctor))).First();
            _context.Doctor.Remove(res);
            _context.SaveChanges();
            return Ok("Lekarz usunięty");
        }

        [HttpPost("{IdDoctor1}")]
        public IActionResult UpdateDoctor(Doctor doctor, string IdDoctor1)
        {
            var d = new Doctor
            {
                IdDoctor = Int32.Parse(IdDoctor1),
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };

            _context.Attach(d);
            _context.Entry(d).Property("FirstName").IsModified = true;
            _context.Entry(d).Property("LasttName").IsModified = true;
            _context.Entry(d).Property("Email").IsModified = true;
            _context.SaveChanges();

            return Ok(d);
        }

    }
}