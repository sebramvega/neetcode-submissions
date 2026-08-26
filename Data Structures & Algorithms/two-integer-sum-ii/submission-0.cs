public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            int sum = numbers[left] + numbers[right];

            // Found the target; +1 because the answer must be 1-indexed.
            if (sum == target)
            {
                return new int[] { left + 1, right + 1 };
            }

            // Sum is too small, so move left to a larger number.
            if (sum < target)
            {
                left++;
            }

            // Sum is too large, so move right to a smaller number.
            if (sum > target)
            {
                right--;
            }
        }

        return new int[] { };
    }
}