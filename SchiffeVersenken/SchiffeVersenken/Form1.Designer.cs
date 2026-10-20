namespace SchiffeVersenken
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grid1 = new TableLayoutPanel();
            label1 = new Label();
            button1 = new Button();
            grid2 = new TableLayoutPanel();
            label2 = new Label();
            SuspendLayout();
            // 
            // grid1
            // 
            grid1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            grid1.ColumnCount = 10;
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid1.Location = new Point(83, 100);
            grid1.Name = "grid1";
            grid1.RowCount = 10;
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid1.Size = new Size(300, 300);
            grid1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(83, 52);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 3;
            label1.Text = "Your Ships";
            // 
            // button1
            // 
            button1.Location = new Point(83, 447);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Start Game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // grid2
            // 
            grid2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            grid2.ColumnCount = 10;
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            grid2.Location = new Point(516, 100);
            grid2.Name = "grid2";
            grid2.RowCount = 10;
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            grid2.Size = new Size(300, 300);
            grid2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(516, 52);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 6;
            label2.Text = "Your Turns";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 507);
            Controls.Add(label2);
            Controls.Add(grid2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(grid1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel grid1;
        private Label label1;
        private Button button1;
        private TableLayoutPanel grid2;
        private Label label2;
    }
}