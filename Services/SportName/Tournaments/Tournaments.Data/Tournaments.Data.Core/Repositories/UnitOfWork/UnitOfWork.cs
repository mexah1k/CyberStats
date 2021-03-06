﻿using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;

namespace Tournaments.Data.Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext context;

        public IPlayerRepository Players { get; }

        public ITeamRepository Teams { get; }

        public IPositionRepository Position { get; }

        public IMatchRepository Matches { get; }

        public ISeriesRepository Series { get; }

        public ISeriesTypeRepository SeriesType { get; }

        public ITournamentRepository Tournament { get; }

        public UnitOfWork(IDataContext dbcontext,
            IPlayerRepository players,
            ITeamRepository teams,
            IPositionRepository position, IMatchRepository matches, ISeriesRepository series,
            ISeriesTypeRepository seriesType, ITournamentRepository tournament)
        {
            context = dbcontext;
            Players = players;
            Teams = teams;
            Position = position;
            Matches = matches;
            Series = series;
            SeriesType = seriesType;
            Tournament = tournament;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Players?.Dispose();
            Teams?.Dispose();
            Position?.Dispose();
            Matches?.Dispose();
            Series?.Dispose();
            SeriesType?.Dispose();
            Tournament?.Dispose();
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}