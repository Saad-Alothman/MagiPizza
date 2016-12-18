namespace MagiPizza.Domain.Models
{
    public class order
    {
        public order()
        {
            this.customer_id = 0;
            this.order_id = 0;
            this.order_date = "";
            this.order_processing_FinishTime = "";
            this.order_processing_startTime = "";
            this.order_status = "";
            this.order_time = "";
            this.time_required = "";
            this.dispatch_time = "";
        }
        int order_id, customer_id;
        string order_date, order_status, dispatch_time,
            time_required, order_time, order_processing_startTime, order_processing_FinishTime;

        public string Order_processing_FinishTime
        {
            get { return order_processing_FinishTime; }
            set { order_processing_FinishTime = value; }
        }

        public string Order_processing_startTime
        {
            get { return order_processing_startTime; }
            set { order_processing_startTime = value; }
        }

        public string Order_time
        {
            get { return order_time; }
            set { order_time = value; }
        }

        public string Time_required
        {
            get { return time_required; }
            set { time_required = value; }
        }

        public string Dispatch_time
        {
            get { return dispatch_time; }
            set { dispatch_time = value; }
        }

        public string Order_status
        {
            get { return order_status; }
            set { order_status = value; }
        }

        public string Order_date
        {
            get { return order_date; }
            set { order_date = value; }
        }

        public int Customer_id
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

        public int Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }
    }
}