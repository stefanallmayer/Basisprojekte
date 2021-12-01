using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class Track
    {
        private int capacity;
        private Hut hut;
        private int length;
        private int level;
        private Lift lift;
        private int number;
        private int peopleOnTheTrack;
        private double workload;

        public Track(int nummer, int länge, int level, Hut huette, int kapazität, Lift lift_der_Strecke)
        {
            this.number = nummer;
            this.length = länge;
            this.level = level;
            this.hut = huette;
            this.capacity = kapazität;
            this.lift = lift_der_Strecke;
        }

        public Track(int nummer, int länge, int level, int kapazität, Lift lift_der_Strecke)
        {
            this.number = nummer;
            this.length = länge;
            this.level = level;            
            this.capacity = kapazität;
            this.lift = lift_der_Strecke;
        }

        public double calcWorkload()
        {
            return (double)peopleOnTheTrack / (double)capacity;
        }

        public void changePeopleOnTheTrack(int Anzahl)
        {
            peopleOnTheTrack = Anzahl;
        }

        public Hut getHut()
        {
            return hut;
        }

        public int getLength()
        {
            return length;
        }

        public int getLevel()
        {
            return level;
        }

        public Lift getLift()
        {
            return lift;
        }

        public int getNumber()
        {
            return number;
        }

        public int getPeopleOnTheTrack()
        {
            return peopleOnTheTrack;
        }
    }
}