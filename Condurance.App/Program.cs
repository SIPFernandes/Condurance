// See https://aka.ms/new-console-template for more information
using Condurance.App;
using Condurance.App.Services.Implementations;
using Condurance.App.Services.Interfaces;

string? command = null;

while(command == null)
    command = Console.ReadLine();

IGrid grid = new Grid();

IMarsRover marsRover = new MarsRover(grid);

var result = marsRover.execute(command);

Console.WriteLine(result);
