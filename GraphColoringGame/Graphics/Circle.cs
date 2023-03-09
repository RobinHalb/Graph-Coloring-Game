using System.Drawing;
using System.Drawing.Drawing2D;


namespace GraphColoringGame 
{
    public class Circle 
    {
        // currently looking at TableLayoutPanel or datagridView
        
        // Draw circle in a cell..
        public System.Drawing.Color fillColor { get; set; } // Color to fill/ color the vertex
        public int diameter { get; set; }
        public bool selected { get; set; } // Is this circle/ vertex selected?
        public bool confirmed { get; set; }
        public System.Drawing.Color selectedBorderColor { get; set; } // Highlight circle when selected
        public Point centerCoords { get; set; } // coords
        private int borderWidth = 2;
        public System.Drawing.Color normalBorderColor { get; set; }
        //public Rectangle circleBounds { get { return new Rectangle(centerCoords, new Size(diameter, diameter)); } }
        
        
        /*METHODS */
        // draw
        /*
        public void draw(Graphics g) 
        {
            new Rectangle(centerCoords, );
            //drawOutline(g);
            
        }
        */
        /*
        
        // DRAW CONNECT LINES - use e.g. RectOne.Right RectTwo.Left
        public void drawConnectLine(Graphics g, int rectOne, int RectTwo) 
        {

            using (var pen = new Pen(System.Drawing.Color.Black, 3)) 
            {
               
            }
                
              
            
        */
        //}

   
        // this might be slightly wrong
        // tests (hopefully) if the circle is selected
       /* public bool isSelected() 
        {
            using (var path = new GraphicsPath()) {
                // add ellipse to the grahicspath
                path.AddEllipse(circleBounds);
                selected = path.IsVisible(centerCoords);
            }
            return selected;
        }
       */
       /*
        // should be called only if selected and after the confirmation/ ok button,box
        private void colorVertex(Graphics g) 
        {
            if (confirmed)
            {
                using (var brushColor = new SolidBrush(
                    selected ? fillColor : throw new System.Exception("No color selected")))
                    g.FillEllipse(brushColor, circleBounds);
            }

        }

        private void drawOutline(Graphics g) 
        {
            using (var pen = new Pen(
                selected ? selectedBorderColor : normalBorderColor, borderWidth))
                g.DrawEllipse(pen, circleBounds);
        }


        */


    }


}