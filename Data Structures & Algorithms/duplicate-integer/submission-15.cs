public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> setNums = new HashSet<int>(nums);
        int originalCount = nums.Length;
        int checkCount = setNums.Count;

        if (originalCount == checkCount) {
            return false;
        }
        else {
            return true;
        }
    }
}