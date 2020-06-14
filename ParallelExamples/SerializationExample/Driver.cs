using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExamples
{
    [Serializable]
    public class Driver
    {
        private int id;
        private string nameDriver;
        private string familyDriver;
        private EnumDriver licenseTypeDriver;
        private object lockObject;

        public int Id { get => id; set => id = value; }
        public string Name { get => nameDriver; set => nameDriver = value; }
        public string Family { get => familyDriver; set => familyDriver = value; }
        public EnumDriver LicenseType { get => licenseTypeDriver; set => licenseTypeDriver = value; }

        public Driver (int id, string nameDriver, string familyDriver, EnumDriver licenseType, object lockObject)
        {
            this.id = id;
            this.nameDriver = nameDriver;
            this.familyDriver = familyDriver;
            this.licenseTypeDriver = licenseType;
            this.lockObject = lockObject;
        }

        public void PrintDriver()
        {
            lock (this.lockObject)
            {
                Console.WriteLine($"id = {this.id} Name = {this.nameDriver} Family = {this.familyDriver} LicenseType = {this.LicenseType}");

            }

        }
    }
}
