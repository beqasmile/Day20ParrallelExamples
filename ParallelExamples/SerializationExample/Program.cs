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

            Car x = new Car(" car " , "car 1", EnumCarType.Bus, 100);
            b.Serialize(f, x);


            //close file
            f.Close();



            Car a = null;
            //open existing file
            FileStream ff1 = File.OpenRead("car.ser");
            //create BinaryFormatter that can Deserialize
            BinaryFormatter b1 = new BinaryFormatter();
            //Deserialize and casting from object to serialSAmp
            a = (Car)b.Deserialize(ff1);
            //close file
            f.Close();
            
        }
    }
}
