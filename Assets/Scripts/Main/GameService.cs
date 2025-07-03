using ChestSystem.Chest;
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

        [Header("Scene References")]
        [SerializeField] private Transform chestSystemParent;

        [Header("ScriptableObjects")]
        [SerializeField] private List<ChestScriptableObject> chestScriptableObjects;

        //Services
        public ChestService chestService { get; private set; }

        private void Start() => CreateServices();

        private void CreateServices()
        {
            chestService = new ChestService(chestSlotView, chestSystemParent, chestView, chestScriptableObjects);
        }
    }
}