using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalLibrary.RenovationSessionAggregate.StatisticsModel;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;

namespace HospitalLibrary.RenovationSessionAggregate.Services.Implementation
{
    public class RenovationSessionStatisticsService : IRenovationSessionStatisticsService
    {
        public IRenovationSessionService _renovationSessionService;

        public RenovationSessionStatisticsService(IRenovationSessionService renovationSessionService) {
            this._renovationSessionService = renovationSessionService;
        }

        public FinishedAndUnfinishedSessionStatistic GetFinishedAndUnfinishedSessionStatistic() {
            int all = this._renovationSessionService.GetAll().ToArray().Length;
            int finished = this._renovationSessionService.GetAllFinished().ToArray().Length;
            return new FinishedAndUnfinishedSessionStatistic(finished, all - finished);
        }
        public IEnumerable<FinishedSessionStatisticsForTable> GetFinishedSessionStatisticsForTable() {
            List<RenovationSessionAggregateRoot> listOfFinished = this._renovationSessionService.GetAllFinished().ToList();
            List<FinishedSessionStatisticsForTable> listToReturn = new List<FinishedSessionStatisticsForTable>();
            foreach(RenovationSessionAggregateRoot root in listOfFinished) {
                AverageTimeSpentOnStepsInSession timeSpent = new AverageTimeSpentOnStepsInSession(root.GetAverageTimeForEvent(typeof(OldRoomsChosen)),
                                                 root.GetAverageTimeForEvent(typeof(TypeChosen)),root.GetAverageTimeForEvent(typeof(TimeframeCreated)),
                                                 root.GetAverageTimeForEvent(typeof(NewRoomsCreated)),root.GetAverageTimeForEvent(typeof(SpecificTimeChosen)));
                listToReturn.Add(new FinishedSessionStatisticsForTable(root.GetStartTime(), root.GetTotalTimeSpent(), root.GetTimesGoneBack(),timeSpent));
            }
            return listToReturn;
        }
        public AverageTimeSpentOnStepsInSession GetAverageTimeSpentOnStepsInSession() {
            List<RenovationSessionAggregateRoot> listAll = this._renovationSessionService.GetAll().ToList();
            List<AverageTimeSpentOnStepsInSession> listOfStepsLengts = new List<AverageTimeSpentOnStepsInSession>();
            foreach(RenovationSessionAggregateRoot root in listAll) {
                AverageTimeSpentOnStepsInSession timeSpent = new AverageTimeSpentOnStepsInSession(root.GetAverageTimeForEvent(typeof(OldRoomsChosen)),
                                                 root.GetAverageTimeForEvent(typeof(TypeChosen)),root.GetAverageTimeForEvent(typeof(TimeframeCreated)),
                                                 root.GetAverageTimeForEvent(typeof(NewRoomsCreated)),root.GetAverageTimeForEvent(typeof(SpecificTimeChosen)));
                listOfStepsLengts.Add(timeSpent);
            }
            return AverageTimeSpentOnStepsInSession.AverageOutList(listOfStepsLengts);
        }

        public AverageNumberOfTimesWentBackPerStep GetAverageNumberOfTimesWentBackPerStep() {
            List<RenovationSessionAggregateRoot> listAll = this._renovationSessionService.GetAll().ToList();
            List<AverageNumberOfTimesWentBackPerStep> listOfStepsLengts = new List<AverageNumberOfTimesWentBackPerStep>();
            foreach(RenovationSessionAggregateRoot root in listAll) {
                AverageNumberOfTimesWentBackPerStep timeSpent = new AverageNumberOfTimesWentBackPerStep(root.GetNumberOfOccurences(typeof(ReturnedToOldRoomsSelection)),
                                                 root.GetNumberOfOccurences(typeof(ReturnedToTypeSelection)),root.GetNumberOfOccurences(typeof(ReturnedToTimeframeCreation)),
                                                 root.GetNumberOfOccurences(typeof(ReturnedToNewRoomCreation)),root.GetNumberOfOccurences(typeof(ReturnedToSpecificTimeSelection)));
                listOfStepsLengts.Add(timeSpent);
            }
            return AverageNumberOfTimesWentBackPerStep.AverageOutList(listOfStepsLengts);
        }

        public AverageTimeSpentOnStepsInSession GetAverageTimeSpentOnStepsInSessionForTimeframe(DateTime start, DateTime end) {
            List<RenovationSessionAggregateRoot> listAll = this._renovationSessionService.GetAll().ToList();
            List<AverageTimeSpentOnStepsInSession> listOfStepsLengts = new List<AverageTimeSpentOnStepsInSession>();
            foreach(RenovationSessionAggregateRoot root in listAll) {
                if(!(root.GetStartTime().Hour >= start.Hour && root.GetStartTime().Hour < end.Hour)) {
                    continue;
                }
                AverageTimeSpentOnStepsInSession timeSpent = new AverageTimeSpentOnStepsInSession(root.GetAverageTimeForEvent(typeof(OldRoomsChosen)),
                                                 root.GetAverageTimeForEvent(typeof(TypeChosen)),root.GetAverageTimeForEvent(typeof(TimeframeCreated)),
                                                 root.GetAverageTimeForEvent(typeof(NewRoomsCreated)),root.GetAverageTimeForEvent(typeof(SpecificTimeChosen)));
                listOfStepsLengts.Add(timeSpent);
            }
            return AverageTimeSpentOnStepsInSession.AverageOutList(listOfStepsLengts);
        }

        public NumberOfSessionLeftOffOnEachStep GetNumberOfSessionLeftOffOnEachStep() {
            List<RenovationSessionAggregateRoot> listUnfinished = this._renovationSessionService.GetAllUnfinished().ToList();
            NumberOfSessionLeftOffOnEachStep statistic = new NumberOfSessionLeftOffOnEachStep();
            foreach(RenovationSessionAggregateRoot root in listUnfinished) {
                if(root.GetSessionLastEventType().Equals(typeof(TypeChosen)) || root.GetSessionLastEventType().Equals(typeof(ReturnedToTypeSelection))) {
                    statistic.NumberOnType += 1;
                }
                else if(root.GetSessionLastEventType().Equals(typeof(OldRoomsChosen)) || root.GetSessionLastEventType().Equals(typeof(ReturnedToOldRoomsSelection))) {
                    statistic.NumberOnOldRooms += 1;
                }
                else if(root.GetSessionLastEventType().Equals(typeof(TimeframeCreated)) || root.GetSessionLastEventType().Equals(typeof(ReturnedToTimeframeCreation))) {
                    statistic.NumberOnTimeframe += 1;
                }
                else if(root.GetSessionLastEventType().Equals(typeof(NewRoomsCreated)) || root.GetSessionLastEventType().Equals(typeof(ReturnedToNewRoomCreation))) {
                    statistic.NumberOnNewRooms += 1;
                }
                else{
                    statistic.NumberOnSpecificTime += 1;
                }
            }
            return statistic;
        }
    }
}