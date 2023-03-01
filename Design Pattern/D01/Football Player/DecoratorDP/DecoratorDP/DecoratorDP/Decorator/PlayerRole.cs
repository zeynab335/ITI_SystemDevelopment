using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDP.Decorator
{
    public abstract class PlayerRole : Player
    {
        internal Player player;

        public PlayerRole(Player _player)
        {
            player = _player;
        }
     
    }
}
