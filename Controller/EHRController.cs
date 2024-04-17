using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;

namespace api.Controller
{
    [Route("api/EHRController")]
    [ApiController]
    public class EHRController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        
        public EHRController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ehrs = _context.EHealthRecords.ToList().Select(e => e.ToEHRDTO());
            return Ok(ehrs);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var ehr = _context.EHealthRecords.Find(id);

            if (ehr == null)
            {
                return NotFound();
            }

            return Ok(ehr.ToEHRDTO());
        }
    }
}