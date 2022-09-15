using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExWarcraftWPF.enumUnits
{
    public class Wizard:customMain
    {
        public int strensthMin = 10;
        public int strensthMax = 45;
        public int desterityMin = 20;
        public int desterityMax = 70;
        public int constitutionMin = 15;
        public int constitutionMax = 60;
        public int intellisenseMin = 35;
        public int intellisenseMax = 250;

        public int currentStrensth = 30;
        public int currentDesterity = 0;
        public int currentConstitution = 0;
        public int currentIntellisense = 0;

        int health = 0;
        int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;
   

    public Wizard()
    {
        currentStrensth = strensthMin;
        currentDesterity = desterityMin;
        currentConstitution = constitutionMin;
        currentIntellisense = intellisenseMin; ;
    }

    public override int changeStrensth(bool isPlus)
    {
        if (currentStrensth >= strensthMin)
        {
            if (isPlus)
            {
                currentStrensth += 1;
                Attack += currentStrensth * 3;
                HP += currentStrensth * 1;
            }
            else
            {
                currentStrensth -= 1;
                Attack -= currentStrensth * 3;
                HP -= currentStrensth * 1;
            }
        }
        else
        {
            currentStrensth = strensthMin;
            Attack = currentStrensth * 3;
            HP = currentStrensth * 1;
        }

        return currentStrensth;
    }

    public override int changeDesterity(bool isPlus)
    {
        if (currentDesterity >= desterityMin)
        {
            if (isPlus)
            {
                currentDesterity += 1;
                PDet += currentDesterity * 1;
            }
            else
            {
                currentDesterity -= 1;
                PDet -= currentDesterity * 1;
            }
        }
        else
        {
            currentDesterity = desterityMin;
            PDet = currentDesterity * 1;
        }
        return currentDesterity;
    }

    public override int changeConstitution(bool isPlus)
    {
        if (currentConstitution >= constitutionMin)
        {
            if (isPlus)
            {
                currentConstitution += 1;
                HP += currentConstitution * 3;
                PDet += currentDesterity * 1;
            }
            else
            {
                currentConstitution -= 1;
                HP -= currentConstitution * 3;
                PDet -= currentDesterity * 1;
            }
        }
        else
        {
            currentConstitution = constitutionMin;
            HP = currentConstitution * 3;
            PDet = currentDesterity * 1;
        }
        return currentConstitution;
    }



    public override int changeIntellisense(bool isPlus)
    {
        if (currentIntellisense >= intellisenseMin)
        {
            if (isPlus)
            {
                currentIntellisense += 1;
                MP += currentIntellisense * 2;
                MAH += currentIntellisense * 5;
            }
            else
            {
                currentIntellisense -= 1;
                MP -= currentIntellisense * 2;
                MAH -= currentIntellisense * 5;
            }
        }
        else
        {
            currentIntellisense = intellisenseMin;
            MP = currentIntellisense * 2;
            MAH = currentIntellisense * 5;
        }
        return currentIntellisense;
    }
}
}
