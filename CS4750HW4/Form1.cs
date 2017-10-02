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

    public partial class Form1 : Form
    {
        /***************ATTRIBUTES***************/
        //Fields


        //Properties

        /***************CONSTRUCTOR***************/
        public Form1()
        {
            InitializeComponent();
            this.cmbRow.SelectedIndex = 0;
            this.cmbColumn.SelectedIndex = 0;
        } //End public Form1

        /***************METHODS***************/
        public void displayData(string data)
        {

        } //End 


        /***************EVENTS***************/
        private void btnPlace_Click(object sender, EventArgs e)
        {

        } //End private void btnPlace_Click(object sender, EventArgs e)

        private void btnBeginner_Click(object sender, EventArgs e)
        {

        } //End private void btnBeginner_Click(object sender, EventArgs e)

        private void btnAdvanced_Click(object sender, EventArgs e)
        {

        } //End private void btnAdvanced_Click(object sender, EventArgs e)

        private void btnMaster_Click(object sender, EventArgs e)
        {

        } //End private void btnMaster_Click(object sender, EventArgs e)

        private void btnTournament_Click(object sender, EventArgs e)
        {
            //Testing code for 3 in a row matching
            GameBoard b = new GameBoard();
            String[,] colorMap = new String[5, 6];
            Tuple<List<List<Point>>, List<List<Point>>> triples = b.getThreesInARow(colorMap);
            Tuple<List<List<Point>>, List<List<Point>>> doubles = b.getTwosInARow(colorMap);

            foreach (List<Point> triple in triples.Item1)
            {
                foreach(Point p in triple)
                {
                    System.Diagnostics.Debug.WriteLine(p.ToString());
                }
                System.Diagnostics.Debug.WriteLine("");
            }

            foreach(List<Point> triple in triples.Item2)
            {
                foreach(Point p in triple)
                {
                    System.Diagnostics.Debug.WriteLine(p.ToString());
                }
                System.Diagnostics.Debug.WriteLine("");
            }

            for(int i = 0; i < colorMap.GetLength(0); i++)
            {
                for(int j = 0; j < colorMap.GetLength(1); j++)
                {
                    if (colorMap[i, j] == null)
                    {
                        System.Diagnostics.Debug.Write("#|");
                    }
                    else
                    {
                        System.Diagnostics.Debug.Write(colorMap[i, j]+"|");
                    }
                }
                System.Diagnostics.Debug.Write("\n");
            }

            System.Diagnostics.Debug.Write("\nX doubles:\n");

            foreach (List<Point> pair in doubles.Item1)
            {
                foreach (Point p in pair)
                {
                    System.Diagnostics.Debug.Write(p + "|");
                }
                System.Diagnostics.Debug.Write("\n");
            }

            System.Diagnostics.Debug.Write("\nO doubles:\n");

            foreach (List<Point> pair in doubles.Item2)
            {
                foreach (Point p in pair)
                {
                    System.Diagnostics.Debug.Write(p + "|");
                }
                System.Diagnostics.Debug.Write("\n");
            }
        } //End private void btnTournament_Click(object sender, EventArgs e)
    } //End public partial class Form1 : Form
} //End namespace CS4750HW4