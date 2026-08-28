public class Solution
{
    public int MaxArea(int[] heights)
    {
        // Start at both ends to begin with the widest possible container
        int left = 0;
        int right = heights.Length - 1;

        // Tracks the largest area found so far
        int maxArea = 0;

        while (left < right)
        {
            // Distance between the two bars
            int width = right - left;

            // Water height is limited by the shorter bar
            int containerHeight = Math.Min(heights[left], heights[right]);

            // Area = width * height
            int currentArea = width * containerHeight;

            // Keep the largest area found
            if (currentArea > maxArea)
            {
                maxArea = currentArea;
            }

            // Move the shorter bar inward since it limits the container's height
            if (heights[left] < heights[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}