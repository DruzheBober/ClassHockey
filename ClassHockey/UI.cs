using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHockey
{
    class UI
    {
        public static void PlayMusic()
        {
            Console.Beep(250, 300);
            Console.Beep(250, 300);
            Console.Beep(220, 200);
            Console.Beep(220, 200);
            Console.Beep(250, 300);
        }

        public static void ShowWelcomeLabel()
        {
            Console.SetCursorPosition(10, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("********************");
            Console.SetCursorPosition(10, 1);
            Console.WriteLine("* ВІТАЄМО В ХОКЕЇ! *");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("********************");
            Console.WriteLine();            
        }

        public static void DrawGoalie()
        {
            Console.WindowWidth = Consts.WINDOW_WIDTH;
            Console.WindowHeight = Consts.WINDOW_HEIGHT;
            Console.WindowTop = Consts.WINDOW_TOP;

            //Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorTop = 3;
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░░░░░░░░░░░▄████▄░░░░░░░░░░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░░░░░░░░░░▄██████▄░░░░░░░░░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░░░░░░░░░░▀█▀▄▀▄█▀░░░░░░░░░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░░░░░▄▄▄▄███▀▄▀▄███▄▄▄▄░░░░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░░░░▄█░▀████░░▀░████▀░█▄▄░░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("▄░░░░░▄█▄░▀▄█████▄▄█████▄█▀▄▄█░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("▀▄░░░░█░░█▄▀████████████▀▄█▀░░█░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░▀██████▄░█░████████████░▀▄░░░█▄░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░██████▀░░█░░▀▀▀▀▀▀░░█░░░▀▄████▄");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░███████░░███▀▀█▄▄█▀▀███░░░██████");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░██████░░██▀░░░░█░░░░░░▀█▄░░▀████");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░▀█████▄█▀░░░░░░█▄░░░░░░▀█▄░░░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░░░██▄░░░░░░▄▀▀▄░░░░░░░▀█░░░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░░█▀░▀█░░░░▀░░░░▀▄░░░░░░▀█▄░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░█▀░░░░█▄▄▀░░░░░░▀▄░░░░░░░█░░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░█▀░░░░░░█▄░░░░░░░░░█░░░░░░▀█░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░█░░░░░▄▀░▀█▄▄▄▄▄▄▄░░▀▄░░░░░█░░");
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.WriteLine("░░░░░▀▄▄▄█░░░░░▀▀████▀░░░░█▄▄▄▀░░░");
        }

        public static string EnterTeamName(string showedText, int teamNumber)
        {
            Console.WriteLine("{0} {1}", showedText, teamNumber);

            string teamName = Console.ReadLine();

            if (teamName.Length > Consts.FIELD_LEFT)
            {
                teamName = teamName.Substring(1, Consts.FIELD_LEFT);
            }

            return teamName;
        }

        public static byte EnterGameLength(string showedText)
        {
            Console.Write(showedText);
            byte gameLength;

            while (!(byte.TryParse(Console.ReadLine(), out gameLength)))
            {
                Console.Write(showedText);
            }

            return gameLength;
        }

        public static bool EnterOvertimeSettings(string showedText)
        {
            Console.Write(showedText);
            string userAnswer = Console.ReadLine();

            if ((userAnswer.ToLower() == "n") || (userAnswer.ToLower() == "т"))
            {
                return false;
            }

            return true;
        }

        public static void ClearScreen()
        {
            Console.SetCursorPosition(0, 3);

            for (int i = 0; i < Consts.FIELD_HEIGHT; i++)
            {
                for (int j = 0; j < Consts.FIELD_LEFT + Consts.FIELD_WIDTH; j++)
                {
                    Console.Write(' ');
                }

                Console.WriteLine();
            }
        }

        public static void DrawIceRink()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.CursorTop = Consts.FIELD_TOP;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('┌');

            for (int i = 0; i < Consts.FIELD_WIDTH; i++)
            {
                Console.Write('─');
            }

            Console.WriteLine('┐');

            DrawVerticalLines();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.Write('├');

            for (int i = 0; i < Consts.FIELD_WIDTH; i++)
            {
                Console.Write('─');
            }

            Console.WriteLine('┤');

            DrawVerticalLines();

            Console.CursorLeft = Consts.FIELD_LEFT;
            Console.Write('└');

            for (int i = 0; i < Consts.FIELD_WIDTH; i++)
            {
                Console.Write('─');
            }

            Console.WriteLine('┘');

            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorTop = Consts.UPPER_POST_Y - Consts.POST_DEPTH + 1;
            Console.CursorLeft = Consts.FIELD_LEFT + Consts.LEFT_POST_X + 1;
            Console.Write('┌');

            for (int i = Consts.LEFT_POST_X + 1; i < Consts.RIGHT_POST_X; i++)
            {
                Console.Write('─');
            }

            Console.WriteLine('┐');
            DrawNet();
            DrawNet();

            Console.CursorTop = Consts.LOWER_POST_Y;
            DrawNet();
            DrawNet();
            Console.CursorLeft = Consts.FIELD_LEFT + Consts.LEFT_POST_X + 1;
            Console.CursorLeft = Consts.FIELD_LEFT + Consts.LEFT_POST_X + 1;
            Console.Write('└');

            for (int i = Consts.LEFT_POST_X + 1; i < Consts.RIGHT_POST_X; i++)
            {
                Console.Write('─');
            }

            Console.WriteLine('┘');
        }

        public static void DrawVerticalLines()
        {
            for (int i = 0; i < Consts.FIELD_HEIGHT / 2; i++)
            {
                Console.CursorLeft = Consts.FIELD_LEFT;
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write('│');

                for (int j = 0; j < Consts.FIELD_WIDTH; j++)
                {
                    Console.Write(' ');
                }

                Console.WriteLine('│');
            }
        }

        public static void DrawNet()
        {
            Console.CursorLeft = Consts.FIELD_LEFT + Consts.LEFT_POST_X + 1;
            Console.Write('│');

            for (int i = Consts.LEFT_POST_X + 1; i < Consts.RIGHT_POST_X; i++)
            {
                Console.Write('X');
            }

            Console.WriteLine('│');
        }

        public static void ShowScore(string team1, string team2, byte periodNo, byte periodLength)
        {
            Console.SetCursorPosition(0, 4);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(team1);

            for (int i = team1.Length; i < Consts.FIELD_LEFT - 5; i++)
            {
                Console.Write(' ');
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("- 0");

            Console.SetCursorPosition(0, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(team2);

            for (int i = team2.Length; i < Consts.FIELD_LEFT - 5; i++)
            {
                Console.Write(' ');
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("- 0");

            ChangePeriodNumber(1);
            ChangePeriodTime(periodLength * 60);
        }

        public static void ChangePeriodNumber(int period)
        {
            Console.SetCursorPosition(0, 7);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("{0} період", period);
        }

        public static void ChangePeriodTime(int time)
        {
            Console.SetCursorPosition(0, 8);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            int minuteCount = time / 60;
            int secondCount = time % 60;

            if (secondCount > 9)
            {
                Console.WriteLine("{0}:{1} ", minuteCount, secondCount);
            }
            else
            {
                Console.WriteLine("{0}:0{1} ", minuteCount, secondCount);
            }
        }

        public static void GameBrake()
        {
            Console.SetCursorPosition(0, Consts.MESSAGE_STRING_NUMBER);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Натисніть будь-яку кнопку для початку гри...");
        }

        public static void ClearString(int stringNumber)
        {
            Console.SetCursorPosition(0, stringNumber);
            Console.BackgroundColor = ConsoleColor.Black;

            for (int j = 0; j < Consts.FIELD_LEFT - 2; j++)
            {
                Console.Write(' ');
            }
        }

        public static void DrawPlayer(int positionX, int positionY)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(positionX + Consts.FIELD_LEFT - 1, 
                    positionY + Consts.FIELD_TOP);
            for (int i = 0; i < Consts.PLAYER_WIDTH; i++)
            {
                Console.Write(" ");
            }
            
        }

        public static void DrawPlayer(Position playerPosition, PlayerDirection direction)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(playerPosition.X + Consts.FIELD_LEFT - 1,
                    playerPosition.Y + Consts.FIELD_TOP);
            for (int i = 0; i < Consts.PLAYER_WIDTH; i++)
            {
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.White;

            switch (direction)
            {
                case PlayerDirection.Left:
                    Console.SetCursorPosition(
                            playerPosition.X + Consts.FIELD_LEFT + Consts.PLAYER_HALF_WIDTH + 2,
                            playerPosition.Y + Consts.FIELD_TOP);
                    Console.Write(" ");
                    break;
                case PlayerDirection.Right:
                    Console.SetCursorPosition(
                            playerPosition.X + Consts.FIELD_LEFT - Consts.PLAYER_HALF_WIDTH,
                            playerPosition.Y + Consts.FIELD_TOP);
                    Console.Write(" ");
                    break;
                case PlayerDirection.Up:
                    Console.SetCursorPosition(
                            playerPosition.X + Consts.FIELD_LEFT - 1,
                            playerPosition.Y + Consts.FIELD_TOP + 1);
                    Console.Write("     ");
                    break;
                case PlayerDirection.Down:
                    Console.SetCursorPosition(
                            playerPosition.X + Consts.FIELD_LEFT - 1,
                            playerPosition.Y + Consts.FIELD_TOP - 1);
                    Console.Write("     ");
                    break;
            }
        }
        
        public static void DrawPlayer(ref int positionX, ref int positionY, 
                int oldPositionX = 100, int oldPositionY = 100)
        {
            if (((positionX - 2) < 0) || (positionX > 37))
            {
                Console.Beep(200, 150);
                positionX = oldPositionX;
            }

            if ((positionY == 21) || (positionY < 7) || (positionY > 36))
            {
                Console.Beep(200, 150);
                positionY = oldPositionY;
            }

            if ((oldPositionX != 100) && (oldPositionY != 100))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(oldPositionX - 2 + 51, oldPositionY);
                Console.Write("     ");
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(positionX - 2 + 51, positionY);
            for (int i = 0; i < Consts.PLAYER_WIDTH; i++)
            {
                Console.Write(" ");
            }
        }

        public static void DrawPuck(Position position, Position oldPosition, bool isPlayer)
        {
            if (isPlayer)
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
            }            
            Console.SetCursorPosition(oldPosition.X, oldPosition.Y);
            if (oldPosition.Y != Consts.FIELD_WIDTH / 2 + 1)
            {
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("─");
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("*");
        }

        public static void DrawPuck(int x, int y, int oldX, int oldY, bool isPlayer)
        {
            Position newPosition;
            Position oldPosition;

            newPosition.X = (sbyte)x;
            newPosition.Y = (sbyte)y;
            oldPosition.X = (sbyte)oldX;
            oldPosition.Y = (sbyte)oldY;

            DrawPuck(newPosition, oldPosition, isPlayer);
        }

        public static void DrawNetAfterScore(int positionY)
        {
            Console.SetCursorPosition(65, positionY);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('│');

            for (int i = Consts.LEFT_POST_X + 1; i < Consts.RIGHT_POST_X; i++)
            {
                Console.Write('X');
            }

            Console.WriteLine('│');
        }

        public static void AddScore(byte teamNumber, int score, string teamName)
        {
            Console.SetCursorPosition(Consts.FIELD_LEFT - 3, 3 + teamNumber);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(score);

            ClearString(10);
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Гол {0}!!!", teamName);
        }

        public static void IcePrepearing(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x + Consts.FIELD_LEFT + 1, y);
            if (y != Consts.FIELD_WIDTH / 2 + 1)
            {
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("─");
            }
        }

        public static void ShowAllScores(LinkedList<string> scores)
        {
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            
            foreach(string item in scores)
            {
                Console.WriteLine(item);
            }
        }
    }
}
