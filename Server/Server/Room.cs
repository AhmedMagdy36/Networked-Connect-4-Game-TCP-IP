using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Room
    {
        private int player1, player2, owner;
        private string name;
        private List<int> watchers;
        List<string> moves;
        public Room(int Owner, string Name)
        {
            this.owner = Owner;
            this.player1 = Owner;
            this.name = Name;
            this.watchers = new List<int>();
            moves = new List<string>();

        }

     

        public List<int> Watchers { get { return watchers; } }

        public List<string> Moves { get { return moves; } }


        public int Owner { get { return owner; } set { owner = value; } }
        public int Player1 { get { return player1; } set { player1 = value; } }
        public int Player2 { get { return player2; } set { player2 = value; } }
        public string Name { get { return name; } }

     
        public void AddWatcher(int Watcher)
        {
            this.Watchers.Add(Watcher);
        }
        public void Addmove(string move)
        {
            this.Moves.Add(move);
        }

        public void AddPlayer(int Player2)
        {
            if (num_of_players() < 2)
            {
                this.player2 = Player2;
            
            }
        }

        public int num_of_players()
        {
            int count = 0;
            if (player1 != 0)
                ++count;
            if (player2 != 0)
                ++count;
            return count;
        }



    }

}
