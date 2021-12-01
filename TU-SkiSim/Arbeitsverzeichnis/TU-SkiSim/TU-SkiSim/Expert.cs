using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class Expert : Skier
    {
        private double propHutBasic=0.2;
        public Expert(int number, int arrivingTime) : base(number, arrivingTime)
        {
            this.skillLevel = 3;
            this.velocity = 250;
        }

        public override int calculateNeededTime(Track akt_Strecke)
        {
            return (int)Math.Ceiling(akt_Strecke.getLength() / velocity * (1 + akt_Strecke.calcWorkload() / 2));
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
            //            if (rnd.Next(1, 10) <= 2)
            //                return n;
            //            break;
            //        case 2:
            //            if (rnd.Next(1, 10) <= 3)
            //                return n;
            //            break;
            //        case 3:
            //            if (rnd.Next(1, 10) <= 5)
            //                return n;
            //            break;
            //    }
            //}
            return alle_Strecken.FirstOrDefault(q => q.getNumber() == 1);
        }

        public override double getProbabilityHut()
        {
            if (visitedHuts.Count() < 1)
                return propHutBasic * (1 - visitedHuts.Count()) / 2;
            else
                return propHutBasic * 0.5;
        }
    }
}