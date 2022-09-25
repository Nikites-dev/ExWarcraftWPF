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
        
        public int CurrentStrensth
        {
            get => currentStrensth;
            set => currentStrensth = value;
        }

        public int CurrentDesterity
        {
            get => currentDesterity;
            set => currentDesterity = value;
        }

        public int CurrentConstitution
        {
            get => currentConstitution;
            set => currentConstitution = value;
        }

        public int CurrentIntellisense
        {
            get => currentIntellisense;
            set => currentIntellisense = value;
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
