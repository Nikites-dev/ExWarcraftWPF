using System.Collections.Generic;
using ExWarcraftWPF.res;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExWarcraftWPF.MongoDBa
{
    public class CharacterDb
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        public string ClassName { get; set; }
        [BsonIgnoreIfDefault]
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Constitution { get; set; }
        [BsonIgnoreIfDefault]
        public int Intellisense { get; set; }
        public int Exp { get; set; }
        [BsonIgnoreIfNull]
        public List<Item> Items { get; set; }

        [BsonIgnoreIfNull]
        public List<Equipment> Equipments { get; set; }



        // [BsonIgnoreIfNull]
        // public List<Item> Inventory { get; set; }

        public CharacterDb(string name, string className, 
            int strength, int dexterity, 
            int constitution, int intellisense, List<Item> items, int exp, List<Equipment> eqList)
        {
            Name = name;
            ClassName = className;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intellisense = intellisense;
            Items = items;
            Exp = exp;
            Equipments = eqList;
        }
    }
}