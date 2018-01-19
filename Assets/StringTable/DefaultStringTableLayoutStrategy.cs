using System;
using System.Collections.Generic;
using System.Text;

namespace StringTable
{
    public class DefaultStringTableLayoutStrategy : IStringTableLayoutStrategy
    {
        private string title;
        private string[] header;
        private List<string[]> rows = new List<string[]>();

        private char verticalChar;
        private char horizontalChar;
        private char outerBorderChar;

        private readonly StringBuilder rowBuilder = new StringBuilder();
        private StringTableMeasurement measurement = new StringTableMeasurement();

        private enum Align
        {
            Left,
            Right,
        }

        public DefaultStringTableLayoutStrategy()
        {
            outerBorderChar = '|';
            verticalChar = ',';
            horizontalChar = '-';
        }

        #region Interface

        public IStringTable SetTitle(string title)
        {
            this.title = title;
            return this;
        }


        public IStringTable SetHeader(params string[] header)
        {
            this.header = header;
            return this;
        }

        public IStringTable SetRows(List<string[]> rows)
        {
            this.rows = rows;
            return this;
        }

        public IStringTable AddRow(params string[] labels)
        {
            rows.Add(labels);
            return this;
        }

        public string Layout(int padding = 2)
        {
            //Todo validate max col size;

            measurement.SetTitle(title).SetHeader(header).SetRows(rows);

            var output = new StringBuilder();
            var tableWidth = measurement.TableWidth(padding);
            var maxCols = measurement.MaxCols();

            output.AppendLine(HorizontalLine(tableWidth));
            output.AppendLine(Row(header, maxCols, tableWidth, padding));
            output.AppendLine(HorizontalLine(tableWidth));
            rows.ForEach(row =>
            {
                output.AppendLine(Row(row, maxCols, tableWidth, padding));
                output.AppendLine(HorizontalLine(tableWidth));
            });

            return output.ToString();
        }

        #endregion

        #region Creation

        private string HorizontalLine(int tableWidth)
        {
            return new string(horizontalChar, tableWidth);
        }

        private string Row(string[] row, int maxCols, int tableWidth, int padding = 0, Align align = Align.Left)
        {
            rowBuilder.Length = 0;
            rowBuilder.Append(outerBorderChar);

            for (var i = 0; i < row.Length; i++)
            {
                var maxColWidth = measurement.MaxColumnWidth(i, padding);
                var space = Math.Max(maxColWidth - row[i].Length, 0);
                var leftSpace = align == Align.Left ? padding : space;
                var rightSpace = align == Align.Left ? space : padding;

                rowBuilder.Append(string.Format("{1}{0}{2}", row[i], Padding(leftSpace), Padding(rightSpace)));
                rowBuilder.Append(i == maxCols - 1 ? outerBorderChar : verticalChar);
            }

            var j = row.Length - 1;
            while (j++ < maxCols - 1)
            {
                var maxColWidth = measurement.MaxColumnWidth(j, padding);
                rowBuilder.Append(string.Format("{0}{1}", Padding(maxColWidth),
                    j == maxCols - 1 ? outerBorderChar : verticalChar));
                j++;
            }

            return rowBuilder.ToString();
        }

        private string Padding(int size)
        {
            return new string(' ', size);
        }

        #endregion
    }
}