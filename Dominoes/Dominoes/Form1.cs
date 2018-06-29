/*Loren Wetzel
 * Dominoes assignment
 * 2/7/18
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dominoes
{
    public partial class frmDominoes : Form
    {
        public frmDominoes()
        {
            InitializeComponent();
        }
        Game myGame = null;
        List<Player> availablePlayers = new List<Player>(35);
        private void frmDominoes_Load(object sender, EventArgs e)
        {
            availablePlayers.Add(new Player("Loren"));//hard coding players
            availablePlayers.Add(new Player("Romeo"));
            availablePlayers.Add(new Player("Ash"));
            availablePlayers.Add(new Player("Wyatt"));
            availablePlayers.Add(new Player("Brit"));

            DisplayAvailablePlayers();
            myGame = new Game(pnlBoard, txtMessageArea);
        }
        private void DisplayAvailablePlayers()
        {
            foreach (Player p in availablePlayers)
            {
                lstAvailiblePlayers.Items.Add(p);
            }
        }

        private void ShowGamePlayers()
        {
            lstPlayers.Items.Clear();
            foreach (Player p in myGame.GamePlayers)
            {
                lstPlayers.Items.Add(p);
            }
        }

        private void lstAvailiblePlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player pickedPlayer = (Player)lstAvailiblePlayers.SelectedItem;
            myGame.AddPlayer(pickedPlayer);
            ShowGamePlayers();
        }

        //starts a new game
        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlBoard.Controls.Clear();
            myGame = new Game(pnlBoard, txtMessageArea);
            ShowGamePlayers();
        }
    }
}
