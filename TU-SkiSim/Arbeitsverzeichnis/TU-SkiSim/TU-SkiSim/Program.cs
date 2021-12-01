using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TU_SkiSim
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lift> allLifts = new List<Lift> {new Chairlift(1,100,1500,0,40,4),     //Lift 1
            new Chairlift(2,90,1200,0,30,2),                                            //Lift 2
            new SkiTow(3,50,600,0,30,2)};                                               //Lift 3

            List<Hut> alleHuetten = new List<Hut> {new Hut("Hut1",200,40),
            new Hut("Hut2",150,45),
            new Hut("Hut1",100,25)};
            
            List<Track> allTracks = new List<Track> { new Track(1,2500,1,alleHuetten.FirstOrDefault(q => q.getName() == "Hut1"),120,allLifts.FirstOrDefault(q => q.getNumber() == 1)),
                new Track(2,2200,2,alleHuetten.FirstOrDefault(q => q.getName() == "Hut2"),80,allLifts.FirstOrDefault(q => q.getNumber() == 1)),
                new Track(3,1700,1,alleHuetten.FirstOrDefault(q => q.getName() == "Hut3"),60,allLifts.FirstOrDefault(q => q.getNumber() == 2)),
                new Track(4,1600,2,70,allLifts.FirstOrDefault(q => q.getNumber() == 2)),
                new Track(5,800,3,50,allLifts.FirstOrDefault(q => q.getNumber() == 3))};

            List<Skier> allSkiers = new List<Skier>();
            allSkiers = GetTicketList();

            Console.BufferHeight = Int16.MaxValue - 20000;
            var logger = new Logger();
            Simulation Test = new Simulation(allLifts, allSkiers,alleHuetten,allTracks, logger);
            Test.simulate(8,17);

            foreach (Skier s in allSkiers)
            {
                Console.WriteLine($@"{s}    gefahrene Kilometer: {s.getUsedTracks().Sum(q => q.getLength())/1000}");                
            }

            

            
            
            

            //logger.WriteToFile(@"C:\Users\Steve\Documents\uni\3. Semester\Ing. Inf. II\Basisprojekte Stefan\Neuer Ordner\Logger.txt");
            Console.ReadLine();
        }
        static List<Skier> GetTicketList()
        {
            List<Skier> skierList= new List<Skier>();
            string[] Zeilen = File.ReadAllLines(@"C:\Users\Steve\Documents\uni\3. Semester\Ing. Inf. II\Arbeitsverzeichnis\U1\U1\Basisprojekte Stefan\TU-SkiSim\Angabe\Ticketverkaeufe.CSV");
            foreach (string n in Zeilen)
            {
                string[] skiffahrerArray = n.Split(';');
                string type = skiffahrerArray[2];

                switch (type)
                {
                    case ("1"):
                        skierList.Add(new Beginner(int.Parse(skiffahrerArray[0]), int.Parse(skiffahrerArray[1])*60));
                        break;
                    case ("2"):
                        skierList.Add(new Advanced(int.Parse(skiffahrerArray[0]), int.Parse(skiffahrerArray[1])*60));
                        break;
                    case ("3"):
                        skierList.Add(new Expert(int.Parse(skiffahrerArray[0]), int.Parse(skiffahrerArray[1])*60));
                        break;
                    default:
                        Console.WriteLine("Error 69! Unbekanntes Skilllevel in der Liste");
                        break;
                }
            }        
            return skierList;
        }     
    }
}
