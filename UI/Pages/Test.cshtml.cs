using BLL.Services;
using BLL.Services.ChampionAbilityScripts;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Pages
{
    [IgnoreAntiforgeryToken]
    public class TestModel : PageModel
    {
        private ReadOnlyChampionService _championService;
        protected SamiraAbilities _samiraAbilities;
        private readonly IBaseChampionRepository? _testRepository;  

        public TestModel(IBaseChampionRepository testRepository)
        {
            _testRepository = testRepository;
            _championService = new ReadOnlyChampionService(testRepository);
            _samiraAbilities = new SamiraAbilities();
        }
        public async Task OnGetAsync()
        {
            var samiraBC = await _testRepository.GetByName("Samira");
            var samira = new Champion(samiraBC);
            var dummy = new Dummy();
            dummy.SetResistances(50);

            HttpContext.Session.SetObject("Samira", samira);
            HttpContext.Session.SetObject("Dummy", dummy);
        }

        public class Ability
        {
            public string Letter { get; set; }
        }

        public async Task<JsonResult> OnPostGetAbilityDamage()
        {
            using var reader = new StreamReader(Request.Body);
            var ability = await reader.ReadToEndAsync();
            var samira = HttpContext.Session.GetObject<Champion>("Samira");
            var dummy = HttpContext.Session.GetObject<Dummy>("Dummy");

            string? response;
            switch (ability)
            {
                case "Q":
                    response = _samiraAbilities.Q(samira, dummy, 1, false).ToString();
                    break;
                case "W":
                    response = _samiraAbilities.W(samira, dummy, 1).ToString();
                    break;
                case "E":
                    response = _samiraAbilities.E(samira, dummy, 1).ToString();
                    break;
                case "R":
                    response = _samiraAbilities.R(samira, dummy, 1).ToString();
                    break;
                default:
                    response = null;
                    break;
            }

            return new JsonResult(response);
        }
    }
}
