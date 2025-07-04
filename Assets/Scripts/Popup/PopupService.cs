using ChestSystem.Chest;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace ChestSystem.Popup
{
    public class PopupService
    {
        private GameObject errorPopup;
        private ChestPopupController chestPopup;
        private AddChestButton addChestButton;

        private float errorPopupDuration = 1.5f;

        public PopupService(GameObject errorPopup, ChestPopupController chestPopup, AddChestButton addChestButton, Transform parentCanvas)
        {
            CreatePopups(errorPopup, chestPopup, addChestButton, parentCanvas);
        }

        private void CreatePopups(GameObject errorPopup, ChestPopupController chestPopup, AddChestButton addChestButton, Transform parentCanvas)
        {
            this.addChestButton = GameObject.Instantiate<AddChestButton>(addChestButton, parentCanvas);
            this.errorPopup = GameObject.Instantiate(errorPopup, parentCanvas);
            this.chestPopup = GameObject.Instantiate<ChestPopupController>(chestPopup, parentCanvas);
        }

        public void DisplayErrorText() => ShowErrorTextAsync();

        private async void ShowErrorTextAsync()
        {
            errorPopup.SetActive(true);
            await Task.Delay(TimeSpan.FromSeconds(errorPopupDuration));
            errorPopup.SetActive(false);
        }

        public void ShowChestPopup(int unlockTime)
        {
            chestPopup.gameObject.SetActive(true);
        }
    }
}