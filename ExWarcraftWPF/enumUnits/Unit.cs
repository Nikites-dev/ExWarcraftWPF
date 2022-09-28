using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExWarcraftWPF.enumUnits;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ExWarcraftWPF.enumUnits
{
    public class Unit
    {
        private String name = "Sparky";
        [BsonIgnoreIfDefault]
        int strensthMin = 15;
        [BsonIgnoreIfDefault]
        int strensthMax = 55;
        [BsonIgnoreIfDefault]
        int desterityMin = 30;
        [BsonIgnoreIfDefault]
        int desterityMax = 250;
        [BsonIgnoreIfDefault]
        int constitutionMin = 20;
        [BsonIgnoreIfDefault]
        int constitutionMax = 80;
        [BsonIgnoreIfDefault]
        int intellisenseMin = 15;
        [BsonIgnoreIfDefault]
        int intellisenseMax = 7;
        [BsonIgnoreIfDefault]
        int currentStrensth = 30;
        [BsonIgnoreIfDefault]
        int currentDesterity = 0;
        [BsonIgnoreIfDefault]
        int currentConstitution = 0;
        [BsonIgnoreIfDefault]
        int currentIntellisense = 0;
        [BsonIgnoreIfDefault]
        
        int health = 0;
        [BsonIgnoreIfDefault]
        int damage = 0;
        [BsonIgnoreIfDefault]
        int magicPoints = 0;
        [BsonIgnoreIfDefault]
        int pDet = 0;
        [BsonIgnoreIfDefault]
        int mah = 0;

        public Unit()
        {
            Name = "Sparky";
        }

        public void addCustom()
        {
            
        }
    
        public virtual void setCharacter(int strensth, int desterity, int constitution, int inellisense)
        {
            
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

        [BsonIgnoreIfDefault]
        public int StrensthMin
        {
            get => strensthMin;
            set => strensthMin = value;
        }
        [BsonIgnoreIfDefault]
        public int StrensthMax
        {
            get => strensthMax;
            set => strensthMax = value;
        }
        [BsonIgnoreIfDefault]
        public int DesterityMin
        {
            get => desterityMin;
            set => desterityMin = value;
        }
        [BsonIgnoreIfDefault]
        public int DesterityMax
        {
            get => desterityMax;
            set => desterityMax = value;
        }
        [BsonIgnoreIfDefault]
        public int ConstitutionMin
        {
            get => constitutionMin;
            set => constitutionMin = value;
        }
        [BsonIgnoreIfDefault]
        public int ConstitutionMax
        {
            get => constitutionMax;
            set => constitutionMax = value;
        }
        [BsonIgnoreIfDefault]
        public int IntellisenseMin
        {
            get => intellisenseMin;
            set => intellisenseMin = value;
        }
        [BsonIgnoreIfDefault]
        public int IntellisenseMax
        {
            get => intellisenseMax;
            set => intellisenseMax = value;
        }

        [BsonIgnoreIfDefault]
        public int HP
        {
            get { return health; }
            set
            {
                health = value;
            }
        }
        [BsonIgnoreIfDefault]
        public int MP
        {
            get { return magicPoints; }
            set
            {
                magicPoints = value;
            }
        }
        [BsonIgnoreIfDefault]
        public int Attack
        {
            get { return damage; }
            set
            {
                damage = value;
            }
        }
        [BsonIgnoreIfDefault]
        public int PDet
        {
            get { return pDet; }
            set
            {
                pDet = value;
            }
        }
        [BsonIgnoreIfDefault]
        public int MAH
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
