using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
// this file is originaly found as a tutorial on Code Guru.com
// http://www.codeguru.com/csharp/csharp/cs_graphics/chartsandgraphing/print.php/c6145
namespace PerformanceMonitor
{
    class PieChart
    {
        public List<string[]> branchAndColor;
        public Bitmap Draw(Color bgColor, int width, int height,
           List<DFBranch> branchesInfo)
  {

    // Create a new image and erase the background
    Bitmap bitmap = new Bitmap(width,height,
                               PixelFormat.Format32bppArgb);
    Graphics graphics = Graphics.FromImage(bitmap);
    SolidBrush brush = new SolidBrush(bgColor);
    graphics.FillRectangle(brush, 0, 0, width, height);
    brush.Dispose();
    branchAndColor = new List<string[]>();
    // Create brushes for coloring the pie chart
    SolidBrush[] brushes = new SolidBrush[10];
    brushes[0] = new SolidBrush(Color.Yellow);
    brushes[1] = new SolidBrush(Color.Green);
    brushes[2] = new SolidBrush(Color.Blue);
    brushes[3] = new SolidBrush(Color.Cyan);
    brushes[4] = new SolidBrush(Color.Magenta);
    brushes[5] = new SolidBrush(Color.Red);
    brushes[6] = new SolidBrush(Color.Black);
    brushes[7] = new SolidBrush(Color.Gray);
    brushes[8] = new SolidBrush(Color.Maroon);
    brushes[9] = new SolidBrush(Color.LightBlue);

    // Sum the inputs to get the total
    decimal total = 0.0m;
    foreach( DFBranch b in branchesInfo )
      total += (decimal)b.QueueTime;
    string[] pair ;
    // Draw the pie chart
    float start = 0.0f;
    float end = 0.0f;
    decimal current = 0.0m;
    for (int i = 0; i < branchesInfo.Count; i++)
    {
        current += (decimal)branchesInfo[i].QueueTime;
      start = end;
      end = (float) (current / total) * 360.0f;
      graphics.FillPie(brushes[i % 10], 0.0f, 0.0f, width,
                       height, start, end - start);
        pair=new string [2];
      pair[0] = branchesInfo[i].Branch_id.ToString();
      pair[1] = brushes[i % 10].Color.Name;

      branchAndColor.Add(pair);
    }

    // Clean up the brush resources
    foreach( SolidBrush cleanBrush in brushes )
      cleanBrush.Dispose();

    return bitmap;
    }
  }
}


