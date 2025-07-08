using ChestSystem.Chest;
using ChestSystem.Events;
using ChestSystem.Popup;
using ChestSystem.Resources;
using ChestSystem.UI;
using ChestSystem.Utilities;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("Views/Prefabs")]
        [SerializeField] private ChestView chestView;
        [SerializeField] private GameObject chestSlotView;
        [SerializeField] private Button addChestButton;
        [SerializeField] private TextMeshProUGUI textPopup;
        [SerializeField] private ChestPopupController chestPopup;

        [Header("Scene References")]
        [SerializeField] private Transform chestSystemParent;
        [SerializeField] private Transform parentCanvas;

        [Header("ScriptableObjects")]
        [SerializeField] private List<ChestScriptableObject> chestScriptableObjects;

        [SerializeField] private int initialGold;
        [SerializeField] private int initialGems;

        //Services
        public ChestService ChestService { get; private set; }
        public PopupService PopupService { get; private set; }
        public EventService EventService { get; private set; }
        public PlayerResourcesService PlayerResourcesService { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;

        private void Start() => CreateServices();

        private void CreateServices()
        {
            EventService = new EventService();
            ChestService = new ChestService(chestSlotView, chestSystemParent, chestView, chestScriptableObjects);
            PopupService = new PopupService(textPopup, chestPopup, addChestButton, parentCanvas);
            PlayerResourcesService = new PlayerResourcesService(initialGold, initialGems);
        }
    }
}