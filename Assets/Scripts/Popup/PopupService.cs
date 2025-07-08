using ChestSystem.Chest;
using ChestSystem.Main;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Popup
{
    public class PopupService
    {
        private GameObject slotFullPopup;
        private GameObject unableToUnlockPopup;
        private ChestPopupController chestPopup;
        private Button addChestButton;

        private TextMeshProUGUI textPopup;

        private float errorPopupDuration = 1.5f;

        public PopupService(TextMeshProUGUI textPopup, ChestPopupController chestPopup, Button addChestButton,Transform parentCanvas)
        {
            CreatePopups(textPopup, chestPopup, addChestButton, parentCanvas);
            SubscribeToEvents();
        }

        ~PopupService()
        {
            UnsubscribeToEvents();
        }

        private void CreatePopups(TextMeshProUGUI textPopup, ChestPopupController chestPopup, Button addChestButton,Transform parentCanvas)
        {
            this.addChestButton = GameObject.Instantiate<Button>(addChestButton, parentCanvas);
            this.textPopup = GameObject.Instantiate<TextMeshProUGUI>(textPopup, parentCanvas);
            this.chestPopup = GameObject.Instantiate<ChestPopupController>(chestPopup, parentCanvas);
        }

        private void SubscribeToEvents()
        {
            addChestButton.onClick.AddListener(GameService.Instance.ChestService.TryAddChest);
        }

        private void UnsubscribeToEvents()
        {
            addChestButton.onClick.RemoveListener(GameService.Instance.ChestService.TryAddChest);
        }

        public void ShowTextPopup(string message)
        {
            textPopup.text = message;
            ShowTextPopupAsync(textPopup.gameObject);
        }

        private async void ShowTextPopupAsync(GameObject popup)
        {
            popup.SetActive(true);
            await Task.Delay(TimeSpan.FromSeconds(errorPopupDuration));

            if (popup != null)
                popup.SetActive(false);
        }

        public void ShowChestPopup(ChestController chestController)
        {
            chestPopup.gameObject.SetActive(true);
            chestPopup.SetView(chestController); 
        }
    }
}