namespace Factotum.Gui.Chrono.Dialogs
{
	partial class GregorianDateDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Factotum.Chrono.GregorianDate gregorianDate1 = new Factotum.Chrono.GregorianDate();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GregorianDateDialog));
			this._btOk = new System.Windows.Forms.Button();
			this._btCancel = new System.Windows.Forms.Button();
			this._ctrlGregorianDate = new Factotum.Gui.Chrono.Controls.GregorianDateControl();
			this.SuspendLayout();
			// 
			// _btOk
			// 
			this._btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btOk.Location = new System.Drawing.Point(12, 111);
			this._btOk.Margin = new System.Windows.Forms.Padding(0);
			this._btOk.Name = "_btOk";
			this._btOk.Size = new System.Drawing.Size(80, 32);
			this._btOk.TabIndex = 0;
			this._btOk.Text = "OK";
			this._btOk.UseVisualStyleBackColor = true;
			this._btOk.Click += new System.EventHandler(this.OnOk);
			// 
			// _btCancel
			// 
			this._btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btCancel.Location = new System.Drawing.Point(108, 111);
			this._btCancel.Margin = new System.Windows.Forms.Padding(0);
			this._btCancel.Name = "_btCancel";
			this._btCancel.Size = new System.Drawing.Size(80, 32);
			this._btCancel.TabIndex = 1;
			this._btCancel.Text = "Cancel";
			this._btCancel.UseVisualStyleBackColor = true;
			this._btCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// _ctrlGregorianDate
			// 
			this._ctrlGregorianDate.Dock = System.Windows.Forms.DockStyle.Top;
			this._ctrlGregorianDate.Font = new System.Drawing.Font("Consolas", 10F);
			gregorianDate1.Day = 1;
			gregorianDate1.IsExact = true;
			gregorianDate1.Month = 1;
			gregorianDate1.Year = 1;
			this._ctrlGregorianDate.GregorianDate = gregorianDate1;
			this._ctrlGregorianDate.Location = new System.Drawing.Point(0, 0);
			this._ctrlGregorianDate.Margin = new System.Windows.Forms.Padding(0);
			this._ctrlGregorianDate.Name = "_ctrlGregorianDate";
			this._ctrlGregorianDate.Size = new System.Drawing.Size(585, 72);
			this._ctrlGregorianDate.TabIndex = 2;
			// 
			// GregorianDateDialog
			// 
			this.AcceptButton = this._btOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btCancel;
			this.ClientSize = new System.Drawing.Size(585, 146);
			this.Controls.Add(this._ctrlGregorianDate);
			this.Controls.Add(this._btCancel);
			this.Controls.Add(this._btOk);
			this.Font = new System.Drawing.Font("Consolas", 10F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "GregorianDateDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GregorianDate Dialog";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _btOk;
		private System.Windows.Forms.Button _btCancel;
		private Controls.GregorianDateControl _ctrlGregorianDate;
	}
}