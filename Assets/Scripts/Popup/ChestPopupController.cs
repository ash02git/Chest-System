using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.StateMachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Popup
{
    public class ChestPopupController : MonoBehaviour
    {
        [SerializeField] private Button startTimerButton;
        [SerializeField] private Button openWithGemsButton;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI gemsText;

        private ChestController chestController;//reference to current ChestController

        private int gemsRequired;
        private int seconds;

        private Coroutine timerCoroutine;

        private void Start()
        {
            startTimerButton.onClick.AddListener(OnStartTimerClicked);
            openWithGemsButton.onClick.AddListener(OnUnlockWithGemsClicked);
        }

        public void SetView(ChestController chestController)
        {
            this.chestController = chestController;
            int seconds = chestController.GetTimeLeft();

            if (chestController.GetChestState() == ChestStates.Locked)
                startTimerButton.gameObject.SetActive(true);
            else
            {
                startTimerButton.gameObject.SetActive(false);
                timerCoroutine = StartCoroutine(TimerCoroutine(seconds));
            }

            SetTimerText(seconds);
            SetGemsTextView(seconds);
        }

        private void SetTimerText(int seconds)
        {
            int hrs = seconds / 3600;
            int mins = (seconds % 3600) / 60;
            int secs = seconds % 60;
            string text = "";

            text += (hrs < 10 ? "0" : "") + hrs + ":";
            text += (mins < 10 ? "0" : "") + mins + ":";
            text += (secs < 10 ? "0" : "") + secs;

            timerText.text = text;
        }

        private void SetGemsTextView(int seconds)
        {
            gemsRequired = (((seconds / 600) ) + ((seconds % 600) == 0 ? 0 : 1));
            gemsText.text = "Unlock with gems - " + gemsRequired;
        }

        private void OnStartTimerClicked() => GameService.Instance.ChestService.SetState(chestController, ChestStates.Unlocking);

        private IEnumerator TimerCoroutine(int seconds)
        {
            Debug.Log("Started unlocking timer countdown");
            timerText.text = (seconds / 3600) + ":" + (seconds % 3600 / 60) + ":" + (seconds % 3600 % 60);

            while (seconds >= 0)
            {
                yield return new WaitForSeconds(1.0f);
                seconds--;

                SetTimerText(seconds);
                SetGemsTextView(seconds);
            }
        }

        private void OnUnlockWithGemsClicked()
        {
            if (GameService.Instance.PlayerResourcesService.AreGemsAvailable(gemsRequired))
            {
                GameService.Instance.ChestService.SetState(chestController, ChestStates.Unlocked);
                GameService.Instance.PlayerResourcesService.UpdateGems(-gemsRequired);
            }
            else
                GameService.Instance.PopupService.ShowTextPopup("Not Enough Gems!!");
        }

        private void OnDisable() => StopCoroutine(timerCoroutine);

        private void OnDestroy()
        {
            startTimerButton.onClick.RemoveListener(OnStartTimerClicked);
            openWithGemsButton.onClick.RemoveListener(OnUnlockWithGemsClicked);
        }
    }
}