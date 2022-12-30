using HospitalLibrary.Exceptions;
using System;

namespace HospitalLibrary.Medicines.Model
{
    public class Medicine
    {
        public Guid Id { get; private set; }
        public String Name { get; private set; }

        public Medicine(Guid id, String name)
        {
            Id = id;
            Name = name;

            if (!IsValid())
                throw new EntityObjectValidationFailedException();
        }

        private bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Name);
        }

        public void Update(Medicine medicine)
        {
            Name = medicine.Name;
        }
    }
}
