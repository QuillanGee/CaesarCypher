using CaesarCypherCode1;

namespace CaesarCypherCodeTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.Equal("ere",CaesarCypher.Encode("bob",3));
    }

    [Theory]
    [InlineData("Zob-Zob", "Cre-Cre", 3)]
    [InlineData("2", "2", 1)]
    // [InlineData("bob bob", "ere ere", 3)]

    public void Test2(string decodedMessage, string encodedMessage, int shift)
    {
        Assert.Equal(encodedMessage, CaesarCypher.Encode(decodedMessage, shift));
        Assert.Equal(decodedMessage, CaesarCypher.Decode(encodedMessage, shift));
    }
}