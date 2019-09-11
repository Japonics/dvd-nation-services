using System.Collections.Generic;
using game_nation_shared.Database;
using game_nation_shared.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace game_nation_shared.Repositories
{
    public class CategoriesRepository
    {
        private readonly IMongoDatabase _database;
        private const string CategoriesCollection = "categories";

        public CategoriesRepository(Mongo database)
        {
            this._database = database.Database;
        }

        public Category GetCategory(string id)
        {
            var categories = this._database.GetCollection<Category>(CategoriesCollection);
            return categories.Find<Category>(lib => lib.Id == id).FirstOrDefault();
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = this._database.GetCollection<Category>(CategoriesCollection);
            return categories.Find(x => x.Id != null).ToList();
        }

        public Category StoreCategory(Category cat)
        {
            var categories = this._database.GetCollection<Category>(CategoriesCollection);
            categories.InsertOne(cat);
            return cat;
        }

        public Category UpdateCategory(string id, Category category)
        {
            var users = this._database.GetCollection<Category>(CategoriesCollection);
            var filter = Builders<Category>.Filter.Eq("_id", BsonObjectId.Create(id));
            var update = Builders<Category>.Update
                .Set("cover_image", category.CoverImage)
                .Set("description", category.Description)
                .Set("name", category.Name);

            users.UpdateOne(filter, update);
            category.Id = id;
            return category;
        }

        public void AttachCategory(string id, Category catIn)
        {
            var categories = this._database.GetCollection<Category>(CategoriesCollection);
            categories.ReplaceOne(cat => cat.Id == id, catIn);
        }

        public void DetachCategory(Category catIn)
        {
            var categories = this._database.GetCollection<Category>(CategoriesCollection);
            categories.DeleteOne(cat => cat.Id == catIn.Id);
        }

        public void DetachCategory(string id)
        {
            var categories = this._database.GetCollection<Category>(CategoriesCollection);
            categories.DeleteOne(cat => cat.Id == id);
        }
    }
}