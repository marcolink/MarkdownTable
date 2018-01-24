using StringTable;
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        var stringTable = new StringTableBuilder();

        var result = stringTable
            .SetTitle("Garage")
            .SetHeader("Name", "Manufacture", "Type", "Year")
            .AddRow("Mary", "Aston Martin", "DB7", "1999")
            .AddRow("Madeline", "Cadilac", "Eldorado", "1959")
            .AddRow("Stephanie", "Chevrolet", "Bel Air", "1957")
            .AddRow("Stacy", "Chevrolet", "Corvette Stingray", "1957")
            .AddRow("Kate", "DeToamso", "Pantera", "1971")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .SetTitle("Example Table")
            .SetHeader("11+padding*2", "Column Title", "Third", "Fourth")
            .AddRow("", "012345689", "[1,2,3,4,5]", "4", "abc")
            .AddRow("1", "012345689")
            .SetPadding(1)
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .SetTitle("Test Titles")
            .SetHeader("11+padding*2", "Second", "Third", "Fourth")
            .AddRow("1", "2234433242423", "3", "4", "dsfds")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Reset()
            .SetTitle("Test Titles")
            .SetHeader("11+padding*2", "Second", "Third", "Fourth")
            .AddRow("1", "23423423423", "334", "4")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Reset()
            .SetTitle("Test Titles")
            .SetHeader("Test Titles")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Reset()
            .SetTitle("Test Titles+")
            .SetHeader("Test Titles")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Reset()
            .SetTitle("Test Titles")
            .SetHeader("Test Titles+")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Reset()
            .SetTitle("One Column Example")
            .SetHeader("1.")
            .AddRow("data")
            .ToString();

        result += stringTable.ToDebugString();

        result += stringTable
            .Reset()
            .SetTitle("One Column Exmple")
            .AddRow("data")
            .ToString();

        result += stringTable.ToDebugString();

        Debug.Log(result);
    }
}