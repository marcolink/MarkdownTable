using System.Collections.Generic;

namespace StringTable
{
    public interface IStringTableLayoutStrategy
    {
        void SetTitle(string title);
        void SetHeader(string[] header);
        void SetRows(List<string[]> rows);
        string Layout(int padding = 0);
    }
}