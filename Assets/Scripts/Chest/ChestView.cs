using ChestSystem.Main;
using ChestSystem.StateMachine;
using System.Collections;
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

        private Coroutine timerCoroutine;

        private void Start() => chestButton.onClick.AddListener(OnChestClicked);

        public void SetController(ChestController controller) => this.controller = controller;

        private void OnChestClicked()
        {
            Debug.Log("Clicked a chest");
            switch(controller.GetChestState())
            {
                case ChestStates.Unlocking:
                case ChestStates.Locked:
                    if (!GameService.Instance.ChestService.CheckAnyChestIsUnlocking(controller))
                        GameService.Instance.PopupService.ShowChestPopup(controller);
                    else
                        GameService.Instance.PopupService.ShowTextPopup("Unable To Unlock!!");
                    break;

                case ChestStates.Unlocked:
                    controller.SetState(ChestStates.Collected);
                    break;
            }
        }

        public void InitializeChestView(Sprite icon, int timeLeft) //timeLeft is in seconds
        {
            chestImage.sprite = icon;

            SetTimeText(timeLeft);
        }

        private void SetTimeText(int seconds)
        {
            //logic assuming that all chests have either unlock time values as "x" hours or "x" minutes. (Not a value like 2H 30mins)
            if (seconds / 3600 < 1)
                timeText.text = (seconds / 60).ToString() + "mins";
            else
            {
                timeText.text = (seconds / 3600).ToString() + "H";
            }
        }

        private IEnumerator TimerCoroutine(int seconds)
        {
            Debug.Log("Started unlocking timer countdown");
            
            while(seconds >= 0)
            {
                yield return new WaitForSeconds(1.0f);
                seconds--;
                SetTimerText(seconds);
                controller.UpdateTimeLeft();
            }

            controller.SetState(ChestStates.Unlocked);

            timerCoroutine = null;
        }

        private void SetTimerText(int seconds)
        {
            int hrs = seconds / 3600;
            int mins = (seconds % 3600) / 60;
            int secs = seconds % 60;

            string text = "";
            if( hrs >= 1)
                text += hrs + "h ";

            if (mins >= 1)
                text += mins + "min ";

            if (secs >= 1)
                text += secs + "s";

            timerText.text = text;
        }

        public void StopTimer()
        {
            if(timerCoroutine != null)
                StopCoroutine(timerCoroutine);

            timerCoroutine=null;
        }

        private void OnStateChanged(ChestStates newState) => stateText.text = newState.ToString(); //later add this to an event

        public void ShowStateComponents(ChestStates state)
        {
            switch(state)
            {
                case ChestStates.Locked:
                    //stateText.gameObject.SetActive(true);//later, stateText will always be on
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
                    //stateText.gameObject.SetActive(false);//later, stateText will always be on
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

        public void StartTimer(int seconds) => timerCoroutine = StartCoroutine(TimerCoroutine(seconds));
    }
}