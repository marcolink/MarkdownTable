using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTable
{
    public class DebugLayoutStrategy : BaseLayoutStrategy
    {
        public override string Layout(int padding = 0)
        {
            var layoutStrategy = new DefaultStringTableLayoutStrategy();
            var measurement = new StringTableMeasurement();
            measurement.SetTitle(title).SetHeader(header).SetRows(rows);

            var output = new StringBuilder();
            var tableWidth = measurement.TableWidth(padding);
            var maxCols = measurement.MaxCols();

            var debugRow = measurement.SizeRow(padding);
            var calculatedWidth = debugRow.Sum() + debugRow.Length - 1 + 2;

            layoutStrategy.SetRows(
                new List<string[]> {measurement.SizeRow(padding).Select(v => v.ToString()).ToArray()});

            output.Append(layoutStrategy.Layout());
            output.AppendLine(string.Format("Count: {0}", rows.Count));
            output.AppendLine(string.Format("Padding: {0}", padding));
            output.AppendLine(string.Format("Table Width: {0}", tableWidth));
            output.AppendLine(string.Format("Columns Count: {0}", maxCols));
            output.AppendLine(string.Format("Valid table width: {0} == {1}", tableWidth, calculatedWidth));

            return output.ToString();
        }
    }
}