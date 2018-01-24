using System;
using System.Collections.Generic;
using System.Linq;

namespace StringTable
{
    public partial class StringTableBuilder
    {
        private string[] header = { };
        private readonly List<string[]> rows = new List<string[]>();

        private enum Align
        {
            Left,
            Right,
            Center
        }

        public StringTableBuilder WithHeader(params string[] header)
        {
            this.header = header;
            return this;
        }

        public StringTableBuilder WithRow(params string[] row)
        {
            rows.Add(row);
            return this;
        }

        public StringTableBuilder Clear()
        {
            header = new string[] { };
            rows.Clear();
            return this;
        }

        private int ColumnWidth(int index)
        {
            var width = 1;

            if (header != null && index < header.Length)
            {
                width = header[index].Length;
            }

            return Column(index).Length == 0
                ? 1
                : Math.Max(width,
                    Column(index).Max(r => r != null ? r.Length : 0));
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