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
                    Attack += CurrentStrensth * 5;
                    HP += CurrentStrensth * 2;
                }
            }
            else 
            {
                if (CurrentStrensth > strensthMin)
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
                if (CurrentDesterity < desterityMax)
                {
                    CurrentDesterity += 1;
                    Attack += CurrentDesterity * 1;
                    PDet += CurrentDesterity * 1;
                }
            }
            else
            {
                if (CurrentDesterity > desterityMin)
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
                if (CurrentConstitution < constitutionMax)
                {
                    CurrentConstitution += 1;
                    HP += CurrentConstitution * 10;
                    PDet += CurrentDesterity * 2;
                }
            }
            else
            {
                if (CurrentConstitution > constitutionMin)
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
                if (CurrentIntellisense < intellisenseMax)
                {
                    CurrentIntellisense += 1;
                    MP += CurrentIntellisense * 1;
                    MAH += CurrentIntellisense * 1;
                }
            }
            else
            {
                if (CurrentIntellisense > intellisenseMin)
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


