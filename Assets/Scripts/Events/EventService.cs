using ChestSystem.Chest;

namespace ChestSystem.Events
{
    public class EventService
    {
        //public EventController OnChestAdded;
        //public EventController<int, int> OnChestCollected;
        public EventController<ChestController> OnChestCollected;

        public EventController<int> OnGemsChanged;
        public EventController<int> OnGoldChanged;

        public EventService()
        {
            //OnChestAdded = new EventController();
            //OnChestCollected = new EventController<int, int>();
            OnGemsChanged = new EventController<int>();
            OnGoldChanged = new EventController<int>();
            OnChestCollected = new EventController<ChestController>();
        }
    }
}