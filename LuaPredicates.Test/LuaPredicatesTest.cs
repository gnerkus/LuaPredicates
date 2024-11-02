namespace LuaPredicates.Test;

public class LuaPredicatesTest
{
    private class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    private class PersonOneName
    {
        public string FullName { get; set; }
    }
    
    [Fact]
    public void NullInputTest()
    {
        var luaPredicate = new LuaPredicate<Person, PersonOneName>();
        Assert.Throws<ArgumentNullException>(() =>
        {
            var result = luaPredicate.GetFunction(null);
        });
    }
}