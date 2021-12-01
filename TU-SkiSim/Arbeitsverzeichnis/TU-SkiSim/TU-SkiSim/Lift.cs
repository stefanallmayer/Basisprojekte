using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public abstract class Lift
    {
        protected int elements;
        protected int length;
        protected int number;
        protected int velocity;
        private int waitingQueue;

        protected Lift(int number, int velocity, int length, int elements)
        {
            this.number = number;
            this.velocity = velocity;
            this.length = length;
            this.elements = elements;
        }

        public void addQueue()
        {
            waitingQueue++;
        }

        public abstract int calcFlowRate();
        

        public int getNumber()
        {
            return number;
        }

        public int getTravelTime()
        {
            return length / velocity;
        }

        public int getWaitingQueue()
        {
            return waitingQueue;
        }

        public void redWaitingQueue()
        {
            int a= waitingQueue-calcFlowRate();
            if (a<0)
            {
                a = 0;
            }
            waitingQueue = a;
        }
    }
}