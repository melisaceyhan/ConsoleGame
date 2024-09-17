using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

string[] Character = new string[]
{
                null,

                @"  |o   " + "\n" +
                @"  |)   " + "\n" +
                @"   |   " + "\n" +
                @"  / \  " + "\n" ,

                @"   o   " + "\n" +
                @"  (||  " + "\n" +
                @"   |   " + "\n" +
                @"  / \  " + "\n" ,

                @" __o   " + "\n" +
                @"   |)  " + "\n" +
                @"   |   " + "\n" +
                @"  < \  " + "\n" ,

                @"   o__ " + "\n" +
                @"  (|   " + "\n" +
                @"   |   " + "\n" +
                @"  / >  " + "\n" ,

};

string[] CharactersShooting = new string[]
{
                null,

                @"  .o   " + "\n" +
                @"  |)   " + "\n" +
                @"   |   " + "\n" +
                @"  / \  " + "\n" ,

                @"   o   " + "\n" +
                @"  (||  " + "\n" +
                @"   |.  " + "\n" +
                @"  / \  " + "\n" ,

                @" .__o  " + "\n" +
                @"    |) " + "\n" +
                @"    |  " + "\n" +
                @"   < \ " + "\n" ,

                @"  o__. " + "\n" +
                @" (|    " + "\n" +
                @"  |    " + "\n" +
                @" / >   " + "\n" ,
};

string[] CharactersDying = new string[]
{


                @"       " + "\n" +
                @" //    " + "\n" +
                @"O/__/\ " + "\n" +
                @"     \ " + "\n" ,

                @"       " + "\n" +
                @"       " + "\n" +
                @"       " + "\n" +
                @" o___/\" + "\n" ,

                @"       " + "\n" +
                @"       " + "\n" +
                @"       " + "\n" +
                @"       " + "\n",
};


char[] Bullet = new char[]
{
    default,
    '^',
    'v',
    '<',
    '>',

};

string MatrixMap =

    @"╔═════════════════════════════════════════════════════════════════════════╗" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║             ═════╔════════════╗         ╔════════════╗═════             ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║                  ╚════════════╝         ╚════════════╝                  ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║═════                                                               ═════║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                  ╔════════════╗         ╔════════════╗                  ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║                  ║************║         ║************║                  ║" + "\n" +
    @"║             ═════╚════════════╝         ╚════════════╝═════             ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"║                                                                         ║" + "\n" +
    @"╚═════════════════════════════════════════════════════════════════════════╝" + "\n";

;//inspired by CSGO FY_ICEWORLD MAP

var Characters = new List<Character>();
var AllCharacters = new List<Character>();
var Neo = new Character() { X = 35, Y = 04, IsTheOne = true };
var random = new Random();


Characters.Add(Neo);
Characters.Add(new Character() { X = 35, Y = 23, }); //down-- 1.agent
Characters.Add(new Character() { X = 11, Y = 12, }); //left-- 2.agent
Characters.Add(new Character() { X = 60, Y = 12, }); //right-- 3.agent
AllCharacters.AddRange(Characters);

static void WriteInColor(List<Character> values, ConsoleColor fgColor)
{
    Console.ForegroundColor = fgColor;
    Console.Write(values);
   // Console.ResetColor();

}

WriteInColor(Characters,ConsoleColor.Green);

Console.CursorVisible = false;
if (OperatingSystem.IsWindows())
{
    Console.WindowWidth = Math.Max(Console.WindowWidth, 90);
    Console.WindowHeight = Math.Max(Console.WindowHeight, 35);
}
Console.Clear();
Console.SetCursorPosition(0, 0);


    Render(MatrixMap);
    Console.WriteLine();
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("     Navigate with (W, A, S, D) keys and the arrow keys to shoot.");
    Console.WriteLine("---------------------------------------------------------------------------");

