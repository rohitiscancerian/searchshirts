using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    public class SearchEngineTestsBase
    {
        protected static void AssertResults(List<Shirt> shirts, SearchOptions options)
        {
            Assert.That(shirts, Is.Not.Null);

            var resultingShirtIds = shirts.Select(s => s.Id).ToList();
            var sizeIds = options.Sizes.Select(s => s.Id).ToList();
            var colorIds = options.Colors.Select(c => c.Id).ToList();

            foreach (var shirt in shirts)
            {
                if (sizeIds.Contains(shirt.Size.Id)
                    && colorIds.Contains(shirt.Color.Id)
                    && !resultingShirtIds.Contains(shirt.Id))
                {
                    Assert.Fail($"'{shirt.Name}' with Size '{shirt.Size.Name}' and Color '{shirt.Color.Name}' not found in results, " +
                                $"when selected sizes where '{string.Join(",", options.Sizes.Select(s => s.Name))}' " +
                                $"and colors '{string.Join(",", options.Colors.Select(c => c.Name))}'");
                }
            }
        }


        protected static void AssertSizeCounts(List<Shirt> shirts, SearchOptions searchOptions, List<SizeCount> sizeCounts)
        {
            Assert.That(sizeCounts, Is.Not.Null);

            foreach (var sizeItem in sizeCounts.Where(x=>x.Count > 0).ToList())
            {
                var sizeCount = sizeCounts.SingleOrDefault(s => s.Size.Id == sizeItem.Size.Id);
                Assert.That(sizeCount, Is.Not.Null, $"Size count for '{sizeItem.Size.Name}' not found in results");

                var expectedSizeCount = shirts
                    .Count(s => s.Size.Id == sizeItem.Size.Id
                                && (!searchOptions.Colors.Any() || searchOptions.Colors.Select(c => c.Id).Contains(s.Color.Id)));

                Assert.That(sizeCount.Count, Is.EqualTo(expectedSizeCount), 
                    $"Size count for '{sizeCount.Size.Name}' showing '{sizeCount.Count}' should be '{expectedSizeCount}'");
            }
        }


        protected static void AssertColorCounts(List<Shirt> shirts, SearchOptions searchOptions, List<ColorCount> colorCounts)
        {
            Assert.That(colorCounts, Is.Not.Null);
            
            foreach (var colorItem in colorCounts.Where(x=>x.Count > 0).ToList())
            {   
                var colorCount = colorCounts.SingleOrDefault(s => s.Color.Id == colorItem.Color.Id);
                Assert.That(colorCount, Is.Not.Null, $"Color count for '{colorItem.Color.Name}' not found in results");

                var expectedColorCount = shirts
                    .Count(c => c.Color.Id == colorItem.Color.Id  
                                && (!searchOptions.Sizes.Any() || searchOptions.Sizes.Select(s => s.Id).Contains(c.Size.Id)));

                Assert.That(colorCount.Count, Is.EqualTo(expectedColorCount),
                    $"Color count for '{colorCount.Color.Name}' showing '{colorCount.Count}' should be '{expectedColorCount}'");
            }
        }
    }
}