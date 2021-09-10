using NumberFun.Services.NumberFilterService;

namespace NumberFun.Pages.NumberFilter
{
    public record NumberFilterPageState
    {
        public NumberFilterServiceResponse NumberFilterResult { get; set; }
    }
}