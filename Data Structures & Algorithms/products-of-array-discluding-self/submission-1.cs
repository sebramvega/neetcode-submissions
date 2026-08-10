public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        // Time: O(n) | Space: O(n)
        int[] leftProducts = new int[nums.Length];
        int[] rightProducts = new int[nums.Length];
        int[] result = new int[nums.Length];

        // Nothing exists to the left of the first number, so start with 1
        leftProducts[0] = 1;

        // Build running products of everything to the left of each index
        for (int i = 1; i < nums.Length; i++)
        {
            leftProducts[i] = leftProducts[i - 1] * nums[i - 1];
        }

        // Nothing exists to the right of the last number, so start with 1
        rightProducts[nums.Length - 1] = 1;

        // Build running products of everything to the right of each index
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            rightProducts[i] = rightProducts[i + 1] * nums[i + 1];
        }

        // Left product × right product gives product of everything except nums[i]
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = leftProducts[i] * rightProducts[i];
        }

        return result;
    }
}