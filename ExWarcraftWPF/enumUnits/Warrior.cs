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

        public int currentStrensth = 30;
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

        public int changeStrensth(bool isPlus)
        {
            if(currentStrensth >= strensthMin)
            {
                if (isPlus)      
                {
                    currentStrensth += 1;
                    Attack += currentStrensth * 5;
                    HP += currentStrensth * 2;
                }
                else 
                {
                    currentStrensth -= 1;
                    Attack -= currentStrensth * 5;
                    HP -= currentStrensth * 2;
                }
            }
            else
            {
                currentStrensth = strensthMin;
                Attack = currentStrensth * 5;
                HP = currentStrensth * 2;
            }
                
            return currentStrensth;
        }

        public int changeDesterity(bool isPlus)
        {
            if (currentDesterity >= desterityMin)
            {
                if (isPlus)
                {
                    currentDesterity += 1;
                    Attack += currentDesterity * 1;
                    PDet += currentDesterity * 1;
                } else
                {
                    currentDesterity -= 1;
                    Attack -= currentDesterity * 1;
                    PDet -= currentDesterity * 1;
                }
            }
            else
            {
                currentDesterity = desterityMin;
                Attack = currentDesterity * 1;
                PDet = currentDesterity * 1;
            }
            return currentDesterity;
        }

        public int changeConstitution(bool isPlus)
        {
            if (currentConstitution >= constitutionMin)
            {
                if (isPlus)
                {
                    currentConstitution += 1;
                    HP += currentConstitution * 10;
                    PDet += currentDesterity * 2;
                }
                else
                {
                    currentConstitution -= 1;
                    HP -= currentConstitution * 10;
                    PDet -= currentDesterity * 2;
                }
            }
            else
            {
                currentConstitution = constitutionMin;
                HP = currentConstitution * 10;
                PDet = currentDesterity * 2;
            }
            return currentConstitution;
        }



        public int changeIntellisense(bool isPlus)
        {
            if (currentIntellisense >= intellisenseMin)
            {
                if (isPlus)
                {
                    currentIntellisense += 1;
                    MP += currentIntellisense * 1;
                    MAH += currentIntellisense * 1;
                }
                else
                {
                    currentIntellisense -= 1;
                    MP -= currentIntellisense * 1;
                    MAH -= currentIntellisense * 1;
                }
            }
            else
            {
                currentIntellisense = intellisenseMin;
                MP = currentIntellisense * 1;
                MAH = currentIntellisense * 1;
            }
            return currentIntellisense;
        }
    }
}


