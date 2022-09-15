using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExWarcraftWPF.enumUnits;

namespace ExWarcraftWPF.enumUnits
{
    public class customMain
    {

        public int strensthMin = 15;
        public int strensthMax = 55;
        public int desterityMin = 30;
        public int desterityMax = 250;
        public int constitutionMin = 20;
        public int constitutionMax = 80;
        public int intellisenseMin = 15;
        public int intellisenseMax = 7;

        public int currentStrensth = 30;
        public int currentDesterity = 0;
        public int currentConstitution = 0;
        public int currentIntellisense = 0;

        int health = 0;
        int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;

        public customMain()
        {
        
        }

        public void addCustom()
        {
            
        }

        public int HP
        {
            get { return health; }
            set
            {
                health = value;
            }
        }

        public int MP
        {
            get { return magicPoints; }
            set
            {
                magicPoints = value;
            }
        }

        public int Attack
        {
            get { return damage; }
            set
            {
                damage = value;
            }
        }

        public int PDet
        {
            get { return pDet; }
            set
            {
                pDet = value;
            }
        }

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
