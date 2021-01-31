using System;

namespace Verify
{
    class Verify
    {
        public static bool IsOptionIncorrect(in string option, in int maxLimit)
        {
            if(!String.IsNullOrWhiteSpace(option))
            {
                bool isNotDigit = !int.TryParse(option, out int digit);

                if (isNotDigit)
                    return true;

                for (int i = 1; i <= maxLimit; i++)
                {
                    if (digit == i)
                        return false;
                }
            }
            return true;
        }

        public static bool IsInputNotNumber(in string input)
        {
            return !int.TryParse(input, out _);
        }

    }
}
