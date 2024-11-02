using NLua;

namespace LuaPredicates
{
    public class Class1
    {
        public int Parse()
        {
            var state = new Lua();
            state.DoString("""
                           
                           		function ScriptFunc (val1, val2)
                           			if val1 > val2 then
                           				return val1 + 1
                           			else
                           				return val2 - 1
                           			end
                           		end
                           		
                           """);
            var scriptFunc = state["ScriptFunc"] as LuaFunction;
            var res = (int)(long)scriptFunc.Call(3, 5).First();
            // LuaFunction.Call will also return a array of objects, since a Lua function
            // can return multiple values
            return res;
        }
    }
}