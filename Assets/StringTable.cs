using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Tests.Performance
{
    public class StringTable
    {
        private string[] header;
        private readonly List<string[]> rows = new List<string[]>();
        private string title;

        public StringTable Title(string title)
        {
            this.title = title;
            return this;
        }

        public StringTable Header(params string[] labels)
        {
            header = labels;
            return this;
        }

        public StringTable Row(params string[] labels)
        {
            rows.Add(labels);
            return this;
        }

        public string Print(IStringTableLayoutStrategy layoutStrategy = null)
        {
            if (layoutStrategy == null)
            {
                layoutStrategy = new DefaultStringTableStategy();
            }

            layoutStrategy.SetTitle(title);
            layoutStrategy.SetHeader(header);
            layoutStrategy.SetRows(rows);

            return layoutStrategy.Layout();
        }
    }

    public interface IStringTableLayoutStrategy
    {
        void SetTitle(string title);
        void SetHeader(string[] header);
        void SetRows(List<string[]> rows);
        string Layout(int padding = 0);
    }

    public class DefaultStringTableStategy : IStringTableLayoutStrategy
    {
        private string title;
        private string[] header;
        private List<string[]> rows = new List<string[]>();

        private char verticalChar;
        private char horizontalChar;
        private char outerBorderChar;

        private readonly StringBuilder rowBuilder = new StringBuilder();

        private enum Align
        {
            Left,
            Right,
            Center
        }

        public DefaultStringTableStategy()
        {
            outerBorderChar = '|';
            verticalChar = ',';
            horizontalChar = '-';
        }

        #region Interface

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetHeader(string[] header)
        {
            this.header = header;
        }

        public void SetRows(List<string[]> rows)
        {
            this.rows = rows;
        }

        public string Layout(int padding = 2)
        {
            //Todo validate max col size;

            var output = new StringBuilder();
            var tableWidth = TableWidth(padding);
            var maxCols = MaxCols();

            output.AppendLine(HorizontalLine(tableWidth));
            output.AppendLine(Row(header, maxCols, tableWidth, padding, Align.Center));
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
                var maxColWidth = MaxColumnWidth(i, padding);
                var space = Math.Max(maxColWidth - row[i].Length, 0);
                var leftSpace = align == Align.Left ? padding :
                    align == Align.Center ? space / 2 : space;
                var rightSpace = align == Align.Left ? space :
                    align == Align.Center ? space : padding;

                rowBuilder.Append(string.Format("{1}{0}{2}", /*row[i]*/ maxColWidth, Padding(leftSpace),
                    Padding(rightSpace)));
                rowBuilder.Append(i == maxCols - 1 ? outerBorderChar : verticalChar);
            }

            var j = row.Length - 1;
            while (j++ < maxCols - 1)
            {
                var maxColWidth = MaxColumnWidth(j, padding);
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

        #region Measurement

        private int TableWidth(int padding = 0)
        {
            var width = padding * 2;
            if (!string.IsNullOrEmpty(title))
            {
                width = title.Length + padding * 2;
            }

            var headerWidth = RowWidth(header, padding);
            width = headerWidth > width ? headerWidth : width;

            var rowsWidth = RowsWidth(rows, padding);
            width = rowsWidth > width ? rowsWidth : width;

            return width;
        }

        private int MaxColumnWidth(int index, int padding = 0)
        {
            var width = padding * 2;

            if (header != null && header.Length - 1 >= index)
            {
                width = header[index].Length + 2 * padding;
            }

            rows.ForEach(row =>
            {
                var colWidth = row[Math.Min(index, row.Length - 1)].Length + 2 * padding;
                width = colWidth > width ? colWidth : width;
            });


            return width;
        }

        private static int RowWidth(string[] row, int padding = 0)
        {
            var result = padding * 2;
            if (row != null && row.Length > 0)
            {
                result = string.Join("", row).Length + row.Length * 2 * padding;
            }

            return result;
        }

        private static int RowsWidth(List<string[]> rows, int padding)
        {
            var result = padding * 2;
            if (rows != null && rows.Count > 0)
            {
                rows.ForEach(row =>
                {
                    var rowWidth = RowWidth(row, padding);
                    result = rowWidth > result ? rowWidth : result;
                });
            }

            return result;
        }

        private int MaxCols()
        {
            var result = 0;
            if (header != null)
            {
                result = header.Length;
            }

            rows.ForEach(row =>
            {
                if (row.Length > result)
                {
                    result = row.Length;
                }
            });
            return result;
        }

        #endregion
    }
}