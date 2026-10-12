namespace Lab08_Simplepaint
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            cboMode = new ComboBox();
            lblWidth = new Label();
            nudWidth = new NumericUpDown();
            btnColor = new Button();
            btnUndo = new Button();
            btnClear = new Button();
            chkFill = new CheckBox();
            btnBackColor = new Button();
            btnOpenImage = new Button();
            btnSave = new Button();
            lblStatus = new Label();
            canvas = new DoubleBufferedPanel();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudWidth).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.SteelBlue;
            pnlTop.Controls.Add(cboMode);
            pnlTop.Controls.Add(lblWidth);
            pnlTop.Controls.Add(nudWidth);
            pnlTop.Controls.Add(btnColor);
            pnlTop.Controls.Add(btnUndo);
            pnlTop.Controls.Add(btnClear);
            pnlTop.Controls.Add(chkFill);
            pnlTop.Controls.Add(btnBackColor);
            pnlTop.Controls.Add(btnOpenImage);
            pnlTop.Controls.Add(btnSave);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(4, 4, 4, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1125, 47);
            pnlTop.TabIndex = 0;
            // 
            // cboMode
            // 
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FormattingEnabled = true;
            cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
            cboMode.Location = new Point(14, 11);
            cboMode.Margin = new Padding(4, 4, 4, 4);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(123, 27);
            cboMode.TabIndex = 0;
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWidth.ForeColor = SystemColors.ButtonFace;
            lblWidth.Location = new Point(153, 15);
            lblWidth.Margin = new Padding(4, 0, 4, 0);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new Size(65, 19);
            lblWidth.TabIndex = 1;
            lblWidth.Text = "Độ dày:";
            // 
            // nudWidth
            // 
            nudWidth.Location = new Point(225, 11);
            nudWidth.Margin = new Padding(4, 4, 4, 4);
            nudWidth.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudWidth.Name = "nudWidth";
            nudWidth.Size = new Size(62, 27);
            nudWidth.TabIndex = 2;
            nudWidth.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.Black;
            btnColor.ForeColor = Color.RosyBrown;
            btnColor.Location = new Point(302, 9);
            btnColor.Margin = new Padding(4, 4, 4, 4);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(107, 29);
            btnColor.TabIndex = 3;
            btnColor.Text = "Chọn màu";
            btnColor.UseVisualStyleBackColor = false;
            btnColor.Click += btnColor_Click;
            // 
            // btnUndo
            // 
            btnUndo.BackColor = Color.DarkGreen;
            btnUndo.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUndo.ForeColor = SystemColors.ButtonFace;
            btnUndo.Location = new Point(419, 9);
            btnUndo.Margin = new Padding(4, 4, 4, 4);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(79, 29);
            btnUndo.TabIndex = 4;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = false;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Red;
            btnClear.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = SystemColors.ButtonFace;
            btnClear.Location = new Point(505, 9);
            btnClear.Margin = new Padding(4, 4, 4, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(79, 29);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // chkFill
            // 
            chkFill.AutoSize = true;
            chkFill.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkFill.ForeColor = SystemColors.ButtonFace;
            chkFill.Location = new Point(598, 13);
            chkFill.Margin = new Padding(4, 4, 4, 4);
            chkFill.Name = "chkFill";
            chkFill.Size = new Size(85, 23);
            chkFill.TabIndex = 6;
            chkFill.Text = "Tô màu";
            chkFill.UseVisualStyleBackColor = true;
            // 
            // btnBackColor
            // 
            btnBackColor.Location = new Point(698, 9);
            btnBackColor.Margin = new Padding(4, 4, 4, 4);
            btnBackColor.Name = "btnBackColor";
            btnBackColor.Size = new Size(112, 29);
            btnBackColor.TabIndex = 7;
            btnBackColor.Text = "Màu nền";
            btnBackColor.UseVisualStyleBackColor = true;
            btnBackColor.Click += btnBackColor_Click;
            // 
            // btnOpenImage
            // 
            btnOpenImage.Location = new Point(817, 9);
            btnOpenImage.Margin = new Padding(4, 4, 4, 4);
            btnOpenImage.Name = "btnOpenImage";
            btnOpenImage.Size = new Size(112, 29);
            btnOpenImage.TabIndex = 8;
            btnOpenImage.Text = "Mở ảnh nền";
            btnOpenImage.UseVisualStyleBackColor = true;
            btnOpenImage.Click += btnOpenImage_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(936, 9);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 29);
            btnSave.TabIndex = 9;
            btnSave.Text = "Lưu PNG";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.Fixed3D;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 546);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(4, 0, 0, 0);
            lblStatus.Size = new Size(1125, 24);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "X: 0, Y: 0";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 47);
            canvas.Margin = new Padding(4, 4, 4, 4);
            canvas.Name = "canvas";
            canvas.Size = new Size(1125, 499);
            canvas.TabIndex = 1;
            canvas.Paint += canvas_Paint;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 570);
            Controls.Add(canvas);
            Controls.Add(pnlTop);
            Controls.Add(lblStatus);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            KeyPreview = true;
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(785, 382);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Paint ";
            KeyDown += Form1_KeyDown;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudWidth).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private ComboBox cboMode;
        private Label lblWidth;
        private NumericUpDown nudWidth;
        private Button btnColor;
        private Button btnUndo;
        private Button btnClear;
        private CheckBox chkFill;
        private Button btnBackColor;
        private Button btnOpenImage;
        private Button btnSave;
        private Label lblStatus;
        private DoubleBufferedPanel canvas;
    }
}
