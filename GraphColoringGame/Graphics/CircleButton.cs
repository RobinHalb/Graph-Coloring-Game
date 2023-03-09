using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace GraphColoringGame.Graphics
{
    public class VertexButton : Button
    {
        public Color color = Color.None;
        public int borderSize = 4;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Draw button
            var graphics = e.Graphics;
            var graphicsPath = new GraphicsPath();
            var diameter = Math.Min(ClientSize.Width, ClientSize.Height) - borderSize * 2;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphicsPath.AddEllipse(0, 0, diameter, diameter);
            this.Region = new Region(graphicsPath);
            base.OnPaint(e);

            // Base
            System.Drawing.Color c;
            if (color == Color.None) c = System.Drawing.Color.White;
            else c = System.Drawing.Color.Red;
            Brush b = new SolidBrush(c);
            graphics.FillEllipse(b, 0, 0, diameter, diameter);

            // Border
            Pen p = new Pen(System.Drawing.Color.Black);
            p.Width = borderSize;
            graphics.DrawEllipse(p, 0, 0, diameter, diameter);

            this.Text = "";
            b.Dispose();

            // Add event - NOT SUPPOSED TO BE HERE
            this.Click += (sender, ev) => {
                color = Color.Red;
            };
        }
    }
}
