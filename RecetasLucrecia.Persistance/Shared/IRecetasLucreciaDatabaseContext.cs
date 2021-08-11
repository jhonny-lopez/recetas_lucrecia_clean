using Microsoft.EntityFrameworkCore;
using RecetasLucrecia.Domain.Contacts;
using RecetasLucrecia.Domain.Employees;
using RecetasLucrecia.Domain.Events;
using RecetasLucrecia.Domain.Recipes;
using RecetasLucrecia.Domain.Regions;
using RecetasLucrecia.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace RecetasLucrecia.Persistance
{
    public interface IRecetasLucreciaDatabaseContext : IDisposable
    {
        DbSet<City> Cities { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventCategory> EventsCategories { get; set; }
        DbSet<EventRegisteredContact> EventsRegisteredContacts { get; set; }
        DbSet<EventType> EventsTypes { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeCategory> RecipesCategories { get; set; }
        DbSet<RecipeIngredient> RecipesIngredients { get; set; }
        DbSet<State> States { get; set; }

        void Save();
        Task SaveAsync();
        DbSet<T> Set<T>() where T : class, IEntity;
    }
}