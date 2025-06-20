namespace Factotum.Gui.Chrono.Controls
{
	partial class TemporalControl
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
			Factotum.Chrono.GregorianDate gregorianDate9 = new Factotum.Chrono.GregorianDate();
			Factotum.Chrono.GregorianDate gregorianDate10 = new Factotum.Chrono.GregorianDate();
			this._tlpTemporal = new System.Windows.Forms.TableLayoutPanel();
			this._ctrlStart = new Factotum.Gui.Chrono.Controls.GregorianDateControl();
			this._ctrlEnd = new Factotum.Gui.Chrono.Controls.GregorianDateControl();
			this.label1 = new System.Windows.Forms.Label();
			this._lblStart = new System.Windows.Forms.Label();
			this._lblEnd = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this._txTemporal = new System.Windows.Forms.TextBox();
			this._cxType = new System.Windows.Forms.ComboBox();
			this._btParse = new System.Windows.Forms.Button();
			this._tlpTemporal.SuspendLayout();
			this.SuspendLayout();
			// 
			// _tlpTemporal
			// 
			this._tlpTemporal.ColumnCount = 3;
			this._tlpTemporal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
			this._tlpTemporal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpTemporal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this._tlpTemporal.Controls.Add(this.label2, 0, 3);
			this._tlpTemporal.Controls.Add(this._lblEnd, 0, 2);
			this._tlpTemporal.Controls.Add(this._lblStart, 0, 1);
			this._tlpTemporal.Controls.Add(this._ctrlStart, 1, 1);
			this._tlpTemporal.Controls.Add(this._ctrlEnd, 1, 2);
			this._tlpTemporal.Controls.Add(this.label1, 0, 0);
			this._tlpTemporal.Controls.Add(this._txTemporal, 1, 3);
			this._tlpTemporal.Controls.Add(this._cxType, 1, 0);
			this._tlpTemporal.Controls.Add(this._btParse, 2, 3);
			this._tlpTemporal.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpTemporal.Location = new System.Drawing.Point(0, 0);
			this._tlpTemporal.Margin = new System.Windows.Forms.Padding(0);
			this._tlpTemporal.Name = "_tlpTemporal";
			this._tlpTemporal.RowCount = 4;
			this._tlpTemporal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this._tlpTemporal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this._tlpTemporal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this._tlpTemporal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this._tlpTemporal.Size = new System.Drawing.Size(773, 215);
			this._tlpTemporal.TabIndex = 0;
			// 
			// _ctrlStart
			// 
			this._ctrlStart.Dock = System.Windows.Forms.DockStyle.Top;
			this._ctrlStart.Font = new System.Drawing.Font("Consolas", 10F);
			gregorianDate9.Day = 1;
			gregorianDate9.IsExact = true;
			gregorianDate9.Month = 1;
			gregorianDate9.Year = 1;
			this._ctrlStart.GregorianDate = gregorianDate9;
			this._ctrlStart.Location = new System.Drawing.Point(128, 40);
			this._ctrlStart.Margin = new System.Windows.Forms.Padding(0);
			this._ctrlStart.Name = "_ctrlStart";
			this._ctrlStart.Size = new System.Drawing.Size(565, 71);
			this._ctrlStart.TabIndex = 0;
			// 
			// _ctrlEnd
			// 
			this._ctrlEnd.Dock = System.Windows.Forms.DockStyle.Top;
			this._ctrlEnd.Font = new System.Drawing.Font("Consolas", 10F);
			gregorianDate10.Day = 1;
			gregorianDate10.IsExact = true;
			gregorianDate10.Month = 1;
			gregorianDate10.Year = 1;
			this._ctrlEnd.GregorianDate = gregorianDate10;
			this._ctrlEnd.Location = new System.Drawing.Point(128, 111);
			this._ctrlEnd.Margin = new System.Windows.Forms.Padding(0);
			this._ctrlEnd.Name = "_ctrlEnd";
			this._ctrlEnd.Size = new System.Drawing.Size(565, 71);
			this._ctrlEnd.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "Type";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _lblStart
			// 
			this._lblStart.AutoSize = true;
			this._lblStart.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lblStart.Location = new System.Drawing.Point(0, 45);
			this._lblStart.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this._lblStart.Name = "_lblStart";
			this._lblStart.Size = new System.Drawing.Size(128, 66);
			this._lblStart.TabIndex = 3;
			this._lblStart.Text = "Start";
			this._lblStart.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lblEnd
			// 
			this._lblEnd.AutoSize = true;
			this._lblEnd.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lblEnd.Location = new System.Drawing.Point(0, 116);
			this._lblEnd.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this._lblEnd.Name = "_lblEnd";
			this._lblEnd.Size = new System.Drawing.Size(128, 66);
			this._lblEnd.TabIndex = 4;
			this._lblEnd.Text = "End";
			this._lblEnd.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 182);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 33);
			this.label2.TabIndex = 5;
			this.label2.Text = "Text";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _txTemporal
			// 
			this._txTemporal.Dock = System.Windows.Forms.DockStyle.Fill;
			this._txTemporal.Location = new System.Drawing.Point(131, 185);
			this._txTemporal.Name = "_txTemporal";
			this._txTemporal.Size = new System.Drawing.Size(559, 27);
			this._txTemporal.TabIndex = 6;
			// 
			// _cxType
			// 
			this._cxType.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cxType.FormattingEnabled = true;
			this._cxType.Location = new System.Drawing.Point(131, 3);
			this._cxType.Name = "_cxType";
			this._cxType.Size = new System.Drawing.Size(559, 28);
			this._cxType.TabIndex = 7;
			this._cxType.SelectedIndexChanged += new System.EventHandler(this.OnSelectedTypeChanged);
			// 
			// _btParse
			// 
			this._btParse.Dock = System.Windows.Forms.DockStyle.Fill;
			this._btParse.Location = new System.Drawing.Point(696, 185);
			this._btParse.Name = "_btParse";
			this._btParse.Size = new System.Drawing.Size(74, 27);
			this._btParse.TabIndex = 8;
			this._btParse.Text = "Parse";
			this._btParse.UseVisualStyleBackColor = true;
			this._btParse.Click += new System.EventHandler(this.OnParseTemporal);
			// 
			// TemporalControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._tlpTemporal);
			this.Font = new System.Drawing.Font("Consolas", 10F);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "TemporalControl";
			this.Size = new System.Drawing.Size(773, 215);
			this._tlpTemporal.ResumeLayout(false);
			this._tlpTemporal.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel _tlpTemporal;
		private GregorianDateControl _ctrlStart;
		private GregorianDateControl _ctrlEnd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label _lblStart;
		private System.Windows.Forms.Label _lblEnd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _txTemporal;
		private System.Windows.Forms.ComboBox _cxType;
		private System.Windows.Forms.Button _btParse;
	}
}
