using System.Collections.Generic;
using game_nation_admin_service.Database;
using game_nation_admin_service.Entities;
using MongoDB.Driver;

namespace game_nation_admin_service.Repositories
{
    public class CategoriesRepository
    {
        private readonly IMongoDatabase _database;
        
        public CategoriesRepository(Mongo database)
        {
            this._database = database.database;
        }
        
        public List<Category> GetCategory()
        {
            var categories = this._database.GetCollection<Category>("categories");
            return categories.Find(lib => true).ToList();
        }

        public Category GetCategory(string id)
        {
            var categories = this._database.GetCollection<Category>("categories");
            return categories.Find<Category>(lib => lib.Id == id).FirstOrDefault();
        }

        public Category AddCategory(Category cat)
        {
            var categories = this._database.GetCollection<Category>("categories");
            categories.InsertOne(cat);
            return cat;
        }

        public void AttachCategory(string id, Category catIn)
        {
            var categories = this._database.GetCollection<Category>("categories");
            categories.ReplaceOne(cat => cat.Id == id, catIn);
        }

        public void DetachCategory(Category catIn)
        {
            var categories = this._database.GetCollection<Category>("categories");
            categories.DeleteOne(cat => cat.Id == catIn.Id);
        }

        public void DetachCategory(string id)
        {
            var categories = this._database.GetCollection<Category>("categories");
            categories.DeleteOne(cat => cat.Id == id);
        }
    }
}