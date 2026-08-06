public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> setNums = new HashSet<int>(nums);
        int originalLength = nums.Length;
        int checkCount = setNums.Count;

        if (originalLength == checkCount){
            return false;
        }
        return true;
    }
}