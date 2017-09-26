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
        private BoardVals[,] board;

        //Properties
        private BoardVals[,] Board { get; set; }


        /***************CONSTRUCTOR***************/
        public GameBoard ()
        {
            initGameBoard();
        } //End 

        /***************METHODS***************/
        private void initGameBoard()
        {
            this.Board = new BoardVals[5, 6];

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    this.Board[i, j] = BoardVals.NULL;
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)
        } //End private void initGameBoard()

        public BoardVals[,] getGameBoard()
        {
            //Declare variables
            BoardVals[,] boardCopy = new BoardVals[5, 6];

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    boardCopy[i,j] = this.Board[i, j];
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)

            return boardCopy;
        } //End public BoardVals[,] getGameBoard()

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

        private List<Point> getValidSurroundingTiles(Point tileToConsider)
        {
            //Declare variables
            List<Point> validTiles = new List<Point>();

            //Up
            if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1)))
            {
                validTiles.Add(new Point(tileToConsider.X, tileToConsider.Y - 1));
            } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y - 1)))

            //Down
            if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1)))
            {
                validTiles.Add(new Point(tileToConsider.X, tileToConsider.Y + 1));
            } //End if (isValidSpace(new Point(tileToConsider.X, tileToConsider.Y + 1)))

            //Left
            if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y)))
            {
                validTiles.Add(new Point(tileToConsider.X - 1, tileToConsider.Y));
            } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y)))

            //Right
            if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y)))
            {
                validTiles.Add(new Point(tileToConsider.X + 1, tileToConsider.Y));
            } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y)))

            //Up-Left
            if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1)))
            {
                validTiles.Add(new Point(tileToConsider.X - 1, tileToConsider.Y - 1));
            } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y - 1)))

            //Up-Right
            if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1)))
            {
                validTiles.Add(new Point(tileToConsider.X + 1, tileToConsider.Y - 1));
            } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y - 1)))

            //Down-Left
            if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1)))
            {
                validTiles.Add(new Point(tileToConsider.X - 1, tileToConsider.Y + 1));
            } //End if (isValidSpace(new Point(tileToConsider.X - 1, tileToConsider.Y + 1)))

            //Down-Right
            if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1)))
            {
                validTiles.Add(new Point(tileToConsider.X + 1, tileToConsider.Y + 1));
            } //End if (isValidSpace(new Point(tileToConsider.X + 1, tileToConsider.Y + 1)))

            return validTiles;
        } //End private List<Point> getValidSurroundingTiles(Point tileToConsider)

        public List<List<Point>> getTwosInARow(BoardVals valToConsider)
        {
            //Declare variables
            List<List<Point>> twos = new List<List<Point>>();

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (this.Board[i,j] == valToConsider)
                    {

                    } //End 
                } //End for (int i = 0; i < 5; i++)
            } //End for (int j = 0; j < 6; j++)

            return twos;
        } //End public List<List<Point>> getTwosInARow(BoardVals valToConsider)

        public List<List<Point>> getThreesInARow(BoardVals valToConsider)
        {
            //Declare variables
            List<List<Point>> threes = new List<List<Point>>();

            return threes;
        } //End public List<List<Point>> getThreesInARow(BoardVals valToConsider)

    } //End class Board
} //End namespace CS4750HW4
