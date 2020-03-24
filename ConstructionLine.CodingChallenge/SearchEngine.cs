using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;
        private readonly Dictionary<string, List<Shirt>> _sortedShirts;
        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
            _sortedShirts = new Dictionary<string, List<Shirt>>();
            SortShirtsByColorAndSizeAndStoreInDictionary();
            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
        }

        private List<Shirt> FilterShirtsByColorAndSize(Size size,Color color)
        {
           return _shirts.Where(x => (size == null || x.Size == size) && ( color == null || x.Color == color )).ToList();
        }
        private void SortShirtsByColorAndSizeAndStoreInDictionary()
        {
            var blackSmallList = FilterShirtsByColorAndSize(Size.Small,Color.Black);
            var blackMediumList = FilterShirtsByColorAndSize(Size.Medium,Color.Black);
            var blackLargeList = FilterShirtsByColorAndSize(Size.Large, Color.Black);

            var whiteSmallList = FilterShirtsByColorAndSize(Size.Small, Color.White);
            var whiteMediumList = FilterShirtsByColorAndSize(Size.Medium, Color.White);
            var whiteLargeList = FilterShirtsByColorAndSize(Size.Large, Color.White);

            var yellowSmallList = FilterShirtsByColorAndSize(Size.Small, Color.Yellow);
            var yellowMediumList = FilterShirtsByColorAndSize(Size.Medium, Color.Yellow); ;
            var yellowLargeList = FilterShirtsByColorAndSize(Size.Large, Color.Yellow);

            var blueSmallList = FilterShirtsByColorAndSize(Size.Small, Color.Blue);
            var blueMediumList = FilterShirtsByColorAndSize(Size.Medium, Color.Blue);
            var blueLargeList = FilterShirtsByColorAndSize(Size.Large, Color.Blue);

            var redSmallList = FilterShirtsByColorAndSize(Size.Small, Color.Red);
            var redMediumList = FilterShirtsByColorAndSize(Size.Medium, Color.Red);
            var redLargeList = FilterShirtsByColorAndSize(Size.Large, Color.Red);

            var small = FilterShirtsByColorAndSize(Size.Small,null);
            var medium = FilterShirtsByColorAndSize(Size.Medium, null);
            var large = FilterShirtsByColorAndSize(Size.Large, null);

            var black = FilterShirtsByColorAndSize(null, Color.Black);
            var white = FilterShirtsByColorAndSize(null, Color.White);
            var yellow = FilterShirtsByColorAndSize(null, Color.Yellow);
            var blue = FilterShirtsByColorAndSize(null, Color.Blue);
            var red = FilterShirtsByColorAndSize(null, Color.Red);


            _sortedShirts.Add("BlackSmall", blackSmallList);
            _sortedShirts.Add("BlackMedium", blackMediumList);
            _sortedShirts.Add("BlackLarge", blackLargeList);

            _sortedShirts.Add("WhiteSmall", whiteSmallList);
            _sortedShirts.Add("WhiteMedium", whiteMediumList);
            _sortedShirts.Add("WhiteLarge", whiteLargeList);

            _sortedShirts.Add("YellowSmall", yellowSmallList);
            _sortedShirts.Add("YellowMedium", yellowMediumList);
            _sortedShirts.Add("YellowLarge", yellowLargeList);

            _sortedShirts.Add("BlueSmall", blueSmallList);
            _sortedShirts.Add("BlueMedium", blueMediumList);
            _sortedShirts.Add("BlueLarge", blueLargeList);

            _sortedShirts.Add("RedSmall", redSmallList);
            _sortedShirts.Add("RedMedium", redMediumList);
            _sortedShirts.Add("RedLarge", redLargeList);


            _sortedShirts.Add("Small", small);
            _sortedShirts.Add("Medium", medium);
            _sortedShirts.Add("Large", large);

            _sortedShirts.Add("Black", black);
            _sortedShirts.Add("White", white);
            _sortedShirts.Add("Yellow", yellow);
            _sortedShirts.Add("Blue", blue);
            _sortedShirts.Add("Red", red);
        }
        private void SearchWithSize(SearchOptions options, SearchResults searchResult)
        {
            foreach (var size in options.Sizes)
            {
                switch (size.Name)
                {
                    case "Small":
                        var countSmall = _sortedShirts["Small"].Count();
                        searchResult.Shirts.AddRange(_sortedShirts["Small"]);
                        searchResult.SizeCounts.Where(x => x.Size == Size.Small).FirstOrDefault().Count += countSmall;
                        break;
                    case "Medium":
                        var countMedium = _sortedShirts["Medium"].Count();
                        searchResult.Shirts.AddRange(_sortedShirts["Medium"]);
                        searchResult.SizeCounts.Where(x => x.Size == Size.Medium).FirstOrDefault().Count += countMedium;
                        break;
                    case "Large":
                        var countLarge = _sortedShirts["Large"].Count();
                        searchResult.Shirts.AddRange(_sortedShirts["Large"]);
                        searchResult.SizeCounts.Where(x => x.Size == Size.Large).FirstOrDefault().Count += countLarge;
                        break;
                    default:
                        break;
                }
            }
        }
        private void SearchWithColor(SearchOptions options, SearchResults searchResult)
            {
                foreach (var color in options.Colors)
                {
                    switch (color.Name)
                    {
                        case "Black":
                            var countBlack = _sortedShirts["Black"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["Black"]);
                            searchResult.ColorCounts.Where(x => x.Color == Color.Black).FirstOrDefault().Count += countBlack;
                            break;
                        case "White":
                            var countWhite = _sortedShirts["White"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["White"]);
                            searchResult.ColorCounts.Where(x => x.Color == Color.White).FirstOrDefault().Count += countWhite;
                            break;
                        case "Yellow":
                            var countYellow = _sortedShirts["Yellow"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["Yellow"]);
                            searchResult.ColorCounts.Where(x => x.Color == Color.Yellow).FirstOrDefault().Count += countYellow;
                            break;
                        case "Blue":
                            var countBlue = _sortedShirts["Blue"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["Blue"]);
                            searchResult.ColorCounts.Where(x => x.Color == Color.Blue).FirstOrDefault().Count += countBlue;
                            break;
                        case "Red":
                            var countRed = _sortedShirts["Red"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["Red"]);
                            searchResult.ColorCounts.Where(x => x.Color == Color.Red).FirstOrDefault().Count += countRed;
                            break;
                        default:
                            break;
                    }
                }
            }
        private void SearchWithSizeAndColor(SearchOptions options, SearchResults searchResult)
        {
            foreach (var color in options.Colors)
            {
                foreach (var size in options.Sizes)
                {
                    switch (color.Name + size.Name)
                    {
                        case "BlackSmall":
                            var countBlackSmall = _sortedShirts["BlackSmall"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["BlackSmall"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Small).FirstOrDefault().Count += countBlackSmall;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Black).FirstOrDefault().Count += countBlackSmall;
                            break;
                        case "BlackMedium":
                            var countBlackMedium = _sortedShirts["BlackMedium"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["BlackMedium"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Medium).FirstOrDefault().Count += countBlackMedium;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Black).FirstOrDefault().Count += countBlackMedium;
                            break;
                        case "BlackLarge":
                            var countBlackLarge = _sortedShirts["BlackLarge"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["BlackLarge"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Large).FirstOrDefault().Count += countBlackLarge;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Black).FirstOrDefault().Count += countBlackLarge;
                            break;
                        case "WhiteSmall":
                            var countWhiteSmall = _sortedShirts["WhiteSmall"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["WhiteSmall"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Small).FirstOrDefault().Count += countWhiteSmall;
                            searchResult.ColorCounts.Where(x => x.Color == Color.White).FirstOrDefault().Count += countWhiteSmall;
                            break;
                        case "WhiteMedium":
                            var countWhiteMedium = _sortedShirts["WhiteMedium"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["WhiteMedium"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Medium).FirstOrDefault().Count += countWhiteMedium;
                            searchResult.ColorCounts.Where(x => x.Color == Color.White).FirstOrDefault().Count += countWhiteMedium;

                            break;
                        case "WhiteLarge":
                            var countWhiteLarge = _sortedShirts["WhiteLarge"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["WhiteLarge"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Large).FirstOrDefault().Count += countWhiteLarge;
                            searchResult.ColorCounts.Where(x => x.Color == Color.White).FirstOrDefault().Count += countWhiteLarge;

                            break;
                        case "YellowSmall":
                            var countYellowSmall = _sortedShirts["YellowSmall"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["YellowSmall"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Small).FirstOrDefault().Count += countYellowSmall;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Yellow).FirstOrDefault().Count += countYellowSmall;

                            break;
                        case "YellowMedium":
                            var countYellowMedium = _sortedShirts["YellowMedium"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["YellowMedium"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Medium).FirstOrDefault().Count += countYellowMedium;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Yellow).FirstOrDefault().Count += countYellowMedium;

                            break;
                        case "YellowLarge":
                            var countYellowLarge = _sortedShirts["YellowLarge"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["YellowLarge"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Large).FirstOrDefault().Count += countYellowLarge;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Yellow).FirstOrDefault().Count += countYellowLarge;

                            break;
                        case "BlueSmall":
                            var countBlueSmall = _sortedShirts["BlueSmall"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["BlueSmall"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Small).FirstOrDefault().Count += countBlueSmall;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Blue).FirstOrDefault().Count += countBlueSmall;

                            break;
                        case "BlueMedium":
                            var countBlueMedium = _sortedShirts["BlueMedium"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["BlueMedium"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Medium).FirstOrDefault().Count += countBlueMedium;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Blue).FirstOrDefault().Count += countBlueMedium;

                            break;
                        case "BlueLarge":
                            var countBlueLarge = _sortedShirts["BlueLarge"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["BlueLarge"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Large).FirstOrDefault().Count += countBlueLarge;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Blue).FirstOrDefault().Count += countBlueLarge;

                            break;
                        case "RedSmall":
                            var countRedSmall = _sortedShirts["RedSmall"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["RedSmall"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Small).FirstOrDefault().Count += countRedSmall;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Red).FirstOrDefault().Count += countRedSmall;

                            break;
                        case "RedMedium":
                            var countRedMedium = _sortedShirts["RedMedium"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["RedMedium"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Medium).FirstOrDefault().Count += countRedMedium;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Red).FirstOrDefault().Count += countRedMedium;

                            break;
                        case "RedLarge":
                            var countRedLarge = _sortedShirts["RedLarge"].Count();
                            searchResult.Shirts.AddRange(_sortedShirts["RedLarge"]);
                            searchResult.SizeCounts.Where(x => x.Size == Size.Large).FirstOrDefault().Count += countRedLarge;
                            searchResult.ColorCounts.Where(x => x.Color == Color.Red).FirstOrDefault().Count += countRedLarge;

                            break;
                        default:
                            break;
                    }

                }
            }
        }
        public SearchResults Search(SearchOptions options)
        {
            // TODO: search logic goes here.
            var searchResult = new SearchResults();
            searchResult.Shirts = new List<Shirt>();
            searchResult.SizeCounts = new List<SizeCount>() 
            { 
                new SizeCount() { Size = Size.Small, Count = 0 },
                new SizeCount() { Size = Size.Medium, Count = 0 },
                new SizeCount() { Size = Size.Large, Count = 0 }
            };
            searchResult.ColorCounts = new List<ColorCount>()
            {
                new ColorCount() { Color = Color.Black, Count = 0 },
                new ColorCount() { Color = Color.White, Count = 0 },
                new ColorCount() { Color = Color.Yellow, Count = 0 },
                new ColorCount() { Color = Color.Blue, Count = 0 },
                new ColorCount() { Color = Color.Red, Count = 0 },
            };
            
            if (IsSizeSpecified(options) && IsColorSpecified(options))
            {
                SearchWithSizeAndColor(options, searchResult);
            }
            else if(IsColorSpecified(options) && !IsSizeSpecified(options))
            {
                SearchWithColor(options, searchResult);
            }
            else if (IsSizeSpecified(options) && !IsColorSpecified(options))
            {
                SearchWithSize(options, searchResult);
            }
            return searchResult;
        }
        private bool IsSizeSpecified(SearchOptions options)
        {
            return options.Sizes != null && options.Sizes.Count > 0 ? true : false;
        }
        private bool IsColorSpecified(SearchOptions options)
        {
            return options.Colors != null && options.Colors.Count > 0 ? true : false;
        }
    }

    
}