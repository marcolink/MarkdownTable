using System;
using System.Text;

namespace StringTable
{
    public class DefaultStringTableLayoutStrategy : BaseLayoutStrategy
    {
        private readonly char verticalChar;
        private readonly char horizontalChar;
        private readonly char outerBorderChar;
        private readonly string leftMargin;

        private readonly StringBuilder rowBuilder = new StringBuilder();

        public DefaultStringTableLayoutStrategy(bool debug = false)
        {
            //Todo: create config object and setter
            outerBorderChar = '|';
            verticalChar = '|';
            leftMargin = " ";
        }

        public override string Layout(int padding = 0)
        {

            var output = new StringBuilder();
            var tableWidth = TableWidth(padding);
            var maxCols = MaxColumns();

            if (!string.IsNullOrEmpty(title))
            {
                output.AppendLine(leftMargin);
                output.AppendLine(HorizontalLine(tableWidth));
                output.AppendLine(TitleRow(tableWidth));
            }

            if (header.Length > 0)
            {
                output.AppendLine(HorizontalLine(tableWidth));
                output.AppendLine(Row(header, maxCols, tableWidth, padding));
            }

            output.AppendLine(HorizontalLine(tableWidth));

            rows.ForEach(row =>
            {
                output.AppendLine(Row(row, maxCols, tableWidth, padding));
                output.AppendLine(HorizontalLine(tableWidth));
            });

            return output.ToString();
        }

        #region Creation

        private string HorizontalLine(int tableWidth, char spaceChar = '-')
        {
            return string.Format("{0}{1}", leftMargin, new string(spaceChar, tableWidth));
        }

        private string TitleRow(int tableWidth)
        {
            var format = leftMargin + outerBorderChar + "{0}" + outerBorderChar;
            if (string.IsNullOrEmpty(title) || tableWidth <= title.Length + 3)
            {
                return string.Format(format, title);
            }

            var space = tableWidth - title.Length - 1;
            var leftSpace = space / 2;
            var rightSpace = space - leftSpace;

            format = string.Format(format,
                Fill(leftSpace - 2, '*') + Fill(1) + "{0}" + Fill(1) + Fill(rightSpace - 1, '*'));

            return string.Format(format, title);
        }

        private string Row(string[] row, int maxCols, int tableWidth, int padding = 0, Align align = Align.Left)
        {
            //Todo: respect tableWidth issue:#2

            rowBuilder.Length = 0;
            rowBuilder.Append(leftMargin);
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
                var maxColWidth = ColumnWidth(j, padding);
                rowBuilder.Append(Fill(maxColWidth));
                rowBuilder.Append(j == maxCols - 1 ? outerBorderChar : verticalChar);
                j++;
            }

            return rowBuilder.ToString();
        }
        
        private static string Fill(int size, char fillChar = ' ')
        {
            return new string(fillChar, Math.Max(size, 0));
        }

        #endregion
    }
}