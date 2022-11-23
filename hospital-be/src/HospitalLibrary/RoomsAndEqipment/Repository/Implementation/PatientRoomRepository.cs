using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Implementation
{
    public class PatientRoomRepository : IPatientRoomRepository
    {
        private readonly HospitalDbContext _context;
        private readonly IBedRepository _bedRepository;
        public PatientRoomRepository(HospitalDbContext context, IBedRepository bedRepository)
        {
            _context = context;
            _bedRepository = bedRepository;
        }
        public PatientRoom Create(PatientRoom entity)
        {
            _context.PatientRooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid roomId)
        {
            var room = GetById(roomId);
            _context.PatientRooms.Remove(room);
            _context.SaveChanges();
        }

        public IEnumerable<PatientRoom> GetAll()
        {
            return _context.PatientRooms.ToList();
        }

        public PatientRoom GetById(Guid id)
        {
            var result = _context.PatientRooms.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public PatientRoom Update(PatientRoom room)
        {
            var updatingRoom = _context.PatientRooms.SingleOrDefault(p => p.Id == room.Id);
            if (updatingRoom == null)
            {
                throw new NotFoundException();
            }

            updatingRoom.Update(room);

            _context.SaveChanges();
            return updatingRoom;
        }

       public List<Bed> GetBedsFromPatientRoom(PatientRoom patientRoom)
        {
            List<Bed> result = new List<Bed>();
            if(patientRoom.BedIds != null)
            {
                foreach (var bId in patientRoom.BedIds)
                {
                    foreach (var bed in _context.Beds.ToList())
                    {
                        if (bed.Id == bId)
                        {
                            result.Add(bed);
                        }
                    }
                }
                return result;
            }
            return null;
            
            
        }

        public List<PatientRoom> GetRoomsWithFreeBeds()
        {
            List<PatientRoom> result = new List<PatientRoom>();
            foreach(var pRoom in _context.PatientRooms.ToList())
            {
                if(GetBedsFromPatientRoom(pRoom) != null)
                {
                    foreach (var bed in GetBedsFromPatientRoom(pRoom))
                    {
                        if (bed.IsFree)
                        {
                            if (!result.Contains(pRoom))
                            {
                                result.Add(pRoom);
                            }
                           
                        }
                    }
                }
                
            }
            return result;
        }

        public PatientRoom CaptureBed(PatientRoom patientRoom)
        {
            List<Bed> beds = GetBedsFromPatientRoom(patientRoom);
            foreach(var bed in beds)
            {
                if(bed.IsFree == true)
                {
                    _bedRepository.CaptureBed(bed);
                    break;
                }
            }
            return patientRoom;
            
        }
        public PatientRoom FreeBed(PatientRoom patientRoom)
        {
            List<Bed> beds = GetBedsFromPatientRoom(patientRoom);
            foreach (var bed in beds)
            {
                if (bed.IsFree == false)
                {
                    _bedRepository.FreeBed(bed);
                    break;
                }
            }
            return patientRoom;

        }
    }
}
