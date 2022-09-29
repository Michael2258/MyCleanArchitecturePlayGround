namespace MyCleanArchitecturePlayGround.Domain.Shipments
{
    public abstract class Stop
    {
        public int StopId { get; protected set; }
        public StopStatus Status { get; private set; } = StopStatus.InTransit;
        public Address Address { get; protected set; }
        public DateTime Scheduled { get; protected set; }
        public DateTime Arrived { get; protected set; }
        public DateTime? Departed { get; protected set; }

        public void Arrive(DateTime arrived)
        {
            if (Status != StopStatus.InTransit)
            {
                throw new InvalidOperationException("Stop has already arrived.");
            }

            Status = StopStatus.Arrived;
            Arrived = arrived;
        }

        public void Depart(DateTime departed)
        {
            if (Status == StopStatus.Departed)
            {
                throw new InvalidOperationException("Stop has already departed.");
            }

            if (departed < Arrived)
            {
                throw new InvalidOperationException("Departed Date/Time cannot be before Arrived Date/Time.");
            }

            Status = StopStatus.Departed;
            Departed = departed;
        }
    }

    public enum StopType
    {
        Pickup,
        Delivery
    }

    public enum StopStatus
    {
        InTransit,
        Arrived,
        Departed
    }
}