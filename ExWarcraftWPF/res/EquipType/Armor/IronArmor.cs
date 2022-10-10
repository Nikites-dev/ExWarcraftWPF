using System;

namespace ExWarcraftWPF.res.EquipType
{
    public class IronArmor : Equipment
    {
        private String eqpmtName = "Iron armor";
        private String eqpmtType = "Armor";
        private int eqpmtLevel = 2;
        
        double hp = 30;
        double mp = 20;
        double attack = 0;
        double pDet = 180;
        double mah = 70;

       
        private int exp = 0;
        int strensth = 30;
        int desterity = 40;
        int constitution = 30;
        int intellisense = 16;
        
        public IronArmor()
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