using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassHockey
{
    public class Puck
    {
        #region FIELDS

        private Position _position;
        private PuckDirection _direction;

        #endregion

        #region PROPERTIES

        public sbyte X
        {
            get
            {
                return _position.X;
            }
            set
            {
                _position.X = value;
            }
        }

        public sbyte Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }

        public PuckDirection PuckDirection
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public Puck()
        {
            _position.X = (Consts.FIELD_WIDTH + 1) / 2;
            _position.Y = (Consts.FIELD_HEIGHT + 1) / 2;

            Random rnd = new Random();

            int startPuckPosition = rnd.Next(0, 5);

            _direction = PuckDirection.LeftLeftTop + startPuckPosition;
        }

        #endregion

        public void BeatToTop()
        {
            ++_position.Y;

            PuckDirection = PuckDirection.RightRightTop + (8 - (int)PuckDirection);
        }

        public void BeatToBottom()
        {
            --_position.Y;

            PuckDirection = PuckDirection.RightRightTop - ((int)PuckDirection - 8);
        }

        public void BeatToLeft()
        {
            ++_position.X;

            if (PuckDirection < PuckDirection.Top)
            {
                PuckDirection = PuckDirection.Top + (3 - (int)PuckDirection);
            }

            if (PuckDirection > PuckDirection.Bottom)
            {
                PuckDirection = PuckDirection.Bottom - ((int)PuckDirection - 11);
            }
        }

        public void BeatToRight()
        {
            --_position.X;

            if (PuckDirection <= PuckDirection.RightRightTop)
            {
                PuckDirection = PuckDirection.Top - ((int)PuckDirection - 3);
            }

            if (PuckDirection > PuckDirection.RightRightTop)
            {
                PuckDirection = PuckDirection.Bottom + (11 - (int)PuckDirection);
            }
        }

        public void BeatToPlayer(int playerPart)
        {
            if ((byte)_direction > 8)
            {
                _direction = PuckDirection.LeftTop + playerPart;
            }
            else
            {
                _direction = PuckDirection.LeftBottom - playerPart;
            }
        }

        public void Move(bool PuckMoment, ref bool IsScore)
        {
            sbyte Vertical = 0;     //Для визначення напрямку після удару в кут або штангу
            
            if ((PuckDirection > PuckDirection.LeftLeftTop) && 
                    (PuckDirection < PuckDirection.RightRightTop))
            {
                --_position.Y;
                Vertical = -1;
            }

            if (((PuckDirection == PuckDirection.LeftLeftTop) || 
                    (PuckDirection == PuckDirection.RightRightTop)) && PuckMoment)
            {
                --_position.Y;
                Vertical = -1;
            }

            if ((PuckDirection > PuckDirection.RightRightBottom) && 
                    (PuckDirection < PuckDirection.LeftLeftBottom))
            {
                ++_position.Y;
                Vertical = 1;
            }

            if (((PuckDirection == PuckDirection.RightRightBottom) || 
                    (PuckDirection == PuckDirection.LeftLeftBottom)) && PuckMoment)
            {
                ++_position.Y;
                Vertical = 1;
            }

            if (((PuckDirection >= PuckDirection.LeftLeftTop) && 
                    (PuckDirection < PuckDirection.LeftTopTop)) ||
                    ((PuckDirection > PuckDirection.LeftBottomBottom) && 
                    (PuckDirection <= PuckDirection.LeftLeftBottom)))
            {
                --_position.X;
            }

            if (((PuckDirection == PuckDirection.LeftTopTop) || 
                    (PuckDirection == PuckDirection.LeftBottomBottom)) && PuckMoment)
            {
                --_position.X;
            }

            if ((PuckDirection > PuckDirection.RightTopTop) && 
                    (PuckDirection < PuckDirection.RightBottomBottom))
            {
                ++_position.X;
            }

            if (((PuckDirection == PuckDirection.RightTopTop) || 
                    (PuckDirection == PuckDirection.RightBottomBottom)) && PuckMoment)
            {
                ++_position.X;
            }

            //Борти
            if (_position.X <= -1)
            {
                BeatToLeft();
            }

            if (_position.X == Consts.FIELD_WIDTH)
            {
                BeatToRight();
            }

            if (_position.Y == 0)
            {
                BeatToTop();
            }

            if (_position.Y > Consts.FIELD_HEIGHT)
            {
                BeatToBottom();
            }

            //Каркас воріт
            if (((_position.X > Consts.LEFT_POST_X) && 
                    (_position.X < Consts.RIGHT_POST_X)) &&
                    (_position.Y == Consts.UPPER_POST_Y - Consts.POST_DEPTH + 1))
            {
                BeatToBottom();
            }

            if (((_position.X > Consts.LEFT_POST_X) &&
                    (_position.X < Consts.RIGHT_POST_X)) &&
                    (_position.Y == Consts.LOWER_POST_Y + Consts.POST_DEPTH - 1))
            {
                BeatToTop();
            }

            //TODO: перебороти лінощі і переробити алгоритм потрапляння у боковий каркас на нормальний
            if (((_position.Y == Consts.UPPER_POST_Y - 1) ||
                    (_position.Y == Consts.LOWER_POST_Y + 1)) &&
                    (_position.X == Consts.LEFT_POST_X))
            {
                BeatToRight();
            }

            if (((_position.Y == Consts.UPPER_POST_Y - 1) ||
                    (_position.Y == Consts.LOWER_POST_Y + 1)) &&
                    (_position.X == Consts.RIGHT_POST_X))
            {
                BeatToLeft();
            }

            //Кут воріт
            if (((_position.X == Consts.LEFT_POST_X) ||
                    (_position.X == Consts.RIGHT_POST_X)) && (Vertical == 1) &&
                    (_position.Y == Consts.UPPER_POST_Y - Consts.POST_DEPTH + 1))
            {
                BeatToBottom();
            }

            if (((_position.X == Consts.LEFT_POST_X) ||
                    (_position.X == Consts.RIGHT_POST_X)) && (Vertical == -1) &&
                    (_position.Y == Consts.LOWER_POST_Y + Consts.POST_DEPTH - 1))
            {
                BeatToTop();
            }

            if ((_position.X == Consts.LEFT_POST_X) && (Vertical == -1) &&
                    (_position.Y == Consts.UPPER_POST_Y - Consts.POST_DEPTH + 1))
            {
                BeatToRight();
            }

            if ((_position.X == Consts.LEFT_POST_X) && (Vertical == 1) &&
                    (_position.Y == Consts.LOWER_POST_Y + Consts.POST_DEPTH - 1))
            {
                BeatToRight();
            }

            if ((_position.X == Consts.RIGHT_POST_X) && (Vertical == -1) &&
                    (_position.Y == Consts.UPPER_POST_Y - Consts.POST_DEPTH + 1))
            {
                BeatToLeft();
            }

            if ((_position.X == Consts.RIGHT_POST_X) && (Vertical == 1) &&
                    (_position.Y == Consts.LOWER_POST_Y + Consts.POST_DEPTH - 1))
            {
                BeatToLeft();
            }

            //Штанга
            if (((_position.X == Consts.LEFT_POST_X) ||
                    (_position.X == Consts.RIGHT_POST_X)) && (Vertical == -1) &&
                    (_position.Y == Consts.UPPER_POST_Y))
            {
                BeatToTop();
            }

            if (((_position.X == Consts.LEFT_POST_X) ||
                    (_position.X == Consts.RIGHT_POST_X)) && (Vertical == 1) &&
                    (_position.Y == Consts.LOWER_POST_Y))
            {
                BeatToBottom();
            }

            if ((_position.X == Consts.LEFT_POST_X) && (Vertical != -1) &&
                    (_position.Y == Consts.UPPER_POST_Y))
            {
                BeatToRight();
            }

            if ((_position.X == Consts.LEFT_POST_X) && (Vertical != 1) &&
                    (_position.Y == Consts.LOWER_POST_Y))
            {
                BeatToRight();
            }

            if ((_position.X == Consts.RIGHT_POST_X) && (Vertical != -1) &&
                    (_position.Y == Consts.UPPER_POST_Y))
            {
                BeatToLeft();
            }

            if ((_position.X == Consts.RIGHT_POST_X) && (Vertical != 1) &&
                    (_position.Y == Consts.LOWER_POST_Y))
            {
                BeatToLeft();
            }

            //ГООООООООООООООООООООООЛ!!!!!
            if ((_position.X > Consts.LEFT_POST_X) && 
                    (_position.X < Consts.RIGHT_POST_X) &&
                    ((_position.Y == Consts.UPPER_POST_Y) ||
                    (_position.Y == Consts.LOWER_POST_Y)))
            {
                IsScore = true;
            }
            else
            {
                IsScore = false;
            }
        }
    }
}
