using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCore
{
    public class PriorityAlg : IDriverFinder
    {
        public List<Driver> FindNearest(List<Driver> drivers, Order order, int count = 5)
        {
            var candidates = new List<(Driver driver, double distance)>();
            foreach (var driver in drivers)
            {
                double distance = GetDistance.SquaredDistance(driver, order);
                if (candidates.Count < count) { candidates.Add((driver, distance)); }
                else
                {
                    int index = 0;
                    for (int i = 1; i < candidates.Count; i++)
                    {
                        if (candidates[i].distance > candidates[index].distance)
                            index = i;
                    }
                    if (distance < candidates[index].distance)
                    {
                        candidates[index] = (driver, distance);
                    }
                }
            }
            candidates.Sort((a, b) => a.distance.CompareTo(b.distance));
            var res = new List<Driver>();
            foreach (var (driver, distance) in candidates) { res.Add(driver); }
            return res;
        }
    }
}
