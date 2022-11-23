using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Moq;
using Shouldly;
using Xunit;


namespace TestHospitalApp.UnitTesting.BedTest
{
    public class CaptureOrFreeBadTest
    {
        [Fact]
        public void Capture_free_bed()
        {
            
            var stubRepository = new Mock<IBedRepository>();
            var beds = new List<Bed>();

            Bed b = new Bed();
            b.Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e");
            b.IsFree = true;
            b.equipmentId = new Guid("5c036fba-1118-4f4b-b153-90d75e606255");

            beds.Add(b);

           // stubRepository.Setup(m => m.GetAll()).Returns(beds);
            BedService service = new BedService(stubRepository.Object);

            Bed res = service.CaptureBed(b);
            
            res.IsFree.ShouldBeFalse();

            
        }
    }
}
