using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClient
{
    class PlayerStats
    {
        protected string myPlayerName;
        public string playerName
        {
            get
            {
                return myPlayerName;
            }
            set
            {
                myPlayerName = value;
            }
        }

        protected int myGamesPlayed;
        public int gamesPlayed
        {
            get
            {
                return myGamesPlayed;
            }
            set
            {
                myGamesPlayed = value;
            }
        }

        protected int myGameRounds;
        public int gameRounds
        {
            get
            {
                return myGameRounds;
            }
            set
            {
                myGameRounds = value;
            }
        }

        protected int myPlayerWins;
        public int playerWins
        {
            get
            {
                return myPlayerWins;
            }
            set
            {
                myPlayerWins = value;
            }
        }


        protected int myPlayerTies;
        public int playerTies
        {
            get
            {
                return myPlayerTies;
            }
            set
            {
                myPlayerTies = value;
            }
        }

        protected int myPlayerLosses;
        public int playerLosses
        {
            get
            {
                return myPlayerLosses;
            }
            set
            {
                myPlayerLosses = value;
            }
        }


        // Default Constructor
        public PlayerStats()
        {
            this.myPlayerName = "";
            this.myGamesPlayed = 0;
            this.myGameRounds = 0;
            this.myPlayerWins = 0;
            this.myPlayerTies = 0;
            this.myPlayerLosses = 0;
        }

        public PlayerStats(string playerName, int gamesPlayed, int gameRounds, int playerWins, int playerTies, int playerLosses)
        {
            this.myPlayerName = playerName;
            this.myGamesPlayed = gamesPlayed;
            this.myGameRounds = gameRounds;
            this.myPlayerWins = playerWins;
            this.myPlayerTies = playerTies;
            this.myPlayerLosses = playerLosses;
        }



    }
}
