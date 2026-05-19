using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCore
{
    public class LinearAlg : IDriverFinder
    {
        public List<Driver> FindNearest(List<Driver> drivers, Order order, int count = 5)
        {
            var driversNdistance = new List<(Driver driver, double distance)>();
            foreach (var driver in drivers)
            {
                double distance = GetDistance.SquaredDistance(driver, order);
                driversNdistance.Add((driver, distance));
            }

            driversNdistance.Sort((a, b) => a.distance.CompareTo(b.distance));
            var res = new List<Driver>();
            for (int i = 0; i < count && i < driversNdistance.Count; i++)
            {
                res.Add(driversNdistance[i].driver);
            }
            return res;
        }
    }
}