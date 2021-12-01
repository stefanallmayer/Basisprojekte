using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class Beginner : Skier
    {
        private double propHutBasic = 1;

        public Beginner(int number, int arrivingTime) : base(number, arrivingTime) 
        {
            this.skillLevel = 1;
            this.velocity = 50;
        }       
        

       

        public override Track calculateNextTrack(List<Track> alle_Strecken)
        {
            Track[] potStrecken = alle_Strecken.Where(q => q.getLevel() <= skillLevel).ToArray();
            Random rnd = new Random();

            //foreach (Track n in potStrecken)
            //{
            //    if (rnd.Next(0, 1) == 1)
            //    {
            //        return n;
            //    }
            //}

            return potStrecken.FirstOrDefault(q => q.getNumber() == 1);
        }

        public override double getProbabilityHut()
        {
            if (visitedHuts.Count() < 3)
                return propHutBasic * (3 - visitedHuts.Count());
            else
                return propHutBasic * 0.5;
        }
    }
}