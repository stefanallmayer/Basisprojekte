using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public abstract class Skier
    {
        private int arrivingTime;       //
        private int leavingTime;        //
        private int number;             //
        protected int skillLevel;       //
        private Status status ;         //   
        private int timeToNextStep;     //
        private List<Lift> usedLifts;   //
        private List<Track> usedTracks; //
        protected int velocity;         //
        protected List<Hut> visitedHuts;    
        private int waitingNumber;

        protected Skier(int number, int arrivingTime)
        {
            this.number = number;
            this.arrivingTime = arrivingTime;
            usedLifts = new List<Lift>();
            usedTracks = new List<Track>();
            visitedHuts = new List<Hut>();
            this.status = Status.vorLift;
            this.timeToNextStep = 0;
            this.waitingNumber = 0;
        }

        public virtual int calculateNeededTime(Track akt_Strecke)
        {
            return (int)Math.Ceiling((double)akt_Strecke.getLength() / velocity);
        }

        public abstract Track calculateNextTrack(List<Track> alle_Strecken);



        public void countDownTime()
        {
            timeToNextStep--;
            if (timeToNextStep<0)
            {
                timeToNextStep = 0;
            }
        }

        public int getArrivingTime()
        {
            return arrivingTime;
        }

        public int getLeavingTime()
        {
            return leavingTime;
        }

        public int getNumber()
        {
            return number;
        }

        public abstract double getProbabilityHut();
        

        public Status getStatus()
        {
            return status;
        }

        public int getTimeToNextStep()
        {
           return timeToNextStep;
        }

        public List<Lift> getUsedLifts()
        {
            return usedLifts;
        }

        public List<Track> getUsedTracks()
        {
            return usedTracks;
        }

        public List<Hut> getVisitedHuts()
        {
            return visitedHuts;
        }

        public int getWaitingNumber()
        {
           return waitingNumber;
        }

        public void setLeavingTime(int set_leaving_time)
        {
            leavingTime = set_leaving_time;
        }

        public void setStatus(Status set_status)
        {
            status=set_status;
        }

        public void setTimeToNextStep(int set_time)
        {
            timeToNextStep= set_time;
        }

        public void setUsedLift(Lift lift)
        {
            usedLifts.Add(lift);
        }

        public void setUsedTrack(Track strecke)
        {
            usedTracks.Add(strecke);
        }

        public void setVisitedHut(Hut huette)
        {
            visitedHuts.Add(huette);
        }

        public void setWaitingNumber(int set_waitingnumber)
        {
           waitingNumber=set_waitingnumber;
        }

        public override string ToString()
        {
            return $"Nummer: {number}, SkillLevel: {skillLevel}, Time of arrival: {arrivingTime/60}, Leaving time: {leavingTime/60}";
        }
    }
    public enum Status:int
    {
        vorLift = -1,
        inLift = 0,
        inTrack = 1,
        leftResort = 2
    } 
}