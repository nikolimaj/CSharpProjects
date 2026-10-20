namespace SchiffeVersenken
{

    internal enum Direction
    {
        Horizontal,
        Vertical,
        None
    }


    internal class Ship
    {
        public int Length
        { get { return Tiles.Count; } }
        public List<IGameTile> Tiles { get; } = new List<IGameTile>();


        private int hits;
        public int Hits
        {
            get { return hits; }
            set
            {
                hits = value;
                if (hits == Length)
                {
                    foreach (IGameTile tile in Tiles)
                    {
                        tile.NotifyIsSunk();
                    }

                }
            }
        }
        public bool IsSunk
        { get { return Hits == Length; } }

        public Direction direction
        {
            get
            {
                if (Tiles.Count < 2) return Direction.None;
                else if (Tiles[0].PosX == Tiles[1].PosX) return Direction.Vertical;
                else return Direction.Horizontal;
            }
        }
        public bool IsValidPosition(IGameTile tile, int maxLength)
        {
            if (Length < maxLength)
            {
                if (Length == 0)
                {
                    return true;
                }

                if(direction != Direction.None) {

                    Direction tileDirection = IGameTile.horizontal(Tiles[0], tile);

                    if (tileDirection == direction)
                    {
                        return IsNeighbour(tile);
                    }
                }
                else
                {
                    return IsNeighbour(tile);
                }
            }
            return false;
        }

        public bool AddShipTile(IGameTile tile, int maxLength)
        {
            if (IsValidPosition(tile, maxLength))
            {
                AddGameTile(tile);
                return true;
            }
            return false;
        }

        public void RemoveShipTile(IGameTile tile)
        {
            Tiles.Remove(tile);
            tile.Ship = null;
        }

        private void AddGameTile(IGameTile tile)
        {
            Tiles.Add(tile);
            tile.Ship = this;
        }

        public bool IsNeighbour(IGameTile tile)
        {
            foreach (IGameTile t in Tiles)
            {
                // return true when neighbour is found
                if ((t.PosX == tile.PosX && Math.Abs(t.PosY - tile.PosY) == 1) || (t.PosY == tile.PosY && Math.Abs(t.PosX - tile.PosX) == 1))
                    return true;
            }

            return false;
        }

    }

}