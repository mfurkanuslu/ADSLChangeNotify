/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 04:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ADSLChangeNotify
{
	partial class LoginForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MaskedTextBox ipTextBox;
		
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
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.loginButton = new System.Windows.Forms.Button();
			this.infoLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ipTextBox = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.passwordTextBox.Location = new System.Drawing.Point(108, 29);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(239, 20);
			this.passwordTextBox.TabIndex = 0;
			this.passwordTextBox.UseSystemPasswordChar = true;
			// 
			// loginButton
			// 
			this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.loginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.loginButton.Location = new System.Drawing.Point(263, 90);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(84, 23);
			this.loginButton.TabIndex = 1;
			this.loginButton.Text = "Giriş Yap";
			this.loginButton.UseVisualStyleBackColor = true;
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.ForeColor = System.Drawing.Color.Red;
			this.infoLabel.Location = new System.Drawing.Point(12, 58);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(24, 13);
			this.infoLabel.TabIndex = 2;
			this.infoLabel.Text = "info";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Modemin Şifresi:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Modemin IP adresi:";
			// 
			// ipTextBox
			// 
			this.ipTextBox.Location = new System.Drawing.Point(108, 6);
			this.ipTextBox.Name = "ipTextBox";
			this.ipTextBox.PromptChar = ' ';
			this.ipTextBox.Size = new System.Drawing.Size(239, 20);
			this.ipTextBox.TabIndex = 6;
			this.ipTextBox.Text = "192.168.2.1";
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 125);
			this.Controls.Add(this.ipTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.passwordTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Giriş";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
