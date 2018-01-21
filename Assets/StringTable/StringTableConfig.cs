namespace StringTable
{
    public struct StringTableConfig
    {
        public enum Align
        {
            Left,
            Right
        }
        
        const char TOP_LEFT_JOINT = '┌';
        const char TOP_RIGHT_JOINT = '┐';
        const char BOTTOM_LEFT_JOINT = '└';
        const char BOTTOM_RIGHT_JOINT = '┘';
        const char TOP_JOINT = '┬';
        const char BOTTOM_JOINT = '┴';
        const char LEFT_JOINT = '├';
        const char JOINT = '┼';
        const char RIGHT_JOINT = '┤';
        const char HORIZONTAL_LINE = '─';
        const char PADDING = ' ';
        const char VERTICAL_LINE = '│';

    }
}
/*
const char TOP_LEFT_JOINT = '┌';
const char TOP_RIGHT_JOINT = '┐';
const char BOTTOM_LEFT_JOINT = '└';
const char BOTTOM_RIGHT_JOINT = '┘';
const char TOP_JOINT = '┬';
const char BOTTOM_JOINT = '┴';
const char LEFT_JOINT = '├';
const char JOINT = '┼';
const char RIGHT_JOINT = '┤';
const char HORIZONTAL_LINE = '─';
const char PADDING = ' ';
const char VERTICAL_LINE = '│';
*/