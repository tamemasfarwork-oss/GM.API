using GM.DAL.Data;
using GM.DAL.Domain;
using GM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;
        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Player createPlayer)
        {

            await _context.Players.AddAsync(createPlayer);
         var  result =  await _context.SaveChangesAsync();
            Console.WriteLine(createPlayer.PlayerId);
            return createPlayer.PlayerId;
        }

        public async Task<bool> UpdateAsync(Player updatePlayer)//here the prameter only for arcticture
        {
           
             var save = await _context.SaveChangesAsync();
            
            return save>0;

        }
     public  async Task<Player> FindeAsync(int PlayerID)
        {
             var palyer =  await _context.Players.FindAsync(PlayerID);

            return palyer;
        }



  public  async Task<bool> DeactivatePlayer(Player player)
        {

          _context.Attach(player);

            player.Active = 0;
            _context.Entry(player).Property(p => p.Active).IsModified = true;
            var result = await _context.SaveChangesAsync();
            return result > 0;

        }

        // Data Access Layer
        public async Task<List<TResult>> GetPlayersAsync<TResult>(
            Expression<Func<Player, TResult>> selector)
        {
            return await _context.Players
                .Where(s => s.Active == 1)
                .Select(selector)
                .ToListAsync();
        }
    }


}
