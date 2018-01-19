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
            var width = padding * 2;
            if (!string.IsNullOrEmpty(title))
            {
                width = title.Length + padding * 2;
            }

            var headerWidth = RowWidth(header, padding);
            width = headerWidth > width ? headerWidth : width;

            var rowsWidth = RowsWidth(rows, padding);
            width = rowsWidth > width ? rowsWidth : width;

            //Todo: calcualte on borderCharWidth
            return width + 2;
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