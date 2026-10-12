using System.Drawing.Drawing2D;

namespace Lab08_Simplepaint
{
    public enum DrawMode { Pen, Line, Rectangle, Ellipse }

    /// <summary>Một đối tượng đã vẽ (dữ liệu gốc, dùng để vẽ lại trong Paint).</summary>
    public class DrawItem
    {
        public DrawMode Mode { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; } = 1;
        public bool Fill { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public List<Point> Points { get; } = new List<Point>();   // dùng cho Pen

        /// <summary>Chuẩn hóa hình chữ nhật để kéo chuột theo mọi hướng đều đúng.</summary>
        public static Rectangle GetRectangle(Point a, Point b)
        {
            int x = Math.Min(a.X, b.X);
            int y = Math.Min(a.Y, b.Y);
            int w = Math.Abs(a.X - b.X);
            int h = Math.Abs(a.Y - b.Y);
            return new Rectangle(x, y, w, h);
        }

        public void Draw(Graphics g)
        {
            using (var pen = new Pen(Color, Width))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                switch (Mode)
                {
                    case DrawMode.Pen:
                        if (Points.Count >= 2)
                            g.DrawLines(pen, Points.ToArray());
                        else if (Points.Count == 1)       // chỉ chấm một điểm
                            g.DrawLine(pen, Points[0], Points[0]);
                        break;

                    case DrawMode.Line:
                        g.DrawLine(pen, Start, End);
                        break;

                    case DrawMode.Rectangle:
                        {
                            Rectangle r = GetRectangle(Start, End);
                            if (Fill)
                            {
                                using (var br = new SolidBrush(Color))
                                    g.FillRectangle(br, r);
                            }
                            else
                            {
                                g.DrawRectangle(pen, r);
                            }
                            break;
                        }

                    case DrawMode.Ellipse:
                        {
                            Rectangle r = GetRectangle(Start, End);
                            if (Fill)
                            {
                                using (var br = new SolidBrush(Color))
                                    g.FillEllipse(br, r);
                            }
                            else
                            {
                                g.DrawEllipse(pen, r);
                            }
                            break;
                        }
                }
            }
        }
    }
}
