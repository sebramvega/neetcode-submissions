public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        Dictionary<char, int> counts = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            if (counts.ContainsKey(s[i])) {
                counts[s[i]]++;
            }
            else {
                counts.Add(s[i], 1);
            }
        }
        
        for (int i = 0; i < t.Length; i++) {
            if (!counts.ContainsKey(t[i])) {
                return false;
            }
            counts[t[i]]--;

            if (counts[t[i]] < 0) {
                return false;
            }
        }
        
        foreach (KeyValuePair<char, int> pair in counts) {
            if (pair.Value != 0) {
                return false;
            }
        }
        return true;
    }
}
