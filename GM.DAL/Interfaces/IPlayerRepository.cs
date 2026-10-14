using GM.DAL.Domin;
using GM.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Interfaces
{
    public interface IPlayerRepository
    {
        Task<int> CreateAsync(Player createPlayer);
        Task<bool> UpdateAsync(Player updatePlayer);
        Task<Player> FindeAsync(int PlayerID);
        Task<bool> DeactivatePlayer(Player player);
        Task<List<TResult>> GetPlayersAsync<TResult>(
         Expression<Func<Player, TResult>> selector);
        public Task<List<TResult>> SearchByName<TResult>(
            string? term,
            int take,
            Expression<Func<Player, TResult>> selector);

        Task<int> CountPlayers();

        Task<(List<TResult> Items, int TotalCount)> Search<TResult>(
    PlayerSearchCriteria c, Expression<Func<Player, TResult>> selector);

    }
           

}
