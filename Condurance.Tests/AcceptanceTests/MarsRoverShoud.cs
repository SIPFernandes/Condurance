using Condurance.App;
using Condurance.App.Services.Implementations;

namespace Condurance.Tests.AcceptanceTests
{
    public class MarsRoverShoud
    {
        [Fact]
        public void ReturnRoverLastPosition()
        {
            string input = "MMRMMLM";
            var expectedOutput = "2:3:N";

            var grid = new Grid();

            var marRover = new MarsRover(grid);

            var result = marRover.execute(input);

            Assert.Equal(expectedOutput, result);            
        }
    }
}
