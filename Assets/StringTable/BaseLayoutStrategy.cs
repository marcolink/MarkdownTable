using System.Collections.Generic;

namespace StringTable
{
    public abstract class BaseLayoutStrategy : IStringTableLayoutStrategy
    {
        protected string title;
        protected string[] header = { };
        protected List<string[]> rows = new List<string[]>();

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
    }
}