using ChestSystem.Main;
using ChestSystem.StateMachine;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        private ChestController controller;

        //Components
        [SerializeField] private Button chestButton;
        [SerializeField] private Image chestImage;

        //Locked State Components
        [SerializeField] private TextMeshProUGUI stateText;
        [SerializeField] private TextMeshProUGUI timeText;

        //Unlocking State Components
        [SerializeField] private GameObject timer;
        [SerializeField] private TextMeshProUGUI timerText;

        //Unlocked State Components
        [SerializeField] private TextMeshProUGUI openText;

        private void Start()
        {
            chestButton.onClick.AddListener(OnChestClicked);
        }

        public void SetController(ChestController controller) => this.controller = controller;

        private void OnChestClicked() //popup should be opened
        {
            GameService.Instance.PopupService.ShowChestPopup(controller.GetUnlockTime());
        }

        public void InitializeChestView(Sprite icon, float unlockTime)
        {
            chestImage.sprite = icon;

            if (unlockTime < 60.0f)
                timeText.text = unlockTime.ToString() + "Mins";
            else
            {
                int hours = (int)unlockTime / 60;
                timeText.text = hours.ToString() + "Hrs";
            }
        }

        private void Update() => controller?.UpdateEnemy();

        public void ShowStateComponents(ChestStates state)
        {
            switch(state)
            {
                case ChestStates.Locked:
                    stateText.gameObject.SetActive(true);
                    timeText.gameObject.SetActive(true);
                    break;
                case ChestStates.Unlocking:
                    timer.SetActive(true);
                    break;
                case ChestStates.Unlocked:
                    openText.gameObject.SetActive(true);
                    break;
            }
        }

        public void HideStateComponents(ChestStates state)
        {
            switch (state)
            {
                case ChestStates.Locked:
                    stateText.gameObject.SetActive(false);
                    timeText.gameObject.SetActive(false);
                    break;
                case ChestStates.Unlocking:
                    timer.SetActive(false);
                    break;
                case ChestStates.Unlocked:
                    openText.gameObject.SetActive(false);
                    break;
            }
        }
    }
}