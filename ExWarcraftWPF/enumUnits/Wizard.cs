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

        int health = 0;
        int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;
   

    public Wizard()
    {
        CurrentStrensth = strensthMin;
        CurrentDesterity = desterityMin;
        CurrentConstitution = constitutionMin;
        CurrentIntellisense = intellisenseMin; ;
    }

    


    public override int changeStrensth(bool isPlus)
    {

        if (isPlus)
        {
            if (CurrentStrensth < strensthMax)
            {
                CurrentStrensth += 1;
                Attack += CurrentStrensth * 3;
                HP += CurrentStrensth * 1;
            }
        }
        else
        {
            if (CurrentStrensth > strensthMin)
            {
                Attack -= CurrentStrensth * 3;
                HP -= CurrentStrensth * 1;
                CurrentStrensth -= 1;
            }
        }
        return CurrentStrensth;
    }

    public override int changeDesterity(bool isPlus)
    {

        if (isPlus)
        {
            if (CurrentDesterity < desterityMax)
            {
                CurrentDesterity += 1;
                PDet += CurrentDesterity * 1;
            }
        }
        else
        {
            if (CurrentDesterity > desterityMin)
            {
                PDet -= CurrentDesterity * 1;
                CurrentDesterity -= 1;
            }
        }
        return CurrentDesterity;
    }

    public override int changeConstitution(bool isPlus)
    {
        if (isPlus)
        {
            if (CurrentConstitution < constitutionMax)
            {
                CurrentConstitution += 1;
                HP += CurrentConstitution * 3;
                PDet += CurrentConstitution * 1;
            }
        }
        else
        {
            if (CurrentConstitution > constitutionMin)
            {
                HP -= CurrentConstitution * 3;
                PDet -= CurrentConstitution * 1;
                CurrentConstitution -= 1;
            }
        }
        return CurrentConstitution;
    }

    public override int changeIntellisense(bool isPlus)
    {
        if (isPlus)
        {
            if (CurrentIntellisense < intellisenseMax)
            {
                CurrentIntellisense += 1;
                MP += CurrentIntellisense * 2;
                MAH += CurrentIntellisense * 5;
            }
        }
        else
        {
            if (CurrentIntellisense > intellisenseMin)
            {
                MP -= CurrentIntellisense * 2;
                MAH -= CurrentIntellisense * 5;
                CurrentIntellisense -= 1;
            }
        }
        return CurrentIntellisense;
    }
}
}
