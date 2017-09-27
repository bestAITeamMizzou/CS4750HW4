using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4750HW4
{
    class GameBoard
    {
        /***************ATTRIBUTES***************/
        //Fields

        //Properties
        private BoardVals[,] Board { get; set; }


        /***************CONSTRUCTOR***************/
        public GameBoard ()
        {
            initGameBoard();
        } //End 

        /***************METHODS***************/
        private bool isValidSpace(Point tile)
        {
            //Declare variables
            bool returnVal = false;

            if ((tile.X >= 0 && tile.X < 5) && (tile.Y >= 0 && tile.Y < 6))
            {
                returnVal = true;
            } //End if ((tile.X >= 0 && tile.X < 5) && (tile.Y >= 0 && tile.Y < 6))

            return returnVal;
        } //End private bool isValidSpace(Point tile)

        public bool isValidSpace(Point tileToConsider, BoardVals valToConsider)
        {
            //Declare variables
            bool returnVal = false;

            if ((tileToConsider.X >= 0 && tileToConsider.X < 5) && (tileToConsider.Y >= 0 && tileToConsider.Y < 6))
            {
                if (this.Board[tileToConsider.X, tileToConsider.Y] == valToConsider)
                {
                    returnVal = true;
                } //End if (this.Board[tileToConsider.X, tileToConsider.Y] == valToConsider)
            } //End if ((tileToConsider.X >= 0 && tileToConsider.X < 5) && (tileToConsider.Y >= 0 && tileToConsider.Y < 6))

            return returnVal;
        } //End public bool isValidSpace(Point tileToConsider, BoardVals valToConsider)
        
        public bool isNotVal(Point tileToConsider, BoardVals valToAvoid)
        {
            //Declare variables
            bool returnVal = false;

            if ((tileToConsider.X >= 0 && tileToConsider.X < 5) && (tileToConsider.Y >= 0 && tileToConsider.Y < 6))
            {
                if (this.Board[tileToConsider.X, tileToConsider.Y] != valToAvoid)
                {
                    returnVal = true;
                } //End if (this.Board[tileToConsider.X, tileToConsider.Y] == valToConsider)
            } //End if ((tileToConsider.X >= 0 && tileToConsider.X < 5) && (tileToConsider.Y >= 0 && tileToConsider.Y < 6))
            else
            {
                ///Seems stupid to always return true, however, a tile outside the game board
                ///is indeed not the value that was passed, so technically is true.
                ///This helps handle the case where there are n in a row, with one end against
                ///the edge of the board.
                returnVal = true;
            } //End else

            return returnVal;
        } //End public bool isNotVal(Point tileToConsider, BoardVals valToAvoid)
        /// <summary>
        /// Places the given value in a tile if it's empty
        /// </summary>
        /// <param name="tileToConsider"></param>
        /// <param name="valToBePlaced"></param>
        /// <returns></returns>
        public bool setState(Point tileToConsider, BoardVals valToBePlaced)
        {
            //Declare variables
            bool returnVal = false;

            if (isValidSpace(tileToConsider, BoardVals.NULL))
            {
                this.Board[tileToConsider.X, tileToConsider.Y] = valToBePlaced;
                returnVal = true;
            } //End if (isValidSpace(tileToConsider, BoardVals.NULL))

            return returnVal;
        } //End public bool setState(Point tileToConsider, BoardVals valToBePlaced)
        /// <summary>
        /// Gets all the possible moves, ie. all the empty spaces
        /// </summary>
        /// <returns></returns>
        public List<Point> getPossibleMoves()
        {
            //Declare variables
            List<Point> possibleMoves = new List<Point>();

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (this.Board[i,j] == BoardVals.NULL)
                    {
                        possibleMoves.Add(new Point(i, j));
                    } //End if (this.Board[i,j] == BoardVals.NULL)
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)

            return possibleMoves;
        } //End public List<Point> getPossibleMoves()
        /// <summary>
        /// Gets all the possible surrounding tiles that are the same as the one considering
        /// </summary>
        /// <param name="tileToConsider"></param>
        /// <param name="valToConsider"></param>
        /// <returns>A list of the valid tiles found</returns>
        private List<Point> getValidSurroundingTiles(Point tileToConsider, BoardVals valToConsider)
        {
            //Declare variables
            List<Point> validTiles = new List<Point>();

            //Up
            if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X, tileToConsider.Y - 1));
            } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1), valToConsider))

            //Down
            if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X, tileToConsider.Y + 1));
            } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1), valToConsider))

            //Left
            if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X - 1, tileToConsider.Y));
            } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y), valToConsider))

            //Right
            if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X + 1, tileToConsider.Y));
            } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y), valToConsider))

            //Up-Left
            if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X - 1, tileToConsider.Y - 1));
            } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1), valToConsider))

            //Up-Right
            if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X + 1, tileToConsider.Y - 1));
            } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1), valToConsider))

            //Down-Left
            if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X - 1, tileToConsider.Y + 1));
            } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1), valToConsider))

            //Down-Right
            if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1), valToConsider))
            {
                validTiles.Add(new Point(tileToConsider.X + 1, tileToConsider.Y + 1));
            } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1), valToConsider))

            return validTiles;
        } //End private List<Point> getValidSurroundingTiles(Point tileToConsider, BoardVals valToConsider)
        /// <summary>
        /// Gets the next tile in a row based on the tile and direction given
        /// </summary>
        /// <param name="tileToConsider"></param>
        /// <param name="valToConsider"></param>
        /// <param name="direction"></param>
        /// <returns>Returns the next tile if valid, otherwise it returns Point(-1,-1) (ie. an invalid tile)</returns>
        private Point getPossibleNthInARow(Point tileToConsider, BoardVals valToConsider, BoardDirection direction)
        {
            //Declare variables
            Point validTile = new Point(-1, -1);

            switch (direction)
            {
                case BoardDirection.Up:
                    if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X, tileToConsider.Y - 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1), valToConsider))
                    break;
                case BoardDirection.Down:
                    if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X, tileToConsider.Y + 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1), valToConsider))
                    break;
                case BoardDirection.Left:
                    if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X - 1, tileToConsider.Y);
                    } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y), valToConsider))
                    break;
                case BoardDirection.Right:
                    if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X + 1, tileToConsider.Y);
                    } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y), valToConsider))
                    break;
                case BoardDirection.UpLeft:
                    if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X - 1, tileToConsider.Y - 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1), valToConsider))
                    break;
                case BoardDirection.UpRight:
                    if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X + 1, tileToConsider.Y - 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1), valToConsider))
                    break;
                case BoardDirection.DownLeft:
                    if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X - 1, tileToConsider.Y + 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1), valToConsider))
                    break;
                case BoardDirection.DownRight:
                    if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1), valToConsider))
                    {
                        validTile = new Point(tileToConsider.X + 1, tileToConsider.Y + 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1), valToConsider))
                    break;
                default:
                    break;
            } //End switch (direction)

            return validTile;
        } //End private Point getPossibleNthInARow(Point tileToConsider, BoardVals valToConsider, BoardDirection direction)

        private Point getPossibleNthInARow(Point tileToConsider, BoardDirection direction)
        {
            //Declare variables
            Point validTile = new Point(-1, -1);

            switch (direction)
            {
                case BoardDirection.Up:
                    if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1)))
                    {
                        validTile = new Point(tileToConsider.X, tileToConsider.Y - 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1), valToConsider))
                    break;
                case BoardDirection.Down:
                    if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1)))
                    {
                        validTile = new Point(tileToConsider.X, tileToConsider.Y + 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1), valToConsider))
                    break;
                case BoardDirection.Left:
                    if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y)))
                    {
                        validTile = new Point(tileToConsider.X - 1, tileToConsider.Y);
                    } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y), valToConsider))
                    break;
                case BoardDirection.Right:
                    if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y)))
                    {
                        validTile = new Point(tileToConsider.X + 1, tileToConsider.Y);
                    } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y), valToConsider))
                    break;
                case BoardDirection.UpLeft:
                    if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1)))
                    {
                        validTile = new Point(tileToConsider.X - 1, tileToConsider.Y - 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1), valToConsider))
                    break;
                case BoardDirection.UpRight:
                    if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1)))
                    {
                        validTile = new Point(tileToConsider.X + 1, tileToConsider.Y - 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1), valToConsider))
                    break;
                case BoardDirection.DownLeft:
                    if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1)))
                    {
                        validTile = new Point(tileToConsider.X - 1, tileToConsider.Y + 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1), valToConsider))
                    break;
                case BoardDirection.DownRight:
                    if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1)))
                    {
                        validTile = new Point(tileToConsider.X + 1, tileToConsider.Y + 1);
                    } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1), valToConsider))
                    break;
                default:
                    break;
            } //End switch (direction)

            return validTile;
        } //End private Point getPossibleNthInARow(Point tileToConsider, BoardVals valToConsider, BoardDirection direction)
        /// <summary>
        /// Finds 2 tiles in the same direction with an empty space at one end
        /// </summary>
        /// <param name="valToConsider">Look at Xs or Os</param>
        /// <returns></returns>
        public List<List<Point>> getTwosInARow(BoardVals valToConsider)
        {
            //Declare variables
            List<List<Point>> twos = new List<List<Point>>();
            List<Point> possible2nds = new List<Point>();
            Point empty3rd;
            Point precedingTile;
            BoardDirection dir = BoardDirection.NUll;

            for (int j = 0; j < this.Board.GetLength(1) - 1; j++)
            {
                for (int i = 0; i < this.Board.GetLength(0); i++)
                {
                    if (this.Board[i,j] == valToConsider)
                    {
                        possible2nds = getValidSurroundingTiles(new Point(i,j), valToConsider);
                        if (possible2nds.Count > 0)
                        {
                            for (int x = 0; x < possible2nds.Count; x++)
                            {
                                dir = determineDirectionT1ToT2(new Point(i, j), possible2nds[x]);
                                empty3rd = getPossibleNthInARow(possible2nds[x], dir);
                                //empty3rd = getPossibleNthInARow(possible2nds[x], BoardVals.NULL, dir);
                                if (isValidSpace(empty3rd, BoardVals.NULL))
                                {
                                    if (isNotVal(getPossibleNthInARow(new Point(i,j), getReverseDirection(dir)), valToConsider))
                                    {
                                        //Create a list containing the tiles making up the row, plus the possible empty edge tiles
                                        List<Point> temp = new List<Point>();

                                        //Add the preceding tile if it is empty
                                        precedingTile = getPossibleNthInARow(new Point(i, j), getReverseDirection(dir));
                                        if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)
                                        {
                                            temp.Add(precedingTile);
                                        } //End if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)

                                        temp.Add(new Point(i, j));
                                        temp.Add(possible2nds[x]);
                                        temp.Add(empty3rd);
                                        twos.Add(temp);
                                    } //End if (isNotVal(getPossibleNthInARow(new Point(i,j), getReverseDirection(dir)), valToConsider))
                                } //End if (isValidSpace(empty3rd, valToConsider))
                                else if (isValidSpace(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), BoardVals.NULL) && isNotVal(empty3rd, valToConsider))
                                {
                                    if (isNotVal(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), valToConsider))
                                    {
                                        //Create a list containing the tiles making up the row, plus the possible empty edge tiles
                                        List<Point> temp = new List<Point>();

                                        //Add the preceding tile if it is empty
                                        precedingTile = getPossibleNthInARow(new Point(i, j), getReverseDirection(dir));
                                        if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)
                                        {
                                            temp.Add(precedingTile);
                                        } //End if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)

                                        temp.Add(new Point(i, j));
                                        temp.Add(possible2nds[x]);
                                        twos.Add(temp);
                                    } //End if (isNotVal(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), valToConsider))
                                } //End 
                            } //End for (int x = 0; x < possible2nds.Count; x++)
                        } //End if (possible2nds.Count > 0)
                    } //End if (this.Board[i,j] == valToConsider)
                } //End for (int i = 0; i < this.Board.GetLength(0); i++)
            } //End for (int j = 0; j < this.Board.GetLength(1) - 1; j++)

            if (twos.Count > 1)
            {
                filterCopyNInARow(twos);
            } //End if (twos.Count > 1)

            return twos;
        } //End public List<List<Point>> getTwosInARow(BoardVals valToConsider)
        /// <summary>
        /// Finds 3 tiles all in the same direction with an empty space at one end
        /// </summary>
        /// <param name="valToConsider">Look at Xs or Os</param>
        /// <returns></returns>
        public List<List<Point>> getThreesInARow(BoardVals valToConsider)
        {
            //Declare variables
            List<List<Point>> threes = new List<List<Point>>();
            List<Point> possible2nds = new List<Point>();
            Point possible3rd;
            Point empty4th;
            Point precedingTile;
            BoardDirection dir = BoardDirection.NUll;

            for (int j = 0; j < this.Board.GetLength(1) - 1; j++)
            {
                for (int i = 0; i < this.Board.GetLength(0); i++)
                {
                    if (this.Board[i, j] == valToConsider)
                    {
                        possible2nds = getValidSurroundingTiles(new Point(i, j), valToConsider);
                        if (possible2nds.Count > 0)
                        {
                            for (int x = 0; x < possible2nds.Count; x++)
                            {
                                dir = determineDirectionT1ToT2(new Point(i, j), possible2nds[x]);
                                possible3rd = getPossibleNthInARow(possible2nds[x], valToConsider, dir);
                                if (isValidSpace(possible3rd, valToConsider))
                                {
                                    empty4th = getPossibleNthInARow(possible3rd, dir);
                                    //empty4th = getPossibleNthInARow(possible3rd, BoardVals.NULL, dir);
                                    if (isValidSpace(empty4th, BoardVals.NULL))
                                    {
                                        if (isNotVal(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), valToConsider))
                                        {
                                            //Create a list containing the tiles making up the row, plus the possible empty edge tiles
                                            List<Point> temp = new List<Point>();

                                            //Add the preceding tile if it is empty
                                            precedingTile = getPossibleNthInARow(new Point(i, j), getReverseDirection(dir));
                                            if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)
                                            {
                                                temp.Add(precedingTile);
                                            } //End if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)

                                            temp.Add(new Point(i, j));
                                            temp.Add(possible2nds[x]);
                                            temp.Add(possible3rd);
                                            temp.Add(empty4th);
                                            threes.Add(temp);
                                        } //End if (isNotVal(getPossibleNthInARow(new Point(i,j), getReverseDirection(dir)), valToConsider))
                                    } //End if (isValidSpace(empty4th, BoardVals.NULL))
                                    else if (isValidSpace(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), BoardVals.NULL) && isNotVal(empty4th, valToConsider))
                                    {
                                        if (isNotVal(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), valToConsider))
                                        {
                                            //Create a list containing the tiles making up the row, plus the possible empty edge tiles
                                            List<Point> temp = new List<Point>();

                                            //Add the preceding tile if it is empty
                                            precedingTile = getPossibleNthInARow(new Point(i, j), getReverseDirection(dir));
                                            if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)
                                            {
                                                temp.Add(precedingTile);
                                            } //End if (isValidSpace(precedingTile) && this.Board[precedingTile.X, precedingTile.Y] == BoardVals.NULL)

                                            temp.Add(new Point(i, j));
                                            temp.Add(possible2nds[x]);
                                            temp.Add(possible3rd);
                                            threes.Add(temp);
                                        } //End if (isNotVal(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), valToConsider))
                                    } //End else if (isValidSpace(getPossibleNthInARow(new Point(i, j), getReverseDirection(dir)), BoardVals.NULL) && isNotVal(empty4th, valToConsider))
                                } //End if (isValidSpace(possible3rd, valToConsider))
                            } //End for (int x = 0; x < possible2nds.Count; x++)
                        } //End if (possible2nds.Count > 0)
                    } //End if (this.Board[i,j] == valToConsider)
                } //End for (int i = 0; i < this.Board.GetLength(0); i++)
            } //End for (int j = 0; j < this.Board.GetLength(1) - 1; j++)

            if (threes.Count > 1)
            {
                filterCopyNInARow(threes);
            } //End if (threes.Count > 1)

            return threes;
        } //End public List<List<Point>> getThreesInARow(BoardVals valToConsider)
        /// <summary>
        /// Determines the direction when going from tile1 to tile 2
        /// </summary>
        /// <param name="tile1"></param>
        /// <param name="tile2"></param>
        /// <returns></returns>
        private BoardDirection determineDirectionT1ToT2(Point tile1, Point tile2)
        {
            //Declare variables
            BoardDirection returnVal = BoardDirection.NUll;

            if (isValidSpace(tile1) && isValidSpace(tile2))
            {
                if (tile1.X > tile2.X)
                {
                    if (tile1.Y > tile2.Y)
                    {
                        returnVal = BoardDirection.UpLeft;
                    } //End if (tile1.Y > tile2.Y)
                    else if (tile1.Y < tile2.Y)
                    {
                        returnVal = BoardDirection.DownLeft;
                    } //End else if (tile1.Y < tile2.Y)
                    else
                    {
                        returnVal = BoardDirection.Left;
                    } //End else
                } //End if (tile1.X > tile2.X)
                else if (tile1.X < tile2.X)
                {
                    if (tile1.Y > tile2.Y)
                    {
                        returnVal = BoardDirection.UpRight;
                    } //End if (tile1.Y > tile2.Y)
                    else if (tile1.Y < tile2.Y)
                    {
                        returnVal = BoardDirection.DownRight;
                    } //End else if (tile1.Y < tile2.Y)
                    else
                    {
                        returnVal = BoardDirection.Right;
                    } //End else
                } //End else if (tile1.X < tile2.X)
                else
                {
                    if (tile1.Y > tile2.Y)
                    {
                        returnVal = BoardDirection.Up;
                    } //End if (tile1.Y > tile2.Y)
                    else if (tile1.Y < tile2.Y)
                    {
                        returnVal = BoardDirection.Down;
                    } //End else if (tile1.Y < tile2.Y)
                    else
                    {
                        returnVal = BoardDirection.NUll;
                    } //End else
                } //End else
            } //End if (isValidSpace(tile1) && isValidSpace(tile2))

            return returnVal;
        } //End private BoardDirection determineDirectionT1ToT2(Point tile1, Point tile2)
        private void initGameBoard()
        {
            this.Board = new BoardVals[5, 6];

            for (int j = 0; j < this.Board.GetLength(1); j++)
            {
                for (int i = 0; i < this.Board.GetLength(0); i++)
                {
                    this.Board[i, j] = BoardVals.NULL;
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)
        } //End private void initGameBoard()

        public BoardVals[,] getGameBoard()
        {
            /**
            //Declare variables
            BoardVals[,] boardCopy = new BoardVals[5, 6];

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    boardCopy[i, j] = this.Board[i, j];
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)

            return boardCopy;
            //*/
            return (BoardVals[,])this.Board.Clone();
        } //End public BoardVals[,] getGameBoard()
        
        public BoardDirection getReverseDirection(BoardDirection direction)
        {
            //Declare variables
            BoardDirection reverseDirection = BoardDirection.NUll;

            switch (direction)
            {
                case BoardDirection.Up:
                    reverseDirection = BoardDirection.Down;
                    break;
                case BoardDirection.Down:
                    reverseDirection = BoardDirection.Up;
                    break;
                case BoardDirection.Left:
                    reverseDirection = BoardDirection.Right;
                    break;
                case BoardDirection.Right:
                    reverseDirection = BoardDirection.Left;
                    break;
                case BoardDirection.UpLeft:
                    reverseDirection = BoardDirection.DownRight;
                    break;
                case BoardDirection.UpRight:
                    reverseDirection = BoardDirection.DownLeft;
                    break;
                case BoardDirection.DownLeft:
                    reverseDirection = BoardDirection.UpRight;
                    break;
                case BoardDirection.DownRight:
                    reverseDirection = BoardDirection.UpLeft;
                    break;
                default:
                    break;
            } //End switch (direction)

            return reverseDirection;
        } //End public BoardDirection getReverseDirection(BoardDirection direction)
        
        public string displayBoard()
        {
            //Declare variables
            string returnString = "";

            for (int j = 0; j < this.Board.GetLength(1); j ++)
            {
                returnString += "| ";
                for (int i = 0; i < this.Board.GetLength(0); i++)
                {
                    if (this.Board[i,j] == BoardVals.NULL)
                    {
                        returnString += "   ";
                    } //End if (this.Board[i,j] == BoardVals.NULL)
                    else
                    {
                        returnString += this.Board[i, j].ToString();
                    } //End else

                    if (i < this.Board.GetLength(0) - 1)
                    {
                        returnString += " | ";
                    } //End if (i < 6 - 1)
                } //End for (int i = 0; i < 5; i++)

                returnString += " |";

                if (j < this.Board.GetLength(1) - 1)
                {
                    returnString += "\n------------------------------\n";
                } //End if (j < 5 - 1)
            } //End for (int j = 0; j < 5; j ++)

            return returnString;
        } //End public string displayBoard()

        private void filterCopyNInARow(List<List<Point>> nsInARow)
        {
            //Declare variables
            List<Point> temp;
            int numMatches = 0;

            for (int k = 0; k < nsInARow.Count; k++)
            {
                temp = nsInARow[k];

                for (int j = 0; j < nsInARow.Count; j++)
                {
                    numMatches = 0;

                    if (j == k)
                    {
                        if (j < nsInARow.Count - 1)
                        {
                            j += 1;
                        } //End 
                        else
                        {
                            break;
                        } //End else
                    } //End if (j == k)

                    for (int i = 0; i < nsInARow[j].Count; i++)
                    {
                        for (int x = 0; x < temp.Count; x++)
                        {
                            if (temp[x] == nsInARow[j][i])
                            {
                                numMatches += 1;
                            } //End if (temp[x] == nsInARow[j][i])
                        } //End for (int x = 0; x < temp.Count; x++)
                    } //End for (int i = 0; i < nsInARow[j].Count; i++)

                    if (numMatches == nsInARow[j].Count && numMatches == temp.Count)
                    {
                        nsInARow.RemoveAt(j);
                        j--;
                    } //End if (numMatches == nsInARow[j].Count && numMatches == temp.Count)
                } //End for (int j = 0; j < nsInARow.Count; j++)
            } //End for (int k = 0; k < nsInARow.Count; k++)



        } //End 

    } //End class Board
} //End namespace CS4750HW4
