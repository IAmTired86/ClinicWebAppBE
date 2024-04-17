using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.EHR;
using api.Models;

namespace api.Mappers
{
    public static class EHRMapper
    {
        public static EHRDTO ToEHRDTO(this EHealthRecord ehr)
        {
            return new EHRDTO   
            {
                Id = ehr.Id,
                PatientId = ehr.PatientId,
                Name = ehr.Name,
                DOB = ehr.DOB,
                History = ehr.History,
                Diagnosis = ehr.Diagnosis,
                Medication = ehr.Medication,
                Treatment = ehr.Treatment,
                Instruction = ehr.Instruction,
                Allergies = ehr.Allergies,
                Notes = ehr.Notes
            };

        }

        public static EHealthRecord ToEHealthRecordFromCreateDTO(this CreateEHRDTO EHRDTO)
        {
            return new EHealthRecord
            {
                PatientId = EHRDTO.PatientId,
                Name = EHRDTO.Name,
                DOB = EHRDTO.DOB,
                History = EHRDTO.History,
                Diagnosis = EHRDTO.Diagnosis,
                Medication = EHRDTO.Medication,
                Treatment = EHRDTO.Treatment,
                Instruction = EHRDTO.Instruction,
                Allergies = EHRDTO.Allergies,
                Notes = EHRDTO.Notes
            };
        }
    }
}