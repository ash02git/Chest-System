using ChestSystem.Chest;
using ChestSystem.Popup;
using ChestSystem.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("Views/Prefabs")]
        [SerializeField] private ChestView chestView;
        [SerializeField] private GameObject chestSlotView;
        [SerializeField] private AddChestButton addChestButton;
        [SerializeField] private GameObject errorTextPopup;
        [SerializeField] private ChestPopupController chestPopup;

        [Header("Scene References")]
        [SerializeField] private Transform chestSystemParent;
        [SerializeField] private Transform parentCanvas;

        [Header("ScriptableObjects")]
        [SerializeField] private List<ChestScriptableObject> chestScriptableObjects;

        //Services
        public ChestService ChestService { get; private set; }
        public PopupService PopupService { get; private set; }

        private void Start() => CreateServices();

        private void CreateServices()
        {
            ChestService = new ChestService(chestSlotView, chestSystemParent, chestView, chestScriptableObjects);
            PopupService = new PopupService(errorTextPopup, chestPopup, addChestButton, parentCanvas);
        }
    }
}