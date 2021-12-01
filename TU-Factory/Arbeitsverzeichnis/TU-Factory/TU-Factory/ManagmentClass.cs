using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TU_Factory
{
    public class ManagmentClass
    {
        private List<Part> allParts = new List<Part>();
        private List<Machine> brokenMachines = new List<Machine>();
        private List<Part> finishedParts = new List<Part>();
        private List<Machine> machines = new List<Machine>();
        private List<Part> openParts = new List<Part>();
        private QualityManagmentClass qualityManagment;
        private List<Machine> workingMachines = new List<Machine>();

        public ManagmentClass(QualityManagmentClass QM)
        {
            this.qualityManagment = QM;
        }

        public void addMachine(Machine M)
        {
            machines.Add(M);
            workingMachines.Add(M);
        }

        public void getStates()
        {
            allParts.ForEach(q => Console.WriteLine(q));
        }

        public void produce(int currentTime)
        {
            List<Part> tempFinishedParts = new List<Part>();
            foreach (Part P in allParts)
            {
                if (P.getNumberOfOpenOperations() == 0)
                {
                    P.setState(state.FertigesTeil);
                    
                    tempFinishedParts.Add(P);
                }
            }
            finishedParts.AddRange(tempFinishedParts);
            foreach (Part P in tempFinishedParts)
            {
                openParts.Remove(P);
            }
            tempFinishedParts.Clear();

            foreach (Part p in openParts)
            {                
                foreach (Machine m in workingMachines)
                {
                    if (!m.getInUse() && m.getMachineType() == p.getNextMachiningMachineType())
                    {
                        

                        m.setInUse(true);
                        m.setCurrentPart(p);
                        m.setMachineVolume();
                        m.setTimeAndCalculateWear(currentTime, m.getCalcMachinTime() + currentTime);
                        p.setState(state.aktiveBearbeitung);
                        p.setCurrentMachine(m);
                        p.setQuality(p.getQuality() - p.getQuality() * m.getInfluenceOnQuality());
                        

                        Console.WriteLine($"{p} wird nun in {m} bearbeitet");
                        break;
                    }
                }               
            }
            foreach (Machine m in workingMachines)          
            {
                if (currentTime >= m.getEndTime() && !m.getInRepair())
                {
                    m.setInUse(false);
                    if (m.getCurrentPart() != null)
                    {
                        Part currentPart = m.getCurrentPart();
                        currentPart.setPartFree();
                        currentPart.deleteMachineStep();
                        m.setCurrentPart(null);
                        Console.WriteLine($"{m} ist jetzt wieder frei und bereit zum Bearbeiten neuer Teile.");
                    }
                }
            }         
  
           
        }

        public void readOrders()
        {
            List<Part> TeilListe = new List<Part>();
            string[] Zeilen = File.ReadAllLines(@"C:\Users\Steve\Documents\uni\3. Semester\Ing. Inf. II\Basisiprjekte Repo\Basisprojekte\TU-Factory\Angabe\TeileListe_neu.csv").Skip(1).ToArray();
            foreach (string n in Zeilen)
            {
                string[] TeilArray = n.Split(';');
                List<WorkingStep> Arbeitsschritte = new List<WorkingStep>();
                if (TeilArray[2] != "")
                    Arbeitsschritte.Add(new WorkingStep(TeilArray[2], double.Parse(TeilArray[3])));
                if (TeilArray[4] != "")
                    Arbeitsschritte.Add(new WorkingStep(TeilArray[4], double.Parse(TeilArray[5])));
                if (TeilArray[6] != "")
                    Arbeitsschritte.Add(new WorkingStep(TeilArray[6], double.Parse(TeilArray[7])));
                
                Part neuesTeil =new Part(Arbeitsschritte, int.Parse(TeilArray[1]));
                allParts.Add(neuesTeil);
                openParts.Add(neuesTeil);
            }
        }

        public void sendToQualityCheck()
        {
            foreach (Part n in finishedParts)
            {
                qualityManagment.qualityCheck(n);
            }
        }

        public void simulatePossbibleError(int currentTime)
        {
            List<Machine> tempMachineList = new List<Machine>();
            List<Machine> tempBrokenMachineList = new List<Machine>();
            foreach (Machine m in workingMachines)
            {
                if (m.possibleError())
                {
                    brokenMachines.Add(m);
                    tempMachineList.Add(m);
                    Console.WriteLine($"{m} ist kaputt.");
                }
            }
            foreach (Machine m in brokenMachines)
            {
                if(!m.getInRepair())
                {
                    m.setInRpair(true);
                    m.addToEndingTime(3);
                    Console.WriteLine($"{m} ist in Reperatur.");
                }
            }
            foreach (Machine m in tempMachineList)
            {
                workingMachines.Remove(m);
            }
            tempMachineList.Clear();
            
            foreach (Machine m in workingMachines)
            {
                if(currentTime >= m.getEndTime() && m.getInRepair())
                {
                    m.setInUse(false);
                    m.setInRpair(false);
                    tempBrokenMachineList.Add(m);
                    m.repair();
                    Console.WriteLine($"{m} wurde repariert und ist wieder einsatzbereit.");
                }
            }
            foreach (Machine m in tempBrokenMachineList)
            {
                workingMachines.Add(m);
                brokenMachines.Remove(m);   
            }
            tempBrokenMachineList.Clear();
        }

        public void writeAllQualities()
        {
            Console.WriteLine("\n********************************");
            allParts.ForEach(q => Console.WriteLine(q.ToString().PadRight(40,' ') + "Quality: " + q.getQuality().ToString()));
        }
        
          
        
    }
}