# StringTableBuilder
A Simple StringBuilder for printing well formed tables.

## Example

### Direct use of *StringTableBuilder*

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

### IEnumerable<T> Extension with *object*

**Input**

```csharp
var garage = new[]
{
	new {Name = "Mary", Manufacturer = "Aston Martin", Type = "DB7", Year = 1999},
	new {Name = "Madeline", Manufacturer = "Cadilac", Type = "Eldorado", Year = 1959},
	new {Name = "Stephanie", Manufacturer = "Chevrolet", Type = "Bel Air", Year = 1957},
	new {Name = "Stacy", Manufacturer = "Chevrolet", Type = "Corvette Stingray", Year = 1957},
	new {Name = "Kate", Manufacturer = "DeTomaso", Type = "Pantera", Year = 1971}
};

Debug.Log(garage.ToMardownTableString());
```

### IEnumerable<T> Extension with custom type

```csharp

public class Car
{
	public string Name;
	public string Manufacturer;
	public string Type;
	public uint Year;
}

var typedGarage = new List<Car>
{
	new Car {Name = "Mary", Manufacturer = "Aston Martin", Type = "DB7", Year = 1999},
	new Car {Name = "Madeline", Manufacturer = "Cadilac", Type = "Eldorado", Year = 1959},
	new Car {Name = "Stephanie", Manufacturer = "Chevrolet", Type = "Bel Air", Year = 1957},
	new Car {Name = "Stacy", Manufacturer = "Chevrolet", Type = "Corvette Stingray", Year = 1957},
	new Car {Name = "Kate", Manufacturer = "DeTomaso", Type = "Pantera", Year = 1971}
}
 
Debug.Log(typedGarage.ToMardownTableString()); 
```

### Output 

```
Name      | Manufacturer | Type              | Year  
----------|--------------|-------------------|----- 
Mary      | Aston Martin | DB7               | 1999  
Madeline  | Cadilac      | Eldorado          | 1959  
Stephanie | Chevrolet    | Bel Air           | 1957  
Stacy     | Chevrolet    | Corvette Stingray | 1957  
Kate      | DeToamso     | Pantera           | 1971  
```
Name      | Manufacturer | Type              | Year  
----------|--------------|-------------------|----- 
Mary      | Aston Martin | DB7               | 1999  
Madeline  | Cadilac      | Eldorado          | 1959  
Stephanie | Chevrolet    | Bel Air           | 1957  
Stacy     | Chevrolet    | Corvette Stingray | 1957  
Kate      | DeToamso     | Pantera           | 1971  
