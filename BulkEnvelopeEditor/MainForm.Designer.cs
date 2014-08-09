namespace BulkEnvelopeEditor {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.minLengthBox = new System.Windows.Forms.TextBox();
			this.lengthLab = new System.Windows.Forms.Label();
			this.p3Box = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.p4Box = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.p5Box = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.v5Box = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.v4Box = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.v3Box = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.doItBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// minLengthBox
			// 
			this.minLengthBox.Location = new System.Drawing.Point(16, 29);
			this.minLengthBox.Name = "minLengthBox";
			this.minLengthBox.Size = new System.Drawing.Size(100, 20);
			this.minLengthBox.TabIndex = 1;
			this.minLengthBox.Text = "0";
			this.minLengthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
			// 
			// lengthLab
			// 
			this.lengthLab.AutoSize = true;
			this.lengthLab.Location = new System.Drawing.Point(13, 13);
			this.lengthLab.Name = "lengthLab";
			this.lengthLab.Size = new System.Drawing.Size(132, 13);
			this.lengthLab.TabIndex = 2;
			this.lengthLab.Text = "Note length is greater than";
			// 
			// p3Box
			// 
			this.p3Box.Location = new System.Drawing.Point(148, 64);
			this.p3Box.Name = "p3Box";
			this.p3Box.Size = new System.Drawing.Size(57, 20);
			this.p3Box.TabIndex = 8;
			this.p3Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(122, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "p3";
			// 
			// p4Box
			// 
			this.p4Box.Location = new System.Drawing.Point(247, 64);
			this.p4Box.Name = "p4Box";
			this.p4Box.Size = new System.Drawing.Size(57, 20);
			this.p4Box.TabIndex = 10;
			this.p4Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(221, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(19, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "p4";
			// 
			// p5Box
			// 
			this.p5Box.Location = new System.Drawing.Point(46, 64);
			this.p5Box.Name = "p5Box";
			this.p5Box.Size = new System.Drawing.Size(57, 20);
			this.p5Box.TabIndex = 12;
			this.p5Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(19, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "p5";
			// 
			// v5Box
			// 
			this.v5Box.Location = new System.Drawing.Point(46, 99);
			this.v5Box.Name = "v5Box";
			this.v5Box.Size = new System.Drawing.Size(57, 20);
			this.v5Box.TabIndex = 22;
			this.v5Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 102);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(19, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "v5";
			// 
			// v4Box
			// 
			this.v4Box.Location = new System.Drawing.Point(247, 99);
			this.v4Box.Name = "v4Box";
			this.v4Box.Size = new System.Drawing.Size(57, 20);
			this.v4Box.TabIndex = 20;
			this.v4Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(221, 102);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(19, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "v4";
			// 
			// v3Box
			// 
			this.v3Box.Location = new System.Drawing.Point(148, 99);
			this.v3Box.Name = "v3Box";
			this.v3Box.Size = new System.Drawing.Size(57, 20);
			this.v3Box.TabIndex = 18;
			this.v3Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(122, 102);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(19, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "v3";
			// 
			// doItBtn
			// 
			this.doItBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.doItBtn.Location = new System.Drawing.Point(163, 157);
			this.doItBtn.Name = "doItBtn";
			this.doItBtn.Size = new System.Drawing.Size(141, 32);
			this.doItBtn.TabIndex = 23;
			this.doItBtn.Text = "Do ittttt";
			this.doItBtn.UseVisualStyleBackColor = true;
			this.doItBtn.Click += new System.EventHandler(this.doItBtn_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 201);
			this.Controls.Add(this.doItBtn);
			this.Controls.Add(this.v5Box);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.v4Box);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.v3Box);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.p5Box);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.p4Box);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.p3Box);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lengthLab);
			this.Controls.Add(this.minLengthBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "UTAU Bulk Envelope Editor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox minLengthBox;
		private System.Windows.Forms.Label lengthLab;
		private System.Windows.Forms.TextBox p3Box;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox p4Box;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox p5Box;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox v5Box;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox v4Box;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox v3Box;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button doItBtn;

	}
}

