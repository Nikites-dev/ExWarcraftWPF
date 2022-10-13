using System;

namespace ExWarcraftWPF.res.EquipType
{
    public class IronHelmet : Equipment
    {
        private String eqpmtName = "Iron Helmet";
        private String eqpmtType = "Helmet";
        private int eqpmtLevel = 2;
        
        double hp = 30;
        double mp = 0;
        double attack = 0;
        double pDet = 1250;
        double mah = 40;

       
        private int exp = 0;
        int strensth = 30;
        int desterity = 15;
        int constitution = 20;
        int intellisense = 10;
        
        public IronHelmet()
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