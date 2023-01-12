using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.RenovationSessionAggregate.StatisticsModel
{
    public class AverageNumberOfTimesWentBackPerStep
    {
        public double AvgTimesWentBackToType {get; private set;}
        public double AvgTimesWentBackToOldRooms {get; private set;}
        public double AvgTimesWentBackToTimeframe {get; private set;}
        public double AvgTimesWentBackToNewRooms {get; private set;}
        public double AvgTimesWentBackToSpecificTime {get; private set;}

        public AverageNumberOfTimesWentBackPerStep(double avgTimeSpentOnChooseOldRooms, double avgTimeSpentOnChooseType,
                                                double avgTimeSpentOnCreateTimeframe, double avgTimeSpentOnCreateNewRooms, double avgTimeSpentOnSelectSpecificTime) {
            this.AvgTimesWentBackToType = avgTimeSpentOnChooseType;
            this.AvgTimesWentBackToOldRooms = avgTimeSpentOnChooseOldRooms;
            this.AvgTimesWentBackToTimeframe = avgTimeSpentOnCreateTimeframe;
            this.AvgTimesWentBackToNewRooms = avgTimeSpentOnCreateNewRooms;
            this.AvgTimesWentBackToSpecificTime = avgTimeSpentOnSelectSpecificTime;
        }

        public static AverageNumberOfTimesWentBackPerStep AverageOutList(IEnumerable<AverageNumberOfTimesWentBackPerStep> list) {
            double avgType = 0;
            double avgOld = 0;
            double avgTimeframe = 0;
            double avgNew = 0;
            double avgSpecific = 0;
            int length = list.ToArray().Length;
            if(length == 0) {
                return new AverageNumberOfTimesWentBackPerStep(0,0,0,0,0);
            }

            foreach(AverageNumberOfTimesWentBackPerStep s in list.ToList()) {
                avgType += s.AvgTimesWentBackToType;
                avgOld += s.AvgTimesWentBackToOldRooms;
                avgTimeframe += s.AvgTimesWentBackToTimeframe;
                avgNew += s.AvgTimesWentBackToNewRooms;
                avgSpecific += s.AvgTimesWentBackToSpecificTime;
            }
            
            return new AverageNumberOfTimesWentBackPerStep(avgOld/length, avgType/length, avgTimeframe/length, avgNew/length, avgSpecific/length);

        }
    }
}