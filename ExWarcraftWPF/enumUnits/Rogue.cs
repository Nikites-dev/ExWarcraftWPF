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

        public Rogue()
        {
            currentStrensth = strensthMin;
            currentDesterity = desterityMin;
            currentConstitution = constitutionMin;
            currentIntellisense = intellisenseMin; ;
        }

        

        public int changeStrensth(bool isPlus)
        {
            if (currentStrensth >= strensthMin)
            {
                if (isPlus)
                {
                    currentStrensth += 1;
                    Attack += currentStrensth * 2;
                    HP += currentStrensth * 1;
                }
                else
                {
                    currentStrensth -= 1;
                    Attack -= currentStrensth * 2;
                    HP -= currentStrensth * 1;
                }
            }
            else
            {
                currentStrensth = strensthMin;
                Attack = currentStrensth * 2;
                HP = currentStrensth * 1;
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
                    Attack += currentDesterity * 2;
                    PDet += currentDesterity * 2;
                }
                else
                {
                    currentDesterity -= 1;
                    Attack -= currentDesterity * 2;
                    PDet -= currentDesterity * 2;
                }
            }
            else
            {
                currentDesterity = desterityMin;
                Attack = currentDesterity * 2;
                PDet = currentDesterity * 2;
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
                    HP += currentConstitution * 6;
                }
                else
                {
                    currentConstitution -= 1;
                    HP -= currentConstitution * 6;
                }
            }
            else
            {
                currentConstitution = constitutionMin;
                HP = currentConstitution * 6;
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
                    MP += currentIntellisense * 2;
                    MAH += currentIntellisense * 2;
                }
                else
                {
                    currentIntellisense -= 1;
                    MP -= currentIntellisense * 2;
                    MAH -= currentIntellisense * 2;
                }
            }
            else
            {
                currentIntellisense = intellisenseMin;
                MP = currentIntellisense * 2;
                MAH = currentIntellisense * 2;
            }
            return currentIntellisense;
        }
    }
}

