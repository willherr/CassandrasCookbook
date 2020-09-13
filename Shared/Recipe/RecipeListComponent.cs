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

        // testing
        public static IEnumerable<RecipeItem> AllRecipes => AppetizerRecipes.Concat(BreakfastRecipes).Concat(DessertRecipes).Concat(DinnerRecipes).Concat(LunchRecipes);

        public static List<RecipeItem> AppetizerRecipes => new List<RecipeItem>
        {
            new RecipeItem
            {
                Type = Type.Appetizer,
                Title = "Mozzarella Sticks",
                Introduction = "These are my grandma's favorite appetizer. You will love them.",
                ImageUrl = "https://static.olocdn.net/menu/applebees/060f209dc400632e3fec451a81bbb7ea.jpg",
                Ingredients = new List<Ingredient> 
                { 
                    new Ingredient { Amount = 2, UnitOfMeasure = "Sticks", Title = "Cheese" },
                    new Ingredient { Amount = 4, UnitOfMeasure = "Tablespoons", Title = "Breadcrumbs", AdditionalNotes = "Meijer Brand" }
                },
                Steps = new List<(int, Step)> 
                { 
                    (1, new Step { Subtitle = "Get your sticks", Instructions = "First, you will need to gather your ingredients. Do that first.", ImageUrl = "https://www.thegunnysack.com/wp-content/uploads/2012/09/cutstringcheese.jpg" }),
                    (2, new Step { Instructions = "Finally, make the Mozzarella sticks." })
                }
            }
        };

        public static List<RecipeItem> BreakfastRecipes => new List<RecipeItem>
        {
            new RecipeItem
            {
                Type = Type.Breakfast,
                Title = "Ultimate Pancakes",
                ImageUrl = "https://i.ytimg.com/vi/7ebZWviUfUA/maxresdefault.jpg"
            }
        };

        public static List<RecipeItem> DessertRecipes => new List<RecipeItem>
        {
            new RecipeItem
            {
                Type = Type.Dessert,
                Title = "Frozen Peanut Butter Cup",
                ImageUrl = "https://i.pinimg.com/originals/4a/51/9f/4a519f7658f35b94446f31add54dcbc7.jpg"
            }
        };

        public static List<RecipeItem> DinnerRecipes => new List<RecipeItem>
        {
            new RecipeItem
            {
                Type = Type.Dinner,
                Title = "Meatloaf",
                ImageUrl = "https://static01.nyt.com/images/2016/03/21/dining/21COOKING_MEATLOAF2/21COOKING_MEATLOAF2-superJumbo.jpg"
            }
        };

        public static List<RecipeItem> LunchRecipes => new List<RecipeItem>
        {
            new RecipeItem
            {
                Type = Type.Lunch,
                Title = "Peanut Butter Jellies",
                ImageUrl = "https://rowaytonmarket.com/wp-content/uploads/2016/10/peanut-butter-jelly.jpg"
            }
        };
    }
}
