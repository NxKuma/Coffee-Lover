
namespace PBL_CoffeeDatingApp
{
    partial class StartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPage));
            this.custButton1 = new PBL_CoffeeDatingApp.CustButton();
            this.custButton2 = new PBL_CoffeeDatingApp.CustButton();
            this.SuspendLayout();
            // 
            // custButton1
            // 
            this.custButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.custButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.custButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.custButton1.BorderRadius = 70;
            this.custButton1.BorderSize = 0;
            this.custButton1.FlatAppearance.BorderSize = 0;
            this.custButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custButton1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.custButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(219)))), ((int)(((byte)(198)))));
            this.custButton1.Location = new System.Drawing.Point(135, 696);
            this.custButton1.Name = "custButton1";
            this.custButton1.Size = new System.Drawing.Size(386, 72);
            this.custButton1.TabIndex = 0;
            this.custButton1.Text = "LOG IN";
            this.custButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(219)))), ((int)(((byte)(198)))));
            this.custButton1.UseVisualStyleBackColor = false;
            this.custButton1.Click += new System.EventHandler(this.custButton1_Click);
            // 
            // custButton2
            // 
            this.custButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(219)))), ((int)(((byte)(198)))));
            this.custButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(219)))), ((int)(((byte)(198)))));
            this.custButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.custButton2.BorderRadius = 70;
            this.custButton2.BorderSize = 7;
            this.custButton2.FlatAppearance.BorderSize = 0;
            this.custButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custButton2.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.custButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.custButton2.Location = new System.Drawing.Point(135, 786);
            this.custButton2.Name = "custButton2";
            this.custButton2.Size = new System.Drawing.Size(386, 72);
            this.custButton2.TabIndex = 1;
            this.custButton2.Text = "SIGN UP";
            this.custButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
            this.custButton2.UseVisualStyleBackColor = false;
            this.custButton2.Click += new System.EventHandler(this.custButton2_Click);
            // 
            // StartPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(639, 1071);
            this.Controls.Add(this.custButton2);
            this.Controls.Add(this.custButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartPage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustButton custButton1;
        private CustButton custButton2;
    }
}

