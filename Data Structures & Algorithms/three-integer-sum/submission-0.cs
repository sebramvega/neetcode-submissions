public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);

        List<List<int>> result = new List<List<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // Skip duplicate starting numbers.
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    // Add the three numbers that sum to zero.
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    left++;
                    right--;

                    // Skip duplicate left values.
                    while (left < right && nums[left] == nums[left - 1])
                    {
                        left++;
                    }

                    // Skip duplicate right values.
                    while (left < right && nums[right] == nums[right + 1])
                    {
                        right--;
                    }
                }
                else if (sum < 0)
                {
                    // Sum is too small, so move left to a larger number.
                    left++;
                }
                else
                {
                    // Sum is too large, so move right to a smaller number.
                    right--;
                }
            }
        }

        return result;
    }
}