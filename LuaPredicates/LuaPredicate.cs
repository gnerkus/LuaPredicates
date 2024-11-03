using NLua;

namespace LuaPredicates
{
    public class LuaPredicate<TSource, TResult>: ILuaPredicate<TSource, TResult>
    {
        public LuaPredicate()
        {
            
        }


        /// <summary>
        /// Creates a <see cref="Func{TSource, TResult}" /> from a Lua function named "Calculate"
        /// </summary>
        /// <param name="scriptSource">A <see cref="Lua"/> state</param>
        /// <returns></returns>
        public Func<TSource, TResult> GetFunction(Lua scriptSource)
        {
            ArgumentNullException.ThrowIfNull(scriptSource);

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