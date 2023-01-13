using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.RenovationSessionAggregate.StatisticsModel
{
    public class AverageTimeSpentOnStepsInSession
    {
        public double AvgTimeSpentOnChooseType {get; private set;}
        public double AvgTimeSpentOnChooseOldRooms {get; private set;}
        public double AvgTimeSpentOnCreateTimeframe {get; private set;}
        public double AvgTimeSpentOnCreateNewRooms {get; private set;}
        public double AvgTimeSpentOnSelectSpecificTime {get; private set;}

        public AverageTimeSpentOnStepsInSession(double avgTimeSpentOnChooseOldRooms, double avgTimeSpentOnChooseType,
                                                double avgTimeSpentOnCreateTimeframe, double avgTimeSpentOnCreateNewRooms, double avgTimeSpentOnSelectSpecificTime) {
            this.AvgTimeSpentOnChooseType = avgTimeSpentOnChooseType;
            this.AvgTimeSpentOnChooseOldRooms = avgTimeSpentOnChooseOldRooms;
            this.AvgTimeSpentOnCreateTimeframe = avgTimeSpentOnCreateTimeframe;
            this.AvgTimeSpentOnCreateNewRooms = avgTimeSpentOnCreateNewRooms;
            this.AvgTimeSpentOnSelectSpecificTime = avgTimeSpentOnSelectSpecificTime;
        }

        public static AverageTimeSpentOnStepsInSession AverageOutList(IEnumerable<AverageTimeSpentOnStepsInSession> list) {
            double avgType = 0;
            double avgOld = 0;
            double avgTimeframe = 0;
            double avgNew = 0;
            double avgSpecific = 0;
            int length = list.ToArray().Length;
            if(length == 0) {
                new AverageTimeSpentOnStepsInSession(0,0,0,0,0); 
            }

            foreach(AverageTimeSpentOnStepsInSession s in list.ToList()) {
                avgType += s.AvgTimeSpentOnChooseType;
                avgOld += s.AvgTimeSpentOnChooseOldRooms;
                avgTimeframe += s.AvgTimeSpentOnCreateTimeframe;
                avgNew += s.AvgTimeSpentOnCreateNewRooms;
                avgSpecific += s.AvgTimeSpentOnSelectSpecificTime;
            }
            
            return new AverageTimeSpentOnStepsInSession(avgOld/length, avgType/length, avgTimeframe/length, avgNew/length, avgSpecific/length);

        }
    }
}