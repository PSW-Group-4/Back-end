using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Migrations;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class JmbgTest
    {
        [Fact]
        public void Valid_Jmbg()
        {
            string jmbgValue = "1807000730038";
            Jmbg jmbg = new Jmbg(jmbgValue);

            jmbg.ShouldNotBeNull();
        }

        [Fact]
        public void Jmbg_Has_Non_Digitsw()
        {
            string jmbgValue = "A807000730038";

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Jmbg jmbg = new Jmbg(jmbgValue);
            });
        }

        [Fact]
        public void Jmbg_Not_Valid_Length()
        {
            string jmbgValue = "180700073003";

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Jmbg jmbg = new Jmbg(jmbgValue);
            });
        }

        [Fact]
        public void Checksum_Not_Valid()
        {
            string jmbgValue = "1807000730039";

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Jmbg jmbg = new Jmbg(jmbgValue);
            });
        }

        [Fact]
        public void EqualJmbgs()
        {
            Jmbg jmbg1 = new Jmbg("1807000730038");
            Jmbg jmbg2 = new Jmbg("1807000730038");

            var result = jmbg1.Equals(jmbg2);

            result.ShouldBeTrue();
        }

        [Fact]
        public void NotEqualJmbgs()
        {
            Jmbg jmbg1 = new Jmbg("1807000730038");
            Jmbg jmbg2 = new Jmbg("1502957172694");

            var result = jmbg1.Equals(jmbg2);

            result.ShouldBeFalse();
        }
    }
}
