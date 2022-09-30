using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExWarcraftWPF.enumUnits;

namespace ExWarcraftWPF.enumUnits
{
   public class Rogue:Unit
    {
        public int strensthMin = 15;
        public int strensthMax = 55;
        public int desterityMin = 30;
        public int desterityMax = 250;
        public int constitutionMin = 20;
        public int constitutionMax = 80;
        public int intellisenseMin = 7;
        public int intellisenseMax = 15;

        double health = 0;
        double damage = 0;
        double magicPoints = 0;
        double pDet = 0;
        double mah = 0;

        public Rogue()
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
                if (CurrentStrensth <StrensthMax)
                {
                    CurrentStrensth += 1;
                    Attack += CurrentStrensth * 2;
                    HP += CurrentStrensth * 1;
                }
            }
            else
            {
                if (CurrentStrensth > StrensthMin)
                {
                    Attack -= CurrentStrensth * 2;
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
                    Attack += CurrentDesterity * 4;
                    PDet += CurrentDesterity * 1.5;
                }
            }
            else
            {
                if (CurrentDesterity > DesterityMin)
                {
                    Attack -= CurrentDesterity * 4;
                    PDet -= CurrentDesterity * 1.5;
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
                    HP += CurrentConstitution * 6;
                }
            }
            else
            {
                if (CurrentConstitution > ConstitutionMin)
                {
                    HP -= CurrentConstitution * 6;
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
                    MP += CurrentIntellisense * 1.5;
                    MAH += CurrentIntellisense * 2;
                }
            }
            else
            {
                if (CurrentIntellisense > IntellisenseMin)
                {
                    MP -= CurrentIntellisense * 2;
                    MAH -= CurrentIntellisense * 1.5;
                    CurrentIntellisense -= 1;
                }
            }
            return CurrentIntellisense;
        }
    }
}

