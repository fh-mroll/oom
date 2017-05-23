using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2
{
    [TestFixture]
    public class Tests
    {
        [Test]

        public void SimpleTest()
        {
            Assert.IsTrue(1 == 1);
        }

        [Test]
        public void createTable()
        {
           var table = new Furnishings.Table(12.5, 25.32, 50, "SimpleTable", 26.923);
           Assert.IsNotNull(table);
        }

        [Test]
     
        public void Table_test_negative_price()
        {
            
        var table = new Furnishings.Table(12.5, 25.32, 50, "SimpleTable", 26.923);
        double price = table.Price;

            try
            {
                table.Price = -10;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(1 == 1);
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Table_test_positive_price()
        {
            var table = new Furnishings.Table(12.5, 25.32, 50, "SimpleTable", 26.923);
            table.Price = 100;

            if (table.Price == 100) Assert.Pass();

            Assert.Fail();
        }

        [Test]
        public void createChair()
        {
            var chair = new Furnishings.Chair(true, true, "steel", "DxRacerSpace", 1049.34);
            Assert.IsNotNull(chair);
        }

        [Test]
        public void Chair_test_boolean()
        {
            var chair = new Furnishings.Chair(true, true, "steel", "DxRacerSpace", 1049.34);

            Assert.IsTrue((chair.Mobile == true) && (chair.Rest == true));
       }

        [Test]
        public void Chair_test_cover()
        {
            var chair = new Furnishings.Chair(true, true, "steel", "DxRacerSpace", 1049.34);

            Assert.IsTrue(chair.Cover == "steel");
        }
        [Test]
        public void Chair_test_decimalPrice()
        {
            var chair = new Furnishings.Chair(true, true, "steel", "DxRacerSpace", 1049.34);

            chair.Price = 99.999994;

            Assert.IsTrue(chair.Price == Math.Round(chair.Price,2));
        }
    }
}
