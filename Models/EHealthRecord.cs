using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EHealthRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string DOB { get; set; } = string.Empty;
        public DateTime DateEntry { get; set; }
        public string History { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string Medication { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public string Allergies { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}