using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using TaskCore;

namespace TaskBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Benchmarks
{
    private List<Driver> _drivers = null!;
    private Order _order = null!;
    [Params(1000, 10000, 100000)]
    public int DriverCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _drivers = new List<Driver>();
        for (int i = 1; i <= DriverCount; i++) _drivers.Add(new Driver(i, rnd.Next(1000), rnd.Next(1000)));
        _order = new Order(500, 500);
    }

    [Benchmark(Baseline = true, Description = "Линейный поиск")]
    public List<Driver> Linear() => new LinearAlg().FindNearest(_drivers, _order, 5);

    [Benchmark(Description = "Приоритетный выбор")]
    public List<Driver> Priority() => new PriorityAlg().FindNearest(_drivers, _order, 5);

    [Benchmark(Description = "Поиск по радиусу")]
    public List<Driver> Radius() => new RadiusAlg().FindNearest(_drivers, _order, 5);
}
