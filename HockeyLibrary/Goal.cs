using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassHockey
{
    public class Goal
    {
        #region FIELDS

        private readonly Position _leftPost;
        private readonly Position _rightPost;
        private readonly byte _depth;
        private Half _half;

        #endregion

        #region PROPERTIES

        public byte Depth
        {
            get
            {
                return _depth;
            }
        }

        public sbyte LeftPostX
        {
            get
            {
                return _leftPost.X;
            }
        }

        public sbyte RightPostX
        {
            get
            {
                return _rightPost.X;
            }
        }

        public sbyte PostY
        {
            get
            {
                return _leftPost.Y;
            }
        }

        public sbyte BackY
        {
            get
            {
                sbyte result;

                if (_half == Half.Top)
                {
                    result = (sbyte)(_leftPost.Y - _depth);
                }
                else
                {
                    result = (sbyte)(_leftPost.Y + _depth);
                }

                return result;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public Goal(int half)
        {
            _depth = Consts.POST_DEPTH;
            
            if (half == 1)
            {
                _half = Half.Top;
                _leftPost.X = Consts.LEFT_POST_X; 
                _leftPost.Y = Consts.UPPER_POST_Y;
                _rightPost.X = Consts.RIGHT_POST_X;
                _rightPost.Y = Consts.UPPER_POST_Y;
            }
            else
            {
                _half = Half.Bottom;
                _leftPost.X = Consts.LEFT_POST_X;
                _leftPost.Y = Consts.LOWER_POST_Y;
                _rightPost.X = Consts.RIGHT_POST_X;
                _rightPost.Y = Consts.LOWER_POST_Y;
            }
        }

        #endregion
    }
}
