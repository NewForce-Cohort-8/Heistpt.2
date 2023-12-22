using System;

namespace heistpt2
{
    public interface IRobber
    {
        // A string property for Name
        public string Name {get; set;}
        // An integer property for SkillLevel
        public int SkillLevel {get; set;}
        // An integer property for PercentageCut
        public int PercentageCut {get; set;}
        // A method called PerformSkill that takes in a Bank parameter and doesn't return anything.
        public void PerformSkill(Bank bank);
        public string Job {get;}
    }




}




// Each type of robber will have a special skill that will come in handy while knocking over banks. Start by creating an interface called IRobber. The interface should include:

