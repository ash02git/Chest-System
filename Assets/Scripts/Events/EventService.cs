namespace ChestSystem.Events
{
    public class EventService
    {
        public EventController OnChestAdded;
        public EventController<int, int> OnChestCollected;

        public EventService()
        {
            OnChestAdded = new EventController();
            OnChestCollected = new EventController<int, int>();
        }
    }
}