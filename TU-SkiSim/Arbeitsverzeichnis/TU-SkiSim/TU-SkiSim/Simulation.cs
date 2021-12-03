using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class Simulation
    {
        private List<Lift> addedLifts;
        private List<Skier> addedSkier;
        private List<Track> addedTracks;
        private bool status;

        

        public Simulation(List<Lift> lifte, List<Skier> schifahrer, List<Hut> huetten, List<Track> strecken)
        {
            this.addedLifts = lifte;
            this.addedSkier = schifahrer;
            this.addedTracks = strecken;            
        }

        public List<Lift> getLifts()
        {
            return addedLifts;
        }

        public List<Skier> getSkier()
        {
            return addedSkier;
        }

        public List<Track> getTracks()
        {
            return addedTracks;
        }

        public void simulate(int startzeit, int endzeit)
        {
            endzeit *= 60;
            startzeit *= 60;
            status = false;
            int Zeit = startzeit;
            while (Zeit <= endzeit)
            {               
                int anzahlSkifahrer = addedSkier.Count();
                foreach (Skier n in addedSkier)
                {
                    if (n.getStatus() == Status.inLift && n.getTimeToNextStep() == 0)
                    { }
                    if (n.getStatus() != Status.leftResort && n.getTimeToNextStep() == 0 && Zeit >= n.getArrivingTime())
                    {
                        switch (n.getStatus())
                        {
                            case Status.vorLift:        //4.1
                                enterResort(n);
                                break;
                            case Status.inLift:         //4.2
                                skierOnLift(n, Zeit, endzeit);
                                break;
                            default:
                                sonnstigerStatus(n);
                                break;
                        }
                        
                    }
                    else if (n.getStatus() == Status.leftResort && n.getTimeToNextStep() == 0 && n.getLeavingTime() == Zeit)
                    {
                        n.setLeavingTime(Zeit);                       
                    }
                   
                   
                    n.countDownTime();                   
                    
                }
                foreach (Lift lift in addedLifts)
                {
                    lift.redWaitingQueue();
                }
                if (Zeit % 30 == 0)
                {
                    Console.WriteLine("Halbstündliche Auslastung der Strecken:");
                    foreach (Track strecke in addedTracks)
                    {
                        Console.WriteLine($@"Uhrzeit {(double)Zeit / 60}       Die Strecke {strecke.getNumber()} hat aktuell eine Auslastung von {strecke.calcWorkload():p}");
                    }
                


                }                
                Zeit += 1;
            }
            status = false;
            Console.WriteLine("Simulation beendet");
        }

        
        
        
        
        private Lift getLift1()
        {
            return addedLifts.FirstOrDefault(q => q.getNumber() == 1);
        }





        private void enterResort(Skier skifahrer)
        {
            Lift lift1 = getLift1();
            if (skifahrer.getWaitingNumber() == 0)
            { 
                lift1.addQueue();
                skifahrer.setWaitingNumber(lift1.getWaitingQueue());
            }   
            
            if (lift1.calcFlowRate()>= skifahrer.getWaitingNumber())
            {
                skifahrer.setUsedLift(lift1);
                skifahrer.setStatus(Status.inLift);
                skifahrer.setTimeToNextStep(lift1.getTravelTime());
                skifahrer.setWaitingNumber(0);                
            }
            else
            {
                skifahrer.setWaitingNumber(skifahrer.getWaitingNumber() - lift1.calcFlowRate());                
            }
        }
        
        
        
        
        
        private void skierOnLift(Skier skifahrer, int zeit, int endzeit)
        {
            if (zeit < endzeit - 90)
            {
                Track nextTrack = skifahrer.calculateNextTrack(getTracks());
                skifahrer.setUsedTrack(nextTrack);
                nextTrack.changePeopleOnTheTrack(nextTrack.getPeopleOnTheTrack() + 1);
                skifahrer.setStatus(Status.inTrack);
                skifahrer.setTimeToNextStep(skifahrer.calculateNeededTime(nextTrack));               

                //if (nextTrack.getHut() != null)
                //{
                //    Random rnd = new Random();
                //    if (skifahrer.getProbabilityHut() > rnd.NextDouble() && nextTrack.getHut().getGuests() < nextTrack.getHut().getMaxGuests())
                //    {
                //        skifahrer.setTimeToNextStep(nextTrack.getHut().getAverageStay());
                //        skifahrer.setVisitedHut(nextTrack.getHut());
                //        nextTrack.getHut().addGuests(1);
                //    }
                //}
            }
            else
            {               
                skifahrer.setStatus(Status.leftResort);
                Track nextTrack = skifahrer.calculateNextTrack(getTracks().Where(q => q.getNumber() == 1 || q.getNumber() == 2).ToList());
                int abfahrtszeit = skifahrer.calculateNeededTime(nextTrack);
                skifahrer.setUsedTrack(nextTrack);
                nextTrack.changePeopleOnTheTrack(nextTrack.getPeopleOnTheTrack() + 1);
                skifahrer.setTimeToNextStep(abfahrtszeit);
                skifahrer.setLeavingTime(zeit + abfahrtszeit);                
            }
        }
       
        
        
        
        
        
        private void sonnstigerStatus(Skier skifahrer)
        {
            Track lastTrack = skifahrer.getUsedTracks().Last();
            Lift nextlift = lastTrack.getLift();          
            if(skifahrer.getWaitingNumber() == 0)
            {
                nextlift.addQueue();
                skifahrer.setWaitingNumber(nextlift.getWaitingQueue());
            }                      
            

            if ((nextlift.calcFlowRate() >= skifahrer.getWaitingNumber()))
            {
                skifahrer.setStatus(Status.inLift);
                skifahrer.setUsedLift(nextlift);
                skifahrer.setTimeToNextStep(nextlift.getTravelTime());
                skifahrer.setWaitingNumber(0);
                lastTrack.changePeopleOnTheTrack(lastTrack.getPeopleOnTheTrack() - 1);                
            }
            else
            {
                skifahrer.setWaitingNumber(skifahrer.getWaitingNumber() - getLift1().calcFlowRate());
            }
        }
    }
}