using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class Hut
    {
        private int averageStay;
        private int guests;
        private int maxGuests;
        private string name;

        public Hut(string name, int max_besucher, int average_stay)
        {
            this.name = name;
            this.maxGuests = max_besucher;
            this.averageStay = average_stay;
        }

        public void addGuests(int anzahl)
        {
            guests++;
        }

        public int getAverageStay()
        {
            return averageStay;
        }

        public int getGuests()
        {
            return guests;
        }

        public int getMaxGuests()
        {
            return maxGuests;
        }
        public string getName()
        {
            return name;
        }
    }
}