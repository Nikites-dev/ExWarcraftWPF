using System;

namespace ExWarcraftWPF.res
{
    public class Equipment
    {
        public Equipment(String name, int level)
        {
            EqpmtName = name;
            EqpmtLevel = level;
        }
        
        public String EqpmtName { get; set; }
        public int EqpmtLevel { get; set; }
    }
}