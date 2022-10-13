using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExWarcraftWPF.res;

namespace ExWarcraftWPF.enumUnits
{
    public class Warrior:Unit
    {
         int strensthMin = 30;
         int strensthMax = 250;
         int desterityMin = 15;
         int desterityMax = 70;
         int constitutionMin = 20;
         int constitutionMax = 100;
         int intellisenseMin = 10;
         int intellisenseMax = 50;
       
        double health = 0;
        double damage = 0;
        double magicPoints = 0;
        double pDet = 0;
        double mah = 0;

        public Warrior()
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
            CurrentIntellisense = intellisenseMin;
        
        }

        public Warrior(int strensth, int desterity, int constitution, int inellisense, List<Item> items, int exp, List<Equipment> equipments)
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
        
        public override void AddToInvertory(Item item)
        {
            Inventory.Add(item);
        }
        
        public override void AddToEquipments(Equipment equipment)
        {
            Equipments.Add(equipment);  
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
                    Attack += CurrentStrensth * 5;
                    HP += CurrentStrensth * 2;
                }
            }
            else 
            {
                if (CurrentStrensth > StrensthMin)
                {
                    Attack -= CurrentStrensth * 5;
                    HP -= CurrentStrensth * 2;
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
                    Attack += CurrentDesterity * 1;
                    PDet += CurrentDesterity * 1;
                }
            }
            else
            {
                if (CurrentDesterity > DesterityMin)
                {
                    Attack -= CurrentDesterity * 1;
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
                    HP += CurrentConstitution * 10;
                    PDet += CurrentConstitution * 2;
                }
            }
            else
            {
                if (CurrentConstitution > ConstitutionMin)
                {
                    HP -= CurrentConstitution * 10;
                    PDet -= CurrentConstitution * 2;
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
                    MP += CurrentIntellisense * 1;
                    MAH += CurrentIntellisense * 1;
                }
            }
            else
            {
                if (CurrentIntellisense > IntellisenseMin)
                {
                    MP -= CurrentIntellisense * 1;
                    MAH -= CurrentIntellisense * 1;
                    CurrentIntellisense -= 1;
                }
            }
            return CurrentIntellisense;
        }
    }
}


