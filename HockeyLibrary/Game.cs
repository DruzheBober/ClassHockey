using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassHockey
{
    public class Game
    {
        #region FIELDS

        private readonly byte _periodsCount;
        private readonly byte _periodLength;
        private readonly byte _gameSpeed;
        private readonly bool _isOverTime;
        private readonly bool _isGoldenGoal;
        private readonly bool _isTwoPlayers;
        private Field _field;

        #endregion

        #region PROPERTIES

        public byte PeriodsCount
        {
            get
            {
                return _periodsCount;
            }
        }

        public byte PeriodLength
        {
            get
            {
                return _periodLength;
            }
        }

        public byte GameSpeed
        {
            get
            {
                return _gameSpeed;
            }
        }

        public bool IsOverTime
        {
            get
            {
                return _isOverTime;
            }
        }

        public bool IsGoldenGoal
        {
            get
            {
                return _isGoldenGoal;
            }
        }

        public bool IsTwoPlayers
        {
            get
            {
                return _isTwoPlayers;
            }
        }

        public Field IceField
        {
            get
            {
                return _field;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public Game(byte periodsCount, byte periodLength, byte gameSpeed, 
                bool isOverTime, bool isGoldenGoal, bool isTwoPlayers,
                string player1Name, string player2Name)
        {
            _periodsCount = periodsCount;
            _periodLength = PeriodLength;
            _gameSpeed = gameSpeed;
            _isOverTime = isOverTime;
            _isGoldenGoal = isGoldenGoal;
            _isTwoPlayers = isTwoPlayers;

            _field = new Field(player1Name, player2Name);
        }

        #endregion
    }
}
