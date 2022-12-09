using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Renovation.Model
{
    public class RoomRenovationPlan : IComparable<RoomRenovationPlan>, IEquatable<RoomRenovationPlan>
    {
        public enum TypeOfPlan { Old, New }
        public Guid Id {get; private set;}
        public String Name {get; private set;}
        public String Description {get; private set;}
        public TypeOfPlan Type {get; private set;}
        public int Number {get; private set;}

        public RoomRenovationPlan(Guid id) {
            this.Id = id;
            this.Type = TypeOfPlan.Old;
            this.Validate();
        }

        public RoomRenovationPlan(String name, String description, int number ) {
            this.Name = name;
            this.Description = description;
            this.Number = number;
            this.Type = TypeOfPlan.New;
            this.Validate();
        }

        private void Validate() {
            if (Type == TypeOfPlan.New) {
                ValidateForNewPlan();
            }
        }

        public override string ToString() {
            if ( Type == TypeOfPlan.Old) {
                return Id.ToString() + Type.ToString(); 
            }
            return Name + Description + Number.ToString() + Type.ToString();
        }

        public bool Equals(RoomRenovationPlan other) {
            return CompareTo(other) == 0;
        }

        public int CompareTo(RoomRenovationPlan other) {
            return string.Compare(ToString(), other.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) {
            return obj is RoomRenovationPlan plan && Equals(plan);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id, Name, Description, Number, Type);
        }

        private void ValidateForNewPlan() {
            ValidateName();
            ValidateDescription();
            ValidateNumber();
        }

        private void ValidateName() {
            if (Name is null || Name.Equals("")) {
                throw new InvalidValueException();
            }
        }

        private void ValidateDescription() {
            if (Description is null || Description.Equals("")) {
                throw new InvalidValueException();
            }
        }

        private void ValidateNumber() {
            if (Number <= 0) {
                throw new InvalidValueException();
            }
        }
    }
}