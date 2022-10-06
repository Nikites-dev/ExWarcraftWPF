using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.res;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ExWarcraftWPF.res;

namespace ExWarcraftWPF.enumUnits
{
    public class Unit
    {
        private String name = "Sparky";
        [BsonIgnoreIfDefault]
        int strensthMin = 15;
        int strensthMax = 55;
        int desterityMin = 30;
        int desterityMax = 250;
        int constitutionMin = 20;
        int constitutionMax = 80;
        int intellisenseMin = 15;
        int intellisenseMax = 7;
        int currentStrensth = 30;
        int currentDesterity = 0;
        int currentConstitution = 0;
        int currentIntellisense = 0;
        [BsonIgnoreIfDefault]
        double health = 0;
        double damage = 0;
        double magicPoints = 0;
        double pDet = 0;
        double mah = 0;

        int level = 0;
        int exp = 1;
        
        public List<Item> inventory;
        
        [BsonIgnoreIfDefault] 
        public List<Item> Inventory { get => inventory; set=> inventory = value; }
        

        public Unit()
        {
            Name = "Sparky";
            inventory = new List<Item>();
        }

        public virtual void AddToInvertory(Item item)
        {
            Inventory.Add(item);
        }
    
        public virtual void setCharacter(int strensth, int desterity, int constitution, int inellisense)
        {
            
        }


        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Exp
        {
            get => exp;
            set => exp = value;
        }

        [BsonIgnoreIfDefault]
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public string Name
        {
            get => name;
            set => name = value;
        }
        [BsonIgnoreIfDefault]
        public int CurrentStrensth
        {
            get => currentStrensth;
            set => currentStrensth = value;
        }
        [BsonIgnoreIfDefault]
        public int CurrentDesterity
        {
            get => currentDesterity;
            set => currentDesterity = value;
        }
        [BsonIgnoreIfDefault]
        public int CurrentConstitution
        {
            get => currentConstitution;
            set => currentConstitution = value;
        }
        [BsonIgnoreIfDefault]
        public int CurrentIntellisense
        {
            get => currentIntellisense;
            set => currentIntellisense = value;
        }

        
        public int StrensthMin
        {
            get => strensthMin;
            set => strensthMin = value;
        }
        
        public int StrensthMax
        {
            get => strensthMax;
            set => strensthMax = value;
        }

        public int DesterityMin
        {
            get => desterityMin;
            set => desterityMin = value;
        }
 
        public int DesterityMax
        {
            get => desterityMax;
            set => desterityMax = value;
        }
 
        public int ConstitutionMin
        {
            get => constitutionMin;
            set => constitutionMin = value;
        }

        public int ConstitutionMax
        {
            get => constitutionMax;
            set => constitutionMax = value;
        }
 
        public int IntellisenseMin
        {
            get => intellisenseMin;
            set => intellisenseMin = value;
        }

        public int IntellisenseMax
        {
            get => intellisenseMax;
            set => intellisenseMax = value;
        }


        public double HP
        {
            get { return health; }
            set
            {
                health = value;
            }
        }
        [BsonIgnoreIfDefault]
        public double MP
        {
            get { return magicPoints; }
            set
            {
                magicPoints = value;
            }
        }
        [BsonIgnoreIfDefault]
        public double Attack
        {
            get { return damage; }
            set
            {
                damage = value;
            }
        }
        [BsonIgnoreIfDefault]
        public double PDet
        {
            get { return pDet; }
            set
            {
                pDet = value;
            }
        }
        [BsonIgnoreIfDefault]
        public double MAH
        {
            get { return mah; }
            set
            {
                mah = value;
            }
        }



        public virtual int changeStrensth(bool isPlus)
        {
            return currentStrensth;
        }

        public virtual int changeDesterity(bool isPlus)
        {
            return currentDesterity;
        }

        public virtual int changeConstitution(bool isPlus)
        {
            return currentConstitution;
        }

        public virtual int changeIntellisense(bool isPlus)
        {
            return currentIntellisense;
        }

    }
}
