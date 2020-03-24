using System;
using System.Collections.Generic;
using ConstructionLine.CodingChallenge;

namespace ConstructionLine.CodingChallenge.Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            var engine = new SearchEngine(null);
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color>() { Color.Red, Color.Blue, Color.Black },
                Sizes = new List<Size>() { Size.Large, Size.Medium }
            };
                                                    
         engine.Search(searchOptions);
        }
    }
}
