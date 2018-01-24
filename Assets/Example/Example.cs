using StringTable;
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        var data = new[]
        {
            new {Name = "Mary", Manufacturer = "Aston Martin", Type = "DB7", Year = 1999},
            new {Name = "Madeline", Manufacturer = "Cadilac", Type = "Eldorado", Year = 1959},
            new {Name = "Stephanie", Manufacturer = "Checvrolet", Type = "Bel Air", Year = 1957},
            new {Name = "Stacy", Manufacturer = "Checvrolet", Type = "Corvette Stingray", Year = 1957},
            new {Name = "Kate", Manufacturer = "DeTomaso", Type = "Pantera", Year = 1971}
        };

        var stringTable = new StringTableBuilder();

        var builder = stringTable
            .WithHeader("Name", "Manufacture", "Type", "Year")
            .WithRow("Mary", "Aston Martin", "DB7", "1999")
            .WithRow("Madeline", "Cadilac", "Eldorado", "1959")
            .WithRow("Stephanie", "Chevrolet", "Bel Air", "1957")
            .WithRow("Stacy", "Chevrolet", "Corvette Stingray", "1957")
            .WithRow("Kate", "DeToamso", "Pantera", "1971");

        Debug.Log(builder.ToString());
    }
}