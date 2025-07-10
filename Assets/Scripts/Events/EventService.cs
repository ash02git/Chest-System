using ChestSystem.Chest;

namespace ChestSystem.Events
{
    public class EventService
    {
        public EventController<ChestController> OnChestCollected;
        public EventController<int> OnGemsChanged;
        public EventController<int> OnGoldChanged;

        public EventService()
        {
            OnChestCollected = new EventController<ChestController>();
            OnGemsChanged = new EventController<int>();
            OnGoldChanged = new EventController<int>();
        }

        
    }
}