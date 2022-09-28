using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExWarcraftWPF.enumUnits
{
    public class Wizard:Unit
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
        StrensthMin = strensthMin;
        StrensthMax = strensthMax;
        DesterityMin = desterityMin;
        DesterityMax = desterityMax;
        ConstitutionMin = constitutionMin;
        ConstitutionMax = constitutionMax;
        IntellisenseMin = intellisenseMin;
        IntellisenseMax = intellisenseMax;
        
        CurrentStrensth = strensthMin;
        CurrentDesterity = desterityMin;
        CurrentConstitution = constitutionMin;
        CurrentIntellisense = intellisenseMin; ;
    }

    public override void setCharacter(int strensth, int desterity, int constitution, int inellisense)
    {
        for (int i = 0; i < strensth-strensthMin; i++)
        {
            changeStrensth(true);
        }

        for (int i = 0; i < constitution-constitutionMin; i++)
        {
            changeConstitution(true);
        }

        for (int i = 0; i < desterity-desterityMin; i++)
        {
            changeDesterity(true);
        }

        for (int i = 0; i < inellisense-intellisenseMin; i++)
        {
            changeIntellisense(true);
        }
    }


    public override int changeStrensth(bool isPlus)
    {

        if (isPlus)
        {
            if (CurrentStrensth < StrensthMax)
            {
                CurrentStrensth += 1;
                Attack += CurrentStrensth * 3;
                HP += CurrentStrensth * 1;
            }
        }
        else
        {
            if (CurrentStrensth > StrensthMin)
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
            if (CurrentDesterity < DesterityMax)
            {
                CurrentDesterity += 1;
                PDet += CurrentDesterity * 1;
            }
        }
        else
        {
            if (CurrentDesterity > DesterityMin)
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
            if (CurrentConstitution < ConstitutionMax)
            {
                CurrentConstitution += 1;
                HP += CurrentConstitution * 3;
                PDet += CurrentConstitution * 1;
            }
        }
        else
        {
            if (CurrentConstitution > ConstitutionMin)
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
            if (CurrentIntellisense < IntellisenseMax)
            {
                CurrentIntellisense += 1;
                MP += CurrentIntellisense * 2;
                MAH += CurrentIntellisense * 5;
            }
        }
        else
        {
            if (CurrentIntellisense > IntellisenseMin)
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
