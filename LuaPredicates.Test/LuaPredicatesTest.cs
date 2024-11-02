using NLua;

namespace LuaPredicates.Test;

public class LuaPredicatesTest
{
    private record Dimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    private record Measures
    {
        public int Area { get; set; }
    }
    
    [Fact]
    public void NullInputTest()
    {
        var luaPredicate = new LuaPredicate<Dimensions, Measures>();
        Assert.Throws<ArgumentNullException>(() =>
        {
            var result = luaPredicate.GetFunction(null);
        });
    }

    [Fact]
    public void IntegerResultTest()
    {
        var luaPredicate = new LuaPredicate<Dimensions, long>();
        var state = new Lua();
        state.DoString("""
                       
                       		function Calculate (dim)
                       		    return dim.Width * dim.Height
                       		end
                       		
                       """);
        var func = luaPredicate.GetFunction(state);
        var records = new List<Dimensions>
        {
            new ()
            {
                Width = 10,
                Height = 10
            }
        };
        var areas = records.Select(func).ToList();
        Assert.Equal(100, areas[0]);
    }
}