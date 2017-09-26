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
        } //End public Form1()

        /***************METHODS***************/

        /***************EVENTS***************/

    } //End public partial class Form1 : Form
} //End namespace CS4750HW4
