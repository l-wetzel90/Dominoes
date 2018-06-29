/*Loren Wetzel
 * Dominoes assignment
 * 2/7/18
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominoes
{
    public class Domino
    {
        private string tile;

        private int tileVal;

        public Domino()
        {
        }

        public Domino(string theTile)
        {
            string[] parts = theTile.Split(',');//this splits the string array up to to single numbers

            tile = parts[0] + "   |   " + parts[1];//assigns the name basically to the domino
            tileVal = Convert.ToInt16(parts[0]) + Convert.ToInt16(parts[1]);//assigns value
        }

        public string Tile { get => tile; set => tile = value; }
        public int TileVal { get => tileVal; set => tileVal = value; }

        //I didn't make another class for the list. Maybe I should have.
        public List<Domino> getDomino()
        {
            string[] tileValues = {
                "0,1","0,2","0,3","0,4","0,5","0,6",
                "1,2","1,3","1,4","1,5","1,6",
                "2,3","2,4","2,5","2,6",
                "3,4","3,5","3,6",
                "4,5","4,6",
                "5,6",
                "0,0","1,1","2,2", "3,3", "4,4","5,5","6,6"
            };

            List<Domino> dominoes = new List<Domino>();

            for (int d = 0; d <= tileValues.GetUpperBound(0); d++)
            {
                dominoes.Add(new Domino(tileValues[d]));
            }
            var rnd = new Random();
            dominoes = dominoes.OrderBy(x => rnd.Next()).ToList();//shuffles dominos

            return dominoes;
        }

        public override string ToString()
        {
            return Tile;
        }
    }//end of class
}
