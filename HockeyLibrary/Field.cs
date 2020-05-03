using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassHockey
{
    public class Field
    {
        #region FIELDS

        private Puck _puck;
        private Goal _topGoal;
        private Goal _bottomGoal;
        private Player _player1;
        private Player _player2;
        private readonly byte _width;
        private readonly byte _height;
        private readonly byte _top;
        private readonly byte _left;

        #endregion

        #region PROPERTIES

        public byte Width
        {
            get
            {
                return _width;
            }
        }

        public byte Height
        {
            get
            {
                return _height;
            }
        }

        public byte Top
        {
            get
            {
                return _top;
            }
        }

        public byte Left
        {
            get
            {
                return _left;
            }
        }

        public Player Player1
        {
            get
            {
                return _player1;
            }
        }

        public Player Player2
        {
            get
            {
                return _player2;
            }
        }

        public Puck CurrentPuck
        {
            get
            {
                return _puck;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public Field (string player1Name, string player2Name)
        {
            _puck = new Puck();
            _topGoal = new Goal(1);
            _bottomGoal = new Goal(2);

            Player._playersCount = 0;
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);

            _width = Consts.FIELD_WIDTH;
            _height = Consts.FIELD_HEIGHT;
            _top = Consts.FIELD_TOP;
            _left = Consts.FIELD_LEFT;
        }

        #endregion
    }
}
