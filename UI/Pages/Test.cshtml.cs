using BLL.Services;
using Core.Interfaces;
using Core.Models;
using Core.Models.Items;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UI.Pages
{
    [IgnoreAntiforgeryToken]
    public class TestModel : PageModel
    {
        private readonly BaseChampionService _baseChampionService;
        private readonly ConfigService _configService;
        protected readonly SamiraAbilitiesService _samiraAbilitieService;
        private readonly ItemService _itemService;

        private readonly string defaultSelectedChampion = "Samira";
        private readonly string defaultPatch = "25.14";

        public Config? Config { get; private set; }

        public TestModel(IBaseChampionRepository mockBaseChampionRepository,
                    IItemRepository mockItemRepository, IConfigRepository configRepository)
        {
            _baseChampionService = new BaseChampionService(mockBaseChampionRepository);
            _itemService = new ItemService(mockItemRepository);
            _configService = new ConfigService(configRepository, mockBaseChampionRepository, mockItemRepository);
            _samiraAbilitieService = new SamiraAbilitiesService();
        }
        public async Task OnGetAsync()
        {
            var samiraBC = await _baseChampionService.GetChampionByName("Samira");
            var samira = new Champion(samiraBC);
            samira.Q = _samiraAbilitieService.GetQ();
            samira.W = _samiraAbilitieService.GetW();
            samira.E = _samiraAbilitieService.GetE();
            samira.R = _samiraAbilitieService.GetR();
            var dummy = new Dummy();
            dummy.SetResistances(50);

            string? configID = HttpContext.Session.GetString("Config");
            if (!string.IsNullOrEmpty(configID))
            {
                samira = await _configService.GetChampionByID(configID);
                Config = await _configService.GetConfigByID(configID);
            }
            else
            {
                Config config = new();
                config.ChampionName = defaultSelectedChampion;
                config.Level = 1;
                await _configService.Add(config);
                HttpContext.Session.SetString("Config", config.ID);
            }
        }

        private async Task<Champion> GetSamira()
        {
            var samiraBC = await _baseChampionService.GetChampionByName("Samira");
            var samira = new Champion(samiraBC);
            samira.Q = _samiraAbilitieService.GetQ();
            samira.W = _samiraAbilitieService.GetW();
            samira.E = _samiraAbilitieService.GetE();
            samira.R = _samiraAbilitieService.GetR();
            samira.LevelUp();

            return samira;
        }

        private Dummy GetDummy()
        {
            var dummy = new Dummy();
            dummy.SetResistances(50);

            return dummy;
        }

        public class AbilityRequest
        {
            public string Ability { get; set; }
            public int Level { get; set; }
            /*public string? ChampionName { get; set; }
            public List<string>? ItemIDs { get; set; }*/
        }

        public async Task<JsonResult> OnPostGetAbilityDamage([FromBody]AbilityRequest request)
        {
            /*var samira = HttpContext.Session.GetObject<Champion>("Samira");
            var dummy = HttpContext.Session.GetObject<Dummy>("Dummy");*/

            var samira = await GetSamira();
            samira.Level = request.Level;
            var dummy = GetDummy();

            string? damage;
            switch (request.Ability)
            {
                case "Q":
                    damage = samira.Q.TestUse(samira, dummy).PostMitigationDamage.ToString();
                    break;
                case "W":
                    damage = samira.W.TestUse(samira, dummy).PostMitigationDamage.ToString();
                    break;
                case "E":
                    damage = samira.E.TestUse(samira, dummy).PostMitigationDamage.ToString();
                    break;
                case "R":
                    damage = samira.R.TestUse(samira, dummy).PostMitigationDamage.ToString();
                    break;
                default:
                    damage = null;
                    break;
            }

            return new JsonResult(new { damage });
        }
        public async Task<IActionResult> OnPostSaveConfigAsync([FromBody]Config config)
        {
            if (config == null) return BadRequest();

            string? storedConfigId = HttpContext.Session.GetString("Config");
            if (!string.IsNullOrEmpty(storedConfigId)) config.ID = storedConfigId;
            await _configService.UpdateOrCreateConfig(config);
            return new OkResult();
        }
    }
}
