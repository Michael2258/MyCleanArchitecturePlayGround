namespace MyCleanArchitecturePlayGround.Domain.Shipments
{
    public class Shipment
    {
        public Guid ShipmentId { get; set; }
        private readonly SortedList<int, Stop> _stops = new();

        private Shipment(IReadOnlyList<Stop> stops)
        {
            for (var x = 0; x < stops.Count; x++)
            {
                _stops.Add(x, stops[x]);
            }
        }

        public static Shipment Create(PickupStop pickup, DeliveryStop delivery)
        {
            return new Shipment(new Stop[] { pickup, delivery });
        }

        public static Shipment Create(Stop[] stops)
        {
            if (stops.Length < 2)
            {
                throw new InvalidOperationException("Shipment requires at least 2 stops.");
            }

            if (stops.First() is not PickupStop)
            {
                throw new InvalidOperationException("First stop must be a Pickup");
            }

            if (stops.Last() is not DeliveryStop)
            {
                throw new InvalidOperationException("first stop must be a Pickup");
            }

            return new Shipment(stops);
        }

        public void Arrive(int stopId, DateTime arrived)
        {
            var currentStop = _stops.SingleOrDefault(x => x.Value.StopId == stopId);
            if (currentStop.Value == null)
            {
                throw new InvalidOperationException("Stop does not exist.");
            }

            var previousStopsAreNotDeparted = _stops.Any(x => x.Key < currentStop.Key && x.Value.Status != StopStatus.Departed);
            if (previousStopsAreNotDeparted)
            {
                throw new InvalidOperationException("Previous stops have not departed.");
            }

            currentStop.Value.Arrive(arrived);
        }

        public void Deliver(int stopId, DateTime departed)
        {
            var currentStop = _stops.SingleOrDefault(x => x.Value.StopId == stopId);
            if (currentStop.Value == null)
            {
                throw new InvalidOperationException("Stop does not exist.");
            }

            if (currentStop.Value is not DeliveryStop)
            {
                throw new InvalidOperationException("Stop is not a delivery.");
            }

            if (currentStop.Value.Status != StopStatus.Arrived)
            {
                Arrive(stopId, departed);
            }

            currentStop.Value.Depart(departed);
        }
    }
}