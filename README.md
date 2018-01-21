# StringTable
A Simple StringBuilder for printing well formed tables.

## Example
**Input**

```csharp
var stringTable = new StringTable.StringTableBuilder();
		
var result = stringTable
 	.Title("Garage")
	.Header("Name", "Manufacture", "Type", "Year")
	.Row("Mary", "Aston Martin", "DB7", "1999")
	.Row("Madeline", "Cadilac", "Eldorado", "1959")
	.Row("Stephanie", "Chevrolet", "Bel Air", "1957")
	.Row("Stacy", "Chevrolet", "Corvette Stingray", "1957")
	.Row("Kate", "DeToamso", "Pantera", "1971")
  .Print();

Debug.Log(result);
```

**Output** 

```
 -------------------------------------------------------
 |********************** Garage ***********************|
 -------------------------------------------------------
 | Name      | Manufacture  | Type              | Year |
 -------------------------------------------------------
 | Mary      | Aston Martin | DB7               | 1999 |
 -------------------------------------------------------
 | Madeline  | Cadilac      | Eldorado          | 1959 |
 -------------------------------------------------------
 | Stephanie | Chevrolet    | Bel Air           | 1957 |
 -------------------------------------------------------
 | Stacy     | Chevrolet    | Corvette Stingray | 1957 |
 -------------------------------------------------------
 | Kate      | DeToamso     | Pantera           | 1971 |
 -------------------------------------------------------
```
