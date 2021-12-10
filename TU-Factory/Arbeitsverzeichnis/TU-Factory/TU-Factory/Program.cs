using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            QualityManagmentClass QualityManagment = new QualityManagmentClass(0.95, 0, 0);
            ManagmentClass Managment = new ManagmentClass(QualityManagment);
            Managment.addMachine(new TurningMachine(1, 0, 75, 0.5, 0.1, 10, 10));
            Managment.addMachine(new MillingMachine(2, 0, 5, 25, 20, 0, 10));
            Managment.addMachine(new GrindingMachine(3, 0, 0.02, 50, 30, 80, 20, 0));

            Managment.readOrders();
            int currentTime = 0;
            while (currentTime <=30)
            {
                Console.WriteLine($"***************************************** Time: {currentTime} *****************************************");
                Managment.produce(currentTime);
                Managment.sendToQualityCheck();
                Managment.simulatePossbibleError(currentTime);
                Managment.getStates();
                currentTime++;
            }

            Managment.writeAllQualities();
            Console.ReadKey();

        }
    }   
}
