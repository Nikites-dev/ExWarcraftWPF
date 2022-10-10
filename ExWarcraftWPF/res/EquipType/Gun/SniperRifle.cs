using System;

namespace ExWarcraftWPF.res.EquipType
{
    
    public class SniperRifle: Equipment
    {
        private String eqpmtName = "Sniper Rifle";
        private String eqpmtType = "Gun";
        private int eqpmtLevel = 3;
        
        double hp = 0;
        double mp = 0;
        double attack = 200;
        double pDet = 10;
        double mah = 0;

       
        private int exp = 0;
        int strensth = 45;
        int desterity = 60;
        int constitution = 20;
        int intellisense = 50;
        
        public SniperRifle()
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