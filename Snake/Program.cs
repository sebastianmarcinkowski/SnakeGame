using Snake;

char horizontal = '═';
char vertical = '║';
char topLeft = '╔';
char topRight = '╗';
char bottomLeft = '╚';
char bottomRight = '╝';

int width = 32;
int height = 16;

// Direction
Direction _direction = Direction.Right;

// Game state
bool gameOver = false;

// Head
Pixel snakeHead = new Pixel
{
    X = 19,
    Y = 8,
    Character = 'o',
    ConsoleColor = ConsoleColor.Magenta
};

// Tail
int startLength = 8;
List<Pixel> snakeTails = new List<Pixel>();

for (int i = 1; i < startLength + 1; i++)
{
    Pixel snakeTail = new Pixel
    {
        X = snakeHead.X - i * 2,
        Y = snakeHead.Y,
        Character = 'x',
        ConsoleColor = ConsoleColor.Blue
    };

    snakeTails.Add(snakeTail);
}

// Food
Pixel food = new Pixel
{
    Character = '*',
    ConsoleColor = ConsoleColor.DarkYellow
};
Random random = new Random();

// Score
int score = 0;

Console.WindowHeight = 20; // 16 + 4 for score
Console.WindowWidth = 32;

GenerateFood();
DrawBoard();

Console.WriteLine("Press enter to start     ");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("It is recommended to resize");
Console.WriteLine("window at least by 1px.");
Console.ResetColor();
Console.ReadKey();

while (true)
{
    DrawBoard();
    WaitForKey();
    MoveSnake();
    CheckCollision();
    CheckFoodCollision();
}

void GenerateFood()
{
    bool foodGenerated = false;

    while (!foodGenerated)
    {
        food.X = random.Next(1, (width - 2) / 2) * 2 + 1; // ensure X is odd
        food.Y = random.Next(1, height - 2);

        // Check if food is generated inside the head
        if (food.X == snakeHead.X && food.Y == snakeHead.Y)
            continue;

        // Check if food is generated inside any tail segment
        bool insideTail = false;

        foreach (var tail in snakeTails)
        {
            if (food.X == tail.X && food.Y == tail.Y)
            {
                insideTail = true;
                break;
            }
        }
        if (insideTail)
            continue;

        foodGenerated = true;
    }
}

void DrawBoard()
{
    if (gameOver)
        ShowScore();

    Console.Clear();

    // Top
    for (int i = 0; i < width; i++)
    {
        Console.SetCursorPosition(i, 0);

        if (i == 0)
            Console.Write(topLeft);
        else if (i == width - 1)
            Console.Write(topRight);
        else
            Console.Write(horizontal);
    }

    // Left && right
    for (int i = 1; i < height - 1; i++)
    {
        Console.SetCursorPosition(0, i);
        Console.Write(vertical);

        Console.SetCursorPosition(width - 1, i);
        Console.Write(vertical);
    }

    // Bottom
    for (int i = 0; i < width; i++)
    {
        Console.SetCursorPosition(i, height - 1);

        if (i == 0)
            Console.Write(bottomLeft);
        else if (i == width - 1)
            Console.Write(bottomRight);
        else
            Console.Write(horizontal);
    }

    // Head
    Console.ForegroundColor = snakeHead.ConsoleColor;
    Console.SetCursorPosition(snakeHead.X, snakeHead.Y);
    Console.WriteLine(snakeHead.Character);
    Console.ResetColor();

    // Tail
    foreach (Pixel tail in snakeTails)
    {
        Console.SetCursorPosition(tail.X, tail.Y);
        Console.ForegroundColor = tail.ConsoleColor;
        Console.Write(tail.Character);
        Console.ResetColor();
    }

    // Food
    Console.SetCursorPosition(food.X, food.Y);
    Console.ForegroundColor = food.ConsoleColor;
    Console.Write(food.Character);
    Console.ResetColor();

    ShowScore();

    // Set cursor at the end
    Console.SetCursorPosition(0, height + 1);
}
void ShowScore()
{
    if (gameOver)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(width / 5, 17);
        Console.WriteLine("    Game Over    ");

        Console.SetCursorPosition(width / 5, 18);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(width / 5, 17);
    }

    Console.WriteLine($"Your score is: {score}");
    Console.SetCursorPosition(width / 5, 19);

    if (gameOver)
        Environment.Exit(0);

    Console.ResetColor();
}

void WaitForKey()
{
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo info = Console.ReadKey(true);

        switch (info.Key)
        {
            case ConsoleKey.UpArrow:
                if (_direction != Direction.Bottom)
                    _direction = Direction.Top;
                break;

            case ConsoleKey.DownArrow:
                if (_direction != Direction.Top)
                    _direction = Direction.Bottom;
                break;

            case ConsoleKey.LeftArrow:
                if (_direction != Direction.Right)
                    _direction = Direction.Left;
                break;

            case ConsoleKey.RightArrow:
                if (_direction != Direction.Left)
                    _direction = Direction.Right;
                break;
        }
    }

    Thread.Sleep(300);
}

void MoveSnake()
{
    for (int i = snakeTails.Count - 1; i > 0; i--)
    {
        snakeTails[i].X = snakeTails[i - 1].X;
        snakeTails[i].Y = snakeTails[i - 1].Y;
    }

    snakeTails[0].X = snakeHead.X;
    snakeTails[0].Y = snakeHead.Y;


    switch (_direction)
    {
        case Direction.Top:
            snakeHead.Y -= 1;
            break;
        case Direction.Bottom:
            snakeHead.Y += 1;
            break;
        case Direction.Left:
            snakeHead.X -= 2; // 2 because height != width in console
            break;
        case Direction.Right:
            snakeHead.X += 2; // 2 because height != width in console
            break;
    }
}

void CheckCollision()
{
    if (snakeHead.X == 0 || snakeHead.X == width - 1 || snakeHead.Y == 0 || snakeHead.Y == height - 1)
        gameOver = true;

    foreach (Pixel tail in snakeTails)
    {
        if (snakeHead.X == tail.X && snakeHead.Y == tail.Y)
            gameOver = true;
    }
}

void CheckFoodCollision()
{
    // Check if head collides with food
    if (snakeHead.X == food.X && snakeHead.Y == food.Y)
    {
        // Add new tail segment
        Pixel newTail = new Pixel
        {
            X = snakeTails[snakeTails.Count - 1].X,
            Y = snakeTails[snakeTails.Count - 1].Y,
            Character = 'x'
        };

        snakeTails.Add(newTail);
        score++;

        // Generate new food
        GenerateFood();
    }
}