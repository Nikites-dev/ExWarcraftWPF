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

        int health = 0;
        int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;

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

            CurrentStrensth = StrensthMin;
            CurrentDesterity = DesterityMin;
            CurrentConstitution = ConstitutionMin;
            CurrentIntellisense = IntellisenseMin; ;
        }

        public void setCharacter(int strensth, int desterity, int constitution, int inellisense)
        {
            for (int i = 0; i < strensth; i++)
            {
                changeStrensth(true);
            }

            for (int i = 0; i < constitution; i++)
            {
                changeConstitution(true);
            }

            for (int i = 0; i < desterity; i++)
            {
                changeDesterity(true);
            }

            for (int i = 0; i < inellisense; i++)
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
                    PDet += CurrentDesterity * 2;
                }
            }
            else
            {
                if (CurrentConstitution > ConstitutionMin)
                {
                    HP -= CurrentConstitution * 10;
                    PDet -= CurrentDesterity * 2;
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


