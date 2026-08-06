class Solution:
    def hasDuplicate(self, nums: List[int]) -> bool:      

        answer = []

        for num in range(len(nums)):
            if str(nums[num]) in answer:
                return True
            else:
                answer.append(str(nums[num]))
        return False
            

