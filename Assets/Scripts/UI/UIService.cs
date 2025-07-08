using TMPro;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIService : MonoBehaviour
    {
        [Header("Resource")]
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private TextMeshProUGUI gemsText;

        public void UpdateGoldUI(int value) => goldText.SetText(value.ToString()); 

        public void UpdateGemsUI(int value) => gemsText.SetText(value.ToString());
    }
}