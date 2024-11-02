using NLua;

namespace LuaPredicates
{
    public static class LuaPredicateExtensions
    {
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