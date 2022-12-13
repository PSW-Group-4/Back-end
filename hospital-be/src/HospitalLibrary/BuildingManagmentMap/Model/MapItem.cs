using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.BuildingManagmentMap.Model
{
    public abstract class MapItem
    {
        public Guid Id { get; set; }

        public MapLocation MapLocation {get; set;} 

        public void Update(MapItem item)
        {
            this.MapLocation = item.MapLocation;
        }
    }
}
