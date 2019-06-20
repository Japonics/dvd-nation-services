﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using game_nation_admin_service.Models;

namespace game_nation_admin_service.Db
{
    public class Mongo
    {
        private readonly IMongoCollection<Categories> _categories;

        public Mongo()
        {
            var _client = new MongoClient("mongodb://localhost:27017");
            var _db = _client.GetDatabase("GameNation");
            _categories = _db.GetCollection<Categories>("Categories");
        }

        public List<Categories> GetCategory()
        {
            return _categories.Find(lib => true).ToList();
        }

        public Categories GetCategory(int id)
        {
            return _categories.Find<Categories>(lib => lib.Id == id).FirstOrDefault();
        }

        public Categories AddCategory(Categories cat)
        {
            _categories.InsertOne(cat);
            return cat;
        }

        public void AttacheCategory(int id, Categories catIn)
        {
            _categories.ReplaceOne(cat => cat.Id == id, catIn);
        }

        public void DettachCategory(Categories catIn)
        {
            _categories.DeleteOne(cat => cat.Id == catIn.Id);
        }

        public void DettachCategory(int id)
        {
            _categories.DeleteOne(cat => cat.Id == id);
        }
    }
}