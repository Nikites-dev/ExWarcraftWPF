using System;

namespace ExWarcraftWPF.res.EquipType
{
    public class ModernHelmet : Equipment
    {
        private String eqpmtName = "Modern Helmet";
        private String eqpmtType = "Helmet";
        private int eqpmtLevel = 3;
        
        double hp = 100;
        double mp = 0;
        double attack = 0;
        double pDet = 1550;
        double mah = 70;

       
        private int exp = 0;
        int strensth = 40;
        int desterity = 45;
        int constitution = 30;
        int intellisense = 20;
        
        public ModernHelmet()
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