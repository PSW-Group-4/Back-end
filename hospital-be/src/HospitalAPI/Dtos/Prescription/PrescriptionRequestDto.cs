using HospitalAPI.Dtos.Medicine;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.Prescription
{
    public class PrescriptionRequestDto
    {
        public List<HospitalLibrary.Medicines.Model.Medicine> Medicines { get; set; }
    }
}
