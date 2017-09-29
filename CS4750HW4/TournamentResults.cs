using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4750HW4
{
    class TournamentResults
    {
        /***************ATTRIBUTES***************/
        //Fields

        //Properties
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        /***************CONSTRUCTOR***************/
        public TournamentResults()
        {
            this.Wins = this.Losses = this.Ties = 0;
        } //End public TournamentResults()

        /***************METHODS***************/
        

    } //End class TournamentResults
} //End namespace CS4750HW4
