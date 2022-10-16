using System;
using System.Collections.Generic;
using ExWarcraftWPF.enumUnits;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExWarcraftWPF.Match
{
    public class MatchInfo
    {
        public MatchInfo()
        {
            
        }   
        
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        
        public MatchInfo(String date, List<Unit> listHeroes, List<Unit> teamUnit1, List<Unit> teamUnit2)
        {
            Date = date;
            ListHeroes = listHeroes;
            TeamUnit1 = teamUnit1;
            TeamUnit2 = teamUnit2;
        }  
        [BsonIgnoreIfDefault]
        public String Date { get; set; }
        [BsonIgnoreIfDefault]
        public List<Unit> ListHeroes { get; set; }
        [BsonIgnoreIfDefault]
        public List<Unit> TeamUnit1 { get; set; }
        [BsonIgnoreIfDefault]
        public List<Unit> TeamUnit2 { get; set; }
    }
}