using Xunit;
using Challenge2;
namespace Challenge2;

public class UnitTest1
{
    [Fact]
    public void MainUnitTest()
    {
        try
        {
            Program.Main();
            Assert.False(false);
        }
        catch (System.Exception)
        {
            Assert.False(true);
        }

    }
}