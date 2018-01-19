using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StringTable
{
    public class DefaultStringTableLayoutStrategy : IStringTableLayoutStrategy
    {
        private string title;
        private string[] header = { };
        private List<string[]> rows = new List<string[]>();

        private readonly char verticalChar;
        private readonly char horizontalChar;
        private readonly char outerBorderChar;
        private readonly string leftMargin;

        private readonly StringBuilder rowBuilder = new StringBuilder();
        private readonly StringTableMeasurement measurement = new StringTableMeasurement();

        private bool debug;

        private enum Align
        {
            Left,
            Right,
        }

        public DefaultStringTableLayoutStrategy(bool debug = false)
        {
            //Todo: create config object and setter
            outerBorderChar = '|';
            verticalChar = '|';
            leftMargin = " ";
            this.debug = debug;
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

        public string Layout(int padding = 0)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            measurement.SetTitle(title).SetHeader(header).SetRows(rows);

            var output = new StringBuilder();
            var tableWidth = measurement.TableWidth(padding);
            var maxCols = measurement.MaxCols();

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
            output.AppendLine(leftMargin);
            output.AppendLine(string.Format("{1}Count: {0}", rows.Count, leftMargin));

            stopWatch.Stop();

            if (debug)
            {
                var debugRow = measurement.SizeRow(padding);
                var calculatedWidth = debugRow.Sum() + debugRow.Length - 1 + 2;

                output.AppendLine(leftMargin);
                output.AppendLine(string.Format("{0}Sizing:", leftMargin));
                output.AppendLine(HorizontalLine(tableWidth));
                output.AppendLine(Row(debugRow.Select(v => v.ToString()).ToArray(), maxCols, tableWidth, padding));
                output.AppendLine(HorizontalLine(tableWidth));
                output.AppendLine(string.Format("{1}Time(ms): {0}", stopWatch.ElapsedMilliseconds, leftMargin));
                output.AppendLine(string.Format("{1}Padding: {0}", padding, leftMargin));
                output.AppendLine(string.Format("{1}Table Width: {0}", tableWidth, leftMargin));
                output.AppendLine(string.Format("{1}Columns Count: {0}", maxCols, leftMargin));
                output.AppendLine(string.Format("{1}Valid table width: {0} == {2}", tableWidth, leftMargin,
                    calculatedWidth));
            }

            return output.ToString();
        }

        #endregion

        #region Creation

        private string HorizontalLine(int tableWidth, char spaceChar = '-')
        {
            return string.Format("{0}{1}", leftMargin, new string(spaceChar, tableWidth));
        }

        private string TitleRow(int tableWidth)
        {
            var format = leftMargin + outerBorderChar + "{0}" + outerBorderChar;
            if (tableWidth > title.Length)
            {
                var space = tableWidth - title.Length - 1;
                var leftSpace = space / 2;
                var rightSpace = space - leftSpace;

                Console.WriteLine("table:{0}, title:{1}, space:{2}, left:{3}, right:{4}", tableWidth, title.Length, space, leftSpace, rightSpace);
                
                format = string.Format(format, Padding(leftSpace-1, '*') + "{0}" + Padding(rightSpace, '*'));
            }

            return string.Format(format, title);
        }

        private string Row(string[] row, int maxCols, int tableWidth, int padding = 0, Align align = Align.Left)
        {
            rowBuilder.Length = 0;
            rowBuilder.Append(leftMargin);
            rowBuilder.Append(outerBorderChar);

            for (var i = 0; i < row.Length; i++)
            {
                var maxColWidth = measurement.MaxColumnWidth(i);
                var format = "{0,-" + maxColWidth + "}";

                rowBuilder.Append(Padding(padding));
                rowBuilder.Append(string.Format(format, row[i]));
                rowBuilder.Append(Padding(padding));
                rowBuilder.Append(i == maxCols - 1 ? outerBorderChar : verticalChar);
            }

            var j = row.Length - 1;
            while (j++ < maxCols - 1)
            {
                var maxColWidth = measurement.MaxColumnWidth(j, padding);
                rowBuilder.Append(Padding(maxColWidth));
                rowBuilder.Append(j == maxCols - 1 ? outerBorderChar : verticalChar);
                j++;
            }

            return rowBuilder.ToString();
        }

        private string Padding(int size, char paddingChar = ' ')
        {
            return new string(paddingChar, size);
        }

        #endregion
    }
}
