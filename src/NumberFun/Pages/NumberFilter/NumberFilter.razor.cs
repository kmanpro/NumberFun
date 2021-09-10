using Microsoft.AspNetCore.Components;
using NumberFun.Services.NumberFilterService;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NumberFun.Pages.NumberFilter
{
    public partial class NumberFilter
    {
        [Inject] private NumberFilterService numberFilterService { get; set; }

        private readonly NumberFilterPageState pageState = new();
        private readonly NumberFilterInputModel numberFilterInputModel = new();

        private void executeNumberFilter()
        {
            if (string.IsNullOrEmpty(numberFilterInputModel.NumberArrayInput)) return;

            var numArray = numberFilterInputModel.NumberArrayInput.Split(',', System.StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ConvertAll(x => int.TryParse(x, out var n) ? n : 0);

            if (!numArray.Any()) return;

            pageState.NumberFilterResult = numberFilterService.Execute(numArray, numberFilterInputModel.NumberFilterInput);
        }
    }

    public class NumberFilterInputModel
    {
        [Required]
        [RegularExpression(@"^\d*(,\d*)*$", ErrorMessage = "please only enter in a comma separated list of numbers with no spaces. Ex (1,10,20,9,2)")]
        public string NumberArrayInput { get; set; } = "1,5,2,1,10";

        public int NumberFilterInput { get; set; } = 6;
    }
}
