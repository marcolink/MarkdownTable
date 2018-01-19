using System;
using System.Collections.Generic;

namespace StringTable
{
    public class StringTableMeasurement : IStringTable
    {
        private string title;
        private string[] header;
        private List<string[]> rows = new List<string[]>();

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

        public int TableWidth(int padding = 0)
        {
            var result = 1;
            var colsCount = MaxCols();

            for (int i = 0; i < colsCount; i++)
            {
                result += MaxColumnWidth(i, padding) + 1;
            }
            
            return result;
        }

        public int MaxColumnWidth(int index, int padding = 0)
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
        
        public int[] SizeRow(int padding)
        {
            var debugRow = new List<int>();
            var maxCols = MaxCols();
            for (int i = 0; i < maxCols; i++)
            {
                debugRow.Add(MaxColumnWidth(i, padding));
            }

            return debugRow.ToArray();
        }

        public int MaxCols()
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
    }
}
