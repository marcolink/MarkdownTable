using NUnit.Framework;

namespace StringTable
{
    public class DefaultStringTableLayoutStrategyTest
    {
        private DefaultStringTableLayoutStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new DefaultStringTableLayoutStrategy();
        }
    }
}
