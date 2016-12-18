namespace MagiPizza.Domain.Feed
{
    public class journeyDestinations
    {
        int journeyId;        // 	 	 	 	 	 	
        int destinationId;
        string postcode;
        int destination_sequence;
        int order_id;
        int duration_from_last_stop;
        int duration_from_branch;
        public journeyDestinations()
        {
            this.journeyId = -1;
            this.postcode = "";
            this.order_id = -1;
            this.destination_sequence = -1;
            this.destinationId = -1;
            this.duration_from_branch = -1;
            this.duration_from_last_stop = -1;
        }

        public int Duration_from_branch
        {
            get { return duration_from_branch; }
            set { duration_from_branch = value; }
        }

        public int Duration_from_last_stop
        {
            get { return duration_from_last_stop; }
            set { duration_from_last_stop = value; }
        }

        public int Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        public int Destination_sequence
        {
            get { return destination_sequence; }
            set { destination_sequence = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }


        public int DestinationId
        {
            get { return destinationId; }
            set { destinationId = value; }
        }

        public int JourneyId
        {
            get { return journeyId; }
            set { journeyId = value; }
        }
    }
}