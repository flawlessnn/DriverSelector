using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskCore;

namespace TaskTests
{

    [TestFixture]
    public class SearchTests
    {
        private List<Driver> _drivers = null!;

        [SetUp]
        public void Setup()
        {
            _drivers = new List<Driver>
            {
                new Driver(1,  501, 500),
                new Driver(2,  500, 502),
                new Driver(3,  498, 499),
                new Driver(4,  503, 503),
                new Driver(5,  498, 504),
                new Driver(6,  498, 497),
                new Driver(7,  510, 490),
            };

        }

        [Test]
        public void LinearAlg_Returns5()
        {
            var result = new LinearAlg().FindNearest(_drivers, new Order(500, 500));
            Assert.That(result.Count, Is.EqualTo(5));
        }

        [Test]
        public void LinearAlg_Nearest1()
        {
            var result = new LinearAlg().FindNearest(_drivers, new Order(500, 500));
            Assert.That(result[0].Id, Is.EqualTo(1));
        }

        [Test]
        public void LinearAlg_NoDrivers()
        {
            var result = new LinearAlg().FindNearest(new List<Driver>(), new Order(500, 500));
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void PriorityAlg_Returns5()
        {
            var result = new PriorityAlg().FindNearest(_drivers, new Order(500, 500));
            Assert.That(result.Count, Is.EqualTo(5));
        }

        [Test]
        public void PriorityAlg_Nearest1()
        {
            var result = new PriorityAlg().FindNearest(_drivers, new Order(500, 500));
            Assert.That(result[0].Id, Is.EqualTo(1));
        }

        [Test]
        public void PriorityAlg_NoDrivers()
        {
            var result = new PriorityAlg().FindNearest(new List<Driver>(), new Order(500, 500));
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void RadiusAlg_Returns5()
        {
            var result = new RadiusAlg().FindNearest(_drivers, new Order(500, 500));
            Assert.That(result.Count, Is.EqualTo(5));
        }

        [Test]
        public void RadiusAlg_Nearest1()
        {
            var result = new RadiusAlg().FindNearest(_drivers, new Order(500, 500));
            Assert.That(result[0].Id, Is.EqualTo(1));
        }

        [Test]
        public void RadiusAlg_NoDrivers()
        {
            var result = new RadiusAlg().FindNearest(new List<Driver>(), new Order(500, 500));
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}