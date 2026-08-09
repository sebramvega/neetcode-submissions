public class Solution
{
    public string Encode(IList<string> strs)
    {
        // Build one encoded string from all strings in the list.
        string encoded = "";

        foreach (string x in strs)
        {
            // Get the length of the current string.
            int lengthOfString = x.Length;
            string resultLengthOfString = lengthOfString.ToString();

            // Store each string as: length + "#" + string.
            encoded += (resultLengthOfString + "#" + x);
        }

        return encoded;
    }

    public List<string> Decode(string s)
    {
        // Store each decoded string as we reconstruct it.
        List<string> decoded = new List<string>();

        // Track our current position in the encoded string.
        int tracker = 0;

        while (tracker < s.Length)
        {
            // Start searching from the beginning of the current length.
            int delimiter = tracker;

            // Find "#" to determine where the length number ends.
            while (s[delimiter] != '#')
            {
                delimiter++;
            }

            // Extract the characters representing the string's length.
            string lengthAsString =
                s.Substring(tracker, delimiter - tracker);

            // Convert the length from a string into an integer.
            int length = int.Parse(lengthAsString);

            // Read exactly "length" characters after the "#".
            string word = s.Substring(delimiter + 1, length);

            // Add the reconstructed string to the result list.
            decoded.Add(word);

            // Move to the beginning of the next encoded string.
            tracker = delimiter + 1 + length;
        }

        return decoded;
    }
}