var horizontal = '═';
var vertical = '║';
var topLeft = '╔';
var topRight = '╗';
var bottomLeft = '╚';
var bottomRight = '╝';

var width = 32;
var height = 16;

DrawBoard();

void DrawBoard()
{
    Console.Clear();
    Console.WriteLine($"{topLeft}{new string(horizontal, width - 2)}{topRight}");

    for (int i = 0; i < height - 2; i++)
    {
        Console.WriteLine($"{vertical}{new string(' ', width - 2)}{vertical}");
    }

    Console.WriteLine($"{bottomLeft}{new string(horizontal, width - 2)}{bottomRight}");
}
