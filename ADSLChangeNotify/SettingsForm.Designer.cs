/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 00:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ADSLChangeNotify
{
	partial class SettingsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown refreshIntervalUpDown;
		private System.Windows.Forms.CheckBox notifyCheckBox;
		private System.Windows.Forms.Button applyButton;
		private System.Windows.Forms.Button cancelbutton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.refreshIntervalUpDown = new System.Windows.Forms.NumericUpDown();
			this.notifyCheckBox = new System.Windows.Forms.CheckBox();
			this.applyButton = new System.Windows.Forms.Button();
			this.cancelbutton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Yenileme Periyodu(dakika): ";
			// 
			// refreshIntervalUpDown
			// 
			this.refreshIntervalUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.refreshIntervalUpDown.Location = new System.Drawing.Point(145, 14);
			this.refreshIntervalUpDown.Maximum = new decimal(new int[] {
			720,
			0,
			0,
			0});
			this.refreshIntervalUpDown.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.refreshIntervalUpDown.Name = "refreshIntervalUpDown";
			this.refreshIntervalUpDown.Size = new System.Drawing.Size(128, 20);
			this.refreshIntervalUpDown.TabIndex = 1;
			this.refreshIntervalUpDown.Value = new decimal(new int[] {
			30,
			0,
			0,
			0});
			// 
			// notifyCheckBox
			// 
			this.notifyCheckBox.AutoSize = true;
			this.notifyCheckBox.Checked = true;
			this.notifyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.notifyCheckBox.Location = new System.Drawing.Point(23, 48);
			this.notifyCheckBox.Name = "notifyCheckBox";
			this.notifyCheckBox.Size = new System.Drawing.Size(143, 17);
			this.notifyCheckBox.TabIndex = 2;
			this.notifyCheckBox.Text = "Oranlar değiştiğinde bildir";
			this.notifyCheckBox.UseVisualStyleBackColor = true;
			// 
			// applyButton
			// 
			this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.applyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.applyButton.Location = new System.Drawing.Point(198, 87);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(75, 23);
			this.applyButton.TabIndex = 3;
			this.applyButton.Text = "Uygula";
			this.applyButton.UseVisualStyleBackColor = true;
			// 
			// cancelbutton
			// 
			this.cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelbutton.Location = new System.Drawing.Point(114, 87);
			this.cancelbutton.Name = "cancelbutton";
			this.cancelbutton.Size = new System.Drawing.Size(75, 23);
			this.cancelbutton.TabIndex = 4;
			this.cancelbutton.Text = "İptal";
			this.cancelbutton.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 122);
			this.Controls.Add(this.cancelbutton);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(this.notifyCheckBox);
			this.Controls.Add(this.refreshIntervalUpDown);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ayarlar";
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
