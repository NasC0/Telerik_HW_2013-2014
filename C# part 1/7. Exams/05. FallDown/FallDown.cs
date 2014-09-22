using System;
using System.Collections.Generic;

class FallDown
{
    static void Main()
    {
        int[] nums = new int[8];
        for (int i = 0; i < 8; i++)
        {
            int.TryParse(Console.ReadLine(), out nums[i]);
        }

        for (int k = 0; k < 7; k++)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                for (int bitPosition = 0; bitPosition < 8; bitPosition++)
                {
                    if ((nums[i] >> bitPosition & 1) == 0 &&
                        (nums[i - 1] >> bitPosition & 1) == 1)
                    {
                        nums[i] |= (1 << bitPosition);
                        nums[i - 1] ^= (1 << bitPosition);
                    }
                }
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(nums[i]);
        }
    }
}
