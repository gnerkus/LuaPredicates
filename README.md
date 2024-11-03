# LuaPredicates #

<a href="https://www.nuget.org/packages/Nanotome.LuaPredicates"><img src="https://img.shields.io/nuget/v/Nanotome.LuaPredicates.svg" alt="NuGet Version" /></a>

[LuaPredicates]: https://github.com/gnerkus/LuaPredicates
[MIT License]: https://opensource.org/licenses/MIT

[LuaPredicates] is a .NET Core library to parse collections in .NET with functions written in Lua.

## Installing LuaPredicates ##

You can use [NuGet](https://www.nuget.org) to install [LuaPredicates]. Run the following command
in the [Package Manager Console](http://docs.nuget.org/consume/package-manager-console).

```powershell
PM> Install-Package LuaPredicates
```

## Usage ##

Given a record in the system:
```csharp
private record Dimensions
{
    public int Width { set; }
    public int Height { set; }
}
```

We can transform a collection of `Dimensions` objects into a collection of `long` expressing 
the area of each `Dimensions` object:

```csharp
using LuaPredicates;

namespace Test;

public class Program 
{
    public static void Main(string[] args) 
    {
        var luaPredicate = new LuaPredicate<Dimensions, long>();
        var func = luaPredicate.ReadFromString(
            """
                function Calculate (dim)
                    return dim.Width * dim.Height
                end
           """
        );
        var records = new List<Dimensions>
        {
            new ()
            {
                Width = 10,
                Height = 10
            }
        };
        var areas = records.Select(func).ToList();
        Console.WriteLine(areas[0]); // 100
    }
}
```

## License ##

The library is released under terms of the [MIT License]:

* [https://github.com/gnerkus/LuaPredicates](https://github.com/gnerkus/LuaPredicates)