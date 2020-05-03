using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassHockey
{
    public class Player
    {
        #region FIELDS

        private readonly string _name;
        private int _scores;
        private Position _position;
        private Half _half;

        public static byte _playersCount;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Scores
        {
            get
            {
                return _scores;
            }
            set
            {
                _scores = value;
            }
        }

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

        public Position Pos
        {
            get
            {
                return _position;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public Player(string name)
        {
            _name = name;
            _scores = 0;

            ++_playersCount;

            if (_playersCount == 1)
            {
                _position.X = Consts.PLAYER_TOP_START_POSITION_X;
                _position.Y = Consts.PLAYER_TOP_START_POSITION_Y;
                _half = Half.Top;
            }
            else
            {
                _position.X = Consts.PLAYER_BOTTOM_START_POSITION_X;
                _position.Y = Consts.PLAYER_BOTTOM_START_POSITION_Y;
                _half = Half.Bottom;
            }
        }

        #endregion

        #region METHODS

        public bool Move(PlayerDirection direction)
        {
            bool result = false;
            
            switch (direction)
            {
                case PlayerDirection.Left:
                    if (_position.X - Consts.PLAYER_HALF_WIDTH > 0)
                    {
                        --_position.X;
                        result = true;
                    }
                    break;
                case PlayerDirection.Right:
                    if (_position.X + Consts.PLAYER_HALF_WIDTH + 1 < Consts.FIELD_WIDTH)
                    {
                        ++_position.X;
                        result = true;
                    }
                    break;
                case PlayerDirection.Up:
                    if ((_position.Y - 1 != Consts.UPPER_POST_Y) &&
                            (_position.Y - 1 != Consts.FIELD_HEIGHT / 2 + 1))
                    {
                        --_position.Y;
                        result = true;
                    }
                    break;
                case PlayerDirection.Down:
                    if ((_position.Y + 1 != Consts.LOWER_POST_Y) &&
                            (_position.Y + 1 != Consts.FIELD_HEIGHT / 2 + 1))
                    {
                        ++_position.Y;
                        result = true;
                    }
                    break;
            }

            return result;
        }

        #endregion
    }
}
