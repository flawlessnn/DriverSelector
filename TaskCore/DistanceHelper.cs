using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCore
{
    public static class DistanceHelper
    {
        public static double SquaredDistance(Driver driver, Order order)
        {
            var dx = driver.X - order.X;
            var dy = driver.Y - order.Y;

            return dx * dx + dy * dy;
        }
        public static double Distance(Driver driver, Order order)
        {
            return Math.Sqrt(SquaredDistance(driver, order));
        }   
    }
}
