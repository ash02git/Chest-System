using ChestSystem.Commands;
using ChestSystem.Main;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Popup
{
    public class UndoPopupController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI undoText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;

        private int displayTime = 3;
        private Coroutine coroutine;

        private void Start()
        {
            yesButton.onClick.AddListener(OnYesButtonClicked);
            noButton.onClick.AddListener(OnNoButtonClicked);
        }

        private void OnNoButtonClicked()
        {
            if (coroutine != null) 
                StopCoroutine(coroutine);

            gameObject.SetActive(false);
        }

        private void OnYesButtonClicked() => GameService.Instance.CommandInvoker.Undo();

        public void UpdateDetails(int gemsRequired)
        {
            undoText.text = "Do you want to undo and get " + gemsRequired + " gems?";
            coroutine = StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            int i = 0;
            while(i <= displayTime)
            {
                timerText.text = (displayTime - i).ToString();
                yield return new WaitForSeconds(1.0f);
                i++;
            }
            coroutine = null;

            gameObject.SetActive(false);
        }
    }
}