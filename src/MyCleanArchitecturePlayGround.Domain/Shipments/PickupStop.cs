namespace MyCleanArchitecturePlayGround.Domain.Shipments
{
    public class PickupStop : Stop
    {
        public PickupStop(int stopId)
        {
            StopId = stopId;
        }
    }
}