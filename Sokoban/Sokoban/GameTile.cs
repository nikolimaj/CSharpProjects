using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    // base class for all game tiles
    internal abstract class GameTile
    {
        public GameTile() { }

        public virtual char Symbol { get; set; }

    }

    // base class for moving game tiles (Player and Chests)
    internal abstract class MovingGameTile:GameTile
    {
        public GameTile standingOn = new Empty();

        public int x, y;

    }

    // Player class as Singleton
    internal class Player : MovingGameTile
    {
        public override char Symbol { get { return standingOn is Target ? '+' : '@'; } }

        private static Player instance;

        private Player() { }

        public static Player createPlayer(int x, int y, bool onTarget = false)
        {
            // make sure there is only one player in the file
            if (instance == null)
            {
                instance = new Player();
            }
            else
            {
                throw new Exception("There is more than one player in the file");
            }

            instance.x = x;
            instance.y = y;

            // if the player is on a target, create a target object
            if (onTarget) instance.standingOn = new Target();

            return instance;
        }   

        public static void killPlayer()
        {
            instance = null;
        }

        public static Player getPlayer()
        {
            return instance;
        }

    }

    internal class Chest : MovingGameTile
    {
        public static int numInstances = 0;
        public static int numInstancesOnTarget;
        public override char Symbol { get { return standingOn is Target ? '*' : '$'; } }

        public Chest(int x, int y, bool onTarget = false)
        {
            numInstances++;
            // if the chest is on a target, create a target object
            if (onTarget)
            {
                standingOn = new Target();
                numInstancesOnTarget++;
            }
            this.x = x;
            this.y = y;
        }
    }

    internal class Empty : GameTile
    {
        public Empty()
        {
            Symbol = ' ';
        }
    }

    internal class Wall : GameTile
    {
        public Wall()
        {
            Symbol = '#';
        }
    }


    internal class Target : GameTile
    {
        public static int numInstances = 0;
        public Target()
        {
            Symbol = '.';
            numInstances++;
        }
    }


}
