using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExWarcraftWPF.enumUnits;

namespace ExWarcraftWPF.enumUnits
{
   public class Rogue:customMain
    {
        public int strensthMin = 15;
        public int strensthMax = 55;
        public int desterityMin = 30;
        public int desterityMax = 250;
        public int constitutionMin = 20;
        public int constitutionMax = 80;
        public int intellisenseMin = 7;
        public int intellisenseMax = 15;

        public int currentStrensth = 30;
        public int currentDesterity = 0;
        public int currentConstitution = 0;
        public int currentIntellisense = 0;

        int health = 0;
        int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;

        public Rogue()
        {
            currentStrensth = strensthMin;
            currentDesterity = desterityMin;
            currentConstitution = constitutionMin;
            currentIntellisense = intellisenseMin; ;
        }

        

        public override int changeStrensth(bool isPlus)
        {
            if (isPlus)
            {
                if (currentStrensth <strensthMax)
                {
                    currentStrensth += 1;
                    Attack += currentStrensth * 2;
                    HP += currentStrensth * 1;
                }
            }
            else
            {
                if (currentStrensth > strensthMin)
                {
                    Attack -= currentStrensth * 2;
                    HP -= currentStrensth * 1;
                    currentStrensth -= 1;
                }
            }
            return currentStrensth;
        }

        public override int changeDesterity(bool isPlus)
        {
            if (isPlus)
            {
                if (currentDesterity < desterityMax)
                {
                    currentDesterity += 1;
                    Attack += currentDesterity * 2;
                    PDet += currentDesterity * 2;
                }
            }
            else
            {
                if (currentDesterity > desterityMin)
                {
                    Attack -= currentDesterity * 2;
                    PDet -= currentDesterity * 2;
                    currentDesterity -= 1;
                }
            }
            return currentDesterity;
        }

        public override int changeConstitution(bool isPlus)
        {
            if (isPlus)
            {
                if (currentConstitution < constitutionMax)
                {
                    currentConstitution += 1;
                    HP += currentConstitution * 6;
                }
            }
            else
            {
                if (currentConstitution > constitutionMin)
                {
                    HP -= currentConstitution * 6;
                    currentConstitution -= 1;
                }
            }
            return currentConstitution;
        }
        
        public override int changeIntellisense(bool isPlus)
        {
            if (isPlus)
            {
                if (currentIntellisense < intellisenseMax)
                {
                    currentIntellisense += 1;
                    MP += currentIntellisense * 2;
                    MAH += currentIntellisense * 2;
                }
            }
            else
            {
                if (currentIntellisense > intellisenseMin)
                {
                    MP -= currentIntellisense * 2;
                    MAH -= currentIntellisense * 2;
                    currentIntellisense -= 1;
                }
            }
            return currentIntellisense;
        }
    }
}

