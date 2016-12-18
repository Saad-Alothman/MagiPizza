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

        public void Add(DiGraphVertix diGraphVertix)
        {
            diGraphVertixes.Add(diGraphVertix);
        }

        public List<DiGraphVertix>  diGraphVertixes = new List<DiGraphVertix>();
     public   List<DiGraphEdge> diGraphEdges = new List<DiGraphEdge>();

        public void AddEdge(int fromVertixId, int toVertixId)
        {
            diGraphEdges.Add(new DiGraphEdge(fromVertixId,toVertixId));        }
    }
    public class DiGraphVertix
    {
        public DiGraphVertix(int id, int x, int y, VertixType vertixType, int size=1):this(id,x,y)
        {
            this.VertixType = vertixType;
        }


        public DiGraphVertix(int id, int x, int y)
        {
            this.Id = id;
            this.Label = id.ToString();
            this.X = x;
            this.Y  = y;

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

        public int SourceNodeId { get; set; }
        public int DstinationNodeId { get; set; }
    }
    public enum VertixType
    {
        Client,
        Branch
    }
}
