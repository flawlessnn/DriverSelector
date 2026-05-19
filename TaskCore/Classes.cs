using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCore
{
    public static class GetDistance
    {
        public static double SquaredDistance(Driver driver, Order order)
        {
            double dx = driver.X - order.X;
            double dy = driver.Y - order.Y;
            return dx * dx + dy * dy;
        }
        public static double Distance(Driver driver, Order order)
        {
            return Math.Sqrt(SquaredDistance(driver, order));
        }
    }
    public class Driver
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Driver(int id, int x, int y) { Id = id; X = x; Y = y; }
    }
    public class Order
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Order(int x, int y) { X = x; Y = y; }
    }
}
