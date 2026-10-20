using SchiffeVersenken;

namespace SchiffeVersenken
{
    public partial class Form1 : Form
    {

        Game game;

        public Form1()
        {
            InitializeComponent();

            // create first grid

            for (int row = 0; row < grid1.RowCount; row++)
            {
                for (int col = 0; col < grid1.ColumnCount; col++)
                {
                    grid1.Controls.Add(new BindablePlacementTile(row, col)
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.LightBlue,
                        Margin = new Padding(0),
                        Padding = new Padding(0)
                    }, row, col);
                }
            }


            // create second grid
            for (int row = 0; row < grid2.RowCount; row++)
            {
                for (int col = 0; col < grid2.ColumnCount; col++)
                {
                    grid2.Controls.Add(new BindableGuessingTile(row, col)
                    {
                        Dock = DockStyle.None,
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                    }, row, col);
                }
            }

            // add event handlers
            foreach (Panel pnl in grid1.Controls)
            {
                pnl.MouseClick += toggleState;
            }

            game = new Game(grid1, grid2);
            
            game.Restart += Initialize;

        }

        public void Initialize()
        {
            game.Initialize();

            foreach (Panel pnl in grid1.Controls)
            {
                pnl.MouseClick += toggleState;
            }

            foreach (Panel pnl in grid2.Controls)
            {
                pnl.MouseClick -= takeGuess;
            }

            button1.Text = "Start Game";
        }

        private void toggleState(object sender, EventArgs e)
        {
            if (sender is BindablePlacementTile clickedCell)
            {
                game.ToggleShipState(grid1.GetColumn(clickedCell), grid1.GetRow(clickedCell));

            }
        }

        private void takeGuess(object sender, EventArgs e)
        {
            if (sender is Panel clickedCell)
            {
                game.TakeGuess(grid2.GetColumn(clickedCell), grid2.GetRow(clickedCell));

                // remove event handler - > can't click twice
                clickedCell.MouseClick -= takeGuess;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(game.Started)
            {
                Initialize();

            }
            else
            {
                //if (game.IsValidPlacement())
                {

                    // remove event handlers
                    foreach (Panel pnl in grid1.Controls)
                    {
                        pnl.MouseClick -= toggleState;
                    }

                    foreach (Panel pnl in grid2.Controls)
                    {
                        pnl.MouseClick += takeGuess;
                    }

                    game.Start();
                    button1.Text = "Reset";
                }
                //else { MessageBox.Show("Invalid Placement. Please read the Instructions!");}
            }

            


        }
    }




}

