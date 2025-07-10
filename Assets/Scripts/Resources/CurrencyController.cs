using ChestSystem.Main;

namespace ChestSystem.Resources
{
    public class CurrencyController
    {
        private int gold;
        private int gems;

        public CurrencyController(int initialGold, int initialGems)
        {
            gold = initialGold;
            gems = initialGems;
        }

        public void UpdateGold(int value)
        {
            gold += value;
            GameService.Instance.UIService.UpdateGoldUI(gold);
        }

        public void UpdateGems(int value)
        {
            gems += value;
            GameService.Instance.UIService.UpdateGemsUI(gems);
        }

        public bool AreGemsAvailable(int value) => gems >= value;
    }
}