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
        public CytoscapeElement(DiGraphVertix vertix)
        {
            this.Group = "nodes";
            this.Data = new {id = vertix.Id};
            this.Position = new {x=vertix.X,y=vertix.Y};
            this.Classes = vertix.VertixType == VertixType.Branch ? "branch-node":"client-node";

        }

        public object Position { get; set; }

        public object Data { get; set; }

        public string Group { get; set; }
        public string Classes { get; set; }

        public CytoscapeElement(DiGraphEdge edge)
        {

            this.Group = "edges";
            this.Data = new { id = edge.SourceNodeId+edge.DstinationNodeId,source= edge.SourceNodeId.ToString(),Target=edge.DstinationNodeId };
        }
    }
    public class PocResultsViewModel
    {
        public PocResultsViewModel(Bitmap piechart, DiGraph diGraph, string statText)
        {
            this.PieChart = piechart;
            this.DiGraph =diGraph;
            this.StatText = statText;
        }

        public string StatText { get; set; }
        public DiGraph DiGraph { get; set; }
        public Bitmap PieChart { get; set; }

        public List<CytoscapeElement> GetElements()
        {
            var list =DiGraph.diGraphEdges.Select(e => new CytoscapeElement(e)).ToList();
            list.AddRange(DiGraph.diGraphVertixes.Select(e => new CytoscapeElement(e)).ToList());
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
    }

    public class MinMaxViewModel
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
    public enum TestMode
    {
        RandomData=1,HardCoded=2
    }
}