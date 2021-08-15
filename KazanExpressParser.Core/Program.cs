using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KazanExpress.Parser.Domain.Entities;
using KazanExpress.Parser.Infrastructure.Data;
using KazanExpressParser.Core.Services.ApiClient;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories;
using Microsoft.EntityFrameworkCore;

namespace KazanExpressParser.Core
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var apiClient = new KazanApiClient();
            var context = new KazanExpressParserDbContext();
            await context.Database.MigrateAsync();
            Console.WriteLine("Database migrated.");
            var categories = await apiClient.GetCategories();
            var items = await GetCategoriesWithoutChildren(categories);
            var existCategories = context.Products.Select(x => x.CategoryName).Distinct().ToList();

            items = items.Where(x => !existCategories.Contains(x.Title))
                .ToArray();

            var taskList = new List<Task>();
            
            for (int i = 1; i < 6; i++)
            {
                taskList.Add(DoTaskByOneThread(items, apiClient, 5, i));
            }

            await Task.WhenAll(taskList);
        }

        private static async Task DoTaskByOneThread(ApiCategoryItem[] items, KazanApiClient apiClient, int countThread , int startItem)
        {
            await Task.Yield();
            var context = new KazanExpressParserDbContext();
            for (int i = startItem; i < items.Length; i+= countThread)
            {
                var item = items[i];
                
                var productsForCategory = await apiClient.GetProductsByCategoryId(item.Id);
                var productEntities = productsForCategory.Select(x =>
                        new ProductEntity(x.ProductId,
                            x.Title,
                            x.SellPrice,
                            x.FullPrice,
                            x.Rating,
                            x.OrdersQuantity,
                            x.ROrdersQuantity,
                            x.CharityCommission,
                            x.IsEco,
                            item.Title))
                    .ToArray();
                await context.AddOrUpdateProducts(productEntities);
                Console.WriteLine($"Category {item.Id} complited, update {productsForCategory.Length} products");
            }
        }
        

        private static async Task<ApiCategoryItem[]> GetCategoriesWithoutChildren(ApiCategoryItem category)
        {
            var result = new List<ApiCategoryItem>();
            if (category.Children.Count == 0)
            {
                result.Add(category);
            }

            foreach (var categoryChild in category.Children)
            {
                var items = await GetCategoriesWithoutChildren(categoryChild);
                result.AddRange(items);
            }

            return result.ToArray();
        }
    }
}