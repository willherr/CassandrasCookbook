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
                ImageUrl = "http://assets.epicurious.com/photos/57eab27ecf9338f824b78b4b/master/pass/old-fashioned-meat-loaf.jpg"
            }
        };

        public static List<RecipeItem> LunchRecipes => new List<RecipeItem>
        {
            new RecipeItem
            {
                Type = Type.Lunch,
                Title = "Peanut Butter Jellies",
                ImageUrl = "http://allthingsd.com/files/2012/08/peanut_butter_jelly430x300.jpeg"
            }
        };
    }
}
