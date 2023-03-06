using System;
using Walkers.UI.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Walkers.UI.Server.Services
{
    public static class FizzBuzzService
    {
      // I wouldnt implement a static class. I would have normal class with constructor for injectable dependancies and inteferface implementation. makes for loose coupling,
      //testability and reusability. I would also make dependency with scoped lifetime using ServiceCollection within startup file. this means you can implement service with repository
      //pattern/ unit of work which will give access to different DAL being sql, no sql, entityframework ect..for this use case and time constraints it made sense to use static classes and methods

      

        public static IList<string> GetFizzBuzzValues(int number,int current, int limit)
        {
            return Enumerable.Range(1, number).Select(x =>
            {
                if (x % 3 == 0 && x % 5 == 0)
                    return "walkers".AddDayTag() +" assesment".AddDayTag();
                else if (x % 3 == 0)
                    return "walkers".AddDayTag();
                else if (x % 5 == 0)
                    return "assesment".AddDayTag();
                else
                    return x.ToString();
            }).Skip(current).Take(limit).ToList();

        }
    }
}

