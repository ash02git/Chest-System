using ChestSystem.Chest;

namespace ChestSystem.Events
{
    public class EventService
    {
        public EventController<ChestController> OnChestCollected;

        public EventService()
        {
            OnChestCollected = new EventController<ChestController>();
        }
    }
}