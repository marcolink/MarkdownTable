using System.Collections.Generic;

namespace StringTable
{
    public interface IStringTableLayoutStrategy : IStringTable
    {
        string Layout(int padding = 0);
    }
    
    public interface IStringTable
    {
        IStringTable SetTitle(string title);
        IStringTable SetHeader(params string[] header);
        IStringTable AddRow(params string[] labels);
        IStringTable SetRows(List<string[]> rows);
    }
}