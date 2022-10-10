using System;

namespace ExWarcraftWPF.res.EquipType
{
    public class LeatherArmor : Equipment
    {
        private String eqpmtName = "Leather armor";
        private String eqpmtType = "Armor";
        private int eqpmtLevel = 1;
        
        double hp = 20;
        double mp = 10;
        double attack = 0;
        double pDet = 150;
        double mah = 50;

       
        private int exp = 0;
        int strensth = 20;
        int desterity = 20;
        int constitution = 20;
        int intellisense = 10;
        
        public LeatherArmor()
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