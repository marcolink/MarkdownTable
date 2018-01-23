using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTable
{
    public partial class StringTableBuilder
    {
        public string ToDebugString()
        {
            var output = new StringBuilder();
            var debugRow = SizeRow();
            var calculatedWidth = debugRow.Sum() + debugRow.Length - 1 + 2;

            //layoutStrategy.SetRows(new List<string[]> {SizeRow().Select(v => v.ToString()).ToArray()});
            //var row = Row({SizeRow().Select(v => v.ToString()).ToArray()}, MaxColumns(), TableWidth());
            //output.Append(row);
            
            output.AppendLine(string.Format("Count: {0}", rows.Count));
            output.AppendLine(string.Format("Padding: {0}", padding));
            output.AppendLine(string.Format("Table Width: {0}", TableWidth()));
            output.AppendLine(string.Format("Columns Count: {0}", MaxColumns()));
            output.AppendLine(string.Format("Valid table width: {0} == {1}", TableWidth(), calculatedWidth));

            return output.ToString();
        }
    }
}