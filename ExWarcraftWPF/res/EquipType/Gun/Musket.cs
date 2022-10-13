using System;

namespace ExWarcraftWPF.res.EquipType
{
    
    public class Musket: Equipment
    {
        private String eqpmtName = "Musket";
        private String eqpmtType = "Gun";
        private int eqpmtLevel = 2;
        
        double hp = 0;
        double mp = 20;
        double attack = 120;
        double pDet = 20;
        double mah = 0;

       
        private int exp = 0;
        int strensth = 30;
        int desterity = 45;
        int constitution = 20;
        int intellisense = 10;
        
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