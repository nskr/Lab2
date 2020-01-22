using System;

namespace Labs2
{
    enum CarsType : byte
    {
        Sedan = 1,
        Minivan = 2,
        Coupe = 3,
        Truck = 4,
        Hatchback = 5
    }
    enum GarageQuality : byte
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    struct Garage
    {
        public CarsType body;
        public GarageQuality quality;
        public string carnumber;
        public string owner;
    }
    struct GarageWithConstruct
    {
        public CarsType body;
        public GarageQuality quality;
        public string carnumber;
        public string owner;
        public GarageWithConstruct(CarsType body, GarageQuality quality, string carnumber, string owner)
        {
            this.body = body;
            this.quality = quality;
            this.carnumber = carnumber;
            this.owner = owner;
        }
    }
    class TestStruct
    {
        public static void TestWithoutConstruct()
        {
            Garage garage;
            garage.body = CarsType.Coupe;
            garage.quality = GarageQuality.High;
            garage.carnumber = "A127ME";
            garage.owner = "John";
            Console.WriteLine("{0}\n{1}\n{2}\n{3}", garage.body,garage.quality,garage.carnumber,garage.owner);
        }
        public static void TestWithConstruct()
        {
            GarageWithConstruct garage = new GarageWithConstruct(CarsType.Coupe,GarageQuality.High,"A127ME","John");
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n", garage.body, garage.quality, garage.carnumber, garage.owner);
        }

    }
}
