using ChestSystem.Chest;
using ChestSystem.Commands;
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
        [SerializeField] private UndoPopupController undoPopup;

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
        public ResourcesService PlayerResourcesService { get; private set; }

        public CommandInvoker CommandInvoker { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;

        private void Start() => CreateServices();

        private void CreateServices()
        {
            EventService = new EventService();
            ChestService = new ChestService(chestSlotView, chestSystemParent, chestView, chestScriptableObjects);
            PopupService = new PopupService(textPopup, chestPopup, undoPopup, addChestButton, parentCanvas);
            PlayerResourcesService = new ResourcesService(initialGold, initialGems);
            CommandInvoker = new CommandInvoker();
        }
    }
}