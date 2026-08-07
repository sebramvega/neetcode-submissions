public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        
        Dictionary<string, List<string>> result =
            new Dictionary<string, List<string>>();

        foreach (string word in strs)
        {
            char[] sortedWord = word.ToCharArray();
            Array.Sort(sortedWord);
            string key = new string(sortedWord);

            if (result.ContainsKey(key))
            {
                result[key].Add(word);
            }
            else
            {
                result.Add(key, new List<string> {word});
            }
        }

        return result.Values.ToList();
    }
}
