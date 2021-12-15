using System;

namespace CompositeHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the composite part door
            CompositeHousePart door = new CompositeHousePart("door", 25);
            //Add knob to the door
            door.AddHousePart(new SimpleHousePart("knob", 5));
            //Create house 
            CompositeHousePart house = new CompositeHousePart("House", 70);
            //Add two window
            house.AddHousePart(new SimpleHousePart("right window", 15));
            house.AddHousePart(new SimpleHousePart("left window", 15));
            //Then add door to house
            house.AddHousePart(door);
            //Print result
            Console.WriteLine(house.CalculateSize());
        }
    }
}
