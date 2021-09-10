using System.Linq;

namespace NumberFun.Services.StringRotatorService
{
    public class StringRotatorService
    {
        public StringRotatorResponse Execute(int numberOfRotations, string givenString)
        {
            if (string.IsNullOrWhiteSpace(givenString))
            {
                if (numberOfRotations > givenString.Length) return new StringRotatorResponse(ErrorMessage: $"'{nameof(givenString)}' cannot be null or whitespace.");
            }

            var result = givenString.ToList();

            var lastIndex = givenString.Length - 1;
            for (var i = 0; i < numberOfRotations; i++)
            {
                var chr = result[lastIndex];
                result.RemoveAt(lastIndex);
                result.Insert(0, chr);
            }
            
            return new StringRotatorResponse(Result: string.Join("", result));
        }
    }
}
