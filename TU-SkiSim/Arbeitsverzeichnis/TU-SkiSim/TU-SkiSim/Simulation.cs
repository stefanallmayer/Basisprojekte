﻿using System;
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

        private readonly Logger logger;

        public Simulation(List<Lift> lifte, List<Skier> schifahrer, List<Hut> huetten, List<Track> strecken, Logger logger = null)
        {
            this.addedLifts = lifte;
            this.addedSkier = schifahrer;
            this.addedTracks = strecken;
            this.logger = logger;
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
               if (Zeit >= endzeit-90)
                { }
                int anzahlSkifahrer = addedSkier.Count();
                foreach (Skier n in addedSkier)
                {
                    if (n.getStatus() == Status.inLift && n.getTimeToNextStep() == 0)
                    { }
                    if (n.getStatus() != Status.leftResort && n.getTimeToNextStep() == 0 && Zeit >= n.getArrivingTime())
                    {
                        switch (n.getStatus())
                        {
                            case Status.vorLift:
                                enterResort(n);
                                break;
                            case Status.inLift:
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
                        logger?.AppendTask("Skigebiet verlassen");
                    }
                    else
                    {
                        logger?.AppendTask("keine Aktion");
                    }
                   
                    n.countDownTime();                   
                    logger?.Log(Zeit, n);
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

                logger?.AppendTask($"4.1 Wartenr: {skifahrer.getWaitingNumber()}");
            }   
            
            if (lift1.calcFlowRate()>= skifahrer.getWaitingNumber())
            {
                skifahrer.setUsedLift(lift1);
                skifahrer.setStatus(Status.inLift);
                skifahrer.setTimeToNextStep(lift1.getTravelTime());
                skifahrer.setWaitingNumber(0);
                logger?.AppendTask($"4.1.1 Lift wählen: {lift1}");
            }
            else
            {
                skifahrer.setWaitingNumber(skifahrer.getWaitingNumber() - lift1.calcFlowRate());
                logger?.AppendTask($"4.1.2 Wartenummer reduzieren zu: {skifahrer.getWaitingNumber()}");
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
                logger?.AppendTask($"4.2 nächste Strecke Track: {nextTrack.getNumber()}");

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
                logger?.AppendTask("6. letzte Abfahrt ");
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
                       
            
            
            logger?.AppendTask($"4.4 nächsten Lift wählen Track: {lastTrack.getNumber()} Wartenr: {skifahrer.getWaitingNumber()}");

            if ((nextlift.calcFlowRate() >= skifahrer.getWaitingNumber()))
            {
                skifahrer.setStatus(Status.inLift);
                skifahrer.setUsedLift(nextlift);
                skifahrer.setTimeToNextStep(nextlift.getTravelTime());
                skifahrer.setWaitingNumber(0);
                lastTrack.changePeopleOnTheTrack(lastTrack.getPeopleOnTheTrack() - 1);
                logger?.AppendTask("4.4.1 Lift nehmen ");
            }
            else
            {
                skifahrer.setWaitingNumber(skifahrer.getWaitingNumber() - getLift1().calcFlowRate());
            }
        }
    }
}