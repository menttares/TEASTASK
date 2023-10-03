using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Services.Interfaces;
using TestTask.Models;
using TestTask.Data;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Services
{
    public class UserService : IUserService
    {   
    

        private ApplicationDbContext database;
        public UserService(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// Асихронный метод по возвращению пользователя c самым большим количеством заказов с базы данных
        /// </summary>
        /// <returns>Объект User с наибольшим количеством заказов, иначе NULL</returns>
        public async Task<User> GetUser()
        {
            return await database.Users.OrderByDescending(u => u.Orders.Count).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Асихронный метод по возвращению списка пользователей с статусом "Неактивный" с базы данных
        /// </summary>
        /// <returns>List<User> с статусом Inactive</returns>
        public async Task<List<User>> GetUsers()
        {
            return await database.Users.Where(u => u.Status == Enums.UserStatus.Inactive).ToListAsync();
        }
    }
}