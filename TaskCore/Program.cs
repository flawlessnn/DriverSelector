using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TaskCore;

var random = new Random();
var mapSize = 1000;
var totalDrivers = 10000;
var drivers = new List<Driver>();

for (int i = 0; i < totalDrivers; i++)
{
    drivers.Add(new Driver(i, random.Next(mapSize), random.Next(mapSize)));
}

var order = new Order(mapSize / 2, mapSize / 2);

Console.WriteLine($"Карта размером - {mapSize}x{mapSize}, водителей {totalDrivers}");
Console.WriteLine($"Заказ по координатам - ({order.X}, {order.Y})");
Console.WriteLine();

Run("Линейный поиск", new LinearAlg());
Console.WriteLine();

Run("Приоритетный выбор", new PriorityAlg());
Console.WriteLine();

Run("Поиск по радиусу", new RadiusAlg());
Console.WriteLine();

void Run(string name, IDriverFinder alg)
{
    var timer = Stopwatch.StartNew();
    var res = alg.FindNearest(drivers, order, 5);

    timer.Stop();

    Console.WriteLine($"{name} -  {timer.Elapsed.TotalMilliseconds:F2} мс ");

    for (int i = 0; i<res.Count; i++)
    {
        var d = res[i];
        var dist = DistanceHelper.Distance(d, order);

        Console.WriteLine($"{i + 1}. Водитель {d.Id}, координаты - {d.X}x{d.Y}, расстояние {dist:F1}");
    }
}

