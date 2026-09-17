using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Interfaces
{
    public interface IPlayerRepository
    {
        Task<bool> CreateAsync(Player createPlayer);
        Task<bool> UpdateAsync(Player updatePlayer);
        Task<Player> FindeAsync(int PlayerID);
        Task<bool> DeactivatePlayer(Player player);
    }
}
