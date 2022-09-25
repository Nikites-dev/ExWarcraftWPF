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
        public int intellisenseMin = 7;
        public int intellisenseMax = 15;

        int health = 0;
        int damage = 0;
        int magicPoints = 0;
        int pDet = 0;
        int mah = 0;

        public Rogue()
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
                if (CurrentStrensth <strensthMax)
                {
                    CurrentStrensth += 1;
                    Attack += CurrentStrensth * 2;
                    HP += CurrentStrensth * 1;
                }
            }
            else
            {
                if (CurrentStrensth > strensthMin)
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
                if (CurrentDesterity < desterityMax)
                {
                    CurrentDesterity += 1;
                    Attack += CurrentDesterity * 2;
                    PDet += CurrentDesterity * 2;
                }
            }
            else
            {
                if (CurrentDesterity > desterityMin)
                {
                    Attack -= CurrentDesterity * 2;
                    PDet -= CurrentDesterity * 2;
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
                    HP += CurrentConstitution * 6;
                }
            }
            else
            {
                if (CurrentConstitution > constitutionMin)
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
                if (CurrentIntellisense < intellisenseMax)
                {
                    CurrentIntellisense += 1;
                    MP += CurrentIntellisense * 2;
                    MAH += CurrentIntellisense * 2;
                }
            }
            else
            {
                if (CurrentIntellisense > intellisenseMin)
                {
                    MP -= CurrentIntellisense * 2;
                    MAH -= CurrentIntellisense * 2;
                    CurrentIntellisense -= 1;
                }
            }
            return CurrentIntellisense;
        }
    }
}

