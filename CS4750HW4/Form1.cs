using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS4750HW4
{
    public enum BoardVals
    {
        NULL = -1,
        O = 0,
        X = 1
    } //End public enum BoardVals

    public enum BoardDirection
    {
        NUll = -1,
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
        UpLeft = 4,
        UpRight = 5,
        DownLeft = 6,
        DownRight = 7
    } //End public enum BoardDirection

    public enum Difficulty
    {
        NULL = -1,
        Beginner = 0,
        Advanced = 1,
        Master = 2
    } //End public enum Difficulty

    public partial class Form1 : Form
    {
        /***************ATTRIBUTES***************/
        //Fields
        private Stopwatch timer;

        //Properties
        private GameBoard Board { get; set; }
        private Beginner Beginner { get; set; }
        private Advanced Advanced { get; set; }
        private Master Master { get; set; }
        private BoardVals WhosTurn { get; set; }
        private Difficulty Difficulty { get; set; }

        /***************CONSTRUCTOR***************/
        public Form1()
        {
            InitializeComponent();
            this.cmbRow.SelectedIndex = 0;
            this.cmbColumn.SelectedIndex = 0;
            this.Board = new GameBoard();
            this.Beginner = new Beginner(BoardVals.X);
            this.Advanced = new Advanced(BoardVals.X);
            this.Master = new Master(BoardVals.X);
            this.Difficulty = Difficulty.Beginner;
            displayData(this.Board.displayBoard());
        } //End public Form1

        /***************METHODS***************/
        public void displayData(string data)
        {
            //this.rtxtDisplay.Text += data + "\n\n" + "*****************************************************************\n";
            this.rtxtDisplay.Text = data;
        } //End public void displayData(string data)

        public void displayDataAppend(string data)
        {
            this.rtxtDisplay.Text += "\n\n" + data;
        } //End public void displayData(string data)

        public void displayMillisecondsElapsed()
        {
            timer.Stop();
            this.displayDataAppend("Time elapsed: " + this.timer.ElapsedMilliseconds.ToString() + " milliseconds");
        } //End public void displayMillisecondsElapsed()

        private void reset()
        {
            this.Board = new GameBoard();
            this.Beginner = new Beginner(BoardVals.X);
            this.Advanced = new Advanced(BoardVals.X);
            this.Master = new Master(BoardVals.X);
            displayData(this.Board.displayBoard());
            this.WhosTurn = BoardVals.O;
        } //End private void reset()

        /***************EVENTS***************/
        private void btnPlace_Click(object sender, EventArgs e)
        {
            //Declare variables
            Point playerChoice = new Point(this.cmbRow.SelectedIndex, this.cmbColumn.SelectedIndex);
            BoardVals playerVal = BoardVals.NULL;

            if (this.Difficulty == Difficulty.Beginner)
            {
                playerVal = this.Beginner.OpponentsVal;
            } //End if (this.Difficulty == Difficulty.Beginner)
            else if (this.Difficulty == Difficulty.Advanced)
            {
                playerVal = this.Advanced.OpponentsVal;
            } //End else if (this.Difficulty == Difficulty.Advanced)
            else if (this.Difficulty == Difficulty.Master)
            {
                playerVal = this.Master.OpponentsVal;
            } //End else if (this.Difficulty == Difficulty.Master)

            this.Board.setState(playerChoice, playerVal);
            this.Beginner.Board.setState(playerChoice, this.Advanced.OpponentsVal);
            this.Advanced.Board.setState(playerChoice, this.Advanced.OpponentsVal);
            this.Master.Board.setState(playerChoice, this.Master.OpponentsVal);
            displayData(this.Board.displayBoard());
        } //End private void btnPlace_Click(object sender, EventArgs e)

        private void btnBeginner_Click(object sender, EventArgs e)
        {
            //Declare variables
            Point move = this.Beginner.beginnerDecision();

            this.Difficulty = Difficulty.Beginner;

            this.Board.setState(move, this.Beginner.PlayersVal);
            this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
            displayData(this.Board.displayBoard());
        } //End private void btnBeginner_Click(object sender, EventArgs e)

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            //Declare variables
            Point move = new Point(-1, -1);

            this.Difficulty = Difficulty.Advanced;

            if (this.chkAIOnly.Checked)
            {
                if (this.chkSingleTurn.Checked)
                {
                    if (this.Beginner.PlayersVal != BoardVals.O)
                    {
                        this.Beginner = new Beginner(BoardVals.O);
                    } //End if (this.Beginner.PlayersVal != BoardVals.O)

                    if (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        if (this.WhosTurn == BoardVals.O)
                        {
                            this.WhosTurn = BoardVals.X;

                            move = this.Beginner.beginnerDecision();

                            if (!this.Board.setState(move, this.Beginner.PlayersVal))
                            {
                                ///wat?
                            } //End 
                            this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
                            this.Advanced.Board.setState(move, this.Beginner.PlayersVal);
                            displayData("Beginner's Turn\n\n" + this.Board.displayBoard());
                        } //End if (this.WhosTurn == BoardVals.O)
                        else if (this.WhosTurn == BoardVals.X)
                        {
                            this.WhosTurn = BoardVals.O;

                            this.timer = Stopwatch.StartNew();
                            move = this.Advanced.minimaxDecision();
                            this.timer.Stop();

                            if (!this.Board.setState(move, this.Advanced.PlayersVal))
                            {
                                ///wat?
                            } //End 
                            this.Beginner.Board.setState(move, this.Advanced.PlayersVal);
                            this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                            displayData("Advanced's Turn\n\n" + this.Board.displayBoard());
                            displayDataAppend("Number of nodes generated: " + this.Advanced.NodesGenerated);
                            displayMillisecondsElapsed();
                        } //End else if (this.WhosTurn == BoardVals.X)
                    } //End if (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.chkSingleTurn.Checked)
                else
                {
                    if (!this.chkFinishGame.Checked)
                    {
                        reset();
                        this.Beginner = new Beginner(BoardVals.O);
                    } //End if (!this.chkFinishGame.Checked)

                    int turns = 0;
                    while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                    {
                        turns += 1;

                        move = this.Beginner.beginnerDecision();

                        this.Board.setState(move, this.Beginner.PlayersVal);
                        this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
                        this.Advanced.Board.setState(move, this.Beginner.PlayersVal);
                        displayData(this.Board.displayBoard());

                        if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                        {
                            break;
                        } //End if (this.Board.findFourInAROw(this.Beginner.PlayersVal))

                        this.timer = Stopwatch.StartNew();
                        move = this.Advanced.minimaxDecision();
                        this.timer.Stop();

                        this.Board.setState(move, this.Advanced.PlayersVal);
                        this.Beginner.Board.setState(move, this.Advanced.PlayersVal);
                        this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                        displayData(this.Board.displayBoard());
                        displayDataAppend("Number of nodes generated: " + this.Advanced.NodesGenerated);
                        displayMillisecondsElapsed();
                    } //End while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End else

                if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        displayDataAppend("Advanced won!");
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        displayDataAppend("Beginner won!");
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    displayDataAppend("Draw!");
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End if (this.chkAIOnly.Checked)
            else
            {
                move = this.Advanced.minimaxDecision();

                this.Board.setState(move, this.Advanced.PlayersVal);
                this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                displayData(this.Board.displayBoard());
            } //End else


        } //End private void btnAdvanced_Click(object sender, EventArgs e)

        private void btnMaster_Click(object sender, EventArgs e)
        {
            //Declare variables
            Point move = new Point(-1, -1);

            this.Difficulty = Difficulty.Master;

            if (this.chkAIOnly.Checked)
            {
                if (this.chkSingleTurn.Checked)
                {
                    if (this.Advanced.PlayersVal != BoardVals.O)
                    {
                        this.Advanced = new Advanced(BoardVals.O);
                    } //End if (this.Beginner.PlayersVal != BoardVals.O)

                    if (!this.Board.findFourInARow(this.Master.PlayersVal) && !this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        if (this.WhosTurn == BoardVals.O)
                        {
                            this.WhosTurn = BoardVals.X;

                            move = this.Advanced.minimaxDecision();

                            if (!this.Board.setState(move, this.Advanced.PlayersVal))
                            {
                                ///wat?
                            } //End 
                            this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                            this.Master.Board.setState(move, this.Advanced.PlayersVal);
                            displayData("Advanced's Turn\n\n" + this.Board.displayBoard());
                        } //End if (this.WhosTurn == BoardVals.O)
                        else if (this.WhosTurn == BoardVals.X)
                        {
                            this.WhosTurn = BoardVals.O;

                            this.timer = Stopwatch.StartNew();
                            move = this.Master.minimaxDecision();
                            this.timer.Stop();

                            if (!this.Board.setState(move, this.Master.PlayersVal))
                            {
                                ///wat?
                            } //End 
                            this.Advanced.Board.setState(move, this.Master.PlayersVal);
                            this.Master.Board.setState(move, this.Master.PlayersVal);
                            displayData("Master's Turn\n\n" + this.Board.displayBoard());
                            displayDataAppend("Number of nodes generated: " + this.Master.NodesGenerated);
                            displayMillisecondsElapsed();
                        } //End else if (this.WhosTurn == BoardVals.X)
                    } //End if (!this.Board.findFourInARow(this.Master.PlayersVal) && !this.Board.findFourInARow(this.Advanced.PlayersVal))
                } //End if (this.chkSingleTurn.Checked)
                else
                {
                    if (!this.chkFinishGame.Checked)
                    {
                        reset();
                        this.Advanced = new Advanced(BoardVals.O);
                    } //End if (!this.chkFinishGame.Checked)

                    int turns = 0;
                    while (!this.Board.findFourInARow(this.Master.PlayersVal) && !this.Board.findFourInARow(this.Advanced.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                    {
                        turns += 1;

                        move = this.Advanced.minimaxDecision();

                        this.Board.setState(move, this.Advanced.PlayersVal);
                        this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                        this.Master.Board.setState(move, this.Advanced.PlayersVal);
                        displayData(this.Board.displayBoard());

                        if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                        {
                            break;
                        } //End if (this.Board.findFourInAROw(this.Advanced.PlayersVal))

                        this.timer = Stopwatch.StartNew();
                        move = this.Master.minimaxDecision();
                        this.timer.Stop();

                        this.Board.setState(move, this.Master.PlayersVal);
                        this.Advanced.Board.setState(move, this.Master.PlayersVal);
                        this.Master.Board.setState(move, this.Master.PlayersVal);
                        displayData(this.Board.displayBoard());
                        displayDataAppend("Number of nodes generated: " + this.Master.NodesGenerated);
                        displayMillisecondsElapsed();
                    } //End while (!this.Board.findFourInARow(this.Master.PlayersVal) && !this.Board.findFourInARow(this.Advanced.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                } //End else

                if (this.Board.findFourInARow(this.Master.PlayersVal) || this.Board.findFourInARow(this.Advanced.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Master.PlayersVal))
                    {
                        displayDataAppend("Master won!");
                    } //End if (this.Board.findFourInARow(this.Master.PlayersVal))
                    else if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        displayDataAppend("Advanced won!");
                    } //End else if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Master.PlayersVal) || !this.Board.findFourInARow(this.Advanced.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    displayDataAppend("Draw!");
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End if (this.chkAIOnly.Checked)
            else
            {
                move = this.Master.minimaxDecision();

                this.Board.setState(move, this.Master.PlayersVal);
                //this.Master.Board.setState(move, this.Master.PlayersVal);
                if (!this.Master.Board.setState(move, this.Master.PlayersVal))
                {
                    ///wat?
                } //End 
                displayData(this.Board.displayBoard());
            } //End else


        } //End private void btnMaster_Click(object sender, EventArgs e)

        private void btnTournament_Click(object sender, EventArgs e)
        {
            //Declare variables
            TournamentResults bVa = new TournamentResults();
            TournamentResults bVm = new TournamentResults();
            TournamentResults aVb = new TournamentResults();
            TournamentResults aVm = new TournamentResults();
            TournamentResults mVb= new TournamentResults();
            TournamentResults mVa = new TournamentResults();
            Point move = new Point(-1, -1);

            //Beginner first vs Advanced
            for (int i = 0; i < 50; i++)
            {
                reset();
                this.Beginner = new Beginner(BoardVals.O);
                
                while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                {
                    move = this.Beginner.beginnerDecision();

                    this.Board.setState(move, this.Beginner.PlayersVal);
                    this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
                    this.Advanced.Board.setState(move, this.Beginner.PlayersVal);
                    displayData(this.Board.displayBoard());

                    if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        break;
                    } //End if (this.Board.findFourInAROw(this.Beginner.PlayersVal))
                    
                    move = this.Advanced.minimaxDecision();

                    this.Board.setState(move, this.Advanced.PlayersVal);
                    this.Beginner.Board.setState(move, this.Advanced.PlayersVal);
                    this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                    displayData(this.Board.displayBoard());
                } //End while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))

                if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        bVa.Losses += 1;
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        bVa.Wins += 1;
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    bVa.Ties += 1;
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End for (int i = 0; i < 50; i++)
            //**
            //Beginner first vs Master
            for (int i = 0; i < 50; i++)
            {
                reset();
                this.Beginner = new Beginner(BoardVals.O);

                while (!this.Board.findFourInARow(this.Master.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                {
                    move = this.Beginner.beginnerDecision();

                    this.Board.setState(move, this.Beginner.PlayersVal);
                    this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
                    this.Master.Board.setState(move, this.Beginner.PlayersVal);
                    displayData(this.Board.displayBoard());

                    if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        break;
                    } //End if (this.Board.findFourInAROw(this.Beginner.PlayersVal))
                    
                    move = this.Master.minimaxDecision();

                    this.Board.setState(move, this.Master.PlayersVal);
                    this.Beginner.Board.setState(move, this.Master.PlayersVal);
                    this.Master.Board.setState(move, this.Master.PlayersVal);
                    displayData(this.Board.displayBoard());
                } //End while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))

                if (this.Board.findFourInARow(this.Master.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Master.PlayersVal))
                    {
                        bVm.Losses += 1;
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        bVm.Wins += 1;
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    bVm.Ties += 1;
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End for (int i = 0; i < 50; i++)
            //*/
            //Advanced first vs Beginner
            for (int i = 0; i < 50; i++)
            {
                reset();
                this.Advanced = new Advanced(BoardVals.O);

                while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                {
                    move = this.Advanced.minimaxDecision();

                    this.Board.setState(move, this.Advanced.PlayersVal);
                    this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                    this.Beginner.Board.setState(move, this.Advanced.PlayersVal);
                    displayData(this.Board.displayBoard());

                    if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        break;
                    } //End if (this.Board.findFourInAROw(this.Beginner.PlayersVal))

                    move = this.Beginner.beginnerDecision();

                    this.Board.setState(move, this.Beginner.PlayersVal);
                    this.Advanced.Board.setState(move, this.Beginner.PlayersVal);
                    this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
                    displayData(this.Board.displayBoard());
                } //End while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))

                if (this.Board.findFourInARow(this.Beginner.PlayersVal) || this.Board.findFourInARow(this.Advanced.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        aVb.Losses += 1;
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        aVb.Wins += 1;
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    aVb.Ties += 1;
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End for (int i = 0; i < 50; i++)

            /**
            //Advanced first vs Master
            for (int i = 0; i < 50; i++)
            {
                reset();
                this.Advanced = new Advanced(BoardVals.O);

                while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Master.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                {
                    move = this.Advanced.minimaxDecision();

                    this.Board.setState(move, this.Advanced.PlayersVal);
                    this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                    this.Master.Board.setState(move, this.Advanced.PlayersVal);
                    displayData(this.Board.displayBoard());

                    if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        break;
                    } //End if (this.Board.findFourInAROw(this.Beginner.PlayersVal))

                    move = this.Master.minimaxDecision();

                    this.Board.setState(move, this.Master.PlayersVal);
                    this.Advanced.Board.setState(move, this.Master.PlayersVal);
                    this.Master.Board.setState(move, this.Master.PlayersVal);
                    displayData(this.Board.displayBoard());
                } //End while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))

                if (this.Board.findFourInARow(this.Master.PlayersVal) || this.Board.findFourInARow(this.Advanced.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Master.PlayersVal))
                    {
                        aVm.Losses += 1;
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        aVm.Wins += 1;
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    aVm.Ties += 1;
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End for (int i = 0; i < 50; i++)
            //*/
            /**
            //Master first vs Beginner
            for (int i = 0; i < 50; i++)
            {
                reset();
                this.Master = new Master(BoardVals.O);

                while (!this.Board.findFourInARow(this.Master.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                {
                    move = this.Master.minimaxDecision();

                    this.Board.setState(move, this.Master.PlayersVal);
                    this.Master.Board.setState(move, this.Master.PlayersVal);
                    this.Beginner.Board.setState(move, this.Master.PlayersVal);
                    displayData(this.Board.displayBoard());

                    if (this.Board.findFourInARow(this.Master.PlayersVal))
                    {
                        break;
                    } //End if (this.Board.findFourInAROw(this.Beginner.PlayersVal))

                    move = this.Beginner.beginnerDecision();

                    this.Board.setState(move, this.Beginner.PlayersVal);
                    this.Master.Board.setState(move, this.Beginner.PlayersVal);
                    this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
                    displayData(this.Board.displayBoard());
                } //End while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))

                if (this.Board.findFourInARow(this.Beginner.PlayersVal) || this.Board.findFourInARow(this.Master.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        mVb.Losses += 1;
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Master.PlayersVal))
                    {
                        mVb.Wins += 1;
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    mVb.Ties += 1;
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End for (int i = 0; i < 50; i++)
            //*/
            /**
            //Master first vs Advanced
            for (int i = 0; i < 50; i++)
            {
                reset();
                this.Master = new Master(BoardVals.O);

                while (!this.Board.findFourInARow(this.Master.PlayersVal) && !this.Board.findFourInARow(this.Advanced.PlayersVal) && this.Board.getPossibleMoves().Count > 0)
                {
                    move = this.Master.minimaxDecision();

                    this.Board.setState(move, this.Master.PlayersVal);
                    this.Master.Board.setState(move, this.Master.PlayersVal);
                    this.Advanced.Board.setState(move, this.Master.PlayersVal);
                    displayData(this.Board.displayBoard());

                    if (this.Board.findFourInARow(this.Master.PlayersVal))
                    {
                        break;
                    } //End if (this.Board.findFourInAROw(this.Beginner.PlayersVal))

                    move = this.Advanced.minimaxDecision();

                    this.Board.setState(move, this.Advanced.PlayersVal);
                    this.Master.Board.setState(move, this.Advanced.PlayersVal);
                    this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
                    displayData(this.Board.displayBoard());
                } //End while (!this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))

                if (this.Board.findFourInARow(this.Master.PlayersVal) || this.Board.findFourInARow(this.Advanced.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        mVa.Losses += 1;
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Master.PlayersVal))
                    {
                        mVa.Wins += 1;
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) || this.Board.findFourInARow(this.Beginner.PlayersVal))
                else if (this.Board.getPossibleMoves().Count <= 0)
                {
                    mVa.Ties += 1;
                } //End else if (this.Board.getPossibleMoves().Count <= 0)
            } //End for (int i = 0; i < 50; i++)
            //*/
            displayData(
                "\n\nB vs A: \n\tWins - " + bVa.Wins + "\n\tLosses - " + bVa.Losses + "\n\tTies - " + bVa.Ties +
                "\n\nB vs M: \n\tWins - " + bVm.Wins + "\n\tLosses - " + bVm.Losses + "\n\tTies - " + bVm.Ties +
                "\n\nA vs B: \n\tWins - " + aVb.Wins + "\n\tLosses - " + aVb.Losses + "\n\tTies - " + aVb.Ties +
                "\n\nA vs M: \n\tWins - " + aVm.Wins + "\n\tLosses - " + aVm.Losses + "\n\tTies - " + aVm.Ties +
                "\n\nM vs B: \n\tWins - " + mVb.Wins + "\n\tLosses - " + mVb.Losses + "\n\tTies - " + mVb.Ties +
                "\n\nM vs A: \n\tWins - " + mVa.Wins + "\n\tLosses - " + mVa.Losses + "\n\tTies - " + mVa.Ties
                );

        } //End private void btnTournament_Click(object sender, EventArgs e)

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        } //End private void btnReset_Click(object sender, EventArgs e)

    } //End public partial class Form1 : Form
} //End namespace CS4750HW4
