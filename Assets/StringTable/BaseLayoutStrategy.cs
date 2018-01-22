using System;
using System.Collections.Generic;

namespace StringTable
{
    public abstract class BaseLayoutStrategy : IStringTableLayoutStrategy
    {
        protected string title;
        protected string[] header = { };
        protected List<string[]> rows = new List<string[]>();

        public enum Align
        {
            Left,
            Right,
        }

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

        public virtual string Layout(int padding = 0)
        {
            throw new System.NotImplementedException();
        }

        public IStringTable AddRow(params string[] labels)
        {
            rows.Add(labels);
            return this;
        }

        public int TableWidth(int padding = 0)
        {
            var result = 1;

            var colsCount = MaxColumns();

            for (var i = 0; i < colsCount; i++)
            {
                result += ColumnWidth(i, padding) + 1;
            }

            if (!string.IsNullOrEmpty(title) && title.Length + 2 > result)
            {
                result = title.Length + 2;
            }
            
            return result;
        }

        public int ColumnWidth(int index, int padding = 0)
        {
            var width = padding * 2;

            if (header != null && header.Length - 1 >= index)
            {
                width = header[index].Length + 2 * padding;
            }

            rows.ForEach(row =>
            {
                var colWidth = row[Math.Min(index, row.Length - 1)].Length + 2 * padding;
                width = Math.Max(width, colWidth);
            });
            
            return width;
        }
        
        public int[] SizeRow(int padding)
        {
            var row = new List<int>();
            var maxCols = MaxColumns();
            for (var i = 0; i < maxCols; i++)
            {
                row.Add(ColumnWidth(i, padding));
            }

            return row.ToArray();
        }

        public BaseLayoutStrategy.Align[] AlignmentRow()
        {
            var row = new List<BaseLayoutStrategy.Align>();
            var maxCols = MaxColumns();
            
            for (var i = 0; i < maxCols; i++)
            {
                var alignment = BaseLayoutStrategy.Align.Left;
                
                
                row.Add(alignment);
            }

            return row.ToArray();
        }
        
        public int MaxColumns()
        {
            var result = 0;
            if (header != null)
            {
                result = header.Length;
            }

            rows.ForEach(row => { result = Math.Max(row.Length, result); });
            return result;
        }

        protected string[] Column(int index)
        {
            var column = new List<string>();
            rows.ForEach(row => { column.Add(index < row.Length ? row[index] : null); });
            return column.ToArray();
        }
    }
}