using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model {get; set;}
        public int Year { get; set; }
        public int Price { get; set; }

    }
    class Car : Vehicle
    {
        public carTypeEnum CarType;
    }
    class Lorrie : Vehicle
    {
        public int CarryLoad { get; set; }
    }
    class Motobike : Vehicle
    {
        bool TwinSpark { get; set; }
    }
    enum carTypeEnum
    {
        Sedan, Hatchback, Coupe, Convertible, Unknown
    }
}
