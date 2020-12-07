using Core.Entities;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EcommContextSeed
    {
        public static async Task SeedDataAsync(EcommContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    using var transaction = context.Database.BeginTransaction();
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands OFF");
                    transaction.Commit();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    using var transaction = context.Database.BeginTransaction();
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes OFF");
                    transaction.Commit();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    using var transaction = context.Database.BeginTransaction();
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF");
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EcommContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
