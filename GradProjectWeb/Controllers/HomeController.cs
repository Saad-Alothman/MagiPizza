using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WindowsFormsApplication4;
using GradProjectWeb.Models;
using MagiPizza.Domain;
using MagiPizza.Domain.Feed;
using MagiPizza.Domain.Models;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace GradProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Poc()
        {

            ViewBag.Message = "Your contact page.";
            PocViewModel pocViewModel = new PocViewModel();
            pocViewModel.SetDefaultValues();
            return View();
        }
        [HttpPost]
        public ActionResult Poc(PocViewModel pocViewModel)
        {
            

            PocResultsViewModel pocResultsViewModel = RunPoc(pocViewModel);
            ViewData["pocResultsViewModel"] = pocResultsViewModel;
            string serialized = JsonConvert.SerializeObject(pocResultsViewModel);

            return View(pocViewModel);
        }
        
        public ActionResult PocRun()
        {
            PocViewModel pocViewModel = new PocViewModel();
            pocViewModel.SetDefaultValues();
            PocResultsViewModel pocResultsViewModel = RunPoc(pocViewModel);
            string serialized = JsonConvert.SerializeObject(pocResultsViewModel);
            ViewData["pocResultsViewModel"] = pocResultsViewModel;
            return View("Poc",pocViewModel);
        }
        public ActionResult PocRunReady()
        {
            string serialized =System.IO.File.ReadAllText(Server.MapPath("~/Content/pocReadyJSON.txt"));
            PocViewModel pocViewModel = new PocViewModel();
            pocViewModel.SetDefaultValues();
            PocResultsViewModel pocResultsViewModel = (PocResultsViewModel) JsonConvert.DeserializeObject<PocResultsViewModel>(serialized);
            ViewData["pocResultsViewModel"] = pocResultsViewModel;
            return View("Poc", pocViewModel);
        }
        private PocResultsViewModel RunPoc(PocViewModel pocViewModel)
        {
            DataFeed df = new DataFeed();

            df.clearDB();
            df.MinX = 0;
            df.MinY = 0;
            df.MaxY = 1000;
            df.MaxX = 1000;
            //if it is not the first time to test this will cause a problem if not cleared
            df.ClearLists();
            CreateAndInsertRandomData(pocViewModel, df);
            //step3 clear the branches and customers then read them from the DB
            df.dbBranches.Clear();
            df.customersR.Clear();
            //step4 read the customers and the branches
            df.readBranches();
            df.readCustomers();
            df.readProducts();
            // create random vehicles for branches
            df.randomVehiclesForBranches((int) pocViewModel.NumberOfVehiclesPerBranch.Min,
                (int) pocViewModel.NumberOfVehiclesPerBranch.Max, (int) pocViewModel.CapacityOfEachVehicle.Min,
                (int) pocViewModel.CapacityOfEachVehicle.Max);
            df.insertRandomVehicles();
            df.dbVehicles.Clear();
            df.readRandomVehicles();
            // create random staff for branches
            df.randomStaffForBranches((int) pocViewModel.NumberOfStaffPerBranch.Min, pocViewModel.NumberOfStaffPerBranch.Max);
            df.insertRandomStaff();
            df.dbStaff.Clear();

            //read the branches again to get number of staff and vehicles updated;
            df.dbBranches.Clear();
            df.readBranches();
            // create Random Stock Levels
            df.randomStockLevels(pocViewModel.StockLevelsPerBranch.Min, pocViewModel.StockLevelsPerBranch.Max);
            //step5 place orders for the customers
            df.create_orders_for_the_customers();
            //
            //call serve orders eithe with a timer or without
            df.TimedServiceDelay = (int) pocViewModel.DelayTime;
            df.maxjourneyDestinationTimeM = (int) pocViewModel.MaxJourneyDestinationTimeMinutes;
            df.serveOrders();
            //df.readPostCodes();
            var piechart = drawPieChart(df);
            
            Bitmap image = plotPoints(df, df.dbBranches, df.customersR, df.queueOfOrders.ToList());
            DiGraph diGraph = GetGraph(df, df.dbBranches, df.customersR, df.queueOfOrders.ToList());
            string statText = GetStatText(df, pocViewModel);
            PocResultsViewModel pocResultsViewModel = new PocResultsViewModel(piechart, diGraph, statText, image);
            return pocResultsViewModel;
        }

        private static void CreateAndInsertRandomData(PocViewModel pocViewModel, DataFeed df)
        {
//step2 create random store branches
            df.randomBranches((int) pocViewModel.NumberOfBranches);
            df.insertRandomBranches();
            //step1 creat random customers
            df.RandomCustomers(pocViewModel.NumberOfCustomers, pocViewModel.MakeCustomersAroundOneBranch);
            df.insertCustomersR();
        }


        public Bitmap drawPieChart(DataFeed df)
        {
          //  listBox1.Items.Clear();
            List<decimal> qTimes = new List<decimal>();
            List<DFBranch> branchesInfo = new List<DFBranch>();
            DFBranch temp;
            int branchDbIndex;
            foreach (Branch b in df.dbBranches)
            {
                branchDbIndex = df.getbranchIndex(b.Branch_id);
                temp = new DFBranch();
                temp.Branch_id = b.Branch_id;
                temp.QueueTime = df.getBranchQueueTime(df.getOrdersBeingServedBy(b.Branch_id), branchDbIndex);
                branchesInfo.Add(temp);
            }

            
            Color white = new Color();
            PieChart pchart = new PieChart();
            Bitmap pic = pchart.Draw(white, 100, 100, branchesInfo);

            return pic;
        }
        public Bitmap plotPoints(DataFeed df, List<Branch> branches, List<CustomerR> customersR, List<DFOrder> orders)
        {

            // just make the window big enough to fit this graph...

            // add 5 so the bars fit properly
            int x = 5; // the position of the X axis
            int y = 5; // the position of the Y axis
            int graphicWidth=1000;
            int graphicHeight= 1000;
            Bitmap bmp = new Bitmap(graphicWidth, graphicHeight);
            Graphics graphics = Graphics.FromImage(bmp);
            Point xAxispoint1=new Point(x, graphicHeight- y);
            Point xAxispoint2=new Point(graphicWidth , graphicHeight - y);
            Point yAxispoint1 = new Point(x, y);
            Point yAxispoint2 = new Point(x, graphicHeight);
            graphics.DrawLine(new Pen(Color.Blue, 2), xAxispoint1,xAxispoint2);
            graphics.DrawLine(new Pen(Color.Yellow, 2), yAxispoint1, yAxispoint2);
            // let's draw a coordinate equivalent to (20,30) (20 up, 30 across)
            df.readDBOrders();
            foreach (var c in customersR)
            {
                int cx = y + c.XCoordinate;
                int cy = x - c.YCoordinate;
                graphics.DrawString("o", new Font("Calibg.ri", 12), new SolidBrush(Color.Aqua), cx,cy);
                graphics.DrawString(c.Customer_id.ToString(), new Font("Calibg.ri", 7), new SolidBrush(Color.Aqua), cx , cy+5);

            }
            foreach (Branch b in branches)
            {
                int bx = y + int.Parse(b.Branch_postcode.Remove(df.MaxX.ToString().Length - 1));
                int by = x - int.Parse(b.Branch_postcode.Remove(0, df.MaxX.ToString().Length + 1));
                graphics.DrawString("o", new Font("Calibg.ri", 12), new SolidBrush(Color.Red), y +  bx, by);
                graphics.DrawString(b.Branch_id.ToString(), new Font("Calibg.ri", 5), new SolidBrush(Color.Red), 5 + bx, by);



                var ordersAssignedToBranch = df.getOrdersBeingServedBy(b.Branch_id);
                foreach (order o in df.dbOrders)
                {

                    var found = false;
                    for (int i = 0; i < ordersAssignedToBranch.Count; i++)
                    {
                        if (ordersAssignedToBranch[i] == o.Order_id)
                            found = true;
                    }
                    if (found)
                    {

                        var customerInd = df.getCustomerIndex(o.Customer_id);
                        var customerX = customersR[customerInd].XCoordinate;
                        var customerY = customersR[customerInd].YCoordinate;
                        int branchX = int.Parse(b.Branch_postcode.Remove(df.MaxX.ToString().Length - 1));
                        int branchY = int.Parse(b.Branch_postcode.Remove(0, df.MaxX.ToString().Length + 1));
                        /*
                         int bx = y + int.Parse(b.Branch_postcode.Remove(df.MaxX.ToString().Length - 1));
                int by = x - int.Parse(b.Branch_postcode.Remove(0, df.MaxX.ToString().Length + 1));
                         */
                        graphics.DrawLine(new Pen(Color.Green, 1), y + customerX * 10 + 10, x - customerY * 10 + 10, y + branchX * 10 + 10, x - branchY * 10 + 10);
                    }
                }

            }

            return bmp;

        }
        public DiGraph GetGraph(DataFeed df,List<Branch> branches, List<CustomerR> customersR, List<DFOrder> orders)
        {
            DiGraph diGraph = new DiGraph();
            df.readDBOrders();
            customersR.ForEach(c => diGraph.Add(new DiGraphNode(c.Customer_id, c.XCoordinate, c.YCoordinate, $"Cust:{c.Customer_id}", VertixType.Client)));

            foreach (Branch b in branches)
            {
                var ordersAssignedToBranchIds = df.getOrdersBeingServedBy(b.Branch_id);
                List<order> ordersAssignedToBranchList = df.dbOrders.Where(o => ordersAssignedToBranchIds.Contains(o.Order_id)).ToList();
                var x =Convert.ToInt32(b.Branch_postcode.Remove(df.MaxX.ToString().Length - 1)) ;
                var y = Convert.ToInt32(b.Branch_postcode.Remove(0, df.MaxX.ToString().Length + 1));
                
                diGraph.Add(new DiGraphNode(b.Branch_id, x, y, $"B{b.Branch_id}", VertixType.Branch, ordersAssignedToBranchList.Count));
                ordersAssignedToBranchList.ForEach(o=> diGraph.AddEdge(o.Customer_id, b.Branch_id));
            }

            diGraph.Validate();
            return diGraph;

        }
        private string GetStatText(DataFeed df,PocViewModel pocViewModel)
        {
            //get max orders in a branch and min

            List<int[]> orders = new List<int[]>();
            int[] orderandbId;
            List<int> orderlist;
            foreach (Branch b in df.dbBranches)
            {
                orderlist = new List<int>();
                orderlist = df.getOrdersBeingServedBy(b.Branch_id);
                orderandbId = new int[2];
                orderandbId[0] = b.Branch_id;
                orderandbId[1] = orderlist.Count;
                orders.Add(orderandbId);
            }
            int[] max = { orders[0][0], orders[0][1] };
            int[] min = { orders[0][0], orders[0][1] };

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i][1] > max[1])
                {
                    max[1] = orders[i][1];
                    max[0] = orders[i][0];
                }
                if (orders[i][1] < min[1])
                {
                    min[1] = orders[i][1];
                    min[0] = orders[i][0];
                }
            }

            List<object[]> journeysDest = new List<object[]>();
            journeysDest = df.getJourneys();
            int iTotalNumberOfJourneys = 0;
            int iLongestJourneyM = -1;
            int iShortestJourneyM = 99999;
            int iSumJourneyM = 0;
            int iAvgJourneyM = -1;
            int iSumJourneyDstnationsCount = 0;
            int iHighestJourneyDstnations = -1;
            int iLowestJourneyDstnations = 9999;
            int iAvgJourneyDstnations = -1;
            int iSumOfSurpassingDeliveryTimeDestinations = 0;
            //int iSumJourneyM = -1;
            foreach (var jrnyAndJd in journeysDest)
            {
                journey jnyt = (journey)jrnyAndJd[0];
                List<journeyDestinations> jnyDt = (List<journeyDestinations>)jrnyAndJd[1];

                if (jnyDt.Count > iHighestJourneyDstnations)
                    iHighestJourneyDstnations = jnyDt.Count;
                if (jnyDt.Count < iLowestJourneyDstnations)
                    iLowestJourneyDstnations = jnyDt.Count;
                iSumJourneyDstnationsCount += jnyDt.Count;
                foreach (var jd in jnyDt)
                {
                    if (pocViewModel.MaxJourneyDestinationTimeMinutes < jd.Duration_from_branch)
                        iSumOfSurpassingDeliveryTimeDestinations++;
                    iTotalNumberOfJourneys++;
                    iSumJourneyM += jd.Duration_from_branch;
                    if (jd.Duration_from_branch > iLongestJourneyM)
                        iLongestJourneyM = jd.Duration_from_branch;
                    if (jd.Duration_from_branch < iShortestJourneyM)
                        iShortestJourneyM = jd.Duration_from_branch;
                }

            }
            iAvgJourneyDstnations = iSumJourneyDstnationsCount / iTotalNumberOfJourneys;
            iAvgJourneyM = iSumJourneyM / iTotalNumberOfJourneys;
            string result = "number Of Orders :" + df.queueOfOrders.Count
                + "\t\n highest number oforders assigned to a branch: bId:" + max[0] + " #orders: "
                + max[1] + "\t\n lowest number of orders assigned to a branch: bId:" + min[0] + " #orders: "
                + min[1] + "\t\n average orders per branch: " + (df.queueOfOrders.Count / df.dbBranches.Count)
            + "n umber of orders surpassing the max delivery" + iSumOfSurpassingDeliveryTimeDestinations
            + "max journey" + iHighestJourneyDstnations
            + "min journey" + iLowestJourneyDstnations
            + "avg destinations per journey" + iAvgJourneyDstnations
            + "AVG journey time" + iAvgJourneyM;
            //get average
            return result;
        }

    }
}