using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;

namespace HospitalLibrary.BuildingManagmentMap.Model
{
    public class FloorMap : MapItem
    {
        public virtual Floor Floor { get; set; }    

        public void Update(FloorMap map)
        {
            base.Update(map);
            Floor = map.Floor;
        }
    }
}
