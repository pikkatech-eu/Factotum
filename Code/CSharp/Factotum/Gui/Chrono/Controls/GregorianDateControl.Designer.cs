namespace Factotum.Gui.Chrono.Controls
{
	partial class GregorianDateControl
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
			this._txDateString = new System.Windows.Forms.TextBox();
			this._btParse = new System.Windows.Forms.Button();
			this._tlpGregorianDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudDay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._nudMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._nudYear)).BeginInit();
			this.SuspendLayout();
			// 
			// _tlpGregorianDate
			// 
			this._tlpGregorianDate.ColumnCount = 4;
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
			this._tlpGregorianDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
			this._tlpGregorianDate.Controls.Add(this._nudDay, 3, 1);
			this._tlpGregorianDate.Controls.Add(this._nudMonth, 2, 1);
			this._tlpGregorianDate.Controls.Add(this.label3, 3, 0);
			this._tlpGregorianDate.Controls.Add(this.label2, 2, 0);
			this._tlpGregorianDate.Controls.Add(this._cbIsExact, 0, 1);
			this._tlpGregorianDate.Controls.Add(this.label1, 1, 0);
			this._tlpGregorianDate.Controls.Add(this._nudYear, 1, 1);
			this._tlpGregorianDate.Controls.Add(this._txDateString, 0, 2);
			this._tlpGregorianDate.Controls.Add(this._btParse, 3, 2);
			this._tlpGregorianDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpGregorianDate.Location = new System.Drawing.Point(0, 0);
			this._tlpGregorianDate.Margin = new System.Windows.Forms.Padding(0);
			this._tlpGregorianDate.Name = "_tlpGregorianDate";
			this._tlpGregorianDate.RowCount = 3;
			this._tlpGregorianDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this._tlpGregorianDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this._tlpGregorianDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this._tlpGregorianDate.Size = new System.Drawing.Size(640, 72);
			this._tlpGregorianDate.TabIndex = 0;
			// 
			// _nudDay
			// 
			this._nudDay.Dock = System.Windows.Forms.DockStyle.Fill;
			this._nudDay.Location = new System.Drawing.Point(465, 14);
			this._nudDay.Margin = new System.Windows.Forms.Padding(0);
			this._nudDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this._nudDay.Name = "_nudDay";
			this._nudDay.Size = new System.Drawing.Size(175, 27);
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
			this._nudMonth.Location = new System.Drawing.Point(293, 14);
			this._nudMonth.Margin = new System.Windows.Forms.Padding(0);
			this._nudMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this._nudMonth.Name = "_nudMonth";
			this._nudMonth.Size = new System.Drawing.Size(172, 27);
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
			this.label3.Location = new System.Drawing.Point(465, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(175, 14);
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
			this.label2.Size = new System.Drawing.Size(172, 14);
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
			this._cbIsExact.Location = new System.Drawing.Point(18, 14);
			this._cbIsExact.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this._cbIsExact.Name = "_cbIsExact";
			this._cbIsExact.Size = new System.Drawing.Size(103, 28);
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
			this.label1.Location = new System.Drawing.Point(121, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "Year";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _nudYear
			// 
			this._nudYear.Dock = System.Windows.Forms.DockStyle.Fill;
			this._nudYear.Location = new System.Drawing.Point(121, 14);
			this._nudYear.Margin = new System.Windows.Forms.Padding(0);
			this._nudYear.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
			this._nudYear.Name = "_nudYear";
			this._nudYear.Size = new System.Drawing.Size(172, 27);
			this._nudYear.TabIndex = 4;
			this._nudYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._nudYear.ValueChanged += new System.EventHandler(this.OnValuesChanged);
			// 
			// _txDateString
			// 
			this._tlpGregorianDate.SetColumnSpan(this._txDateString, 3);
			this._txDateString.Dock = System.Windows.Forms.DockStyle.Fill;
			this._txDateString.Location = new System.Drawing.Point(4, 42);
			this._txDateString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this._txDateString.Name = "_txDateString";
			this._txDateString.Size = new System.Drawing.Size(457, 27);
			this._txDateString.TabIndex = 7;
			// 
			// _btParse
			// 
			this._btParse.Dock = System.Windows.Forms.DockStyle.Fill;
			this._btParse.Location = new System.Drawing.Point(465, 42);
			this._btParse.Margin = new System.Windows.Forms.Padding(0);
			this._btParse.Name = "_btParse";
			this._btParse.Size = new System.Drawing.Size(175, 30);
			this._btParse.TabIndex = 8;
			this._btParse.Text = "Parse";
			this._btParse.UseVisualStyleBackColor = true;
			this._btParse.Click += new System.EventHandler(this.OnParse);
			// 
			// GregorianDateControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._tlpGregorianDate);
			this.Font = new System.Drawing.Font("Consolas", 10F);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "GregorianDateControl";
			this.Size = new System.Drawing.Size(640, 72);
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
		private System.Windows.Forms.TextBox _txDateString;
		private System.Windows.Forms.Button _btParse;
	}
}
