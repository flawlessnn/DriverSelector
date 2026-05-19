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
            if (drivers.Count == 0) return new List<Driver>();
            int r = 1;
            while (true)
            {
                var founded = new List<Driver>();
                foreach (var driver in drivers)
                {
                    int dx = Math.Abs(driver.X - order.X);
                    int dy = Math.Abs(driver.Y - order.Y);
                    int manhattanDist = dx + dy;
                    if (manhattanDist <= r) founded.Add(driver);
                }
                if (founded.Count >= count)
                {
                    founded.Sort((a, b) => GetDistance.SquaredDistance(a, order).CompareTo(GetDistance.SquaredDistance(b, order)));
                    var res = new List<Driver>();
                    for (int i = 0; i < count; i++) { res.Add(founded[i]); }
                    return res;
                }
                r++;
                if (r > 20000)
                {
                    founded.Sort((a, b) => GetDistance.SquaredDistance(a, order).CompareTo(GetDistance.SquaredDistance(b, order)));
                    return founded;
                }
            }
        }
    }
}
