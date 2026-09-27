using GM.BLL.Interfaces;
using GM.DAL.Domain;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GM.BLL.DTOs.PlayerDto;


namespace GM.BLL.Services
{
    public class PlayerService : IPlayerService
    {
        public  readonly IPlayerRepository _playerRepository;
       public PlayerService(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }
        public async Task<int> Create( CreatePalyerDto careteplayer)
        {
            var student = new Player
            {
                PlayerId = careteplayer.PlayerId,
                FirstName = careteplayer.FirstName,
                LastName = careteplayer.LastName,
                Phone = careteplayer.Phone,
                Email = careteplayer.Email,
                DateJoin = careteplayer.DateJoin,
                Type = careteplayer.Type,
                Active = careteplayer.Active,
                CreateBy = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return await _playerRepository.CreateAsync(student);
        }

        public async Task<Player>FindePlayer(int playerid)
        {
            var player = await _playerRepository.FindeAsync(playerid);
            return player;
        }

        public async Task<bool> Update(UpdatePlayerDto updatePlayerDto)
        {
            var player = await _playerRepository.FindeAsync(updatePlayerDto.PlayerId);
            if (player == null)
            {
                return false;
            }else
            {

                player.FirstName = updatePlayerDto.FirstName;
                player.LastName = updatePlayerDto.LastName;
                player.Phone = updatePlayerDto.Phone;
                player.Email = updatePlayerDto.Email;

            }

            return await _playerRepository.UpdateAsync(player);


            throw new NotImplementedException();
        }


     public  async Task<bool> DisactivePlayer(int playerId)
        {
            if(playerId < 0)
            {
                return false ;
            }

            var Player = new Player
            {
                PlayerId = playerId
            };

            return await _playerRepository.DeactivatePlayer(Player);

        }

        public async Task<List<GetPlayerDto>> GetPlayers()
        {

            var result = await _playerRepository.GetPlayersAsync(p => new GetPlayerDto
            {
                PlayerID=p.PlayerId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Type = p.Type,
                DateJoin = p.DateJoin,
                Phone = p.Phone
            });

            return result;
        }


        public async Task<List<PlayerLookupDto>> Lookup(string? searchTerm)
        {
            var term = searchTerm?.Trim();

            // نبعت للـ DataAccess الشكل اللي بدنا ياه مباشرة: DTO فيه الرقم والاسم
            return await _playerRepository.SearchByName(term, 10, p => new PlayerLookupDto
            {
                PlayerID = p.PlayerId,
                FullName = p.FirstName + " " + p.LastName,
            });
        }
    }
}
