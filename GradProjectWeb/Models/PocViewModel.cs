using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using MagiPizza.Domain.Feed;

namespace GradProjectWeb.Models
{
    public class CytoscapeElement
{
        public CytoscapeElement()
        {
            
        }
        public CytoscapeElement(DiGraphNode node)
        {
            this.Group = "nodes";
            this.Data = new
            {
                id = node.Id,
                Name=node.Label
            };
            this.Position = new {x=node.X,y=node.Y};
            this.Classes = node.VertixType == VertixType.Branch ? "branch-node":"client-node";

        }

        public object Position { get; set; }

        public object Data { get; set; }

        public string Group { get; set; }
        public string Classes { get; set; }

        public CytoscapeElement(DiGraphEdge edge)
        {

            this.Group = "edges";
            this.Data = new
            {
                id = edge.SourceNodeId+edge.DstinationNodeId,
                source = edge.SourceNodeId.ToString(),
                Target =edge.DstinationNodeId,
                Name= edge.SourceNodeId + edge.DstinationNodeId
            };
        }
    }
    public class PocResultsViewModel
    {
        public PocResultsViewModel(Bitmap piechart, DiGraph diGraph, string statText, Bitmap image)
        {
            this.PieChart = piechart;
            this.DiGraph =diGraph;
            this.StatText = statText;
            this.Image = image;
        }

        public Bitmap Image { get; set; }

        public string StatText { get; set; }
        public DiGraph DiGraph { get; set; }
        public Bitmap PieChart { get; set; }

        public List<CytoscapeElement> GetElements()
        {
            var list = DiGraph.DiGraphNodes.Select(e => new CytoscapeElement(e)).ToList();
            
            list.AddRange(DiGraph.diGraphEdges.Select(e => new CytoscapeElement(e)).ToList());
            return list;
        }
    }
    public class PocViewModel
    {
        public TestMode TestMode { get; set; }
        public bool MakeCustomersAroundOneBranch { get; set; }
        public int NumberOfCustomers { get; set; }
        public int NumberOfBranches { get; set; }
        public int DelayTime { get; set; }
        public MinMaxViewModel NumberOfVehiclesPerBranch { get; set; }
        public MinMaxViewModel CapacityOfEachVehicle { get; set; }
        public MinMaxViewModel NumberOfStaffPerBranch { get; set; }
        public MinMaxViewModel StockLevelsPerBranch { get; set; }
        public int MaxJourneyDestinationTimeMinutes { get; set; }

        public void SetDefaultValues()
        {
            this.TestMode = TestMode.RandomData;
            this.MakeCustomersAroundOneBranch = false;
            this.DelayTime= 1;
            this.NumberOfCustomers = 15;
            this.NumberOfBranches = 3;
            this.NumberOfVehiclesPerBranch = new MinMaxViewModel(3,5);
            this.CapacityOfEachVehicle= new MinMaxViewModel(30,50);
            this.NumberOfStaffPerBranch = new MinMaxViewModel(3,5);
            this.StockLevelsPerBranch = new MinMaxViewModel(500,700);
            this.MaxJourneyDestinationTimeMinutes = 45;
        }
    }

    public class MinMaxViewModel
    {
        public MinMaxViewModel()
        {
            
        }
        public MinMaxViewModel(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
        public int Min { get; set; }
        public int Max { get; set; }
    }
    public enum TestMode
    {
        RandomData=1,HardCoded=2
    }
}