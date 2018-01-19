using UnityEngine;

public class Example : MonoBehaviour {

	void Start () {
		
		var stringTable = new StringTable.StringTableBuilder();
		
		var result = stringTable
			.Title("Test Title")
			.Header("11+padding*2", "Second", "Third", "Fourth")
			.Row("1", "2234433242423", "3", "4", "dsfds")
			.Row("1", "23423423423", "334", "4")
			.Row("1", "2", "3", "4")
			.Row("1", "2", "3", "4")
			.Print(null, true);
		
		Debug.Log(result);
		
		result = stringTable
			.Reset()
			.Title("One Column Example")
			.Row("data")
			.Print(null, true);
		
		Debug.Log(result);
		
	}
}
