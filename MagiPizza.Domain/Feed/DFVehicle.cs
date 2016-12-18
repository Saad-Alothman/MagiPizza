using System.Collections.Generic;
using MagiPizza.Domain.Models;

namespace MagiPizza.Domain.Feed
{
    public class DFVehicle : Vehicle
    {
        bool ifEmptyCanContainOrder;
        double distance_from_customer;
        bool canAddToCurrentJourney;
        bool hasJourney;
        journey lastJourney;
        List<journeyDestinations> jd;
        int timeToDeliver;
        bool isDirect;

        public bool IfEmptyCanContainOrder
        {
            get { return ifEmptyCanContainOrder; }
            set { ifEmptyCanContainOrder = value; }
        }   

        public bool CanAddToCurrentJourney
        {
            get { return canAddToCurrentJourney; }
            set { canAddToCurrentJourney = value; }
        }

        public bool IsDirect
        {
            get { return isDirect; }
            set { isDirect = value; }
        }

        public int TimeToDeliver
        {
            get { return timeToDeliver; }
            set { timeToDeliver = value; }
        }
        public double Distance_from_customer
        {
            get { return distance_from_customer; }
            set { distance_from_customer = value; }
        }

        public journey LastJourney
        {
            get { return lastJourney; }
            set { lastJourney = value; }
        }

        public List<journeyDestinations> Jd
        {
            get { return jd; }
            set { jd = value; }
        }

        public bool HasJourney
        {
            get { return hasJourney; }
            set { hasJourney = value; }
        }
        public DFVehicle()
        {
            this.ifEmptyCanContainOrder = false;
            this.canAddToCurrentJourney = false;
            this.hasJourney = false;
            this.lastJourney = new journey();
            this.jd = new List<journeyDestinations>();
        }
    }
}