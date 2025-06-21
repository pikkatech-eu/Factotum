namespace Factotum.Gui.Chrono.Controls
{
	partial class SimpleGregorianDateControl 
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._tlpGregorianDate = new System.Windows.Forms.TableLayoutPanel();
			this._nudDay = new System.Windows.Forms.NumericUpDown();
			this._nudMonth = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this._cbIsExact = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this._nudYear = new System.Windows.Forms.NumericUpDown();
			this._tlpGregorianDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudDay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._nudMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._nudYear)).BeginInit();
			this.SuspendLayout();
			// 
			// _tlpGregorianDate
			// 
			this._tlpGregorianDate.ColumnCount = 4;
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this._tlpGregorianDate.Controls.Add(this._nudDay, 3, 1);
			this._tlpGregorianDate.Controls.Add(this._nudMonth, 2, 1);
			this._tlpGregorianDate.Controls.Add(this.label3, 3, 0);
			this._tlpGregorianDate.Controls.Add(this.label2, 2, 0);
			this._tlpGregorianDate.Controls.Add(this._cbIsExact, 0, 1);
			this._tlpGregorianDate.Controls.Add(this.label1, 1, 0);
			this._tlpGregorianDate.Controls.Add(this._nudYear, 1, 1);
			this._tlpGregorianDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpGregorianDate.Location = new System.Drawing.Point(0, 0);
			this._tlpGregorianDate.Margin = new System.Windows.Forms.Padding(0);
			this._tlpGregorianDate.Name = "_tlpGregorianDate";
			this._tlpGregorianDate.RowCount = 2;
			this._tlpGregorianDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this._tlpGregorianDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
			this._tlpGregorianDate.Size = new System.Drawing.Size(640, 48);
			this._tlpGregorianDate.TabIndex = 0;
			// 
			// _nudDay
			// 
			this._nudDay.Dock = System.Windows.Forms.DockStyle.Fill;
			this._nudDay.Location = new System.Drawing.Point(466, 16);
			this._nudDay.Margin = new System.Windows.Forms.Padding(0);
			this._nudDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this._nudDay.Name = "_nudDay";
			this._nudDay.Size = new System.Drawing.Size(174, 27);
			this._nudDay.TabIndex = 6;
			this._nudDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._nudDay.ValueChanged += new System.EventHandler(this.OnValuesChanged);
			// 
			// _nudMonth
			// 
			this._nudMonth.Dock = System.Windows.Forms.DockStyle.Fill;
			this._nudMonth.Location = new System.Drawing.Point(293, 16);
			this._nudMonth.Margin = new System.Windows.Forms.Padding(0);
			this._nudMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this._nudMonth.Name = "_nudMonth";
			this._nudMonth.Size = new System.Drawing.Size(173, 27);
			this._nudMonth.TabIndex = 5;
			this._nudMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._nudMonth.ValueChanged += new System.EventHandler(this.OnValuesChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(466, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(174, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Day";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(293, 0);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(173, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Month";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _cbIsExact
			// 
			this._cbIsExact.AutoSize = true;
			this._cbIsExact.Checked = true;
			this._cbIsExact.CheckState = System.Windows.Forms.CheckState.Checked;
			this._cbIsExact.Dock = System.Windows.Forms.DockStyle.Right;
			this._cbIsExact.Location = new System.Drawing.Point(17, 16);
			this._cbIsExact.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this._cbIsExact.Name = "_cbIsExact";
			this._cbIsExact.Size = new System.Drawing.Size(103, 32);
			this._cbIsExact.TabIndex = 0;
			this._cbIsExact.Text = "Is Exact";
			this._cbIsExact.UseVisualStyleBackColor = true;
			this._cbIsExact.CheckStateChanged += new System.EventHandler(this.OnValuesChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(120, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(173, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Year";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _nudYear
			// 
			this._nudYear.Dock = System.Windows.Forms.DockStyle.Fill;
			this._nudYear.Location = new System.Drawing.Point(120, 16);
			this._nudYear.Margin = new System.Windows.Forms.Padding(0);
			this._nudYear.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
			this._nudYear.Name = "_nudYear";
			this._nudYear.Size = new System.Drawing.Size(173, 27);
			this._nudYear.TabIndex = 4;
			this._nudYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._nudYear.ValueChanged += new System.EventHandler(this.OnValuesChanged);
			// 
			// SimpleGregorianDateControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._tlpGregorianDate);
			this.Font = new System.Drawing.Font("Consolas", 10F);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SimpleGregorianDateControl";
			this.Size = new System.Drawing.Size(640, 48);
			this._tlpGregorianDate.ResumeLayout(false);
			this._tlpGregorianDate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudDay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._nudMonth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._nudYear)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel _tlpGregorianDate;
		private System.Windows.Forms.CheckBox _cbIsExact;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown _nudYear;
		private System.Windows.Forms.NumericUpDown _nudMonth;
		private System.Windows.Forms.NumericUpDown _nudDay;
	}
}
