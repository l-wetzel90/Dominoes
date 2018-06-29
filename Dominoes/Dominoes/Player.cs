/*Loren Wetzel
 * Dominoes assignment
 * 2/7/18
 * I bowwored this from the tic tac toe game.
 */

namespace Dominoes
{
    public class Player
    {
        //field values
        private string name;

        private int wins;
        private string team;

        public Player()
        {
        }

        public Player(string theName)
        {
            this.name = theName;
            this.Wins = 0;
            this.Team = "";
        }

        //property procedures
        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        public int Wins
        {
            get { return wins; }
            set { wins = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }//end of class
}
