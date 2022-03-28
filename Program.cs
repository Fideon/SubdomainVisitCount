public class Solution
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] cpdomains = new string[] { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" };

        solution.SubdomainVisits(cpdomains);
    }

    public IList<string> SubdomainVisits(string[] cpdomains)
    {
        Dictionary<string, int> counts = new Dictionary<string, int>();
        foreach (string cpdomain in cpdomains)
        {
            string[] splitcp = cpdomain.Split(' ');
            string domain = splitcp[1];
            int visits = Int32.Parse(splitcp[0]);
            string[] subdomains = domain.Split('.');


            for (int i = 0; i < subdomains.Count(); i++)
            {
                if (!counts.ContainsKey(domain))
                {
                    counts.Add(domain, 0);
                }

                counts[domain] += visits;

                if (i < subdomains.Count() - 1)
                {
                    domain = domain.Replace(subdomains[i], "");
                    domain = domain.Remove(0, 1);
                }
            }
        }

        List<String> result = new List<String>();

        foreach (KeyValuePair<string, int> count in counts)
        {
            string c = count.Value.ToString();
            result.Add($"{c} {count.Key}");
        }

        return result;
    }
}