using System;

namespace SchiffeVersenken
{
    internal class Game
    {
        public delegate void RestartHandler();
        public event RestartHandler Restart;

        private Opponent opponent;

        private PlacementBoard placement_player;
        private PlacementBoard placement_opp;

        private GuessingBoard guessing_player;
        private GuessingBoard guessing_opp;

        private TableLayoutPanel placementGui;
        private TableLayoutPanel guessingGui;

        private HighScoreList highScoreList;

        public bool Started { get; private set; } = false;

        public Game(TableLayoutPanel placement_gui, TableLayoutPanel guessing_gui)
        {
            placementGui = placement_gui;
            guessingGui = guessing_gui;

            highScoreList = new HighScoreList();

            Initialize();

        }

        public void Initialize()
        {
            Started = false;

            placement_player = new PlacementBoard(placementGui);
            placement_player.Reset();

            if(guessing_player != null)
            {
                guessing_player.Reset();
            }
            
        }

        public void Start()
        {
            guessing_opp = new GuessingBoard(placement_player, placementGui);
            opponent = new Opponent(guessing_opp);
            placement_opp = opponent.board;
            guessing_player = new GuessingBoard(placement_opp, guessingGui);

            Started = true;
        }

        public void ToggleShipState(int row, int col)
        {
            placement_player.toggleState(row, col);
        }

        public bool IsValidPlacement()
        {
            return placement_player.isValid();
        }

        public void TakeGuess(int row, int col)
        {
            // player didn't guess ship -> opponent's turn
            if (!guessing_player.Reveal(row, col))
            {
                int posX, posY;
                do
                {
                    (posX, posY) = opponent.TakeTurn();
                }
                while (guessing_opp.Reveal(posX, posY)); // let opponent guess until he didn't guess a ship
            }

            if (guessing_player.Won())
            {
                highScoreList.AddNewItem(guessing_player.Guesses);

                highScoreList.Show();

                Restart?.Invoke();
            }
            else if (guessing_opp.Won())
            {
                MessageBox.Show("You lost!");
                highScoreList.Show();
                Restart?.Invoke();
            }

            
        }
    }
}