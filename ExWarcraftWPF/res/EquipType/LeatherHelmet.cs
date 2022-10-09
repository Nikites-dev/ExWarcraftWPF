using System;

namespace ExWarcraftWPF.res.EquipType
{
    public class LeatherHelmet : Equipment
    {
        private String eqpmtName = "Leather Helmet";
        private String eqpmtType = "Helmet";
        private int eqpmtLevel = 1;
        
        double hp = 10;
        double mp = 0;
        double attack = 0;
        double pDet = 120;
        double mah = 20;

       
        private int exp = 0;
        int strensth = 100;
        int desterity = 50;
        int constitution = 50;
        int intellisense = 15;
        
        public LeatherHelmet()
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