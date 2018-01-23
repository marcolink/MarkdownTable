using System;
using System.Collections.Generic;

namespace StringTable
{
    public partial class StringTableBuilder
    {
        private string title;
        private string[] header = { };
        private List<string[]> rows = new List<string[]>();
        private int padding;

        private enum Align
        {
            Left,
            Right,
        }

        public StringTableBuilder SetTitle(string title)
        {
            this.title = title;
            return this;
        }

        public StringTableBuilder SetHeader(params string[] header)
        {
            this.header = header;
            return this;
        }

        public StringTableBuilder SetRows(List<string[]> rows)
        {
            this.rows = rows;
            return this;
        }

        public StringTableBuilder SetPadding(int padding = 0)
        {
            this.padding = padding;
            return this;
        }

        public StringTableBuilder AddRow(params string[] labels)
        {
            rows.Add(labels);
            return this;
        }
        
        public StringTableBuilder Reset()
        {
            title = string.Empty;
            header = new string[] { };
            rows.Clear();
            return this;
        }

        private int TableWidth()
        {
            int result = 1;

            var colsCount = MaxColumns();

            for (var i = 0; i < colsCount; i++)
            {
                result += ColumnWidth(i) + 1;
            }

            if (!string.IsNullOrEmpty(title) && title.Length + 2 > result)
            {
                result = title.Length + 2;
            }

            return result;
        }

        private int ColumnWidth(int index)
        {
            var width = padding * 2;

            if (header != null && header.Length - 1 >= index)
            {
                width =  (header[index].Length + 2 * padding);
            }

            rows.ForEach(row =>
            {
                var colWidth = row[Math.Min(index, row.Length - 1)].Length + 2 * padding;
                width = Math.Max(width, colWidth);
            });

            return width;
        }

        private int[] SizeRow()
        {
            var row = new List<int>();
            var maxCols = MaxColumns();
            for (var i = 0; i < maxCols; i++)
            {
                row.Add(ColumnWidth(i));
            }

            return row.ToArray();
        }

        private Align[] AlignmentRow()
        {
            var row = new List<Align>();
            var maxCols = MaxColumns();

            for (var i = 0; i < maxCols; i++)
            {
                var alignment = Align.Left;
                row.Add(alignment);
            }

            return row.ToArray();
        }

        private int MaxColumns()
        {
            var result = 0;
            if (header != null)
            {
                result = header.Length;
            }

            rows.ForEach(row => { result = Math.Max(row.Length, result); });
            return result;
        }

        private string[] Column(int index)
        {
            var column = new List<string>();
            rows.ForEach(row => { column.Add(index < row.Length ? row[index] : null); });
            return column.ToArray();
        }
        
        private static string Fill(int size, char fillChar = ' ')
        {
            return new string(fillChar, Math.Max(size, 0));
        }
    }
}