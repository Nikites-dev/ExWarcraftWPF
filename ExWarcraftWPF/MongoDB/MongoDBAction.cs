using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDBa;
using ExWarcraftWPF.res;
using ExWarcraftWPF.Match;

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
                unit.Exp,
                unit.Equipments);
            
            var collection = database.GetCollection<CharacterDb>("HeroCollection");
            collection.InsertOne(db);
        }
        
        public static void AddMatchInfo(MatchInfo match)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");

            MatchDb matchDb = new MatchDb(match.Date, UnitToCharacterList(match.ListHeroes), UnitToCharacterList(match.TeamUnit1), UnitToCharacterList(match.TeamUnit2));
            
            var collection = database.GetCollection<MatchDb>("MatchCollection");
            collection.InsertOne(matchDb);
        }

        public static List<CharacterDb> UnitToCharacterList(List<Unit> listUnit)
        {
            List<CharacterDb> listCharcter = new List<CharacterDb>();

            foreach (var unit in listUnit)
            {
                CharacterDb character = new CharacterDb(
                    unit.Name,
                    unit.GetType().Name,
                    unit.CurrentStrensth, 
                    unit.CurrentDesterity,
                    unit.CurrentConstitution,
                    unit.CurrentIntellisense,
                    unit.Inventory,
                    unit.Exp,
                    unit.Equipments);
                
                listCharcter.Add(character);
            }

            return listCharcter;
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
                unit.Exp,
                unit.Equipments);
            
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
                        unit.Exp, 
                        unit.Equipments)
                    { Name = unit.Name};
                
                case "Wizard":
                    return new Wizard(unit.Strength,
                            unit.Dexterity,
                            unit.Constitution,
                            unit.Intellisense,
                            unit.Items,
                            unit.Exp,
                            unit.Equipments)
                        {Name = unit.Name};
                
                case "Rogue":
                    return new Rogue(unit.Strength,
                            unit.Dexterity,
                            unit.Constitution,
                            unit.Intellisense, 
                            unit.Items,
                            unit.Exp,
                            unit.Equipments)
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

        public static List<String> GetListMatchInfo()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<MatchDb>("MatchCollection");
            var strNames = collection.Find<MatchDb>(x => x.Date != null && x.Date != "")
                .ToEnumerable<MatchDb>();
            return strNames.Select(x => x.Date).ToList<String>();
        }

        public static MatchDb FindByDateMatch(String name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<MatchDb>("MatchCollection");
            MatchDb match = collection.Find(x => x.Date == name).FirstOrDefault();

            //MatchInfo matchInfo = new MatchInfo(match.Date, CharacterToUnitList(match.ListHeroes), CharacterToUnitList(match.TeamUnit1), CharacterToUnitList(match.TeamUnit2)); 
            
            return match;
        }

        public static void UpdateByName(String name, Unit unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Warcraft");
            var collection = database.GetCollection<CharacterDb>("HeroCollection");
            var b = collection.ReplaceOne(x => x.Name == name, UnitToCharacter(name, unit)).ModifiedCount > 0;
        }
        
        
        public static List<Unit> CharacterToUnitList(List<CharacterDb> listCharacter)
        {
            List<Unit> listUnits = new List<Unit>();

            foreach (var unit in listCharacter)
            {

                if (unit == null)
                {
                    return null;
                }

                switch (unit.ClassName)
                {
                    case "Warrior":
                        listUnits.Add( new Warrior(unit.Strength,
                                unit.Dexterity,
                                unit.Constitution,
                                unit.Intellisense,
                                unit.Items, 
                                unit.Exp, 
                                unit.Equipments)
                                { Name = unit.Name});
                        break;
                
                    case "Wizard":
                        listUnits.Add( new Wizard(unit.Strength,
                                unit.Dexterity,
                                unit.Constitution,
                                unit.Intellisense,
                                unit.Items,
                                unit.Exp,
                                unit.Equipments)
                            {Name = unit.Name});
                        break;
                
                    case "Rogue":
                        listUnits.Add( new Rogue(unit.Strength,
                                unit.Dexterity,
                                unit.Constitution,
                                unit.Intellisense, 
                                unit.Items,
                                unit.Exp,
                                unit.Equipments)
                            {Name = unit.Name});
                        break;
                    default: return null;
                }
            }
            
            
            
            return listUnits;
        }
    }
}
