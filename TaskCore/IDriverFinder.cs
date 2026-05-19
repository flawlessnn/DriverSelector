using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCore
{
    public interface IDriverFinder
    {
        List<Driver> FindNearest(List<Driver> drivers, Order order, int count = 5);
    }
}
