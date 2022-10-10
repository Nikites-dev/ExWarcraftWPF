using System;

namespace ExWarcraftWPF.res.EquipType
{
    
    public class Revolver: Equipment
    {
        private String eqpmtName = "Revolver";
        private String eqpmtType = "Gun";
        private int eqpmtLevel = 1;
        
        double hp = 0;
        double mp = 0;
        double attack = 40;
        double pDet = 15;
        double mah = 0;

       
        private int exp = 0;
        int strensth = 20;
        int desterity = 40;
        int constitution = 20;
        int intellisense = 10;
        
        public Revolver()
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