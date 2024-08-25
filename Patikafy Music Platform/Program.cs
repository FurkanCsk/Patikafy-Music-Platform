using Patikafy_Music_Platform;
using System.Threading.Channels;

List<Singers> singers = new List<Singers>
{
    new Singers
    {
        FullName = "Ajda Pekkan",
        MusicType = "Pop",
        Year = 1968,
        AlbumSales = 20000000
    },
    new Singers
    {
        FullName = "Sezen Aksu",
        MusicType = "Turkish Folk Music / Pop",
        Year = 1971,
        AlbumSales = 10000000
    },
    new Singers
    {
        FullName = "Funda Arar",
        MusicType = "Pop",
        Year = 1999,
        AlbumSales = 3000000
    },
    new Singers
    {
        FullName = "Sertab Erener",
        MusicType = "Pop",
        Year = 1994,
        AlbumSales = 5000000
    },
    new Singers
    {
        FullName = "Sıla",
        MusicType = "Pop",
        Year = 2009,
        AlbumSales = 3000000
    },
    new Singers
    {
        FullName = "Serdar Ortaç",
        MusicType = "Pop",
        Year = 1994,
        AlbumSales = 10000000
    },
    new Singers
    {
        FullName = "Tarkan",
        MusicType = "Pop",
        Year = 1992,
        AlbumSales = 40000000
    },
    new Singers
    {
        FullName = "Hande Yener",
        MusicType = "Pop",
        Year = 1999,
        AlbumSales = 7000000
    },
    new Singers
    {
        FullName = "Hadise",
        MusicType = "Pop",
        Year = 2005,
        AlbumSales = 5000000
    },
    new Singers
    {
        FullName = "Gülben Ergen",
        MusicType = "Pop / Turkish Folk Music",
        Year = 1997,
        AlbumSales = 10000000
    },
    new Singers
    {
        FullName = "Neşet Ertaş",
        MusicType = "Turkish Folk Music / Turkish Art Music",
        Year = 1997,
        AlbumSales = 2000000
    },
};

// Print singers whose names start with 'S'
Console.WriteLine("The singers starting with 'S': ");
singers.Where(singer => singer.FullName.StartsWith("S",StringComparison.OrdinalIgnoreCase))
       .OrderBy(singer => singer.FullName)
       .ToList()
       .ForEach(singer => Console.WriteLine(singer.FullName));

// Print singers with album sales over 10 million
Console.WriteLine("\nThe singers with album sales over 10 million: ");
singers.Where(singer => singer.AlbumSales > 10000000)
       .OrderBy(singer => singer.AlbumSales)
       .ToList()
       .ForEach(singer => Console.WriteLine($"Name: {singer.FullName}, Album Sales: {singer.AlbumSales}"));

// Print singers who started their careers before the year 2000 and perform pop music
// Group by year and sort alphabetically
Console.WriteLine("\nThe singers who started their careers before the year 2000 and perform pop music: ");
var groupedByYear = singers.Where(singer => (singer.MusicType.Contains("Pop", StringComparison.OrdinalIgnoreCase) && singer.Year < 2000))
       .OrderBy(singer => singer.FullName)
       .GroupBy(singer => singer.Year)
       .ToList();

foreach (var group in groupedByYear)
{
    Console.WriteLine(group.Key);

    {
        foreach (var singer in group)
        {
            Console.WriteLine(singer.FullName);
        }
    }
}

// Find the singer with thehighest album sales
var mostSellingSinger = singers.OrderByDescending(singer => singer.AlbumSales)
                               .First();
Console.WriteLine($"\nThe most sold album is: {mostSellingSinger.FullName}, Album Sales:  {mostSellingSinger.AlbumSales}");


// Find the newest and oldest singer based on their release year
var newestSinger = singers.OrderByDescending(singer => singer.Year)
                          .First();

var oldestSinger = singers.OrderBy(singer => singer.Year)
                          .First();

Console.WriteLine($"The newest singer: {newestSinger.FullName} , Year: {newestSinger.Year}\nThe oldests singer: {oldestSinger.FullName}, Year:: {oldestSinger.Year}");