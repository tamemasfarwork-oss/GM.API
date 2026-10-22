using GM.DAL.Data;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using GM.DAL.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Repositories
{
    public class PlayerSearchCriteria
    {
        public string? Name { get; set; }          // يبحث بالاسم الكامل
        public string? Type { get; set; }          // لو عندك Enum اجعله PlayerType?
        public string? Email { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; } = 10;
    };

    // what its extension methods
    

      
       

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
             var palyer =  await _context.Players.FirstOrDefaultAsync(S=>S.PlayerId==PlayerID);

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


        public async Task<List<TResult>> SearchByName<TResult>(
    string? term,
    int take,
    Expression<Func<Player, TResult>> selector) // ← الشكل اللي بدنا ياه، جاي من الـ Business
        {
            var query = _context.Players.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(p => (p.FirstName + " " + p.LastName).Contains(term));
            }

            return await query
                .OrderBy(p => p.FirstName)
                .Take(take)
                .Select(selector)   // EF بيترجمه لـ SQL، فبيجيب بس الأعمدة اللي بالـ selector
                .ToListAsync();
        }

        // why ddi we used  the player serch criteria 
        // why did we use experession func instead of func it self 
        public async Task<(List<TResult> Items, int TotalCount)> Search<TResult>(
      PlayerSearchCriteria c,
      Expression<Func<Player, TResult>> selector)
        {
            var query = _context.Players.AsNoTracking()
              ;

            query = query.WhereIf(!string.IsNullOrEmpty(c.Name),
                         p => (p.FirstName + " " + p.LastName).Contains(c.Name!))
                .WhereIf(!string.IsNullOrEmpty(c.Type),
                         p => p.Type == c.Type)
                .WhereIf(!string.IsNullOrEmpty(c.Email),
                         p => p.Email.Contains(c.Email!))
                .MyownOrderBY(true,s=>s.DateJoin);
         
            var total = await query.CountAsync();

            var items = await query
                
                
               
                .Skip(c.Skip)
                .Take(c.Take)
                .Select(selector)
                .ToListAsync();

            return (items, total);
        }

        public async Task<int> CountPlayers()
        {
         
            var countplayers = await _context.Players.AsNoTracking()
                .CountAsync();
            return countplayers;
                
        }
    }


}
