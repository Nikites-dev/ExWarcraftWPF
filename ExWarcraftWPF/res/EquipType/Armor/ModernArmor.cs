using System;

namespace ExWarcraftWPF.res.EquipType
{
    public class ModernArmor : Equipment
    {
        private String eqpmtName = "Modern Armor";
        private String eqpmtType = "Armor";
        private int eqpmtLevel = 3;
        
        double hp = 130;
        double mp = 50;
        double attack = 0;
        double pDet = 200;
        double mah = 100;

       
        private int exp = 0;
        int strensth = 30;
        int desterity = 30;
        int constitution = 35;
        int intellisense = 15;
        
        public ModernArmor()
        {
            EqpmtName = eqpmtName;
            EqpmtType = eqpmtType;
            EqpmtLevel = eqpmtLevel;
            Exp = exp;
            Strensth = strensth;
            Desterity = desterity;
            Constitution = constitution;
            Intellisense = intellisense;

            HP = hp;
            MP = mp;
            Attack = attack;
            PDet = pDet;
            MAH = mah;
        }
    }
}