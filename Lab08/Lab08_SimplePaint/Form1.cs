using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Lab08_Simplepaint
{
    public partial class Form1 : Form
    {
        // Danh sách dữ liệu gốc của các nét đã vẽ
        private readonly List<DrawItem> _items = new List<DrawItem>();
        private DrawItem? _current;              // nét đang kéo dở
        private bool _isDrawing;
        private Color _currentColor = Color.Black;
        private Image? _backgroundImage;         // ảnh nền (nâng cao)

        public Form1()
        {
            InitializeComponent();
            cboMode.SelectedIndex = 0;           // mặc định Pen
        }

        // ================= Chuột =================

        private void canvas_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (!Enum.TryParse(cboMode.SelectedItem?.ToString(), out DrawMode mode))
                mode = DrawMode.Pen;             // kiểm tra lỗi: mặc định Pen

            _current = new DrawItem
            {
                Mode = mode,
                Color = _currentColor,
                Width = (int)nudWidth.Value,
                Fill = chkFill.Checked,
                Start = e.Location,
                End = e.Location
            };
            _current.Points.Add(e.Location);

            _isDrawing = true;
            canvas.Capture = true;               // vẫn nhận chuột khi kéo ra ngoài canvas
        }

        private void canvas_MouseMove(object? sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X: {e.X}, Y: {e.Y}";

            if (!_isDrawing || _current == null) return;

            _current.End = e.Location;
            if (_current.Mode == DrawMode.Pen)
                _current.Points.Add(e.Location);

            canvas.Invalidate();                 // xem trước nét đang kéo
        }

        private void canvas_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!_isDrawing || _current == null) return;

            _current.End = e.Location;
            _items.Add(_current);                // lưu vào danh sách gốc
            _current = null;
            _isDrawing = false;
            canvas.Capture = false;

            canvas.Invalidate();
        }

        // ================= Paint =================

        private void canvas_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_backgroundImage != null)
                g.DrawImage(_backgroundImage, canvas.ClientRectangle);

            foreach (DrawItem item in _items)
                item.Draw(g);

            _current?.Draw(g);                   // nét đang kéo dở
        }

        // ================= Nút chức năng =================

        private void btnColor_Click(object? sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                dlg.Color = _currentColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _currentColor = dlg.Color;
                    btnColor.BackColor = _currentColor;
                    // chọn màu chữ tương phản để vẫn đọc được
                    btnColor.ForeColor = _currentColor.GetBrightness() > 0.5f ? Color.Black : Color.White;
                }
            }
        }

        private void btnUndo_Click(object? sender, EventArgs e)
        {
            if (_items.Count == 0) return;
            _items.RemoveAt(_items.Count - 1);
            canvas.Invalidate();
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            _items.Clear();
            canvas.Invalidate();
        }

        // ================= Nâng cao =================

        // Ctrl+Z để Undo
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                btnUndo.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        // Đổi màu nền canvas
        private void btnBackColor_Click(object? sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                dlg.Color = canvas.BackColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    canvas.BackColor = dlg.Color;
                    canvas.Invalidate();
                }
            }
        }

        // Mở ảnh nền để vẽ đè lên
        private void btnOpenImage_Click(object? sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files|*.png;*.jpg;*.jpeg;*.bmp|All files|*.*";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Đọc qua MemoryStream để không khóa file ảnh
                    using (var temp = Image.FromFile(ofd.FileName))
                    {
                        _backgroundImage?.Dispose();
                        _backgroundImage = new Bitmap(temp);
                    }
                    canvas.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không mở được ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Lưu canvas ra PNG (vẽ lại từ danh sách dữ liệu gốc)
        private void btnSave_Click(object? sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png";
                sfd.FileName = "paint.png";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    int w = Math.Max(1, canvas.ClientSize.Width);
                    int h = Math.Max(1, canvas.ClientSize.Height);

                    using (var bmp = new Bitmap(w, h))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(canvas.BackColor);
                        g.SmoothingMode = SmoothingMode.AntiAlias;

                        if (_backgroundImage != null)
                            g.DrawImage(_backgroundImage, new Rectangle(0, 0, w, h));

                        foreach (DrawItem item in _items)
                            item.Draw(g);

                        bmp.Save(sfd.FileName, ImageFormat.Png);
                    }

                    MessageBox.Show("Đã lưu ảnh.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _backgroundImage?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
