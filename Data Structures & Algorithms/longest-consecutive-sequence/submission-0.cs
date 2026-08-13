public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        // Store every unique number for fast O(1) average lookup.
        HashSet<int> numberSet = new HashSet<int>();

        // Add all numbers to the HashSet; duplicates are automatically ignored.
        foreach (int num in nums)
        {
            numberSet.Add(num);
        }

        // Track the longest consecutive sequence found anywhere so far.
        int longestLength = 0;

        // Examine each unique number as a possible start of a sequence.
        foreach (int num in numberSet)
        {
            // A number starts a sequence only if the number before it does NOT exist.
            // Example: if 1 is missing but 2 exists, then 2 starts a new sequence.
            if (!numberSet.Contains(num - 1))
            {
                // The starting number itself gives us an initial sequence length of 1.
                int currentLength = 1;

                // Track our current position as we move forward through the sequence.
                int currentNumber = num;

                // Keep moving forward while the next consecutive number exists.
                while (numberSet.Contains(currentNumber + 1))
                {
                    currentNumber += 1;
                    currentLength += 1;
                }

                // Keep whichever is larger: this sequence or the previous longest.
                longestLength = Math.Max(longestLength, currentLength);
            }
        }

        // Return the length of the longest consecutive sequence we found.
        return longestLength;
    }
}