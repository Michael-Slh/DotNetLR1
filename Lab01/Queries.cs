using Data;
using Model;

namespace Lab01
{
    public class Queries
    {
        private readonly Assets _data;

        public Queries(Assets data)
        {
            _data = data;
        }

        // query
        public IEnumerable<string> GetByFirstStopAndCount()
        {
            var queue = from route in _data.Routes
                        group route by route.FirstStop.Id into routeGroup
                        select new String
                        (
                            routeGroup.ElementAt(0).FirstStop.Name + " - " + routeGroup.Count()
                        );
            return queue;
        }

        public IOrderedEnumerable<string> GetThreeOrMoreBusses(int amount)
        {
            var queue = _data.Routes
                .Where(route => route.BusAmount >= amount)
                .SelectMany(route => route.Buses
                    .Select(bus => bus.Number))
                .OrderBy(num => num);
            return queue;
        }

        // query
        public IEnumerable<Company> GetTopRoutesCompanies()
        {
            var queue = (from companies in _data.Companies
                         where companies.Courses.Count == (from max in _data.Companies
                                                          select max.Courses.Count).Max()
                         select companies);
            return queue;
        }

        public IEnumerable<Bus> GetFirstAndLastBusses()
        {
            var queue = _data.Buses
                .Take(3)
                .Concat(_data.Buses
                    .TakeLast(3));
            return queue;
        }

        // query
        public IEnumerable<StringString> GetRouteCompany()
        {
            var queue = from routes in _data.Routes
                        join companies in _data.Companies
                        on routes.Company.Id equals companies.Id
                        select new StringString
                        {
                            Name1 = routes.Name,
                            Name2 = companies.Name
                        };
            return queue;
        }

        public IEnumerable<string> GetCommonRoutes()
        {
            var queue = _data.Buses.ElementAt(1).Routes.Intersect(
                _data.Buses
                .ElementAt(2).Routes)
                .Select(r => r.Name);
            return queue;
        }

        public IEnumerable<StringString> GetSameRoutes()
        {
            var queue = _data.Buses.GroupBy(b => b.Routes.Count)
                .Select(b => new StringString
                {
                    Name1 = b.Key.ToString(),
                    Name2 = b.Select(n => n.Number)
                    .Aggregate((n1, n2) => n1 + ", " + n2)
                });
            return queue;

            Console.WriteLine("List of the same amount of routes for buses.\n");
            foreach (var item in queue)
            {
                Console.WriteLine("Amount: " + item.Name1 + ", buses: " + item.Name2);
            }
        }

        // query
        public IEnumerable<StringString> GetNameplates()
        {
            var queue = from res in (from buses in _data.Buses
                                     group buses by buses.Number[..2] into busesGroups
                                     select new StringString
                                     {
                                         Name1 = busesGroups.Key,
                                         Name2 = busesGroups.Count().ToString()
                                     })
                        orderby res.Name2 descending
                        select res;
            return queue;
        }

        public IOrderedEnumerable<BusStop> GetRouteStartAndFinish()
        {
            var queue = _data.Routes.Select(r => r.FirstStop)
                .Union(_data.Routes.Select(r => r.LastStop))
                .OrderBy(r => r.Name.Length);

            return queue;
        }

        // query
        public IEnumerable<StringString> GetRoutesByBusAmount()
        {
            var queue = from res in (from routes in _data.Routes
                                     group routes by routes.BusAmount into routeGroups
                                     select new StringString
                                     {
                                         Name1 = routeGroups.Key + " buses",
                                         Name2 = (from r in routeGroups
                                                  select r.Name).Aggregate((s1, s2) => s1 + ", " + s2)
                                     })
                        orderby res.Name1 descending
                        select res;
            return queue;
        }

        // query
        public double GetAvgBussAmount()
        {
            var queue = (from amount in _data.Routes
                         select amount.BusAmount).Average();

            return queue;
        }

        // query
        public IEnumerable<Bus> GetAllBussesButLastAndFirstRoute()
        {
            var queue = (from buses in _data.Buses
                         select buses).Except((
                            from buses1 in _data.Routes.First().Buses
                            select buses1)
                            .Union(
                                from buses2 in _data.Routes.Last().Buses
                                select buses2)
                            );
            return queue;
        }

        public IEnumerable<StringString> GetRoutesBySymbols()
        {
            var queue = _data.Routes.GroupBy(r =>
                r.Name.Length)
                .Select(r => new StringString
                {
                    Name1 = r.Key.ToString(),
                    Name2 = r.Select(rr => rr.Name)
                        .Aggregate((s1, s2) => s1 + ", " + s2)
                });
            return queue;
        }

        public IEnumerable<StringString> GetRoutesByCompany()
        {
            var queue = _data.Companies.Select(c =>
                new StringString
                {
                    Name1 = c.Name,
                    Name2 = c.Courses.Select(r => r.Name)
                        .Aggregate((n1, n2) => n1 + ", " + n2)
                }
            );
            return queue;
        }

        // query
        public IOrderedEnumerable<Bus> GetAllBusNumbers()
        {
            var queue = from buses in _data.Buses
                        orderby buses.Id
                        select buses;

            return queue;
        }
    }
    public class StringString
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public override string ToString()
        {
            return Name1 + " " + Name2;
        }
    }
}