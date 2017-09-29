using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4750HW4
{
    class Advanced
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
        private Point LastMove { get; set; }
        private int LifeOfLastMove { get; set; }
        private List<Point> PossibleMoves { get; set; }
        public int NodesGenerated { get; private set; }

        /***************CONSTRUCTOR***************/
        public Advanced(BoardVals _PlayersVal)
        {
            this.PlayersVal = _PlayersVal;
            this.Board = new GameBoard();
            this.LastMove = new Point(-1, -1);
            this.LifeOfLastMove = 1;
            this.PossibleMoves = new List<Point>();
            this.NodesGenerated = 0;
        } //End public Advanced(BoardVals _PlayersVal)

        /***************METHODS***************/
        public Point minimaxDecision()
        {
            //Declare variables

            this.NodesGenerated = 0;

            maxValue(new GameBoard(this.Board.getGameBoard()), 2, this.PlayersVal);

            return this.LastMove;
        } //End public Point minimaxDecision()

        private int maxValue(GameBoard curState, int maxPly, BoardVals curPlayerVal)
        {
            //Declare variables
            Point move = new Point(-1, -1);
            int heuristicVal = int.MinValue;
            int possibleHeuristicVal = int.MinValue;
            List<Point> possibleMoves = new List<Point>();
            GameBoard nextState;

            if (maxPly <= 0)
            {
                //Return utility(state)
                return heuristicVal = curState.getHeuristicVal(curPlayerVal);
            } //End if (maxPly <= 0)

            //Get the possible moves
            possibleMoves = curState.getPossibleMoves();
            for (int i = 0; i < possibleMoves.Count; i++)
            {
                move = possibleMoves[i];
                nextState = new GameBoard(curState.getGameBoard());

                if (nextState.setState(possibleMoves[i], curPlayerVal))
                {
                    this.NodesGenerated += 1;
                    possibleHeuristicVal = minValue(nextState, maxPly - 1, curState.oppositeVal(curPlayerVal));

                    if (possibleHeuristicVal > heuristicVal)
                    {
                        heuristicVal = possibleHeuristicVal;
                        this.LastMove = move;
                        this.PossibleMoves.Clear();
                        this.PossibleMoves.Add(move);
                    } //End if (possibleHeuristicVal > heuristicVal)
                    else if (possibleHeuristicVal == heuristicVal)
                    {
                        this.PossibleMoves.Add(move);

                        Random rand = new Random();
                        this.LastMove = this.PossibleMoves[rand.Next(0, this.PossibleMoves.Count - 1)];

                        /*
                        bool moveChanged = false;

                        for (int j = 0; j < this.LifeOfLastMove && !moveChanged; j++)
                        {
                            if (rand.Next(0, 1 + j) != 0)
                            {
                                this.LastMove = move;
                                this.LifeOfLastMove = 1;
                                moveChanged = true;
                            } //End if (rand.Next(0, 1 + j) != 0)
                        } //End for (int j = 0; j < this.LifeOfLastMove && !moveChanged; j++)

                        if (moveChanged)
                        {
                            this.LifeOfLastMove = 1;
                        } //End if (moveChanged)
                        //*/
                    } //End if (nextState.setState(possibleMoves[i], curPlayerVal))
                } //End if (nextState.setState(possibleMoves[i], curPlayerVal))
                else
                {
                    ///Pretty sure it shouldn't be possible to reach this. But who knows, 
                    ///I'm not omniscient. 
                } //End else
            } //End for (int i = 0; i < possibleMoves.Count; i++)

            return heuristicVal;
        } //End private int maxValue(GameBoard curState, int maxPly, BoardVals curPlayerVal)

        private int minValue(GameBoard curState, int maxPly, BoardVals curPlayerVal)
        {
            //Declare variables
            Point move = new Point(-1, -1);
            int heuristicVal = int.MaxValue;
            int possibleHeuristicVal = int.MaxValue;
            List<Point> possibleMoves = new List<Point>();
            GameBoard nextState;

            if (maxPly <= 0)
            {
                //Return utility(state)
                return heuristicVal = curState.getHeuristicVal(curPlayerVal);
            } //End if (maxPly <= 0)

            //Get the possible moves
            possibleMoves = curState.getPossibleMoves();
            for (int i = 0; i < possibleMoves.Count; i++)
            {
                move = possibleMoves[i];
                nextState = new GameBoard(curState.getGameBoard());

                if (nextState.setState(possibleMoves[i], curPlayerVal))
                {
                    this.NodesGenerated += 1;
                    possibleHeuristicVal = maxValue(nextState, maxPly - 1, curState.oppositeVal(curPlayerVal));

                    if (possibleHeuristicVal < heuristicVal)
                    {
                        heuristicVal = possibleHeuristicVal;
                        this.LastMove = move;
                        this.PossibleMoves.Clear();
                        this.PossibleMoves.Add(move);
                    } //End if (possibleHeuristicVal < heuristicVal)
                    else if (possibleHeuristicVal == heuristicVal)
                    {
                        this.PossibleMoves.Add(move);

                        Random rand = new Random();
                        this.LastMove = this.PossibleMoves[rand.Next(0, this.PossibleMoves.Count - 1)];

                        /*
                        bool moveChanged = false;

                        for (int j = 0; j < this.LifeOfLastMove && !moveChanged; j++)
                        {
                            if (rand.Next(0, 1 + j) != 0)
                            {
                                this.LastMove = move;
                                this.LifeOfLastMove = 1;
                                moveChanged = true;
                            } //End if (rand.Next(0, 1 + j) != 0)
                        } //End for (int j = 0; j < this.LifeOfLastMove && !moveChanged; j++)

                        if (moveChanged)
                        {
                            this.LifeOfLastMove = 1;
                        } //End if (moveChanged)
                        //*/
                    } //End if (nextState.setState(possibleMoves[i], curPlayerVal))
                } //End if (nextState.setState(possibleMoves[i], curPlayerVal))
                else
                {
                    ///Pretty sure it shouldn't be possible to reach this. But who knows, 
                    ///I'm not omniscient. 
                } //End else
            } //End for (int i = 0; i < possibleMoves.Count; i++)

            return heuristicVal;
        } //End private int minValue(GameBoard curState, int maxPly, BoardVals curPlayerVal)

    } //End class Advanced
} //End namespace CS4750
