using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassHockey
{
    class Program
    {
        delegate void UIRunner();
        
        static void Main(string[] args)
        {
            Console.Title = "Веселий консольний хокей з класами";

            UIRunner u = UI.PlayMusic;
            u += UI.DrawGoalie;
            u += UI.ShowWelcomeLabel;

            u();

            string team1 = UI.EnterTeamName("Введіть назву команди", 1);
            string team2 = UI.EnterTeamName("Введіть назву команди", 2);

            byte periodsCount = UI.EnterGameLength("Введіть кількість періодів: ");
            byte periodLength = UI.EnterGameLength("Введіть кількість хвилин в періоді: ");
            byte gameSpeed;

            do
            {
                gameSpeed = UI.EnterGameLength("Введіть швидкість гри, 0-9: ");
            }
            while (gameSpeed > 9);

            bool isOvertime = UI.EnterOvertimeSettings("Чи потрібний овертайм в разі нічиєї (y/n): ");

            bool isGoldenGoal = false;
            
            if (isOvertime)
            {
                isGoldenGoal = UI.EnterOvertimeSettings("Чи застосовуємо золотий гол в овертаймі (y/n): ");
            }
            
            bool isTwoPlayers = UI.EnterOvertimeSettings("Граємо удвох (y/n): ");

            Game ourGame = new Game(periodsCount, periodLength, gameSpeed, isOvertime, 
                    isGoldenGoal, isTwoPlayers, team1, team2);

            u = UI.ClearScreen;
            u += UI.DrawIceRink;
            u();
            
            UI.ShowScore(team1, team2, 1, periodLength);

            int periodTime = periodLength * 60;
            int gametime = 0;

            u = UI.GameBrake;
            u();

            ConsoleKeyInfo info = Console.ReadKey();
            bool isKeyPressed;

            UI.ClearString(Consts.MESSAGE_STRING_NUMBER);
            byte periodNumber = 1;

            UI.DrawPlayer(Consts.PLAYER_TOP_START_POSITION_X, 
                    Consts.PLAYER_TOP_START_POSITION_Y);
            UI.DrawPlayer(Consts.PLAYER_BOTTOM_START_POSITION_X, 
                    Consts.PLAYER_BOTTOM_START_POSITION_Y);
            UI.DrawPuck(Consts.FIELD_LEFT + Consts.FIELD_WIDTH / 2 + 1,
                    Consts.FIELD_HEIGHT / 2 + 1,
                    Consts.FIELD_LEFT + Consts.FIELD_WIDTH / 2 + 1,
                    Consts.FIELD_HEIGHT / 2 + 1, false);

            Random rnd = new Random();
            int puckDirection;

            do
            {
                puckDirection = rnd.Next(0, 15);
            }
            while (puckDirection == 7);

            ourGame.IceField.CurrentPuck.PuckDirection = PuckDirection.LeftLeftTop + 
                    puckDirection;

            bool isScore;
            bool puckMoment = false;
            bool isPlay = false;

            LinkedList<string> scoreHistory = new LinkedList<string>();

            do
            {
                do
                {
                    if (Console.KeyAvailable)
                    {
                        isKeyPressed = true;
                    }
                    else
                    {
                        isKeyPressed = false;
                    }

                    if (isKeyPressed)
                    {
                        info = Console.ReadKey(true);

                        if (info.Key == ConsoleKey.LeftArrow)
                        {
                            if (ourGame.IceField.Player1.Move(PlayerDirection.Left))
                            {
                                UI.DrawPlayer(ourGame.IceField.Player1.Pos, PlayerDirection.Left);
                            }
                        }

                        if (info.Key == ConsoleKey.RightArrow)
                        {
                            if (ourGame.IceField.Player1.Move(PlayerDirection.Right))
                            {
                                UI.DrawPlayer(ourGame.IceField.Player1.Pos, PlayerDirection.Right);
                            }
                        }

                        if (info.Key == ConsoleKey.UpArrow)
                        {
                            if (ourGame.IceField.Player1.Move(PlayerDirection.Up))
                            {
                                UI.DrawPlayer(ourGame.IceField.Player1.Pos, PlayerDirection.Up);
                            }
                        }

                        if (info.Key == ConsoleKey.DownArrow)
                        {
                            if (ourGame.IceField.Player1.Move(PlayerDirection.Down))
                            {
                                UI.DrawPlayer(ourGame.IceField.Player1.Pos, PlayerDirection.Down);
                            }
                        }

                        if (isTwoPlayers)
                        {
                            if (info.Key == ConsoleKey.A)
                            {
                                if (ourGame.IceField.Player2.Move(PlayerDirection.Left))
                                {
                                    UI.DrawPlayer(ourGame.IceField.Player2.Pos, PlayerDirection.Left);
                                }
                            }

                            if (info.Key == ConsoleKey.D)
                            {
                                if (ourGame.IceField.Player2.Move(PlayerDirection.Right))
                                {
                                    UI.DrawPlayer(ourGame.IceField.Player2.Pos, PlayerDirection.Right);
                                }
                            }

                            if (info.Key == ConsoleKey.W)
                            {
                                if (ourGame.IceField.Player2.Move(PlayerDirection.Up))
                                {
                                    UI.DrawPlayer(ourGame.IceField.Player2.Pos, PlayerDirection.Up);
                                }
                            }

                            if (info.Key == ConsoleKey.S)
                            {
                                if (ourGame.IceField.Player2.Move(PlayerDirection.Down))
                                {
                                    UI.DrawPlayer(ourGame.IceField.Player2.Pos, PlayerDirection.Down);
                                }
                            }
                        }
                    }

                    gametime++;

                    if ((gametime % 100) == 0)
                    {
                        periodTime--;
                        UI.ChangePeriodTime(periodTime);
                    }

                    isScore = false;

                    if (gametime % (20 / (gameSpeed + 1)) == 0)
                    {
                        Position puckOldPosition;
                        puckOldPosition.X = ourGame.IceField.CurrentPuck.X;
                        puckOldPosition.Y = ourGame.IceField.CurrentPuck.Y;
                        
                        ourGame.IceField.CurrentPuck.Move(puckMoment, ref isScore);

                        puckMoment = !(puckMoment);

                        UI.DrawPuck(ourGame.IceField.CurrentPuck.X + Consts.FIELD_LEFT + 1,
                                ourGame.IceField.CurrentPuck.Y,
                                puckOldPosition.X + Consts.FIELD_LEFT + 1, puckOldPosition.Y, 
                                isPlay);

                        isPlay = false;
                        
                        int puckX = ourGame.IceField.CurrentPuck.X;
                        int puckY = ourGame.IceField.CurrentPuck.Y;
                        int player1X = ourGame.IceField.Player1.X;
                        int player1Y = ourGame.IceField.Player1.Y;
                        int player2X = ourGame.IceField.Player2.X;
                        int player2Y = ourGame.IceField.Player2.Y;
                        
                        if ((puckY == player1Y) && 
                                (puckX >= player1X - Consts.PLAYER_HALF_WIDTH) && 
                                (puckX <= player1X + Consts.PLAYER_HALF_WIDTH))
                        {
                            int direct = Consts.PLAYER_WIDTH - 1 -
                                    (player1X + Consts.PLAYER_HALF_WIDTH - puckX);
                            ourGame.IceField.CurrentPuck.BeatToPlayer(direct);
                            isPlay = true;
                        }

                        if ((puckY == player2Y) &&
                                (puckX >= player2X - Consts.PLAYER_HALF_WIDTH) &&
                                (puckX <= player2X + Consts.PLAYER_HALF_WIDTH))
                        {
                            int direct = Consts.PLAYER_WIDTH - 1 -
                                    (player2X + Consts.PLAYER_HALF_WIDTH - puckX);
                            ourGame.IceField.CurrentPuck.BeatToPlayer(direct);
                            isPlay = true;
                        }
                    }

                    if (isScore)
                    {
                        if (ourGame.IceField.CurrentPuck.Y < Consts.FIELD_HEIGHT / 2)
                        {
                            ++ourGame.IceField.Player2.Scores;
                            UI.AddScore(2, ourGame.IceField.Player2.Scores, team2);
                            Console.Beep(300, 1000);
                            Thread.Sleep(2000);
                            UI.DrawNetAfterScore(Consts.UPPER_POST_Y);
                        }
                        else
                        {
                            ++ourGame.IceField.Player1.Scores;
                            UI.AddScore(1, ourGame.IceField.Player1.Scores, team1);
                            Console.Beep(300, 1000);
                            Thread.Sleep(2000);
                            UI.DrawNetAfterScore(Consts.LOWER_POST_Y);
                        }

                        string seconds;

                        if (periodTime % 60 > 9)
                        {
                            seconds = Convert.ToString(periodTime % 60);
                        }
                        else
                        {
                            seconds = "0"+periodTime % 60;
                        }
                        
                        scoreHistory.AddLast(string.Format("{4} період. {0}.{1} - {2}:{3}",
                                periodTime / 60, seconds,
                                ourGame.IceField.Player1.Scores, 
                                ourGame.IceField.Player2.Scores,
                                periodNumber));
                        
                        ourGame.IceField.CurrentPuck.X = (Consts.FIELD_WIDTH + 1) / 2;
                        ourGame.IceField.CurrentPuck.Y = (Consts.FIELD_HEIGHT + 1) / 2;
                        
                        UI.DrawPuck(Consts.FIELD_LEFT + Consts.FIELD_WIDTH / 2 + 1,
                                    Consts.FIELD_HEIGHT / 2 + 1,
                                    Consts.FIELD_LEFT + Consts.FIELD_WIDTH / 2 + 1,
                                    Consts.FIELD_HEIGHT / 2 + 1, false);
                        
                        do
                        {
                            puckDirection = rnd.Next(0, 15);
                        }
                        while (puckDirection == 7);

                        ourGame.IceField.CurrentPuck.PuckDirection = 
                                PuckDirection.LeftLeftTop + puckDirection;
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
                while (periodTime > 0);

                Console.Beep(400, 1000);
                periodNumber++;
                UI.ChangePeriodNumber(periodNumber);
                UI.GameBrake();

                gametime = 0;
                periodTime = periodLength * 60;

                UI.IcePrepearing(ourGame.IceField.CurrentPuck.X, 
                        ourGame.IceField.CurrentPuck.Y);

                ourGame.IceField.CurrentPuck.X = (Consts.FIELD_WIDTH + 1) / 2;
                ourGame.IceField.CurrentPuck.Y = (Consts.FIELD_HEIGHT + 1) / 2;

                do
                {
                    puckDirection = rnd.Next(0, 15);
                }
                while (puckDirection == 7);

                ourGame.IceField.CurrentPuck.PuckDirection =
                        PuckDirection.LeftLeftTop + puckDirection;

                Console.ReadKey();

                UI.DrawPuck(Consts.FIELD_LEFT + Consts.FIELD_WIDTH / 2 + 1,
                            Consts.FIELD_HEIGHT / 2 + 1,
                            Consts.FIELD_LEFT + Consts.FIELD_WIDTH / 2 + 1,
                            Consts.FIELD_HEIGHT / 2 + 1, false);

                UI.ClearString(Consts.MESSAGE_STRING_NUMBER);
            }
            while ((periodNumber <= periodsCount) ||
                ((periodNumber == periodsCount) && 
                    (ourGame.IceField.Player1.Scores == ourGame.IceField.Player2.Scores) && (isOvertime)));

            Console.ReadKey();

            UI.ShowAllScores(scoreHistory);

            Console.ReadKey();
        }
    }
}
