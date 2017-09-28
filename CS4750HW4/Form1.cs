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

            this.Board.setState(playerChoice, BoardVals.O);
            //this.Beginner.Board.setState(playerChoice, BoardVals.O);
            this.Advanced.Board.setState(playerChoice, BoardVals.O);
            displayData(this.Board.displayBoard());
        } //End private void btnPlace_Click(object sender, EventArgs e)

        private void btnBeginner_Click(object sender, EventArgs e)
        {
            //Declare variables
            Point move = this.Beginner.beginnerDecision();

            this.Board.setState(move, this.Beginner.PlayersVal);
            this.Beginner.Board.setState(move, this.Beginner.PlayersVal);
            displayData(this.Board.displayBoard());
        } //End private void btnBeginner_Click(object sender, EventArgs e)

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            //Declare variables
            Point move = new Point(-1, -1);

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
                
                if (this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))
                {
                    if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    {
                        displayDataAppend("Advanced won!");
                    } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal))
                    else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    {
                        displayDataAppend("Beginner won!");
                    } //End else if (this.Board.findFourInARow(this.Beginner.PlayersVal))
                    else
                    {
                        displayDataAppend("Draw!");
                    } //End else
                } //End if (this.Board.findFourInARow(this.Advanced.PlayersVal) && !this.Board.findFourInARow(this.Beginner.PlayersVal))
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

            if (this.chkAIOnly.Checked)
            {

            } //End if (this.chkAIOnly.Checked)
            else
            {
                move = this.Master.minimaxDecision();

                this.Board.setState(move, this.Master.PlayersVal);
                this.Master.Board.setState(move, this.Master.PlayersVal);
                displayData(this.Board.displayBoard());
            } //End else


        } //End private void btnMaster_Click(object sender, EventArgs e)

        private void btnTournament_Click(object sender, EventArgs e)
        {

        } //End private void btnTournament_Click(object sender, EventArgs e)

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        } //End private void btnReset_Click(object sender, EventArgs e)

    } //End public partial class Form1 : Form
} //End namespace CS4750HW4
