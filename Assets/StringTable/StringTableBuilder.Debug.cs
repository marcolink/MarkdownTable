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

            output.AppendLine(Fill(SizeRow().Sum()));
            output.AppendLine(Row(SizeRow().Select(v => v.ToString()).ToArray(), MaxColumns()));
            output.AppendLine(string.Format("Count: {0}", rows.Count));
            output.AppendLine(string.Format("Columns Count: {0}", MaxColumns()));
            output.AppendLine(Fill(SizeRow().Sum()));

            return output.ToString();
        }
    }
}