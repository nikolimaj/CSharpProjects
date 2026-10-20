namespace SchiffeVersenken
{
    internal enum State
    {
        Unknown,
        Hit,
        Miss,
        Sunk
    }

    internal interface IGameTile
    {
        public State State { get; protected set; }
        public int PosX { get; }
        public int PosY { get; }
        public bool isShip { get { return Ship != null; } }

        public Ship? Ship { get; set; }

        public static Direction horizontal(IGameTile tile1, IGameTile tile2)
        {
            if (tile1.PosX == tile2.PosX)
            {
                return Direction.Vertical;
            }
            else
            {
                return Direction.Horizontal;
            }
        }

        public void Reset()
        {
            Ship = null;
            State = State.Unknown;
        }

        public void Reveal()
        {
            if (Ship != null)
            {
                State = State.Hit;
                Ship.Hits++;
            }
            else
            {
                State = State.Miss;
            }
        }

        public void NotifyIsSunk()
        {
            State = State.Sunk;
        }
    }
    internal class PlacementTile : IGameTile
    {
        public int PosX { get; }
        public int PosY { get; }

        public Ship? Ship { get; set; }
        State IGameTile.State { get; set; }

        public PlacementTile(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }
    }

    internal class BindablePlacementTile : Panel, IGameTile
    {
        private Ship? ship;

        public Ship? Ship
        { get { return ship; } set { ship = value; BackColor = ship == null ? Color.LightBlue : Color.Black; } }

        public int PosX { get; }
        public int PosY { get; }

        private State state;

        public State State
        {
            get { return state; }
            set
            {
                state = value;
                if (Controls.Count == 0)
                {
                    this.Controls.Add(new Panel()
                    {
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        Size = this.Size / 3,
                        BackColor = Color.Gray,
                        Location = new Point((this.Width - this.Width / 3) / 2, (this.Height - this.Height / 3) / 2)
                    });
                }
            }
        }

        public BindablePlacementTile(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }

        public void Reset()
        {
            Ship = null;
            State = State.Unknown;

            Controls.Clear();
        }
    }

    internal class BindableGuessingTile : Panel, IGameTile
    {
        public int PosX { get; }
        public int PosY { get; }
        public Ship? Ship { get; set; }

        private State state;

        public State State
        {
            get { return state; }
            set
            {
                state = value;
                BackColor = state switch
                {
                    State.Unknown => Color.LightGray,
                    State.Hit => Color.Black,
                    State.Miss => Color.LightBlue,
                    State.Sunk => Color.Red
                };
            }
        }

        public BindableGuessingTile(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }
    }
}