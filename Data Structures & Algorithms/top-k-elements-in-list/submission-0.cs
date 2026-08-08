public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!frequencyMap.ContainsKey(nums[i]))
            {
                frequencyMap.Add(nums[i], 1);
            }
            else
            {
                frequencyMap[nums[i]] += 1;
            }
        }

        Dictionary<int, List<int>> frequencyGroup = new Dictionary<int, List<int>>();

        foreach (KeyValuePair<int, int> pair in frequencyMap)
        {
            if (!frequencyGroup.ContainsKey(pair.Value))
            {
                frequencyGroup.Add(pair.Value, new List<int> {pair.Key});
            }
            else
            {
                frequencyGroup[pair.Value].Add(pair.Key);
            }
        }
        List<int> answer = [];
        for (int i = nums.Length; i > 0; i--)
        {
            if (frequencyGroup.ContainsKey(i)) 
            {
                foreach (int num in frequencyGroup[i]) 
                {
                    answer.Add(num);

                    if (answer.Count == k)
                    {
                        return answer.ToArray();
                    }
                }
            }
        }
        throw new InvalidOperationException("Unable to kind k frequent elements.");
    }

}
