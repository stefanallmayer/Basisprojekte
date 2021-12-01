using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class Advanced : Skier
    {
        private double propHutBasic=0.8;
        public Advanced(int number, int arrivingTime) : base(number, arrivingTime)
        {
            this.skillLevel = 2;
            this.velocity = 150;
        }
       

        public override Track calculateNextTrack(List<Track> alle_Strecken)
        {
            Track[] potStrecken = alle_Strecken.Where(q => q.getLevel() <= skillLevel).ToArray();
            Random rnd = new Random();
            //foreach (Track n in potStrecken)
            //{
            //    switch (n.getLevel())
            //    {
            //        case 1:
            //            if (rnd.Next(1, 10) <= 7)
            //                return n;
            //            break;
            //        case 2:
            //            if (rnd.Next(1, 10) <= 3)
            //                return n;
            //            break;
            //    }
            //}
            return alle_Strecken.FirstOrDefault(q => q.getNumber() == 1);
        }

        public override double getProbabilityHut()
        {
            if (visitedHuts.Count() < 2)
                return propHutBasic * (2 - visitedHuts.Count()) / 2;
            else
                return propHutBasic * 0.5;
        }
    }
}