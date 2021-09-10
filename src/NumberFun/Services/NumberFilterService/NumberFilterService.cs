using System.Collections.Generic;
using System.Linq;

namespace NumberFun.Services.NumberFilterService
{
    public class NumberFilterService
    {
        public NumberFilterServiceResponse Execute(IEnumerable<int> array, int inputNumber)
        {
            var above = array.Count(x => x > inputNumber);
            var below = array.Count(x => x < inputNumber);
            return new NumberFilterServiceResponse(NumberOfIntegersAbove: above, NumberOfIntegersBelow: below);
        }
    }
}
