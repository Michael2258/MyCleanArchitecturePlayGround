namespace MyCleanArchitecturePlayGround.Domain.Shipments
{
    public class DeliveryStop : Stop
    {
        public DeliveryStop(int stopId)
        {
            StopId = stopId;
        }
    }
}