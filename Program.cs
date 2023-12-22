using System;
using System.Reflection.Metadata.Ecma335;

namespace heistpt2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>(){
                new Muscle{
                    Name = "BeanTeam",
                    SkillLevel = 100,
                    PercentageCut = 67
                },
                 new Muscle{
                    Name = "Chelsea H",
                    SkillLevel = 65,
                    PercentageCut = 82
                },
                 new LockSpecialist{
                    Name = "Cal",
                    SkillLevel = 100,
                    PercentageCut = 12
                },
                  new LockSpecialist{
                    Name = "Darrin",
                    SkillLevel = 50,
                    PercentageCut = 50
                },
                  new Hacker{
                    Name = "Maxter",
                    SkillLevel = 100,
                    PercentageCut = 2
                },
                new Hacker{
                    Name = "Tommy",
                    SkillLevel = 18,
                    PercentageCut = 15
                },
            };

            Bank bank = new Bank()
            {
                AlarmScore = new Random().Next(0, 100),
                SecurityGuardScore = new Random().Next(0, 100),
                VaultScore = new Random().Next(0, 100),
                CashOnHand = new Random().Next(50000, 1000000)
            };

            Console.WriteLine("Lets plan a heist!");
            Console.WriteLine("----------------------");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Current # of operatives in rolodex: {rolodex.Count}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Add a new Operative or press enter to continue: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("What's their speciality?");
                Console.WriteLine("Enter # to select:");
                Console.WriteLine();
                Console.WriteLine("1) Hacker (Disables alarms)");
                Console.WriteLine("2) Muscle (Disarms guards)");
                Console.WriteLine("3) Lock Specialist (cracks vault)");
                Console.WriteLine();
                string job = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("What's their skill level?");
                Console.WriteLine("Enter a number 1-100:");
                Console.WriteLine();
                string skillLevel = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("What's their percentage cut?");
                Console.WriteLine("Enter a number 1-100:");
                Console.WriteLine();
                string percentageCut = Console.ReadLine();

                if (job == "1")
                {
                    rolodex.Add(
                        new Hacker
                        {
                            Name = name,
                            SkillLevel = int.Parse(skillLevel),
                            PercentageCut = int.Parse(percentageCut)
                        }
                    );
                }
                else if (job == "2")
                {
                    rolodex.Add(
                        new Muscle
                        {
                            Name = name,
                            SkillLevel = int.Parse(skillLevel),
                            PercentageCut = int.Parse(percentageCut)
                        }
                    );
                }
                else if (job == "3")
                {
                    rolodex.Add(
                       new Muscle
                       {
                           Name = name,
                           SkillLevel = int.Parse(skillLevel),
                           PercentageCut = int.Parse(percentageCut)
                       }
                   );
                }

            }

            Console.WriteLine("Let's get a scouting report for the bank:");
            Console.WriteLine();
            bank.Report();

            Console.WriteLine("Time to assemble our team:");

            List<IRobber> crew = new List<IRobber>();
            while (true)
            {
                for (int i = 0; i < rolodex.Count; i++)
                {
                    int percentSum = crew.Sum(x => x.PercentageCut);
         
                    if( !crew.Any( x => x.Name == rolodex[i].Name))
                    {
                        if((percentSum + rolodex[i].PercentageCut) <= 100){
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"Press {i + 1} for:");
                    Console.WriteLine($"Name: {rolodex[i].Name}");
                    Console.WriteLine($"Job: {rolodex[i].Job}");
                    Console.WriteLine($"Skill Level: {rolodex[i].SkillLevel}");
                    Console.WriteLine($"Percent Cut: {rolodex[i].PercentageCut}");
                    Console.WriteLine("--------------------");
                    }
                    }
                }

                Console.WriteLine("Who joining the crew enter a number or press to continue:");
                Console.WriteLine();
                string selection = Console.ReadLine();
                if(selection == ""){
                    break;
                }

                crew.Add(rolodex[int.Parse(selection) - 1]);

            }

            Console.WriteLine("Lets start the heist!");
            Console.WriteLine();

            foreach (IRobber member in crew){

                    member.PerformSkill(bank);
               
            }

            if(bank.IsSecure)
            {
                Console.WriteLine("The heist was a failure. Big Sad");
            }
            else{
                Console.WriteLine("The heist was a Success. Congrats");
                Console.WriteLine("Lets check out each members cut");
                Console.WriteLine(bank.CashOnHand);


                foreach (IRobber member in crew){
                
                    double cut = (bank.CashOnHand / 100) * member.PercentageCut;
                    Console.WriteLine($"{member.Name}'s cut was {cut}");
                    Console.WriteLine();
                }
                    Console.WriteLine($"You were left with {(bank.CashOnHand / 100) * crew.Sum(x => x.PercentageCut)}");

            }
        }
    }
}

// Once the user enters a blank value for a crew member, we're ready to begin the heist. Each crew member should perform his/her skill on the bank. Afterwards, evaluate if the bank is secure. If not, the heist was a success! Print out a success message to the user. If the bank does still have positive values for any of its security properties, the heist was a failure. Print out a failure message to the user.

// If the heist was a success, print out a report of each members' take, along with how much money is left for yourself.