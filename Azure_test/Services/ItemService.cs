using System;
using DSIP_.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace DSIP_.Services
{
    public interface IItemService
    {
        List<Item> Get();
        Item Get(string id);
        Item Create(Item item);
        void Update(string id, Item itemIn);
        void Remove(Item itemIn);
        
    }

    public class ItemService : IItemService
    {
        private readonly IMongoCollection<Item> _items;


        public ItemService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database =  client.GetDatabase(settings.DatabaseName);


            _items = database.GetCollection<Item>(settings.DatabaseCollectionName);
        }

        public List<Item> Get() =>
            _items.Find(item => true).ToList();

        public Item Get(string id) =>
            _items.Find<Item>(item => item.id == id).FirstOrDefault();

        public Item Create(Item item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, Item itemIn) =>
            _items.ReplaceOne(item => item.id == id, itemIn);

        public void Remove(Item itemIn) =>
            _items.DeleteOne(item => item.id == itemIn.id);

        public void Remove(string id) =>
            _items.DeleteOne(item => item.id == id);
        // just to check the deployment
        
    }
}
