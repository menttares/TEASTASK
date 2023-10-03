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
    
    public class OrderService : IOrderService
    {

        private ApplicationDbContext database;
        public OrderService(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// Асихронный метод по возвращению Order c базы данных
        /// </summary>
        /// <returns>Объект Order с самой большой суммой заказа, иначе NULL</returns>
        public async Task<Order> GetOrder()
        {
            return await database.Orders.OrderByDescending(or => or.Price).FirstOrDefaultAsync();
        }
        
        /// <summary>
        /// Асихронный метод по возвращению списка Order c базы данных
        /// </summary>
        /// <returns>List<Order> с количеством товара больше 10</returns>
        public async Task<List<Order>> GetOrders()
        {
            return await database.Orders.Where( or => or.Quantity >= 10).ToListAsync();
        }
    }
}