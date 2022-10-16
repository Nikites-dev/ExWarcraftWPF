using System;
using System.Collections.Generic;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDBa;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExWarcraftWPF.MongoDB
{
    public class MatchDb
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public string Date { get; set; }

        [BsonIgnoreIfDefault]
        public List<CharacterDb> ListHeroes { get; set; }
        [BsonIgnoreIfDefault]
        public List<CharacterDb> TeamUnit1 { get; set; }
        [BsonIgnoreIfDefault]
        public List<CharacterDb> TeamUnit2 { get; set; }
        
        public MatchDb(String date, List<CharacterDb> listHeroes, List<CharacterDb> teamUnit1, List<CharacterDb> teamUnit2)
        {
            Date = date;
            ListHeroes = listHeroes;
            TeamUnit1 = teamUnit1;
            TeamUnit2 = teamUnit2;
        }
    }
}