using NLua;

namespace LuaPredicates
{
    public class LuaPredicate<TSource, TResult>: ILuaPredicate<TSource, TResult>
    {
        public LuaPredicate()
        {
            
        }


        public Func<TSource, TResult> GetFunction(Lua scriptSource)
        {
            ArgumentNullException.ThrowIfNull(scriptSource);

            // TODO: decide on the name of the function
            var scriptFunc = scriptSource["Calculate"] as LuaFunction;
            return sourceEntity => (TResult)scriptFunc.Call
                (sourceEntity).First();
        }

        public override string ToString()
        {
            return $"LuaPredicate";
        }
    }
}