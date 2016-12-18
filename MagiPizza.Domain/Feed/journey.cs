using System;

namespace MagiPizza.Domain.Feed
{
    public class journey
    {
        int journeyId;// 	 	 	
        int vehicle_id;
        DateTime journey_date;
        int journey_capacity;
        DateTime journey_finishTime;
        DateTime journey_startTime;

        public journey()
        {
            this.journey_capacity = -1;
            this.journeyId = -1;
            this.journey_startTime = new DateTime();
            this.journey_finishTime = new DateTime();
            this.vehicle_id = -1;
            this.journey_date = new DateTime();
        }

        public DateTime Journey_startTime
        {
            get { return journey_startTime; }
            set { journey_startTime = value; }
        }

        public DateTime Journey_finishTime
        {
            get { return journey_finishTime; }
            set { journey_finishTime = value; }
        }

        public int Journey_capacity
        {
            get { return journey_capacity; }
            set { journey_capacity = value; }
        }

        public DateTime Journey_date
        {
            get { return journey_date; }
            set { journey_date = value; }
        }
        public int Vehicle_id
        {
            get { return vehicle_id; }
            set { vehicle_id = value; }
        } 	

        public int JourneyId
        {
            get { return journeyId; }
            set { journeyId = value; }
        }
    }
}