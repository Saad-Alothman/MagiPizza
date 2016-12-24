using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagiPizza.Domain.Feed
{
    public class DiGraph
    {
        public DiGraph(int scale)
        {
            this.Scale = scale;
        }
        public DiGraph()
        {
            this.Scale = 1;
        }

        public int Scale { get; set; }

        public void Add(DiGraphNode diGraphNode)
        {
            DiGraphNodes.Add(diGraphNode);
        }

        public List<DiGraphNode>  DiGraphNodes = new List<DiGraphNode>();
     public   List<DiGraphEdge> diGraphEdges = new List<DiGraphEdge>();

        public void AddEdge(int fromVertixId, int toVertixId)
        {
            diGraphEdges.Add(new DiGraphEdge(fromVertixId,toVertixId));        }

        public void Validate()
        {
            
        }
    }
    public class DiGraphNode
    {
        public DiGraphNode(int id, int x, int y,string label, VertixType vertixType, int size=1)
        {
            this.VertixType = vertixType;
            this.Label = label;
            this.Id = id;
            this.X = x;
            this.Y = y;
        }



        public DiGraphNode()
        {
            
        }
        public VertixType VertixType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int Id { get; set; }
        public string Label { get; set; }
    }

    public class DiGraphEdge
    {
        public DiGraphEdge(int fromVertixId, int toNodeId)
        {
            this.SourceNodeId =fromVertixId;
            this.DstinationNodeId=toNodeId;
        }

        public DiGraphEdge()
        {
            
        }
        public int SourceNodeId { get; set; }
        public int DstinationNodeId { get; set; }
    }
    public enum VertixType
    {
        Client,
        Branch
    }
}
