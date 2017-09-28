using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        //Properties
        private GameBoard Board { get; set; }
        private Beginner Beginner { get; set; }
        private Advanced Advanced { get; set; }
        private Master Master { get; set; }

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
            Point move = this.Advanced.minimaxDecision();

            this.Board.setState(move, this.Advanced.PlayersVal);
            this.Advanced.Board.setState(move, this.Advanced.PlayersVal);
            displayData(this.Board.displayBoard());
        } //End private void btnAdvanced_Click(object sender, EventArgs e)

        private void btnMaster_Click(object sender, EventArgs e)
        {
            //Declare variables
            Point move = this.Master.minimaxDecision();

            this.Board.setState(move, this.Master.PlayersVal);
            this.Master.Board.setState(move, this.Master.PlayersVal);
            displayData(this.Board.displayBoard());
        } //End private void btnMaster_Click(object sender, EventArgs e)

        private void btnTournament_Click(object sender, EventArgs e)
        {

        } //End private void btnTournament_Click(object sender, EventArgs e)
    } //End public partial class Form1 : Form
} //End namespace CS4750HW4
