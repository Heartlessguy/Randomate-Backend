using System;
using System.Collections.Generic;
using MongoDB.Driver;
using RandomAteDataManager.Models;

namespace RandomAteDataManager.Services
{
    /// <summary>
    /// CRUD on Dishes collection
    /// </summary>
    public class DishManagementService
    {
        private readonly IMongoCollection<DishModel> _dishes;

        public DishManagementService(IRandomAteDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dishes = database.GetCollection<DishModel>(settings.DishesCollectionName);
        }

        public List<DishModel> Get() =>
            _dishes.Find(dish => true).ToList();

        public DishModel Get(string id) =>
            _dishes.Find(dish => dish.Id == id).FirstOrDefault();

        public DishModel Get(FilterDefinition<DishModel> filter)
        {
            // TODO - сделать фильтр на базе filterdefinition
            throw new NotImplementedException("Сделаю потом, честно");
        }

        public DishModel Create(DishModel dish)
        {
            _dishes.InsertOne(dish);
            return dish;
        }

        public void Update(string id, DishModel dishIn)
        {
            _dishes.ReplaceOne(dish => dish.Id == id, dishIn);
        }

        public void Remove(string id)
        {
            _dishes.DeleteOne(dish => dish.Id == id);
        }
    }
}