using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExamples
{
    [Serializable]
    public class Car
    {
        
        private string carName;
        private string carID;
        private EnumCarType carType;
        private int carSpeed;
        private object lockObject;

        public string CarName { get => carName; set => carName = value; }
        public string CarID { get => carID; set => carID = value; }
        public EnumCarType CarType { get => carType; set => carType = value; }
        public int CarSpeed { get => carSpeed; set => carSpeed = value; }

        public Car(string carName, string carID, EnumCarType carType, int carSpeed, object lockObject)
        {
            this.carName = carName;
            this.carID = carID;
            this.CarType = carType;
            this.carSpeed = carSpeed;
            this.lockObject = lockObject;
        }

        public void PrintCar ()
        {
            lock (this.lockObject)
            {
                Console.WriteLine($"carID =  { carID} carType = {this.carType} carSpeed ={this.carSpeed} carName = {this.carName} ");

            }
        }

    }
}
