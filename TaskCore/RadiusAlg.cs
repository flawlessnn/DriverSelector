using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCore
{
    public class RadiusAlg : IDriverFinder
    {
        public List<Driver> FindNearest(List<Driver> drivers, Order order, int count = 5)
        {
            if (drivers.Count == 0)
            {
                return new List<Driver>();
            }

            var r = 1;

            while (true)
            {
                var founded = new List<Driver>();

                foreach (var driver in drivers)
                {
                    var dx = Math.Abs(driver.X - order.X);
                    var dy = Math.Abs(driver.Y - order.Y);
                    var manhattanDist = dx + dy;

                    if (manhattanDist <= r)
                    {
                        founded.Add(driver);
                    }

                }

                if (founded.Count >= count)
                {
                    founded.Sort((a, b) => DistanceHelper.SquaredDistance(a, order).CompareTo(DistanceHelper.SquaredDistance(b, order)));
                    var res = new List<Driver>();

                    for (int i = 0; i < count; i++) 
                    { 
                        res.Add(founded[i]); 
                    }

                    return res;
                }

                r++;

                if (r > 20000)
                {
                    founded.Sort((a, b) => DistanceHelper.SquaredDistance(a, order).CompareTo(DistanceHelper.SquaredDistance(b, order)));

                    return founded;
                }
            }
        }
    }
}
