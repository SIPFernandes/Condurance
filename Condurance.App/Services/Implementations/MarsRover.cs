using Condurance.App.Services.Interfaces;

namespace Condurance.App.Services.Implementations
{
    public class MarsRover : IMarsRover
    {
        private readonly IGrid _grid;


        public MarsRover(IGrid grid)
        {
            _grid= grid;
        }
        public string execute(string command)
        {
            var charArray = command.ToCharArray();

            Coordinate currentCoord = new(0,0);
            var currentRotation = 'N';            

            foreach (var move in charArray)
            {
                if (move == 'M')
                {
                    var newMove = SetNewMove(currentRotation, currentCoord);

                    if (newMove is null)
                    {
                        return $"O:{currentCoord}:{currentRotation}";
                    }
                    else
                    {
                        currentCoord = newMove;
                    }
                }
                else
                {
                    currentRotation = SetNewRotation(currentRotation, move);
                }
            }

            return $"{currentCoord}:{currentRotation}";
        }

        private Coordinate? SetNewMove(char currentRotation, Coordinate currentCoord)
        {
            Coordinate? newCoord;

            if (currentRotation == 'N')
            {
                var newY = WrapIfLimitIsCrossed(currentCoord.Y + 1, _grid.MaxY);

                newCoord = new Coordinate(currentCoord.X, newY);
            }
            else if (currentRotation == 'S')
            {
                var newY = WrapIfLimitIsCrossed(currentCoord.Y - 1, 0);

                newCoord = new Coordinate(currentCoord.X, newY);
            }
            else if (currentRotation == 'E')
            {
                var newX = WrapIfLimitIsCrossed(currentCoord.X + 1, _grid.MaxX);

                newCoord = new Coordinate(newX, currentCoord.Y);
            }
            else
            {
                var newX = WrapIfLimitIsCrossed(currentCoord.X - 1, 0);

                newCoord = new Coordinate(newX, currentCoord.Y);
            }

            if (_grid.ObstaclesHash.Contains(newCoord))
            {
                newCoord = null;
            }

            return newCoord;
        }

        private static int WrapIfLimitIsCrossed(int newValue, int limitValue)
        {
            if (limitValue > 0 && newValue == limitValue)
            {
                return 0;                
            }
            else if (newValue < 0)
            {                 
                return limitValue;                
            }

            return newValue;
        }

        private static char SetNewRotation(char currentRotation, char newRotation)
        {
            if (newRotation == 'L')
            {
                if(currentRotation == 'N')
                {
                    return 'W';
                }
                else if (currentRotation == 'E')
                {
                    return 'N';
                }
                else if (currentRotation == 'S')
                {
                    return 'E';
                }
                else
                {
                    return 'S';
                }
            }
            else
            {
                if (currentRotation == 'N')
                {
                    return 'E';
                }
                else if (currentRotation == 'E')
                {
                    return 'S';
                }
                else if (currentRotation == 'S')
                {
                    return 'W';
                }
                else
                {
                    return 'N';
                }
            }
        }
    }
}
