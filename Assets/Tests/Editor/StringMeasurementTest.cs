using NUnit.Framework;

namespace StringTable
{
    public class StringMeasurementTest
    {
        private StringTableMeasurement measurement;

        [SetUp]
        public void SetUp()
        {
            measurement = new StringTableMeasurement();
        }

        [Test]
        public void Measure_TableWidth_WithTitleOnly()
        {
            measurement.SetTitle("hello world");
            Assert.AreEqual(13, measurement.TableWidth());
            Assert.AreEqual(17, measurement.TableWidth(2));
        }
        
        [Test]
        public void Measure_TableWidth_WithTitleAndHeader()
        {
            measurement.SetTitle("hello world");
            measurement.SetHeader("one", "two", "three", "four");
            Assert.AreEqual(17, measurement.TableWidth());
            Assert.AreEqual(33, measurement.TableWidth(2));
        }
        
        [Test]
        public void Measure_TableWidth_WithTitleHeaderAndRow()
        {
            measurement.SetTitle("hello world");
            measurement.SetHeader("one", "two", "three", "four");
            measurement.AddRow("one", "two", "three", "four", "six");
            Assert.AreEqual(20, measurement.TableWidth());
            Assert.AreEqual(30, measurement.TableWidth(1));
        }
        
        [Test]
        public void Measure_MaxColumnWidth_WidthHeaderAndRows()
        {
            measurement.SetHeader("one", "two face", "three", "four");
            measurement.AddRow("one and one", "two", "three", "four", "six");
            measurement.AddRow("", "two", "three", "four on the floor", "six");
            Assert.AreEqual(11, measurement.MaxColumnWidth(0));
            Assert.AreEqual(8, measurement.MaxColumnWidth(1));
            Assert.AreEqual(12, measurement.MaxColumnWidth(1, 2));
            Assert.AreEqual(17, measurement.MaxColumnWidth(3));
        }
        
        [Test]
        public void Measure_MaxColumnWidth_WidthHeaderAndRows2()
        {
            measurement.SetHeader("onehundreddollar", "two face", "three", "four");
            measurement.AddRow("one and one", "two", "three", "four", "six");
            measurement.AddRow("", "two", "three", "four on the floor", "six");
            Assert.AreEqual(16, measurement.MaxColumnWidth(0));
            Assert.AreEqual(8, measurement.MaxColumnWidth(1));
            Assert.AreEqual(12, measurement.MaxColumnWidth(1, 2));
            Assert.AreEqual(17, measurement.MaxColumnWidth(3));
        }

        [Test]
        public void Measure_MaxColumns()
        {
            measurement.SetHeader("one", "two face", "three", "four");
            measurement.AddRow("one and one", "two", "three", "four", "five", "six");
            measurement.AddRow("one and one", "two");
            measurement.AddRow("one and one", "two", "three", "four", "five", "six", "seven");
            Assert.AreEqual(7, measurement.MaxCols());
        }
    }
}