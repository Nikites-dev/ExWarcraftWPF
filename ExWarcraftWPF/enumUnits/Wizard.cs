using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExWarcraftWPF.res;

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

        double health = 0;
        double damage = 0;
        double magicPoints = 0;
        double pDet = 0;
        double mah = 0;
   

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
    
    public Wizard(int strensth, int desterity, int constitution, int inellisense, List<Item> items, int exp, List<Equipment> equipments)
    {
        StrensthMin = strensthMin;
        StrensthMax = strensthMax;
        DesterityMin = desterityMin;
        DesterityMax = desterityMax;
        ConstitutionMin = constitutionMin;
        ConstitutionMax = constitutionMax;
        IntellisenseMin = intellisenseMin;
        IntellisenseMax = intellisenseMax;

        CurrentStrensth = strensth;
        CurrentDesterity = desterity;
        CurrentConstitution = constitution;
        CurrentIntellisense = inellisense;
        Inventory = items;
        Exp = exp;
        Equipments = equipments;
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
    
    
    public override void AddToInvertory(Item item)
    {
        Inventory.Add(item);
    }

    public override void AddToEquipments(Equipment equipment)
    {
        Equipments.Add(equipment);  
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
                PDet += CurrentDesterity * 0.5;
            }
        }
        else
        {
            if (CurrentDesterity > DesterityMin)
            {
                PDet -= CurrentDesterity * 0.5;
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
