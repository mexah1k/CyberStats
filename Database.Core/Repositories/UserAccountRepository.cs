﻿using Database.Abstractions.Context;
using Database.Abstractions.Repositories;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Database.Core.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly IDatabaseContext context;

        public UserAccountRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<User> Get(int id)
        {
            return await context.UsersAccounts.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async void Add(User user)
        {
            await context.UsersAccounts.AddAsync(user);
        }

        public async void Delete(int id)
        {
            var user = await context.UsersAccounts.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception(); // todo: Add UserNotFoundException

            context.UsersAccounts.Remove(user);
        }

        public void Dispose()
        {
        }
    }
}