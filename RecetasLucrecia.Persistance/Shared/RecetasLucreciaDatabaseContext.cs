using Microsoft.EntityFrameworkCore;
using RecetasLucrecia.Domain.Contacts;
using RecetasLucrecia.Domain.Employees;
using RecetasLucrecia.Domain.Events;
using RecetasLucrecia.Domain.Recipes;
using RecetasLucrecia.Domain.Regions;
using RecetasLucrecia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Persistance
{
    public class RecetasLucreciaDatabaseContext : DbContext, IRecetasLucreciaDatabaseContext
    {
        public RecetasLucreciaDatabaseContext() : base()
        {

        }

        public RecetasLucreciaDatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventsCategories { get; set; }
        public DbSet<EventRegisteredContact> EventsRegisteredContacts { get; set; }
        public DbSet<EventType> EventsTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipesCategories { get; set; }
        public DbSet<RecipeIngredient> RecipesIngredients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public new DbSet<T> Set<T>() where T: class, IEntity
        {
            return base.Set<T>();
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await this.SaveChangesAsync();
        }
    }
}
