using GM.BLL.DTOs.PlayerDto;
using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface IPlayerService
    {
        Task<int> Create(CreatePalyerDto createPlayerDto);
        Task<bool> Update(UpdatePlayerDto updatePlayerDto);
        Task<bool> DisactivePlayer(int  playerId);
        Task<List<GetPlayerDto>> GetPlayers();
        Task<Player> FindePlayer(int playid);
    }
}
