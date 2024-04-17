using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.DTO.EHR;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var ehrs = await _context.EHealthRecords.ToListAsync();
            var ehrDTO = ehrs.Select(ehr => ehr.ToEHRDTO());
            return Ok(ehrs);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ehr = await _context.EHealthRecords.FindAsync(id);

            if (ehr == null)
            {
                return NotFound();
            }

            return Ok(ehr.ToEHRDTO());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEHRDTO EHRDTO)
        {
            var ehr = EHRDTO.ToEHealthRecordFromCreateDTO();
            ehr.CreatedOn = DateTime.Now;
            await _context.EHealthRecords.AddAsync(ehr);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = ehr.Id }, ehr.ToEHRDTO());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEHRDTO EHRDTO)
        {
            var ehr = await _context.EHealthRecords.FindAsync(id);

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


            await _context.SaveChangesAsync();
            return Ok(ehr.ToEHRDTO());
        }
        

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ehr = await _context.EHealthRecords.FindAsync(id);

            if (ehr == null)    
            {
                return NotFound();
            }

            _context.EHealthRecords.Remove(ehr);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}