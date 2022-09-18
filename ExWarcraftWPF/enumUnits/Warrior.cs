using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExWarcraftWPF.enumUnits
{
    public class Warrior:customMain
    {
        public int strensthMin = 30;
        public int strensthMax = 250;
        public int desterityMin = 15;
        public int desterityMax = 70;
        public int constitutionMin = 20;
        public int constitutionMax = 100;
        public int intellisenseMin = 10;
        public int intellisenseMax = 50;

        public int currentStrensth = 0;
        public int currentDesterity = 0;
        public int currentConstitution = 0;
        public int currentIntellisense = 0;

        int health = 0;
        int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;

        public Warrior()
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
                if (currentStrensth < strensthMax)
                {
                    currentStrensth += 1;
                    Attack += currentStrensth * 5;
                    HP += currentStrensth * 2;
                }
            }
            else 
            {
                if (currentStrensth > strensthMin)
                {
                    Attack -= currentStrensth * 5;
                    HP -= currentStrensth * 2;
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
                    Attack += currentDesterity * 1;
                    PDet += currentDesterity * 1;
                }
            }
            else
            {
                if (currentDesterity > desterityMin)
                {
                    Attack -= currentDesterity * 1;
                    PDet -= currentDesterity * 1;
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
                    HP += currentConstitution * 10;
                    PDet += currentDesterity * 2;
                }
            }
            else
            {
                if (currentConstitution > constitutionMin)
                {
                    HP -= currentConstitution * 10;
                    PDet -= currentDesterity * 2;
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
                    MP += currentIntellisense * 1;
                    MAH += currentIntellisense * 1;
                }
            }
            else
            {
                if (currentIntellisense > intellisenseMin)
                {
                    MP -= currentIntellisense * 1;
                    MAH -= currentIntellisense * 1;
                    currentIntellisense -= 1;
                }
            }
            return currentIntellisense;
        }
    }
}


