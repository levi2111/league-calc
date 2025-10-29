using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL.Services;
using Core.Models;
using Core.Interfaces;

namespace UI.Pages
{
    public class TestModel : PageModel
    {
        public BaseChampion? Samira;
        private readonly IReadOnlyChampionRepository? _testRepository;

        public TestModel(IReadOnlyChampionRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task OnGetAsync()
        {
            Samira = await _testRepository.GetByName("Samira");
        }
    }
}
