public class Solution
{
    public bool IsPalindrome(string s)
    {
        // An empty string has no mismatching characters, so it is a valid palindrome.
        if (string.IsNullOrEmpty(s)) return true;

        // Start two pointers at opposite ends of the string.
        int left = 0;
        int right = s.Length - 1;

        // Move the pointers toward each other until they meet or cross.
        while (left < right)
        {
            // Skip non-alphanumeric characters on the left.
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
            }

            // Skip non-alphanumeric characters on the right.
            else if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
            }

            // Both characters are letters or digits, so compare them.
            else
            {
                // Compare characters ignoring uppercase/lowercase differences.
                if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
                {
                    return false;
                }

                // Characters matched, so move both pointers inward.
                left++;
                right--;
            }
        }

        // No mismatching characters were found, so the string is a palindrome.
        return true;
    }
}