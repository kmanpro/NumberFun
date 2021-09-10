using Microsoft.AspNetCore.Components;
using NumberFun.Services.StringRotatorService;
using System.ComponentModel.DataAnnotations;

namespace NumberFun.Pages.StringRotator
{
    public partial class StringRotator
    {
        [Inject] private StringRotatorService stringRotatorService { get; set; }

        private readonly StringRotatorPageState pageState = new();
        private readonly StringRotatorInputModel stringRotatorInputModel = new();

        private void executeStringRotator()
        {
            if (string.IsNullOrEmpty(stringRotatorInputModel.StringRotatorInput)) return;
            pageState.StringRotatorResult = stringRotatorService.Execute(stringRotatorInputModel.StringRotatorIterations, stringRotatorInputModel.StringRotatorInput);
        }
    }

    public class StringRotatorInputModel
    {
        [Required]
        [MaxLength(50)]
        public string StringRotatorInput { get; set; } = "MyString";
        
        [Range(0, 100)]
        public  int StringRotatorIterations { get; set; } = 2;
    }
}
