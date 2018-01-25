# MarkdownTable
A Simple Markdown table builder for Unity (works also on normal c# projects).

## Usage

### Direct use of *MarkdownTableBuilder*

```csharp
var builder = new MarkdownTable.MarkdownTableBuilder()
 	.WithHeader("Name", "Manufacture", "Type", "Year")
	.WithRow("Mary", "Aston Martin", "DB7", "1999")
	.WithRow("Madeline", "Cadilac", "Eldorado", "1959")
	.WithRow("Stephanie", "Chevrolet", "Bel Air", "1957")
	.WithRow("Stacy", "Chevrolet", "Corvette Stingray", "1957")
	.WithRow("Kate", "DeToamso", "Pantera", "1971");

Debug.Log(builder.ToString());
```

### *IEnumerable<T>* Extension

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

### Log Output 

```
Name      | Manufacturer | Type              | Year  
----------|--------------|-------------------|----- 
Mary      | Aston Martin | DB7               | 1999  
Madeline  | Cadilac      | Eldorado          | 1959  
Stephanie | Chevrolet    | Bel Air           | 1957  
Stacy     | Chevrolet    | Corvette Stingray | 1957  
Kate      | DeToamso     | Pantera           | 1971  
```

The output can be used as normal markup: 
 
Name      | Manufacturer | Type              | Year  
----------|--------------|-------------------|----- 
Mary      | Aston Martin | DB7               | 1999  
Madeline  | Cadilac      | Eldorado          | 1959  
Stephanie | Chevrolet    | Bel Air           | 1957  
Stacy     | Chevrolet    | Corvette Stingray | 1957  
Kate      | DeToamso     | Pantera           | 1971  

### Supported *Property/Field* Types:

* TypeCode.String
* TypeCode.Boolean
* TypeCode.Decimal
* TypeCode.Double
* TypeCode.Single
* TypeCode.Byte
* TypeCode.Int16
* TypeCode.Int32
* TypeCode.Int64
* TypeCode.SByte
* TypeCode.UInt16
* TypeCode.UInt32
* TypeCode.UInt64
