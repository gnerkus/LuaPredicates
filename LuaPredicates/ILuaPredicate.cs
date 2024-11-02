using NLua;

namespace LuaPredicates
{
    public interface ILuaPredicate<TSource, TResult>
    {
        Func<TSource, TResult> GetFunction(Lua scriptSource);
    }
}