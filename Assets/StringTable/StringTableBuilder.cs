using System.Collections.Generic;

namespace StringTable
{
    public class StringTableBuilder
    {
        private string[] header;
        private readonly List<string[]> rows = new List<string[]>();
        private string title;

        public StringTableBuilder Title(string title)
        {
            this.title = title;
            return this;
        }

        public StringTableBuilder Header(params string[] labels)
        {
            header = labels;
            return this;
        }

        public StringTableBuilder Row(params string[] labels)
        {
            rows.Add(labels);
            return this;
        }

        public StringTableBuilder Reset()
        {
            header = new string[]{};
            title = null;
            rows.Clear();
            return this;
        }

        public string Print(IStringTableLayoutStrategy layoutStrategy = null, bool debug = false)
        {
            if (layoutStrategy == null)
            {
                layoutStrategy = new DefaultStringTableLayoutStrategy(debug);
            }

            layoutStrategy
                .SetTitle(title)
                .SetHeader(header)
                .SetRows(rows);
                
            return layoutStrategy.Layout(1);
        }
    }
}
