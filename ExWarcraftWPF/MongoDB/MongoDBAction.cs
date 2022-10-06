using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDBa;
using ExWarcraftWPF.res;

namespace ExWarcraftWPF.MongoDB
{
    public class MongoDBAction
    {
        public static void AddToDatabase(Unit unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            CharacterDb db = new CharacterDb(
                unit.Name,
                unit.GetType().Name,
                unit.CurrentStrensth, 
                unit.CurrentDesterity,
                unit.CurrentConstitution,
                unit.CurrentIntellisense,
                unit.Inventory,
                unit.Exp
                );
            
            var collection = database.GetCollection<CharacterDb>("HeroCollection");
            collection.InsertOne(db);
        }
        
        public static CharacterDb UnitToCharacter(String name, Unit unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            CharacterDb db = new CharacterDb(
                name,
                unit.GetType().Name,
                unit.CurrentStrensth, 
                unit.CurrentDesterity,
                unit.CurrentConstitution,
                unit.CurrentIntellisense,
                unit.Inventory,
                unit.Exp
                );
            
           return db;
        }

        public static Unit FindByName(String name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<CharacterDb>("HeroCollection");
            CharacterDb unit = collection.Find(x => x.Name == name).FirstOrDefault();
            
            if (unit == null)
            {
                return null;
            }

            switch (unit.ClassName)
            {
                case "Warrior":
                    return new Warrior(unit.Strength,
                        unit.Dexterity,
                        unit.Constitution,
                        unit.Intellisense,
                        unit.Items, 
                        unit.Exp)
                    { Name = unit.Name};
                
                case "Wizard":
                    return new Wizard(unit.Strength,
                            unit.Dexterity,
                            unit.Constitution,
                            unit.Intellisense,
                            unit.Items,
                            unit.Exp)
                        {Name = unit.Name};
                
                case "Rogue":
                    return new Rogue(unit.Strength,
                            unit.Dexterity,
                            unit.Constitution,
                            unit.Intellisense, 
                            unit.Items,
                            unit.Exp)
                        {Name = unit.Name};
                default: return null;
            }
            return null;
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

        public static List<String> AddListHeroes()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<CharacterDb>("HeroCollection");
            var strNames = collection.Find<CharacterDb>(x => x.Name != null && x.Name != "")
                .ToEnumerable<CharacterDb>();
            return strNames.Select(x => x.Name).ToList<String>();
        }

        public static void UpdateByName(String name, Unit unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<CharacterDb>("HeroCollection");
            var b = collection.ReplaceOne(x => x.Name == name, UnitToCharacter(name, unit)).ModifiedCount > 0;
        }
    }
}
