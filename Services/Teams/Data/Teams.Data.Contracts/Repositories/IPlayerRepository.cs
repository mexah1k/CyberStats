﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Repositories
{
    public interface IPlayerRepository : IDisposable
    {
        Task<Player> Get(int id);

        Task<IEnumerable<Player>> Get();

        Task<Player> GetPlayerByTeam(int teamId, int playerId);

        Task<ICollection<Player>> GetPlayersByTeam(int teamId);

        Task Add(Player player);

        Task Delete(int id);
    }
}