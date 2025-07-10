using ChestSystem.Main;

namespace ChestSystem.Resources
{
    public class ResourcesService
    {
        private CurrencyController currencyController;

        public ResourcesService(int initialGold, int initialGems)
        {
            currencyController = new CurrencyController(initialGold, initialGems);

            GameService.Instance.UIService.UpdateGemsUI(initialGems);
            GameService.Instance.UIService.UpdateGoldUI(initialGold);

            GameService.Instance.EventService.OnGemsChanged.AddListener(UpdateGems);
            GameService.Instance.EventService.OnGoldChanged.AddListener(UpdateGold);
        }

        public void UpdateGold(int value) => currencyController.UpdateGold(value);

        public void UpdateGems(int value) => currencyController.UpdateGems(value);

        public bool AreGemsAvailable(int value) => currencyController.AreGemsAvailable(value);
    }
}