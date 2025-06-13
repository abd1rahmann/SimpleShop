using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public static class DataInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SimpleShopDbContext>();

            Console.WriteLine("▶️ Kör DataInitializer...");

            if (!context.Database.CanConnect())
            {
                Console.WriteLine("❌ Kan inte ansluta till databasen.");
                return;
            }

            context.Database.Migrate();

            if (context.Products.Any())
            {
                Console.WriteLine("ℹ️ Produkter finns redan i databasen – ingen seeding sker.");
                return;
            }

            Console.WriteLine("🟢 Lägger till 50 produkter...");

            var products = new List<Product>
            {
                new() { Name = "Trådlös mus", Price = 199.00m, Stock = 25 },
                new() { Name = "Mekaniskt tangentbord", Price = 849.00m, Stock = 15 },
                new() { Name = "USB-C laddare", Price = 179.00m, Stock = 40 },
                new() { Name = "27\" 4K Monitor", Price = 3190.00m, Stock = 10 },
                new() { Name = "Bluetooth-högtalare", Price = 549.00m, Stock = 20 },
                new() { Name = "Gaming-headset", Price = 799.00m, Stock = 18 },
                new() { Name = "Smartklocka Pro", Price = 2499.00m, Stock = 12 },
                new() { Name = "Webbkamera 1080p", Price = 499.00m, Stock = 30 },
                new() { Name = "Trådlös laddplatta", Price = 249.00m, Stock = 22 },
                new() { Name = "Powerbank 10000mAh", Price = 349.00m, Stock = 35 },
                new() { Name = "Laptopställ aluminium", Price = 399.00m, Stock = 10 },
                new() { Name = "Ergonomisk kontorsstol", Price = 1990.00m, Stock = 8 },
                new() { Name = "Dockningsstation USB-C", Price = 1299.00m, Stock = 14 },
                new() { Name = "Trådlösa öronsnäckor", Price = 699.00m, Stock = 28 },
                new() { Name = "SSD 1TB NVMe", Price = 999.00m, Stock = 17 },
                new() { Name = "HDMI-kabel 2m", Price = 89.00m, Stock = 50 },
                new() { Name = "Router WiFi 6", Price = 1199.00m, Stock = 11 },
                new() { Name = "iPad-fodral med tangentbord", Price = 799.00m, Stock = 13 },
                new() { Name = "Träningsarmband", Price = 299.00m, Stock = 21 },
                new() { Name = "Ljudisolerande hörlurar", Price = 1599.00m, Stock = 9 },
                new() { Name = "Bärbar projektor", Price = 2590.00m, Stock = 7 },
                new() { Name = "Smart dörrklocka", Price = 899.00m, Stock = 12 },
                new() { Name = "USB-hubb 4 portar", Price = 149.00m, Stock = 38 },
                new() { Name = "Ståmatta för kontor", Price = 699.00m, Stock = 10 },
                new() { Name = "DisplayPort-kabel", Price = 129.00m, Stock = 45 },
                new() { Name = "Gamingmus RGB", Price = 499.00m, Stock = 20 },
                new() { Name = "Laddstation för mobil", Price = 399.00m, Stock = 18 },
                new() { Name = "LED-ring för streaming", Price = 269.00m, Stock = 22 },
                new() { Name = "Kylplatta till laptop", Price = 349.00m, Stock = 16 },
                new() { Name = "Mikrofon med arm", Price = 949.00m, Stock = 9 },
                new() { Name = "Webbkamera med ljus", Price = 699.00m, Stock = 13 },
                new() { Name = "Kabelhållare", Price = 59.00m, Stock = 100 },
                new() { Name = "Trådlös gamingmus", Price = 799.00m, Stock = 15 },
                new() { Name = "USB-minne 128GB", Price = 249.00m, Stock = 40 },
                new() { Name = "Trådlös skrivare", Price = 1399.00m, Stock = 6 },
                new() { Name = "Multifjärrkontroll", Price = 329.00m, Stock = 25 },
                new() { Name = "LED-skrivbordslampa", Price = 289.00m, Stock = 20 },
                new() { Name = "iPhone skal MagSafe", Price = 399.00m, Stock = 30 },
                new() { Name = "USB-C till HDMI-adapter", Price = 199.00m, Stock = 33 },
                new() { Name = "Trådlös smart musmatta", Price = 229.00m, Stock = 19 },
                new() { Name = "Monitor-arm gasfjäder", Price = 599.00m, Stock = 10 },
                new() { Name = "Gamingstol racing", Price = 2290.00m, Stock = 5 },
                new() { Name = "Bluetooth-tangentbord", Price = 499.00m, Stock = 14 },
                new() { Name = "Laptop-ryggsäck", Price = 749.00m, Stock = 18 },
                new() { Name = "Trådlös air pump", Price = 389.00m, Stock = 15 },
                new() { Name = "Smart väckarklocka", Price = 349.00m, Stock = 23 },
                new() { Name = "Värmeplatta för kaffe", Price = 199.00m, Stock = 12 },
                new() { Name = "USB-fläkt", Price = 99.00m, Stock = 45 },
                new() { Name = "Bordsladdare med 6 portar", Price = 299.00m, Stock = 17 },
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            Console.WriteLine("✅ Seeding slutförd. Totalt antal produkter: " + context.Products.Count());
        }
    }
}
