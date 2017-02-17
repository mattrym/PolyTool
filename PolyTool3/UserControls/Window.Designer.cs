namespace PolyTool3.UserControls
{
	partial class Window
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.normalSurfaceGroupBox = new System.Windows.Forms.GroupBox();
			this.functionListBox = new System.Windows.Forms.ListBox();
			this.bumpMapGroupBox = new System.Windows.Forms.GroupBox();
			this.loadBumpMapButton = new System.Windows.Forms.Button();
			this.bumpMappingEnabled = new System.Windows.Forms.CheckBox();
			this.lightGroupBox = new System.Windows.Forms.GroupBox();
			this.centerLightButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.xLightTextBox = new System.Windows.Forms.TextBox();
			this.yLightTextBox = new System.Windows.Forms.TextBox();
			this.heightLabel = new System.Windows.Forms.Label();
			this.radiusLabel = new System.Windows.Forms.Label();
			this.heightLightTextBox = new System.Windows.Forms.TextBox();
			this.radiusLightTextBox = new System.Windows.Forms.TextBox();
			this.lightColorButton = new System.Windows.Forms.Button();
			this.animatedLightRadioButton = new System.Windows.Forms.RadioButton();
			this.constantLightRadioButton = new System.Windows.Forms.RadioButton();
			this.noLightRadioButton = new System.Windows.Forms.RadioButton();
			this.title = new System.Windows.Forms.Label();
			this.backgroundGroup = new System.Windows.Forms.GroupBox();
			this.backgroundBitmapButton = new System.Windows.Forms.Button();
			this.backgroundColorButton = new System.Windows.Forms.Button();
			this.backgroundBitmapRadioButton = new System.Windows.Forms.RadioButton();
			this.backgroundcolorRadioButton = new System.Windows.Forms.RadioButton();
			this.noBackgroundRadioButton = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.normalSurfaceGroupBox.SuspendLayout();
			this.bumpMapGroupBox.SuspendLayout();
			this.lightGroupBox.SuspendLayout();
			this.backgroundGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Resize += new System.EventHandler(this.Surface_ChangeRequest);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.normalSurfaceGroupBox);
			this.splitContainer1.Panel2.Controls.Add(this.bumpMapGroupBox);
			this.splitContainer1.Panel2.Controls.Add(this.lightGroupBox);
			this.splitContainer1.Panel2.Controls.Add(this.title);
			this.splitContainer1.Panel2.Controls.Add(this.backgroundGroup);
			this.splitContainer1.Size = new System.Drawing.Size(784, 561);
			this.splitContainer1.SplitterDistance = 601;
			this.splitContainer1.TabIndex = 0;
			// 
			// normalSurfaceGroupBox
			// 
			this.normalSurfaceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.normalSurfaceGroupBox.Controls.Add(this.functionListBox);
			this.normalSurfaceGroupBox.Location = new System.Drawing.Point(12, 353);
			this.normalSurfaceGroupBox.Name = "normalSurfaceGroupBox";
			this.normalSurfaceGroupBox.Size = new System.Drawing.Size(155, 84);
			this.normalSurfaceGroupBox.TabIndex = 4;
			this.normalSurfaceGroupBox.TabStop = false;
			this.normalSurfaceGroupBox.Text = "Surface";
			// 
			// functionListBox
			// 
			this.functionListBox.FormattingEnabled = true;
			this.functionListBox.Items.AddRange(new object[] {
            "Plane",
            "Cone",
            "Paraboloid",
            "Hyperbolic Paraboloid"});
			this.functionListBox.Location = new System.Drawing.Point(9, 19);
			this.functionListBox.Name = "functionListBox";
			this.functionListBox.Size = new System.Drawing.Size(136, 56);
			this.functionListBox.TabIndex = 0;
			this.functionListBox.SelectedIndexChanged += new System.EventHandler(this.Surface_ChangeRequest);
			// 
			// bumpMapGroupBox
			// 
			this.bumpMapGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bumpMapGroupBox.Controls.Add(this.loadBumpMapButton);
			this.bumpMapGroupBox.Controls.Add(this.bumpMappingEnabled);
			this.bumpMapGroupBox.Location = new System.Drawing.Point(12, 443);
			this.bumpMapGroupBox.Name = "bumpMapGroupBox";
			this.bumpMapGroupBox.Size = new System.Drawing.Size(155, 48);
			this.bumpMapGroupBox.TabIndex = 3;
			this.bumpMapGroupBox.TabStop = false;
			this.bumpMapGroupBox.Text = "Bump mapping";
			// 
			// loadBumpMapButton
			// 
			this.loadBumpMapButton.Location = new System.Drawing.Point(90, 16);
			this.loadBumpMapButton.Name = "loadBumpMapButton";
			this.loadBumpMapButton.Size = new System.Drawing.Size(56, 23);
			this.loadBumpMapButton.TabIndex = 1;
			this.loadBumpMapButton.Text = "Load";
			this.loadBumpMapButton.UseVisualStyleBackColor = true;
			this.loadBumpMapButton.Click += new System.EventHandler(this.BumpMap_ChangeRequest);
			// 
			// bumpMappingEnabled
			// 
			this.bumpMappingEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bumpMappingEnabled.AutoSize = true;
			this.bumpMappingEnabled.Location = new System.Drawing.Point(10, 20);
			this.bumpMappingEnabled.Name = "bumpMappingEnabled";
			this.bumpMappingEnabled.Size = new System.Drawing.Size(59, 17);
			this.bumpMappingEnabled.TabIndex = 0;
			this.bumpMappingEnabled.Text = "Enable";
			this.bumpMappingEnabled.UseVisualStyleBackColor = true;
			this.bumpMappingEnabled.CheckedChanged += new System.EventHandler(this.bumpMappingEnabled_CheckedChanged);
			// 
			// lightGroupBox
			// 
			this.lightGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lightGroupBox.Controls.Add(this.centerLightButton);
			this.lightGroupBox.Controls.Add(this.label2);
			this.lightGroupBox.Controls.Add(this.label1);
			this.lightGroupBox.Controls.Add(this.xLightTextBox);
			this.lightGroupBox.Controls.Add(this.yLightTextBox);
			this.lightGroupBox.Controls.Add(this.heightLabel);
			this.lightGroupBox.Controls.Add(this.radiusLabel);
			this.lightGroupBox.Controls.Add(this.heightLightTextBox);
			this.lightGroupBox.Controls.Add(this.radiusLightTextBox);
			this.lightGroupBox.Controls.Add(this.lightColorButton);
			this.lightGroupBox.Controls.Add(this.animatedLightRadioButton);
			this.lightGroupBox.Controls.Add(this.constantLightRadioButton);
			this.lightGroupBox.Controls.Add(this.noLightRadioButton);
			this.lightGroupBox.Location = new System.Drawing.Point(11, 149);
			this.lightGroupBox.Name = "lightGroupBox";
			this.lightGroupBox.Size = new System.Drawing.Size(155, 198);
			this.lightGroupBox.TabIndex = 2;
			this.lightGroupBox.TabStop = false;
			this.lightGroupBox.Text = "Light";
			// 
			// centerLightButton
			// 
			this.centerLightButton.Location = new System.Drawing.Point(11, 169);
			this.centerLightButton.Name = "centerLightButton";
			this.centerLightButton.Size = new System.Drawing.Size(134, 23);
			this.centerLightButton.TabIndex = 13;
			this.centerLightButton.Text = "Center light";
			this.centerLightButton.UseVisualStyleBackColor = true;
			this.centerLightButton.Click += new System.EventHandler(this.centerLightButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(86, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Y";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "X";
			// 
			// xLightTextBox
			// 
			this.xLightTextBox.Location = new System.Drawing.Point(31, 88);
			this.xLightTextBox.Name = "xLightTextBox";
			this.xLightTextBox.Size = new System.Drawing.Size(39, 20);
			this.xLightTextBox.TabIndex = 10;
			this.xLightTextBox.Text = "200";
			this.xLightTextBox.TextChanged += new System.EventHandler(this.AnimatedLight_PropertiesChanged);
			// 
			// yLightTextBox
			// 
			this.yLightTextBox.Location = new System.Drawing.Point(106, 88);
			this.yLightTextBox.Name = "yLightTextBox";
			this.yLightTextBox.Size = new System.Drawing.Size(39, 20);
			this.yLightTextBox.TabIndex = 9;
			this.yLightTextBox.Text = "200";
			this.yLightTextBox.TextChanged += new System.EventHandler(this.AnimatedLight_PropertiesChanged);
			// 
			// heightLabel
			// 
			this.heightLabel.AutoSize = true;
			this.heightLabel.Location = new System.Drawing.Point(11, 145);
			this.heightLabel.Name = "heightLabel";
			this.heightLabel.Size = new System.Drawing.Size(38, 13);
			this.heightLabel.TabIndex = 8;
			this.heightLabel.Text = "Height";
			// 
			// radiusLabel
			// 
			this.radiusLabel.AutoSize = true;
			this.radiusLabel.Location = new System.Drawing.Point(11, 117);
			this.radiusLabel.Name = "radiusLabel";
			this.radiusLabel.Size = new System.Drawing.Size(40, 13);
			this.radiusLabel.TabIndex = 7;
			this.radiusLabel.Text = "Radius";
			// 
			// heightLightTextBox
			// 
			this.heightLightTextBox.Location = new System.Drawing.Point(89, 142);
			this.heightLightTextBox.Name = "heightLightTextBox";
			this.heightLightTextBox.Size = new System.Drawing.Size(56, 20);
			this.heightLightTextBox.TabIndex = 6;
			this.heightLightTextBox.Text = "100";
			this.heightLightTextBox.TextChanged += new System.EventHandler(this.AnimatedLight_PropertiesChanged);
			// 
			// radiusLightTextBox
			// 
			this.radiusLightTextBox.Location = new System.Drawing.Point(89, 114);
			this.radiusLightTextBox.Name = "radiusLightTextBox";
			this.radiusLightTextBox.Size = new System.Drawing.Size(56, 20);
			this.radiusLightTextBox.TabIndex = 5;
			this.radiusLightTextBox.Text = "200";
			this.radiusLightTextBox.TextChanged += new System.EventHandler(this.AnimatedLight_PropertiesChanged);
			// 
			// lightColorButton
			// 
			this.lightColorButton.Location = new System.Drawing.Point(89, 19);
			this.lightColorButton.Name = "lightColorButton";
			this.lightColorButton.Size = new System.Drawing.Size(56, 63);
			this.lightColorButton.TabIndex = 4;
			this.lightColorButton.Text = "Color";
			this.lightColorButton.UseVisualStyleBackColor = true;
			this.lightColorButton.Click += new System.EventHandler(this.lightColorButton_Click);
			// 
			// animatedLightRadioButton
			// 
			this.animatedLightRadioButton.AutoSize = true;
			this.animatedLightRadioButton.Location = new System.Drawing.Point(13, 65);
			this.animatedLightRadioButton.Name = "animatedLightRadioButton";
			this.animatedLightRadioButton.Size = new System.Drawing.Size(69, 17);
			this.animatedLightRadioButton.TabIndex = 3;
			this.animatedLightRadioButton.Text = "Animated";
			this.animatedLightRadioButton.UseVisualStyleBackColor = true;
			this.animatedLightRadioButton.CheckedChanged += new System.EventHandler(this.AnimatedLight_ChangeRequest);
			// 
			// constantLightRadioButton
			// 
			this.constantLightRadioButton.AutoSize = true;
			this.constantLightRadioButton.Location = new System.Drawing.Point(13, 42);
			this.constantLightRadioButton.Name = "constantLightRadioButton";
			this.constantLightRadioButton.Size = new System.Drawing.Size(67, 17);
			this.constantLightRadioButton.TabIndex = 2;
			this.constantLightRadioButton.Text = "Constant";
			this.constantLightRadioButton.UseVisualStyleBackColor = true;
			this.constantLightRadioButton.CheckedChanged += new System.EventHandler(this.ConstantLight_ChangeRequest);
			// 
			// noLightRadioButton
			// 
			this.noLightRadioButton.AutoSize = true;
			this.noLightRadioButton.Checked = true;
			this.noLightRadioButton.Location = new System.Drawing.Point(13, 19);
			this.noLightRadioButton.Name = "noLightRadioButton";
			this.noLightRadioButton.Size = new System.Drawing.Size(51, 17);
			this.noLightRadioButton.TabIndex = 1;
			this.noLightRadioButton.TabStop = true;
			this.noLightRadioButton.Text = "None";
			this.noLightRadioButton.UseVisualStyleBackColor = true;
			this.noLightRadioButton.CheckedChanged += new System.EventHandler(this.NoLight_ChangeRequest);
			// 
			// title
			// 
			this.title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.title.AutoSize = true;
			this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.title.Location = new System.Drawing.Point(18, 9);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(139, 20);
			this.title.TabIndex = 1;
			this.title.Text = "Polygon Toolbox";
			// 
			// backgroundGroup
			// 
			this.backgroundGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.backgroundGroup.Controls.Add(this.backgroundBitmapButton);
			this.backgroundGroup.Controls.Add(this.backgroundColorButton);
			this.backgroundGroup.Controls.Add(this.backgroundBitmapRadioButton);
			this.backgroundGroup.Controls.Add(this.backgroundcolorRadioButton);
			this.backgroundGroup.Controls.Add(this.noBackgroundRadioButton);
			this.backgroundGroup.Location = new System.Drawing.Point(12, 32);
			this.backgroundGroup.Name = "backgroundGroup";
			this.backgroundGroup.Size = new System.Drawing.Size(155, 111);
			this.backgroundGroup.TabIndex = 0;
			this.backgroundGroup.TabStop = false;
			this.backgroundGroup.Text = "Background";
			// 
			// backgroundBitmapButton
			// 
			this.backgroundBitmapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.backgroundBitmapButton.Location = new System.Drawing.Point(89, 71);
			this.backgroundBitmapButton.Margin = new System.Windows.Forms.Padding(0);
			this.backgroundBitmapButton.Name = "backgroundBitmapButton";
			this.backgroundBitmapButton.Size = new System.Drawing.Size(56, 32);
			this.backgroundBitmapButton.TabIndex = 4;
			this.backgroundBitmapButton.Text = "Load";
			this.backgroundBitmapButton.UseVisualStyleBackColor = true;
			this.backgroundBitmapButton.Click += new System.EventHandler(this.BackgroundImage_ChangeRequest);
			// 
			// backgroundColorButton
			// 
			this.backgroundColorButton.Location = new System.Drawing.Point(89, 39);
			this.backgroundColorButton.Name = "backgroundColorButton";
			this.backgroundColorButton.Size = new System.Drawing.Size(56, 29);
			this.backgroundColorButton.TabIndex = 3;
			this.backgroundColorButton.UseVisualStyleBackColor = true;
			this.backgroundColorButton.Click += new System.EventHandler(this.BackgroundColor_ChangeRequest);
			// 
			// backgroundBitmapRadioButton
			// 
			this.backgroundBitmapRadioButton.AutoSize = true;
			this.backgroundBitmapRadioButton.Location = new System.Drawing.Point(13, 78);
			this.backgroundBitmapRadioButton.Name = "backgroundBitmapRadioButton";
			this.backgroundBitmapRadioButton.Size = new System.Drawing.Size(54, 17);
			this.backgroundBitmapRadioButton.TabIndex = 2;
			this.backgroundBitmapRadioButton.Text = "Image";
			this.backgroundBitmapRadioButton.UseVisualStyleBackColor = true;
			this.backgroundBitmapRadioButton.CheckedChanged += new System.EventHandler(this.BackgroundImage_ChangeRequest);
			// 
			// backgroundcolorRadioButton
			// 
			this.backgroundcolorRadioButton.AutoSize = true;
			this.backgroundcolorRadioButton.Location = new System.Drawing.Point(13, 45);
			this.backgroundcolorRadioButton.Name = "backgroundcolorRadioButton";
			this.backgroundcolorRadioButton.Size = new System.Drawing.Size(49, 17);
			this.backgroundcolorRadioButton.TabIndex = 1;
			this.backgroundcolorRadioButton.Text = "Color";
			this.backgroundcolorRadioButton.UseVisualStyleBackColor = true;
			this.backgroundcolorRadioButton.CheckedChanged += new System.EventHandler(this.BackgroundColor_ChangeRequest);
			// 
			// noBackgroundRadioButton
			// 
			this.noBackgroundRadioButton.AutoSize = true;
			this.noBackgroundRadioButton.Checked = true;
			this.noBackgroundRadioButton.Location = new System.Drawing.Point(13, 19);
			this.noBackgroundRadioButton.Name = "noBackgroundRadioButton";
			this.noBackgroundRadioButton.Size = new System.Drawing.Size(51, 17);
			this.noBackgroundRadioButton.TabIndex = 0;
			this.noBackgroundRadioButton.TabStop = true;
			this.noBackgroundRadioButton.Text = "None";
			this.noBackgroundRadioButton.UseVisualStyleBackColor = true;
			this.noBackgroundRadioButton.CheckedChanged += new System.EventHandler(this.NoBackground_ChangeRequest);
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Window";
			this.Text = "Window";
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.normalSurfaceGroupBox.ResumeLayout(false);
			this.bumpMapGroupBox.ResumeLayout(false);
			this.bumpMapGroupBox.PerformLayout();
			this.lightGroupBox.ResumeLayout(false);
			this.lightGroupBox.PerformLayout();
			this.backgroundGroup.ResumeLayout(false);
			this.backgroundGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label title;
		private System.Windows.Forms.GroupBox backgroundGroup;
		private System.Windows.Forms.Button backgroundBitmapButton;
		private System.Windows.Forms.Button backgroundColorButton;
		private System.Windows.Forms.RadioButton backgroundBitmapRadioButton;
		private System.Windows.Forms.RadioButton backgroundcolorRadioButton;
		private System.Windows.Forms.RadioButton noBackgroundRadioButton;
		private System.Windows.Forms.GroupBox normalSurfaceGroupBox;
		private System.Windows.Forms.ListBox functionListBox;
		private System.Windows.Forms.GroupBox bumpMapGroupBox;
		private System.Windows.Forms.Button loadBumpMapButton;
		private System.Windows.Forms.CheckBox bumpMappingEnabled;
		private System.Windows.Forms.GroupBox lightGroupBox;
		private System.Windows.Forms.Button lightColorButton;
		private System.Windows.Forms.RadioButton animatedLightRadioButton;
		private System.Windows.Forms.RadioButton constantLightRadioButton;
		private System.Windows.Forms.RadioButton noLightRadioButton;
		private System.Windows.Forms.Label heightLabel;
		private System.Windows.Forms.Label radiusLabel;
		private System.Windows.Forms.TextBox heightLightTextBox;
		private System.Windows.Forms.TextBox radiusLightTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox xLightTextBox;
		private System.Windows.Forms.TextBox yLightTextBox;
		private System.Windows.Forms.Button centerLightButton;
	}
}