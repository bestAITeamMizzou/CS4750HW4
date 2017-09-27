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
        
        /// <summary>
        ///     Determines whether a point contains an empty space
        /// </summary>
        /// <param name="p"></param>
        /// <returns>True if the point refrences an empty tile. False otherwise.</returns>
        private bool isEmptySpace(Point p)
        {
            return isValidSpace(p) && this.Board[p.X, p.Y] == BoardVals.NULL;
        }

        private bool isValidSpace(Point tile)
        {
            //Declare variables
            bool returnVal = false;

            if ((tile.X >= 0 && tile.X < Board.GetLength(0)) && (tile.Y >= 0 && tile.Y < Board.GetLength(1)))
            {
                returnVal = true;
            } //End if ((tile.X >= 0 && tile.X < board.GetLength(0)) && (tile.Y >= 0 && tile.Y < board.GetLength(1)))

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

        public bool isTripleMembers(Point a, Point b, String[,] colorBoard)
        {
            String x = colorBoard[a.X, a.Y];
            String y = colorBoard[b.X, b.Y];

            foreach (char c in x)
            {
                foreach (char d in y)
                {
                    if (c == d)
                    {
                        return true;
                    }
                    else if (c < d)
                    {
                        break;
                    }
                }
            }

            return false;
        }
        
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
            Point validTile = new Point (-1, -1);

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

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (this.Board[i,j] == valToConsider)
                    {
                        possible2nds = getValidSurroundingTiles(new Point(i,j), valToConsider);
                        if (possible2nds.Count > 0)
                        {
                            for (int x = 0; x < possible2nds.Count; x++)
                            {
                                empty3rd = getPossibleNthInARow(possible2nds[x], BoardVals.NULL, determineDirectionT1ToT2(new Point(i, j), possible2nds[x]));
                                if (isValidSpace(empty3rd, BoardVals.NULL))
                                {
                                    List<Point> temp = new List<Point>();
                                    temp.Add(new Point(i, j));
                                    temp.Add(possible2nds[x]);
                                    temp.Add(empty3rd);
                                    twos.Add(temp);
                                } //End if (isValidSpace(empty3rd, valToConsider))

                                /*
                                List<Point> temp = new List<Point>();
                                temp.Add(new Point(i, j));
                                temp.Add(possible2nds[x]);
                                twos.Add(temp);
                                //*/
                            } //End for (int x = 0; x < possible2nds.Count; x++)
                        } //End if (possible2nds.Count > 0)
                    } //End if (this.Board[i,j] == valToConsider)
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)

            return twos;
        } //End public List<List<Point>> getTwosInARow(BoardVals valToConsider)
        
        /// <summary>
        /// Finds 3 tiles all in the same direction with an empty space at one end
        /// </summary>
        /// <param name="valToConsider">Look at Xs or Os</param>
        /// <returns>A tuple representing open 3 in a rows. The first element representing Xs and the second Os.</returns>
        public Tuple<List<List<Point>>,List<List<Point>>> getThreesInARow(String[,] coloringGraph)
        {
            
            BoardVals[,] board = getGameBoard();//safety measure to not alter original board
            int height = board.GetLength(0);
            int width = board.GetLength(1);
            char color = 'A';

            List<List<Point>> XTriples = new List<List<Point>>();
            List<List<Point>> OTriples = new List<List<Point>>();
            
            /*
             * ########
             * #XXXXXX#
             * #XXXXXX#
             * ########
             */
            //search mid section(like the Xs in ^^^the picture^^^) for 3 in a row
            for(int i = 1; i < height - 1; i++)
            {
                for(int j = 1; j < width - 1; j++)
                {
                    Point current = new Point(i, j);
                    if(isEmptySpace(current))
                    {
                        continue;
                    }

                    checkDirectionForTriple(current, 1, 1, coloringGraph, ref color, XTriples, OTriples, board);//diagonal check with negative slope
                    checkDirectionForTriple(current, 1, -1, coloringGraph, ref color, XTriples, OTriples, board);//diagonal check with positive slope
                    checkDirectionForTriple(current, 1, 0, coloringGraph, ref color, XTriples, OTriples, board);//vertical check
                    checkDirectionForTriple(current, 0, 1, coloringGraph, ref color, XTriples, OTriples, board);//horizontal check
                }
            }
            
            //the borders are separately checked for 3 in a row for speed
            //search top and bottom borders for 3 in a row
            for(int j = 1; j < width - 1; j++){

                Point currentTop = new Point(0, j);
                Point currentBottom = new Point(height - 1, j);

                if(!isEmptySpace(currentTop))
                {
                    checkDirectionForTriple(currentTop, 0, 1, coloringGraph, ref color, XTriples, OTriples, board);//horizontal check
                }

                if(!isEmptySpace(currentBottom))
                {
                    checkDirectionForTriple(currentBottom, 0, 1, coloringGraph, ref color, XTriples, OTriples, board);//horizontal check
                }
            }
            
            //search left and right borders for 3 in a row
            for(int i = 1; i < height - 1; i++){
                
                Point currentLeft = new Point(i, 0);
                Point currentRight = new Point(i, width - 1);

                 if(!isEmptySpace(currentLeft))
                {
                    checkDirectionForTriple(currentLeft, 1, 0, coloringGraph, ref color, XTriples, OTriples, board);//vertical check
                }

                if(!isEmptySpace(currentRight))
                {
                    checkDirectionForTriple(currentRight, 1, 0, coloringGraph, ref color, XTriples, OTriples, board);//vertical check
                }
            }

            return new Tuple<List<List<Point>>, List<List<Point>>>(XTriples, OTriples);
            
        } //End public List<List<Point>> getThreesInARow(BoardVals valToConsider)

        private void checkDirectionForTriple(Point center, int XOffset, int YOffset, String[,] coloringGraph, ref char color, List<List<Point>> XTriples, List<List<Point>> OTriples, BoardVals[,] board){
            int X = center.X;
            int Y = center.Y;

            //check line passing through center with center being the midpoint of the line
            //For Example #X#
            //Where X is the center
            if(board[X - XOffset, Y - YOffset] == board[X, Y] && board[X, Y] == board[X + XOffset, Y + YOffset])
            {
                //color the graph
                coloringGraph[X - XOffset, Y - YOffset] += color;
                coloringGraph[X, Y] += color;
                coloringGraph[X + XOffset, Y + YOffset] += color;
                color++;

                //check if the triple is open
                if(isEmptySpace(new Point(X - 2 * XOffset, Y - 2 * YOffset)) || isEmptySpace(new Point(X + 2 * XOffset, Y + 2 * YOffset)))
                {
                    //decide which list(X list or O list) to add it to
                    List<Point> triple = new List<Point>()
                    {
                        new Point(X - XOffset, Y - YOffset),
                        new Point(X, Y),
                        new Point(X + XOffset, Y + YOffset)
                    };

                    if(board[X, Y] == BoardVals.X)
                    {
                        XTriples.Add(triple);
                    }
                    else
                    {
                        OTriples.Add(triple);
                    }
                }
            }
        }

        public int heurisic(Boolean isX)
        {
            String[,] colorBoard = new String[Board.GetLength(0), Board.GetLength(1)];//data structure for not marking subsections pof 2 in a rows 
            Tuple<List<List<Point>>, List<List<Point>>> threeInARows = getThreesInARow(colorBoard);

            return isX ? 
                //heuristic for X
                threeInARows.Item1.Count * 3 - threeInARows.Item2.Count * 3 + getTwosInARow(BoardVals.X).Count - getTwosInARow(BoardVals.O).Count
            :
                //heuristic for O
                threeInARows.Item2.Count * 3 - threeInARows.Item1.Count * 3 + getTwosInARow(BoardVals.O).Count - getTwosInARow(BoardVals.X).Count;
        }
        
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
                        returnVal = BoardDirection.DownRight;
                    } //End if (tile1.Y > tile2.Y)
                    else if (tile1.Y < tile2.Y)
                    {
                        returnVal = BoardDirection.UpRight;
                    } //End else if (tile1.Y < tile2.Y)
                    else
                    {
                        returnVal = BoardDirection.Right;
                    } //End else
                } //End if (tile1.X > tile2.X)
                else if (tile1.X < tile2.X)
                {
                    if (tile1.Y > tile2.Y)
                    {
                        returnVal = BoardDirection.DownLeft;
                    } //End if (tile1.Y > tile2.Y)
                    else if (tile1.Y < tile2.Y)
                    {
                        returnVal = BoardDirection.UpLeft;
                    } //End else if (tile1.Y < tile2.Y)
                    else
                    {
                        returnVal = BoardDirection.Left;
                    } //End else
                } //End else if (tile1.X < tile2.X)
                else
                {
                    if (tile1.Y > tile2.Y)
                    {
                        returnVal = BoardDirection.Down;
                    } //End if (tile1.Y > tile2.Y)
                    else if (tile1.Y < tile2.Y)
                    {
                        returnVal = BoardDirection.Up;
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
            /*this.Board = new BoardVals[5, 6]{{BoardVals.NULL,    BoardVals.O, BoardVals.NULL, BoardVals.NULL,    BoardVals.O, BoardVals.NULL},
                                             {BoardVals.NULL,    BoardVals.X,    BoardVals.O,    BoardVals.O, BoardVals.NULL, BoardVals.NULL},
                                             {BoardVals.NULL,    BoardVals.X,    BoardVals.O,    BoardVals.X,    BoardVals.X, BoardVals.NULL},
                                             {BoardVals.NULL,    BoardVals.X, BoardVals.NULL,    BoardVals.O, BoardVals.NULL, BoardVals.NULL},
                                             {BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL}};
            
            this.Board = new BoardVals[5, 6]{{BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL,    BoardVals.X},
                                             {BoardVals.NULL, BoardVals.NULL,    BoardVals.X, BoardVals.NULL,    BoardVals.X,    BoardVals.O},
                                             {BoardVals.NULL, BoardVals.NULL, BoardVals.NULL,    BoardVals.X,    BoardVals.O, BoardVals.NULL},
                                             {BoardVals.NULL,    BoardVals.O,    BoardVals.O,    BoardVals.O,    BoardVals.X, BoardVals.NULL},
                                             {BoardVals.NULL, BoardVals.NULL,    BoardVals.X, BoardVals.NULL, BoardVals.NULL,    BoardVals.O}};*/

            this.Board = new BoardVals[5, 6]{{BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL, BoardVals.NULL},
                                             {   BoardVals.X, BoardVals.NULL,    BoardVals.O,    BoardVals.O, BoardVals.NULL, BoardVals.NULL},
                                             {   BoardVals.X, BoardVals.NULL, BoardVals.NULL,    BoardVals.O, BoardVals.NULL, BoardVals.NULL},
                                             {   BoardVals.X, BoardVals.NULL, BoardVals.NULL,    BoardVals.O,    BoardVals.O, BoardVals.NULL},
                                             {BoardVals.NULL, BoardVals.NULL,    BoardVals.X,    BoardVals.X,    BoardVals.X, BoardVals.NULL}};
            
            /*this.Board = new BoardVals[5, 6];


            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    this.Board[i, j] = BoardVals.NULL;
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)*/
        } //End private void initGameBoard()

        
        public BoardVals[,] getGameBoard()
        {
            return (BoardVals[,])this.Board.Clone();
        } //End public BoardVals[,] getGameBoard()

    } //End class Board
} //End namespace CS4750HW4