static void Render(string @string, bool renderSpace = false)
    {
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
    foreach (char c in @string)
        if (c is '\n')
        {
            try
            {
                Console.SetCursorPosition(x, ++y);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(x);
                Console.WriteLine(y);

                Console.ReadKey();
            }
        }

        else if (c is not ' ' || renderSpace)
        {
            Console.Write(c);
        }
        else 
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
    }
            
    while (Characters.Contains(Neo) && Characters.Count > 1)
    {
        foreach (var character in Characters)
        {
            
            if (character.IsShooting)
            {
                character.Bullet = new Bullet()
                {
                    X = character.Navigation switch
                    {
                        Navigation.Left => character.X - 3,
                        Navigation.Right => character.X + 3,
                        _ => character.X,
                    },

                    Y = character.Navigation switch
                    {
                        Navigation.Up => character.Y - 2,
                        Navigation.Down => character.Y + 2,
                        _ => character.Y,
                    },
                    Navigation = character.Navigation,
                };
                character.IsShooting = false;
                continue;
            }

            if (character.IsDying)
            {
                character.DyingFrame++;
                Console.SetCursorPosition(character.X - 2, character.Y - 1);
                Render(character.DyingFrame > 9
                    ? CharactersDying[2]
                    : CharactersDying[character.DyingFrame % 2], true);
                continue;
            }

            bool MoveCheck(Character movingCharacter, int X, int Y)
            {
                foreach (var character in Characters)
                {
                    if (character == movingCharacter)
                    {
                        continue;
                    }
                    if (Math.Abs(character.X - X) <= 5 && Math.Abs(character.Y - Y) <= 3)
                    {
                        return false; // collision with another character
                    }
                }
                if (X < 3 || X > 68 || Y < 2 || Y > 24)
                {
                    return false; // collision with border walls
                }

               
                if (15 < X && X < 34 && 2 < Y && Y < 12)
                {
                    return false; // 1.square
                }
                if (38 < X && X < 57 && 2 < Y && Y < 12)
                {
                    return false; // 2.square
                }
                if (15 < X && X < 34 && 13 < Y && Y < 23)
                {
                    return false; // 3.square
                }
                if (38 < X && X < 57 && 13 < Y && Y < 23)
                {
                    return false; // 4.square
                }



                if (10 < X && X < 18 && 2 < Y && Y < 7)
                {
                    return false; // left top border
                }

                if (52 < X && X < 62 && 2 < Y && Y < 7)
                {
                    return false; // right top border
                }

                if (10 < X && X < 18 && 18 < Y && Y < 23)
                {
                    return false; // left bottom border
                }

                if (52 < X && X < 60 && 18 < Y && Y < 23)
                {
                    return false; // right bottom border
                }

                if (0 < X && X < 8 && 10 < Y && Y < 15)
                {
                    return false; // left middle border
                }

                if (65 < X && X < 73 && 10 < Y && Y < 15)
                {
                    return false; // right middle border
                }

                return true;
            }

        
            void TryMove(Navigation navigation)
            {

                switch (navigation)
                {
                    case Navigation.Up:
                        if (MoveCheck(character, character.X, character.Y - 1))
                        {

                            Console.SetCursorPosition(character.X - 3, character.Y + 2);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X - 2, character.Y + 2);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X - 1, character.Y + 2);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X, character.Y + 2);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 1, character.Y + 2);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 2, character.Y + 2);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 3, character.Y + 2);
                            Console.Write(' ');

                            character.Y--;
                        }
                        break;
                    case Navigation.Down:
                        if (MoveCheck(character, character.X, character.Y + 1))
                        {
                            //  Console.SetCursorPosition(character.X - 4, character.Y - 1);
                            //  Console.Write(' ');
                            Console.SetCursorPosition(character.X - 3, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X - 2, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X - 1, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 1, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 2, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 3, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 4, character.Y - 1);
                            Console.Write(' ');
                            character.Y++;
                        }
                        break;
                    case Navigation.Left:
                        if (MoveCheck(character, character.X - 1, character.Y))
                        {

                            Console.SetCursorPosition(character.X + 2, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 2, character.Y);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X + 2, character.Y + 1);
                            Console.Write(' ');

                            character.X--;
                        }
                        break;
                    case Navigation.Right:
                        if (MoveCheck(character, character.X + 1, character.Y))
                        {

                            Console.SetCursorPosition(character.X - 2, character.Y - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X - 2, character.Y);
                            Console.Write(' ');
                            Console.SetCursorPosition(character.X - 2, character.Y + 1);
                            Console.Write(' ');

                            character.X++;
                        }
                        break;
                }
            }

            if (character.IsTheOne)
            {
               
                Navigation? move = null;
                Navigation? shoot = null;

                while (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        // Move Direction
                        case ConsoleKey.W: move = move.HasValue ? Navigation.Null : Navigation.Up; break;
                        case ConsoleKey.S: move = move.HasValue ? Navigation.Null : Navigation.Down; break;
                        case ConsoleKey.A: move = move.HasValue ? Navigation.Null : Navigation.Left; break;
                        case ConsoleKey.D: move = move.HasValue ? Navigation.Null : Navigation.Right; break;

                        // Shoot Direction
                        case ConsoleKey.UpArrow: shoot = shoot.HasValue ? Navigation.Null : Navigation.Up; break;
                        case ConsoleKey.DownArrow: shoot = shoot.HasValue ? Navigation.Null : Navigation.Down; break;
                        case ConsoleKey.LeftArrow: shoot = shoot.HasValue ? Navigation.Null : Navigation.Left; break;
                        case ConsoleKey.RightArrow: shoot = shoot.HasValue ? Navigation.Null : Navigation.Right; break;

                        // Closes Game
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.Write("Game ended.");
                            return;
                    }
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                }

                character.IsShooting = shoot.HasValue && shoot.Value is not Navigation.Null && character.Bullet is null;
                if (character.IsShooting)
                {
                    character.Navigation = shoot ?? character.Navigation;
                }

                if (move.HasValue)
                    TryMove(move.Value);

            }
            else
            {
                
                int randomIndex = random.Next(0, 6);
                if (randomIndex < 4)
                    TryMove((Navigation)randomIndex + 1);

                if (character.Bullet is null)
                {
                    Navigation shoot = Math.Abs(character.X - Neo.X) > Math.Abs(character.Y - Neo.Y)
                        ? (character.X < Neo.X ? Navigation.Right : Navigation.Left)
                        : (character.Y > Neo.Y ? Navigation.Up : Navigation.Down);
                    character.Navigation = shoot;
                    character.IsShooting = true;
                }
            }

            Console.SetCursorPosition(character.X - 2, character.Y - 1);
            Render(character.IsDying
                ? CharactersDying[character.DyingFrame % 2]
                : character.IsShooting
                    ? CharactersShooting[(int)character.Navigation]
                    : Character[(int)character.Navigation],
                true);

        }


        bool BulletCollisionCheck(Bullet bullet, out Character combatCharacter)
        {
            combatCharacter = null;
            foreach (var character in Characters)
            {
                if (Math.Abs(bullet.X - character.X) < 4 && Math.Abs(bullet.Y - character.Y) < 3)
                {
                    combatCharacter = character;
                    return true;
                }
            }
            if (bullet.X is 0|| bullet.X is 74 || bullet.Y is 0 || bullet.Y is 27)
            {
                return true;

            }


            if (13 < bullet.X && bullet.X < 33 && bullet.Y == 5)
            {
                return true; //1.square top---
            }
            if (bullet.X == 18 && 4 < bullet.Y && bullet.Y < 11)
            {
                return true; // 1.square left|
            }
            if (bullet.X == 31 && 4 < bullet.Y && bullet.Y < 11)
            {
                return true; // 1.square right|
            }
            if (18 < bullet.X && bullet.X < 33 && bullet.Y == 10)
            {
                return true; // 1.square bottom---
            }



            if (41 < bullet.X && bullet.X < 61 && bullet.Y == 5)
            {
                return true; //2.square top---
            }
            if (bullet.X == 41 && 4 < bullet.Y && bullet.Y < 11)
            {
                return true; // 2.square left|
            }
            if (bullet.X == 54 && 4 < bullet.Y && bullet.Y < 11)
            {
                return true; // 2.square right|
            }
            if (41 < bullet.X && bullet.X < 56 && bullet.Y == 10)
            {
                return true; // 2.square bottom---
            }


            if (18 < bullet.X && bullet.X < 33 && bullet.Y == 16)
            {
                return true; //3.square top---
            }
            if (bullet.X == 18 && 15 < bullet.Y && bullet.Y < 22)
            {
                return true; // 3.square left|
            }
            if (bullet.X == 31 && 15 < bullet.Y && bullet.Y < 22)
            {
                return true; // 3.square right|
            }
            if (13 < bullet.X && bullet.X < 33 && bullet.Y == 21)
            {
                return true; // 3.square bottom---
            }


            if (41 < bullet.X && bullet.X < 56 && bullet.Y == 16)
            {
                return true; //4.square top---
            }
            if (bullet.X == 41 && 15 < bullet.Y && bullet.Y < 22)
            {
                return true; // 4.square left|
            }
            if (bullet.X == 54 && 15 < bullet.Y && bullet.Y < 22)
            {
                return true; // 4.square right|
            }
            if (41 < bullet.X && bullet.X < 61 && bullet.Y == 21)
            {
                return true; // 4.square bottom---
            }


            if (0 < bullet.X && bullet.X < 6 && bullet.Y == 13)
            {
                return true; // left middle edge
            }
            if (68 < bullet.X && bullet.X < 74 && bullet.Y == 13)
            {
                return true; // right middle edge
            }


        return false;
        }
    
        foreach (var character in AllCharacters)
        {
            if (character.Bullet is not null)
            {
                var bullet = character.Bullet;
                Console.SetCursorPosition(bullet.X, bullet.Y);
                Console.Write(' ');
                switch (bullet.Navigation)
                {
                    case Navigation.Up: bullet.Y--; break;
                    case Navigation.Down: bullet.Y++; break;
                    case Navigation.Left: bullet.X--; break;
                    case Navigation.Right: bullet.X++; break;
                }
                Console.SetCursorPosition(bullet.X, bullet.Y);
                bool combat = BulletCollisionCheck(bullet, out Character combatCharacter);
                Console.Write(combat
                    ? '.'
                    : Bullet[(int)bullet.Navigation]);
                if (combat)
                {
                    if (combatCharacter is not null && --combatCharacter.maxHealth <= 0)
                    {
                        combatCharacter.DyingFrame = 1;
                    }
                    character.Bullet = null;
                }
            }
        }

        
        for (int i = 0; i < Characters.Count; i++)
        {
            if (Characters[i].DyingFrame > 10)
            {
                Characters.RemoveAt(i);
                i--;
            }
        }


        Console.SetCursorPosition(0, 0);
        Render(MatrixMap);
        Thread.Sleep(TimeSpan.FromMilliseconds(50)); //character movement speed
}

    Console.SetCursorPosition(0, 33);
    Console.Write(Characters.Contains(Neo)
        ? "Neo, No One Has Ever Done Anything Like This Before. You Are The One!"
        : "Sorry, Kid. You Got The Gift, But It Looks Like You'Re Waiting For Something. Your Next Life, Maybe. Take A Cookie.");
    Console.ReadLine();

enum Navigation
{
    Null = 0,
    Up = 1,
    Down = 2,
    Left = 3,
    Right = 4,
};
class Character
{
    public int X;
    public int Y;
    public int maxHealth = 5;
    public bool IsTheOne;
    public Navigation Navigation = Navigation.Down;
    public Bullet Bullet;
    public bool IsShooting;
    public int DyingFrame;
    public bool IsDying => DyingFrame > 0;

}

class Bullet
{
    public int X;
    public int Y;
    public Navigation Navigation;
}




