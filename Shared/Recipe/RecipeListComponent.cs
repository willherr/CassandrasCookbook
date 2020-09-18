using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CassandrasCookbook.Shared.Recipe
{
    public abstract class RecipeListComponent : ComponentBase
    {
        protected abstract Type Type { get; }
        protected IEnumerable<RecipeItem> GetRecipes()
        {
            return (Type switch
            {
                Type.Appetizer => AppetizerRecipes,
                Type.Breakfast => BreakfastRecipes,
                Type.Dessert => DessertRecipes,
                Type.Dinner => DinnerRecipes,
                Type.Lunch => LunchRecipes,
                _ => AllRecipes
            }).OrderBy(x => x.Title);
        }
        protected string NewRecipeRoute => $"/recipe/new/{true}/{(int)Type}";

        public static IEnumerable<RecipeItem> AllRecipes { get; set; } = new List<RecipeItem>();
        public static IEnumerable<RecipeItem> AppetizerRecipes => AllRecipes.Where(x => x.Type == Type.Appetizer);
        public static IEnumerable<RecipeItem> BreakfastRecipes => AllRecipes.Where(x => x.Type == Type.Breakfast);
        public static IEnumerable<RecipeItem> DessertRecipes => AllRecipes.Where(x => x.Type == Type.Dessert);
        public static IEnumerable<RecipeItem> DinnerRecipes => AllRecipes.Where(x => x.Type == Type.Dinner);
        public static IEnumerable<RecipeItem> LunchRecipes => AllRecipes.Where(x => x.Type == Type.Lunch);
    }
}
