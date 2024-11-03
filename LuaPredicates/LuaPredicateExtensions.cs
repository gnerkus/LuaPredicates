using System.Text;
using NLua;

namespace LuaPredicates
{
    public static class LuaPredicateExtensions
    {

        public static Func<TSource, TResult> ReadFromFile<TSource, TResult>(this
            ILuaPredicate<TSource, TResult> luaPredicate, string fileName, Encoding encoding)
        {
            ArgumentNullException.ThrowIfNull(fileName);

            var scriptSource = File.ReadAllText(fileName, encoding);
            var state = new Lua();
            state.DoString(scriptSource);
            return luaPredicate.GetFunction(state);
        }
        public static Func<TSource, TResult> ReadFromString<TSource, TResult>(this 
                ILuaPredicate<TSource, TResult> 
                luaPredicate, string luaSource)
        {
            var state = new Lua();
            state.DoString(luaSource);
            return luaPredicate.GetFunction(state);
        }
    }
}