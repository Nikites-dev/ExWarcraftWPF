using System;

namespace ExWarcraftWPF.res
{
    public class Equipment
    {
        public Equipment(String name, int level, String type)
        {
            EqpmtName = name;
            EqpmtLevel = level;
            EqpmtType = type;
        }

        public Equipment()
        {
            
        }

        public String EqpmtName { get; set; }
        public int EqpmtLevel { get; set; }
        public String EqpmtType { get; set; }
        
        
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Strensth { get; set; }
        public int Desterity { get; set; }
        public int Constitution { get; set; }
        public int Intellisense { get; set; }
        
        public double HP { get; set; }
        public double MP { get; set; }
        public double Attack { get; set; }
        public double PDet { get; set; }
        public double MAH { get; set; }
        
    }
}