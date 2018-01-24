using System;
using System.Collections.Generic;
using StringTable;
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        var garage = new[]
        {
            new {Name = "Mary", Manufacturer = "Aston Martin", Type = "DB7", Year = 1999},
            new {Name = "Madeline", Manufacturer = "Cadilac", Type = "Eldorado", Year = 1959},
            new {Name = "Stephanie", Manufacturer = "Chevrolet", Type = "Bel Air", Year = 1957},
            new {Name = "Stacy", Manufacturer = "Chevrolet", Type = "Corvette Stingray", Year = 1957},
            new {Name = "Kate", Manufacturer = "DeTomaso", Type = "Pantera", Year = 1971}
        };

        Debug.Log(garage.ToMardownTableString());

        var typedGarage = new List<Car>
        {
            new Car
            {
                Name = "Mary",
                Manufacturer = "Aston Martin",
                Type = "DB 7",
                Year = 1999,
                HP = 335,
                Torque = 490,
                Width = 1830,
                Length = 4646
            }
        };

        typedGarage.ToMardownTableString();
        Debug.Log(typedGarage.ToMardownTableString());

        var stringTable = new StringTableBuilder();

        var builder = stringTable
            .WithHeader("Name", "Manufacture", "Type", "Year")
            .WithRow("Mary", "Aston Martin", "DB7", 1999)
            .WithRow("Madeline", "Cadilac", "Eldorado", 1959)
            .WithRow("Stephanie", "Chevrolet", "Bel Air", 1957)
            .WithRow("Stacy", "Chevrolet", "Corvette Stingray", 1957)
            .WithRow("Kate", "DeToamso", "Pantera", 1971);

        Debug.Log(builder.ToString());
    }

    public class Car
    {
        public string Name;
        public string Manufacturer;
        public string Type;
        public uint Year;
        public int HP;
        public float Width;
        public float Length;
        public float Weight;
        public float Torque;
        public Array colors;
    }
}