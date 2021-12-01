using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public class ManagmentClass
    {
        private List<Part> allParts;
        private List<Machine> brokenMachines;
        private List<Part> finishedParts;
        private List<Machine> machines;
        private List<Part> openParts;
        private QualityManagmentClass qualityManagment;
        private List<Machine> workingMachines;

        public ManagmentClass(QualityManagmentClass QM)
        {
            throw new System.NotImplementedException();
        }

        public void addMachine()
        {
            throw new System.NotImplementedException();
        }

        public void getStates()
        {
            throw new System.NotImplementedException();
        }

        public void produce(int currentTime)
        {
            throw new System.NotImplementedException();
        }

        public void readOrders()
        {
            throw new System.NotImplementedException();
        }

        public void sendToQualityCheck()
        {
            throw new System.NotImplementedException();
        }

        public void simulatePossbibleError(int currentTime)
        {
            throw new System.NotImplementedException();
        }

        public void writeAllQualities()
        {
            throw new System.NotImplementedException();
        }
    }
}