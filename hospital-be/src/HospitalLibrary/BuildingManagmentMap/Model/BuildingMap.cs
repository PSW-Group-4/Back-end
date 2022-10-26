using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;

namespace HospitalLibrary.BuildingManagmentMap.Model
{
    public class BuildingMap : MapItem
    {
        public virtual Building Building { get; set; }

        public void Update(BuildingMap map)
        {
            base.Update(map);
            Building = map.Building;
        }
    }
}
