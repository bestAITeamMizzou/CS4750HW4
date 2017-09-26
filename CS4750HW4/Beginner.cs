﻿using System;
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
        public BoardVals XorO { get; private set; }
        private BoardVals OpponentsVal
        {
            get
            {
                if (XorO == BoardVals.X)
                {
                    return BoardVals.O;
                } //End if (XorO == BoardVals.X)
                else
                {
                    return BoardVals.X;
                } //End else
            } //End get
        } //End private BoardVals OpponentsVal

        /***************CONSTRUCTOR***************/
        public Beginner (BoardVals _XorO)
        {
            this.XorO = _XorO;
            this.Board = new GameBoard();
        } //End 

        /***************METHODS***************/
        public Point BeginnerDecision()
        {
            //Declare variables
            Point move = new Point (-1,-1);
            List<List<Point>> threesInARow = new List<List<Point>>();
            List<Point> possibleMoves = new List<Point>();
            Random randMove = new Random();
            bool skipRand = false;

            threesInARow = this.Board.getThreesInARow(OpponentsVal);
            if (threesInARow.Count > 0)
            {
                for (int x = 0; x < threesInARow[0].Count; x++)
                {
                    if (this.Board.isValidSpace(threesInARow[0][x], BoardVals.NULL))
                    {
                        if (this.Board.setState(threesInARow[0][x], this.XorO))
                        {
                            skipRand = true;
                            break;
                        } //End if (this.Board.setState(threesInARow[0][x], this.XorO))
                        else
                        {
                            ///How did this happen?
                            ///Pretty sure it shouldn't be possible to reach here
                        } //End else
                    } //End if (this.Board.isValidSpace(threesInARow[0][x], BoardVals.NULL))
                } //End for (int x = 0; x < threesInARow[0].Count; x++)
            } //End if (threesInARow.Count > 0)

            if (!skipRand)
            {
                possibleMoves = this.Board.getPossibleMoves();
                if (possibleMoves.Count > 0)
                {
                    move = possibleMoves[randMove.Next(0, possibleMoves.Count - 1)];

                    while (!this.Board.isValidSpace(move, BoardVals.NULL))
                    {
                        move = possibleMoves[randMove.Next(0, possibleMoves.Count - 1)];
                    } //End while (!this.Board.isValidSpace(move, BoardVals.NULL))
                } //End if (possibleMoves.Count > 0)
            } //End (!skipRand)

            return move;
        } //End 

    } //End class Beginner
} //End namespace CS4750
