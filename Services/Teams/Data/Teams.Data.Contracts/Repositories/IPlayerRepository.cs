﻿using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Teams.Data.Entities;

namespace Teams.Data.Contracts.Repositories
{
    public interface IPlayerRepository : IDisposable
    {
        Task<Player> Get(int id);

        Task<PagedList<Player>> Get(PagingParameter paging);

        Task Create(Player player);

        Task Delete(int id);
    }
}