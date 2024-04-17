using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.DTO.EHR;

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


        [HttpPost]
        public IActionResult Create([FromBody] CreateEHRDTO EHRDTO)
        {
            var ehr = EHRDTO.ToEHealthRecordFromCreateDTO();
            ehr.CreatedOn = DateTime.Now;
            _context.EHealthRecords.Add(ehr);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = ehr.Id }, ehr.ToEHRDTO());
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateEHRDTO EHRDTO)
        {
            var ehr = _context.EHealthRecords.Find(id);

            if (ehr == null)
            {
                return NotFound();
            }

            ehr.Name = EHRDTO.Name;
            ehr.DOB = EHRDTO.DOB;
            ehr.History = EHRDTO.History;
            ehr.Diagnosis = EHRDTO.Diagnosis;
            ehr.Medication = EHRDTO.Medication;
            ehr.Treatment = EHRDTO.Treatment;
            ehr.Instruction = EHRDTO.Instruction;
            ehr.Allergies = EHRDTO.Allergies;
            ehr.Notes = EHRDTO.Notes;


            _context.SaveChanges();
            return Ok(ehr.ToEHRDTO());
        }
        

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var ehr = _context.EHealthRecords.Find(id);

            if (ehr == null)
            {
                return NotFound();
            }

            _context.EHealthRecords.Remove(ehr);
            _context.SaveChanges();
            return NoContent();
        }
    }
}