using StringTable;
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        var stringTable = new StringTableBuilder();

        var result = stringTable
            .Title("Garage")
            .Header("Name", "Manufacture", "Type", "year")
            .Row("Mary", "Aston Martin", "DB7", "1999")
            .Row("Madeline", "Cadilac", "Eldorado", "1959")
            .Row("Stephanie", "Chevrolet", "Bel Air", "1957")
            .Row("Stacy", "Chevrolet", "Corvette Stingray", "1957")
            .Row("Kate", "DeToamso", "Pantera", "1971")
            .Print(null, true);
        
        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Title("Example Table")
            .Header("11+padding*2", "Column Title", "Third", "Fourth")
            .Row("", "012345689", "[1,2,3,4,5]", "4", "abc")
            .Row("1", "012345689")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Title("Test Titles")
            .Header("11+padding*2", "Second", "Third", "Fourth")
            .Row("1", "2234433242423", "3", "4", "dsfds")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Reset()
            .Title("Test Titles")
            .Header("11+padding*2", "Second", "Third", "Fourth")
            .Row("1", "23423423423", "334", "4")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Reset()
            .Title("Test Titles")
            .Header("Test Titles")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Reset()
            .Title("Test Titles+")
            .Header("Test Titles")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Reset()
            .Title("Test Titles")
            .Header("Test Titles+")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Reset()
            .Title("One Column Example")
            .Header("1.")
            .Row("data")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        result += stringTable
            .Reset()
            .Title("One Column Exmple")
            .Row("data")
            .Print(null, true);

        result += stringTable.Print(new DebugLayoutStrategy(), true);

        Debug.Log(result);
    }
}