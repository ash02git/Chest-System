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
        [SerializeField] private TextMeshProUGUI chestState;
        [SerializeField] private TextMeshProUGUI timeText;

        public void SetController(ChestController controller)
        {
            this.controller = controller;
        }
    }
}