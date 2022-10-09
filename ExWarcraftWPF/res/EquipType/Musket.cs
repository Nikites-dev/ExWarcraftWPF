using System;

namespace ExWarcraftWPF.res.EquipType
{
    
    public class Musket: Equipment
    {
        private String eqpmtName = "Musket";
        private String eqpmtType = "Gun";
        private int eqpmtLevel = 2;
        
        double hp = 0;
        double mp = 0;
        double attack = 120;
        double pDet = 20;
        double mah = 0;

       
        private int exp = 0;
        int strensth = 40;
        int desterity = 60;
        int constitution = 10;
        int intellisense = 45;
        
        public Musket()
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