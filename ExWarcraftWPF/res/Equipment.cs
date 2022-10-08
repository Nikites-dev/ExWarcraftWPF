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
        
        public String EqpmtName { get; set; }
        public int EqpmtLevel { get; set; }
        public String EqpmtType { get; set; }
    }
}