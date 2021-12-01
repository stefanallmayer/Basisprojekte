using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public class QualityManagmentClass
    {
        private double allowedQuality;
        private List<Part> badParts = new List<Part>();
        private List<Part> goodParts = new List<Part>();
        private int xCoordinate;
        private int yCoordinate;

        public QualityManagmentClass(double allowedQuality, int xCoordinate, int yCoordinate)
        {
            this.allowedQuality = allowedQuality;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public void qualityCheck(Part P)
        {
            if (P.getQuality() >= allowedQuality)
            {
                goodParts.Add(P);
                P.setState(state.QualityGOOD);
            }

            else
            {
                badParts.Add(P);
                P.setState(state.QualityBAD);
            }
        }
    }
}