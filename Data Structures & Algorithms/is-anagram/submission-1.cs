public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in s)
        {
            counts[c] = counts.GetValueOrDefault(c) + 1;
        }

        foreach (char c in t)
        {
            if (!counts.ContainsKey(c))
            {
                return false;
            }

            counts[c]--;

            if (counts[c] < 0)
            {
                return false;
            }
        }

        return true;
    }
}