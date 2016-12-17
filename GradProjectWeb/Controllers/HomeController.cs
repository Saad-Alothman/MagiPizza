using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GradProjectWeb.Models;
using PerformanceMonitor;

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

            return View();
        }
        [HttpPost]
        public ActionResult Poc(PocViewModel pocViewModel)
        {
            DataFeed df = new DataFeed();
            //if it is not the first time to test this will cause a problem if not cleared
            df.dbBranches.Clear();
            df.customersR.Clear();

            //df.customers.Clear();
            df.dbVehicles.Clear();
            //step2 create random store branches
            df.randomBranches((int)pocViewModel.NumberOfBranches);
            df.insertRandomBranches();
            //step1 creat random customers
            if (cbCustomerIsClose.Checked)
                df.RandomCustomers((int)udNoCustomers.Value, true);
            else
                df.RandomCustomers((int)udNoCustomers.Value, false);
            df.insertCustomersR();

            //step3 clear the branches and customers then read them from the DB
            df.dbBranches.Clear();
            df.customersR.Clear();
            //            df.customers.Clear();
            //df.
            //step4 read the customers and the branches
            df.readBranches();
            df.readCustomers();
            df.readProducts();
            // create random vehicles for branches
            df.randomVehiclesForBranches((int)udNoVehiclesMin.Value, (int)udNoVehiclesMax.Value, (int)udVehiclesCapacityMin.Value, (int)udVehiclesCapacityMax.Value);
            df.insertRandomVehicles();
            df.dbVehicles.Clear();
            df.readRandomVehicles();
            // create random staff for branches
            df.randomStaffForBranches((int)udStaffMin.Value, (int)udStaffMax.Value);
            df.insertRandomStaff();
            df.dbStaff.Clear();

            //read the branches again to get number of staff and vehicles updated;
            df.dbBranches.Clear();
            df.readBranches();
            // create Random Stock Levels
            df.randomStockLevels((int)udStaffMin.Value, (int)udStockMax.Value);
            //step5 place orders for the customers
            df.create_orders_for_the_customers();
            //
            //call serve orders eithe with a timer or without
            df.TimedServiceDelay = (int)udDelay.Value;
            df.maxjourneyDestinationTimeM = (int)numericUpDown1.Value;
            df.serveOrders();
            //df.readPostCodes();
            drawPieChart();
            pictureBox2.Image = plotPoints(df.dbBranches, df.customersR, df.queueOfOrders.ToList());
            dispalyStat();
        
            return View();
        }

    }
}