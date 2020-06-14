using ParallelExamples;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f = new FileStream("car.ser", FileMode.Create);

            //create BinaryFormatter that can serilize object into file
            BinaryFormatter b = new BinaryFormatter();
            List<Car> list = new List<Car>();
            for (int i = 0; i < 100000; i++)

            {
                Car x = new Car(" car ", "car 1", EnumCarType.Bus, 100);

                list.Add(x);
              
            }

            b.Serialize(f, list);


            //close file
            f.Close();



            Car a = null;
            //open existing file
            FileStream ff1 = File.OpenRead("car.ser");
            //create BinaryFormatter that can Deserialize
            BinaryFormatter b1 = new BinaryFormatter();
            //List<Car> cars = new List<Car>();

            List<Car> listOut = b1.Deserialize(ff1) as List<Car>;


            //close file
            f.Close();
            
        }
    }
}
