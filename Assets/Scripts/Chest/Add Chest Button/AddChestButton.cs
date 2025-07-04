using ChestSystem.Main;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Popup
{
    public class AddChestButton : MonoBehaviour
    {
        [SerializeField] private Button addChestButton;

        private void Start() => addChestButton.onClick.AddListener(GameService.Instance.ChestService.TryAddChest);

        private void OnDestroy() => addChestButton.onClick.RemoveListener(GameService.Instance.ChestService.TryAddChest);
    }
}