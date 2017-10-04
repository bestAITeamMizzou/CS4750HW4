using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4750HW4
{
    class Beginner
    {
        /***************ATTRIBUTES***************/
        //Fields

        //Properties
        public GameBoard Board { get; private set; }
        public BoardVals PlayersVal { get; private set; }
        public BoardVals OpponentsVal
        {
            get
            {
                if (PlayersVal == BoardVals.X)
                {
                    return BoardVals.O;
                } //End if (PlayersVal == BoardVals.X)
                else
                {
                    return BoardVals.X;
                } //End else
            } //End get
        } //End private BoardVals OpponentsVal

        /***************CONSTRUCTOR***************/
        public Beginner (BoardVals _PlayersVal)
        {
            this.PlayersVal = _PlayersVal;
            this.Board = new GameBoard();
        } //End 

        /***************METHODS***************/
        public Point beginnerDecision()
        {
            //Declare variables
            Point move = new Point (-1,-1);
            Tuple<List<List<Point>>, List<List<Point>>> triples = this.Board.getThreesInARow(new String[5, 6]);
            List<List<Point>> playerTriples = (this.PlayersVal == BoardVals.X) ? triples.Item1 : triples.Item2;
            List<List<Point>> adversaryTriples = (this.OpponentsVal == BoardVals.X) ? triples.Item1 : triples.Item2;
            List<Point> possibleMoves = new List<Point>();
            Random randMove = new Random();

            //this.Board.findFourInARow(OpponentsVal);
            
            if (playerTriples.Count > 0)//make move to win the game
            {
                for (int x = 0; x < playerTriples[0].Count; x++)
                {
                    if (this.Board.isValidSpace(playerTriples[0][x], BoardVals.NULL))
                    {
                        if (this.Board.setState(playerTriples[0][x], this.PlayersVal))
                        {
                            move = playerTriples[0][x];
                            break;
                        } //End if (this.Board.setState(threesInARow[0][x], this.PlayersVal))
                        else
                        {
                            ///How did this happen?
                            ///Pretty sure it shouldn't be possible to reach here
                        } //End else
                    } //End if (this.Board.isValidSpace(threesInARow[0][x], BoardVals.NULL))
                } //End for (int x = 0; x < threesInARow[0].Count; x++)
            } //End if (threesInARow.Count > 0)
            else if (adversaryTriples.Count > 0)//make move to prevent game from being won next round
            {
                for (int x = 0; x < adversaryTriples[0].Count; x++)
                {
                    if (this.Board.isValidSpace(adversaryTriples[0][x], BoardVals.NULL))
                    {
                        if (this.Board.setState(adversaryTriples[0][x], this.PlayersVal))
                        {
                            move = adversaryTriples[0][x];
                            break;
                        } //End if (this.Board.setState(threesInARow[0][x], this.PlayersVal))
                        else
                        {
                            ///How did this happen?
                            ///Pretty sure it shouldn't be possible to reach here
                        } //End else
                    } //End if (this.Board.isValidSpace(threesInARow[0][x], BoardVals.NULL))
                } //End for (int x = 0; x < threesInARow[0].Count; x++)
            } //End if (threesInARow.Count > 0 && !skipRand)
            else//make a random move
            {
                possibleMoves = this.Board.getPossibleMoves();
                move = possibleMoves[randMove.Next(0, possibleMoves.Count - 1)];

                while (!this.Board.isValidSpace(move, BoardVals.NULL))
                {
                    move = possibleMoves[randMove.Next(0, possibleMoves.Count - 1)];
                } //End while (!this.Board.isValidSpace(move, BoardVals.NULL))
            } //End if (possibleMoves.Count > 0)

            return move;
        } //End public Point beginnerDecision()
    } //End class Beginner
} //End namespace CS4750
