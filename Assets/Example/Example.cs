using StringTable;
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        
        var data = new[]
        {
            new { Year = 1991, Album = "Out of Time", Songs = 11, Rating = "* * * *" },
            new { Year = 1992, Album = "Automatic for the People", Songs = 12, Rating = "* * * * *" },
            new { Year = 1994, Album = "Monster", Songs = 12, Rating = "* * *" }
        };
        
        var stringTable = new StringTableBuilder();

        var result = stringTable
            .WithHeader("Name", "Manufacture", "Type", "Year")
            .WithRow("Mary", "Aston Martin", "DB7", "1999")
            .WithRow("Madeline", "Cadilac", "Eldorado", "1959")
            .WithRow("Stephanie", "Chevrolet", "Bel Air", "1957")
            .WithRow("Stacy", "Chevrolet", "Corvette Stingray", "1957")
            .WithRow("Kate", "DeToamso", "Pantera", "1971")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .WithHeader("11+padding*2", "Column Title", "Third", "Fourth")
            .WithRow("", "012345689", "[1,2,3,4,5]", "4", "abc")
            .WithRow("1", "012345689")
            .ToString();

        result += stringTable.ToDebugString();

        /*
        result += stringTable
            .WithHeader("11+padding*2", "Second", "Third", "Fourth")
            .WithRow("1", "2234433242423", "3", "4", "dsfds")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Clear()
            .WithHeader("11+padding*2", "Second", "Third", "Fourth")
            .WithRow("1", "23423423423", "334", "4")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Clear()
            .WithHeader("Test Titles")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Clear()
            .WithHeader("Test Titles")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Clear()
            .WithHeader("Test Titles+")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Clear()
            .WithHeader("1.")
            .WithRow("data")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Clear()
            .WithRow("data")
            .ToString();

        result += stringTable.ToDebugString();
        
        */

        Debug.Log(result);
    }
}