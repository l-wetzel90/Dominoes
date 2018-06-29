/*Loren Wetzel
 * Dominoes assignment
 * 2/7/18
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Dominoes
{
    public class Game
    {
        //parts of the game thats carried over to the form
        private Panel board;

        private Button[] gameBoard;
        private TextBox messageArea;

        //lists for the players and the collection of dominos
        private List<Player> gamePlayers = new List<Player>();

        private List<Domino> dom = new List<Domino>();

        private Player currentPlayer;
        private Domino theDomino = new Domino();

        private Random rnd = new Random();
        private int playerValue;
        private int numberPlayers;

        private bool gameReady = false;
        private int click1;
        private int clickCount;
        private int keepTrack;

        public Game()
        {
        }

        public Game(Panel theBoard, TextBox theMessageArea)
        {
            this.Board = theBoard;
            this.MessageArea = theMessageArea;
            NumberPlayers = 2;
            GameBoard = new Button[28];
            MessageArea.Text = "Pick some Players";
            DrawBoard();
        }

        public List<Player> GamePlayers
        {
            get { return gamePlayers; }
            set { gamePlayers = value; }
        }

        public Panel Board
        {
            get { return board; }
            set { board = value; }
        }

        public Button[] GameBoard
        {
            get { return gameBoard; }
            set { gameBoard = value; }
        }

        public int NumberPlayers
        {
            get { return numberPlayers; }
            set { numberPlayers = value; }
        }

        public TextBox MessageArea
        {
            get { return messageArea; }
            set { messageArea = value; }
        }

        public void DrawBoard()
        {
            dom = theDomino.getDomino();

            int i = 0;//used as counter
            int left = 0;
            int top = 0;

            foreach (Domino d in dom)
            {
                GameBoard[i] = new Button();
                GameBoard[i].Width = 90;
                GameBoard[i].Height = 40;
                GameBoard[i].Tag = d.TileVal;
                GameBoard[i].Text = d.Tile;
                GameBoard[i].Font = new Font(GameBoard[i].Font.FontFamily, 15);
                //used for debugging
                //GameBoard[i].MouseHover += ButtonHover;
                GameBoard[i].BackColor = Color.White;
                GameBoard[i].ForeColor = Color.White;
                GameBoard[i].Location = new Point(left, top);
                GameBoard[i].Click += Game_Click;
                Board.Controls.Add(GameBoard[i]);
                left += 90;
                i++;

                //lays the buttons out in 4 different columns
                if (i % 4 == 0)
                {
                    left = 0;
                    top += 40;
                }
            }
        }

        //was used for testing purposes

        //private void ButtonHover(object sender, EventArgs e)
        //{
        //    ToolTip aTip = new ToolTip();
        //    Button aButton = (Button)sender;
        //    string tagValue = aButton.Tag.ToString();
        //    aTip.SetToolTip(aButton, tagValue);
        //}

        private void Game_Click(object sender, EventArgs e)
        {
            Button clickedButton;
            clickedButton = (Button)sender;

            //checks if players have been picked and checks for tile not flipped.
            //Otherwise it would let you double click the same tile
            if (gameReady && clickedButton.ForeColor == Color.White)
            {
                clickCount++;//keeps track of tiles clicked

                if (clickCount % 2 != 0)//stores first tile clicked value in variable to be used again
                {
                    clickedButton.ForeColor = Color.Black;
                    click1 = Convert.ToInt16(clickedButton.Tag);
                }

                else//if it's the second tile clicked
                {
                    clickedButton.ForeColor = Color.Black;
                    Application.DoEvents();
                    Thread.Sleep(3000);//pauses for 3 seconds to allow player to look at tiles

                    if (CheckFor12(Convert.ToInt16(clickedButton.Tag)))//method used to check for 12 total
                    {
                        currentPlayer.Wins++;//keeps track of the total matches the player has
                        TurnOff();//method used to turn off tiles if they equal 12
                        playerValue++;
                        currentPlayer = gamePlayers[playerValue % 2];
                        NextPlayer();
                        keepTrack++;//used to keep track of total matches so it will end the game
                    }
                    else
                    {
                        playerValue++;
                        currentPlayer = gamePlayers[playerValue % 2];
                        NextPlayer();
                        ChangeBack();//chanegs tiles back
                    }
                    if (keepTrack == 14)
                    {
                        Winner();
                    }
                }
            }
        }

        private void Winner()//checks for winner comparing number of  matched tiles
        {
            if (gamePlayers[0].Wins > gamePlayers[1].Wins)
            {
                messageArea.Text = gamePlayers[0].Name + " wins with " + gamePlayers[0].Wins + " matches";
            }
            else if (gamePlayers[0].Wins < gamePlayers[1].Wins)
            {
                messageArea.Text = gamePlayers[1].Name + " wins with " + gamePlayers[1].Wins + " matches";
            }
            else
            {
                messageArea.Text = "You are both losers. Try that again.";
            }
        }

        private void TurnOff()
        {
            for (int but = 0; but <= GameBoard.GetUpperBound(0); but++)
            {
                if (GameBoard[but].ForeColor == Color.Black)
                {
                    GameBoard[but].Visible = false;
                }
            }
        }

        private void ChangeBack()
        {
            for (int but = 0; but <= GameBoard.GetUpperBound(0); but++)
            {
                if (GameBoard[but].ForeColor == Color.Black)
                {
                    GameBoard[but].ForeColor = Color.White;
                }
            }
        }

        private bool CheckFor12(int aNum)
        {
            if (click1 + aNum == 12)
            {
                return true;
            }
            else return false;
        }

        public void AddPlayer(Player aPlayer)
        {
            if (gamePlayers.Count < NumberPlayers)
            {
                gamePlayers.Add(aPlayer);
                if (gamePlayers.Count == 1)
                {
                    messageArea.Text = "Choose one more player";
                }
                else if (GamePlayers[0] == GamePlayers[1])//checks that you are not picking the same name twice
                {
                    messageArea.Text = "SERIOUSLY.. You can't play yourself.";
                    gamePlayers.RemoveAt(1);
                }
                else
                {
                    PickTeam();
                }
            }
        }

        private void PickTeam()
        {
            playerValue = rnd.Next(0, 2);
            gamePlayers[playerValue].Team = "1";
            currentPlayer = gamePlayers[playerValue];

            //who is the "O"
            if (playerValue == 0)
            {
                gamePlayers[1].Team = "2";
            }
            else
            {
                gamePlayers[0].Team = "2";
            }

            gameReady = true;
            NextPlayer();
        }

        private void NextPlayer()
        {
            messageArea.Text = currentPlayer.Name + "'s Turn";
        }
    }//end of class
}
