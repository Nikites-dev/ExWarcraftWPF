using System;
using MongoDB.Driver;
using ExWarcraftWPF.enumUnits;

namespace ExWarcraftWPF.MongoDB
{
    public class MongoDBAction
    {
        public static void AddToDatabase(Unit unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<Unit>("HeroCollection");
            collection.InsertOne(unit);
        }

        public static Unit FindByName(String name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<Unit>("HeroCollection");
            Unit unit = collection.Find(x => x.Name == name).FirstOrDefault();
            return unit;
        }

        public static String DeleteByName(String name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<Unit>("HeroCollection");
            var unit = collection.DeleteOne(x => x.Name == name);
            return $"Unit {unit.GetType().Name} is remove!";
        }

        public static void ClearDB()
        {
            var client = new MongoClient("mongodb://localhost");
            client.GetDatabase("Warcraft").DropCollectionAsync("HeroCollection");
        }
    }
}
