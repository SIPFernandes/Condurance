using Condurance.App;
using Condurance.App.Services.Implementations;
using Condurance.App.Services.Interfaces;
using Moq;

namespace Condurance.Tests.UnitTests
{
    public class MarsRoverUnitTest
    {
        private readonly IMarsRover _marsRover;
        public MarsRoverUnitTest() 
        {
            var grid = new Mock<Grid>();                           

            _marsRover = new MarsRover(grid.Object);
        }

        [Fact]
        public void ShouldMoveFoward()
        {
            var result = _marsRover.execute("M");

            Assert.Equal("0:1:N", result);
        }

        [Theory]
        [InlineData("RLL", "0:0:W")]
        [InlineData("RLLR", "0:0:N")]
        public void ShouldRotate(string command, string expectedResult)
        {
            var result = _marsRover.execute(command);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("MMRMMLM", "2:3:N")]
        [InlineData("MMRMMM", "3:2:E")]
        public void ShouldRotateAndMove(string command, string expectedResult)
        {
            var result = _marsRover.execute(command);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("MMMMMMMMMM", "0:0:N")]
        public void ShouldWrap(string command, string expectedResult)
        {
            var result = _marsRover.execute(command);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("RMLMMM", "O:1:1:N")]
        public void ShouldDetectObstacles(string command, string expectedResult)
        {
            var grid = new Mock<IGrid>();

            var conflict = new HashSet<Coordinate>
            {
                new Coordinate(1, 2)
            };

            grid.SetupGet(x => x.ObstaclesHash)
                .Returns(() => conflict);

            var marsRover = new MarsRover(grid.Object);            

            var result = marsRover.execute(command);

            Assert.Equal(expectedResult, result);
        }
    }
}