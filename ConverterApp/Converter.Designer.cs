namespace ConverterApp
{
    partial class Converter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Converter));
            this.opcije = new System.Windows.Forms.GroupBox();
            this.radioButtonLength = new System.Windows.Forms.RadioButton();
            this.radioButtonMass = new System.Windows.Forms.RadioButton();
            this.lblPoundsFeet = new System.Windows.Forms.Label();
            this.lblKgM = new System.Windows.Forms.Label();
            this.opcije.SuspendLayout();
            this.SuspendLayout();
            // 
            // opcije
            // 
            resources.ApplyResources(this.opcije, "opcije");
            this.opcije.Controls.Add(this.radioButtonLength);
            this.opcije.Controls.Add(this.radioButtonMass);
            this.opcije.Name = "opcije";
            this.opcije.TabStop = false;
            // 
            // radioButtonLength
            // 
            resources.ApplyResources(this.radioButtonLength, "radioButtonLength");
            this.radioButtonLength.Name = "radioButtonLength";
            this.radioButtonLength.TabStop = true;
            this.radioButtonLength.UseVisualStyleBackColor = true;
            this.radioButtonLength.CheckedChanged += new System.EventHandler(this.radioButtonLength_CheckedChanged);
            // 
            // radioButtonMass
            // 
            resources.ApplyResources(this.radioButtonMass, "radioButtonMass");
            this.radioButtonMass.Checked = true;
            this.radioButtonMass.Name = "radioButtonMass";
            this.radioButtonMass.TabStop = true;
            this.radioButtonMass.UseVisualStyleBackColor = true;
            this.radioButtonMass.CheckedChanged += new System.EventHandler(this.radioButtonMass_CheckedChanged);
            // 
            // lblPoundsFeet
            // 
            resources.ApplyResources(this.lblPoundsFeet, "lblPoundsFeet");
            this.lblPoundsFeet.Name = "lblPoundsFeet";
            // 
            // lblKgM
            // 
            resources.ApplyResources(this.lblKgM, "lblKgM");
            this.lblKgM.Name = "lblKgM";
            // 
            // Converter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.lblKgM);
            this.Controls.Add(this.lblPoundsFeet);
            this.Controls.Add(this.opcije);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Converter";
            this.Opacity = 0.97D;
            this.Shown += new System.EventHandler(this.Draw);
            this.SizeChanged += new System.EventHandler(this.Draw);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Converter_MouseClick);
            this.opcije.ResumeLayout(false);
            this.opcije.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox opcije;
        private System.Windows.Forms.RadioButton radioButtonLength;
        private System.Windows.Forms.RadioButton radioButtonMass;
        private System.Windows.Forms.Label lblPoundsFeet;
        private System.Windows.Forms.Label lblKgM;
    }
}

