using System;
using MongoDB.Driver;
using RandomAteDataManager.Models;

namespace Mongoose
{
    class Program
    {
        static void Main(string[] args)
        {
            IMongoCollection<DishModel> dishes;
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("RandomAteTest");
            dishes = database.GetCollection<DishModel>("Dishes");

            DishModel test = new DishModel()
            {
                Feedbacks = new FeedbackModel[]
                {
                    new FeedbackModel() {Comment = "Говно собачье", FromUser = "1", Rating = 1}, 
                    new FeedbackModel() {Comment = "Так то норм", FromUser = "2", Rating = 5}
                },
                Name = "Говяжьи анусы",
                Recipe = new RecipeModel()
                {
                    Ingredients = new []
                    {
                        "Говядина", "Анусы", "Соль"
                    },
                    Steps = new[]
                    {
                        "Засыпать анусы в кипящую воду",
                        "Посыпать анусами",
                        "Добавить соль по вкусу"
                    }
                }
            };
            dishes.InsertOne(test);
        }
    }
}
