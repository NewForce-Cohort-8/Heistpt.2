using System;

namespace heistpt2
{
    public class Bank
    {
        // An integer property for CashOnHand
        public int CashOnHand { get; set; }
        // An integer property for AlarmScore
        public int AlarmScore { get; set; }
        // An integer property for VaultScore
        public int VaultScore { get; set; }
        // An integer property for SecurityGuardScore
        public int SecurityGuardScore { get; set; }
        // A computed boolean property called IsSecure. If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true
        public bool IsSecure
        {
            get
            {

                if (AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Report()
        {
            Dictionary<string, int> Values = new Dictionary<string, int>();
            Values.Add("Alarm", AlarmScore);
            Values.Add("Vault", VaultScore);
            Values.Add("Security Guards", SecurityGuardScore);

            var weightedScores = from score in Values orderby score.Value ascending select score;

            List<KeyValuePair<string, int>> x = weightedScores.ToList();

            Console.WriteLine($"Most Secure: {x[2].Key} {x[2].Value} ");
            Console.WriteLine($"Least Secure: {x[0].Key} {x[0].Value} ");

            



        }
    }
}
// Knocking over banks isn't going to be easy. Alarms... Vaults... Security Guards.... Each of these safeguards is something we'll have to handle for a successful heist. First things first. Let's create a Bank class to represent the security we're up against. Give the Bank class the following properties:

// An integer property for CashOnHand
// An integer property for AlarmScore
// An integer property for VaultScore
// An integer property for SecurityGuardScore
// A computed boolean property called IsSecure. If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true