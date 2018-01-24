using System.Linq;
using System.Text;
using UnityEngine;

namespace StringTable
{
    public partial class StringTableBuilder
    {
        private readonly char verticalChar;
        private readonly char horizontalChar;
        private readonly char outerBorderChar;
        private readonly int indent;
        private readonly int padding;
        private readonly int minColumnWidth;

        private readonly StringBuilder rowBuilder = new StringBuilder();

        public StringTableBuilder()
        {
            horizontalChar = '-';
            outerBorderChar = '+';
            verticalChar = '|';
            indent = 0;
            padding = 1;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            var maxCols = MaxColumns();

            if (header.Length > 0)
            {
                output.AppendLine(HorizontalLine());
                output.AppendLine(Row(header, maxCols));
            }

            output.AppendLine(HorizontalLine());

            rows.ForEach(row =>
            {
                output.AppendLine(Row(row, maxCols));
                output.AppendLine(HorizontalLine());
            });

            return output.ToString();
        }

        #region Creation

        private string HorizontalLine()
        {
            var content = SizeRow()
                .Select(col => Fill(col + 2 * padding, horizontalChar))
                .Aggregate((a, b) => a + Fill(1, horizontalChar) + b);
            return string.Format("+{0}+", content);
        }

        private string Row(string[] row, int maxCols, Align align = Align.Left)
        {
            rowBuilder.Length = 0;
            rowBuilder.Append(Fill(indent));
            rowBuilder.Append(outerBorderChar);

            for (var i = 0; i < row.Length; i++)
            {
                var maxColWidth = ColumnWidth(i);
                var format = "{0,-" + maxColWidth + "}";


                rowBuilder.Append(Fill(padding));
                rowBuilder.Append(string.Format(format, row[i]));
                rowBuilder.Append(Fill(padding));
                rowBuilder.Append(i == maxCols - 1 ? outerBorderChar : verticalChar);
            }

            var j = row.Length - 1;
            while (j++ < maxCols - 1)
            {
                var maxColWidth = ColumnWidth(j);
                rowBuilder.Append(Fill(maxColWidth + 2 * padding));
                rowBuilder.Append(j == maxCols - 1 ? outerBorderChar : verticalChar);
            }

            return rowBuilder.ToString();
        }

        #endregion
    }
}