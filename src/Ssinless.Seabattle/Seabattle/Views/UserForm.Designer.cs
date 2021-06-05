
namespace Seabattle.Views
{
    partial class UserForm
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
            this.btnBattleshipHorizontal = new System.Windows.Forms.Button();
            this.btnBattleshipVertical = new System.Windows.Forms.Button();
            this.btnCruiserHorizontal = new System.Windows.Forms.Button();
            this.btnCruiserVertical = new System.Windows.Forms.Button();
            this.btnDestroyerHorizontal = new System.Windows.Forms.Button();
            this.btnDestroyerVertical = new System.Windows.Forms.Button();
            this.btnBoat = new System.Windows.Forms.Button();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBattleshipHorizontal
            // 
            this.btnBattleshipHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBattleshipHorizontal.Location = new System.Drawing.Point(635, 12);
            this.btnBattleshipHorizontal.Name = "btnBattleshipHorizontal";
            this.btnBattleshipHorizontal.Size = new System.Drawing.Size(100, 25);
            this.btnBattleshipHorizontal.TabIndex = 0;
            this.btnBattleshipHorizontal.Text = "X X X X";
            this.btnBattleshipHorizontal.UseVisualStyleBackColor = true;
            this.btnBattleshipHorizontal.Click += new System.EventHandler(this.btnBattleshipHorizontal_Click);
            // 
            // btnBattleshipVertical
            // 
            this.btnBattleshipVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBattleshipVertical.Location = new System.Drawing.Point(728, 55);
            this.btnBattleshipVertical.Name = "btnBattleshipVertical";
            this.btnBattleshipVertical.Size = new System.Drawing.Size(25, 100);
            this.btnBattleshipVertical.TabIndex = 1;
            this.btnBattleshipVertical.Text = "XXXX";
            this.btnBattleshipVertical.UseVisualStyleBackColor = true;
            this.btnBattleshipVertical.Click += new System.EventHandler(this.btnBattleshipVertical_Click);
            // 
            // btnCruiserHorizontal
            // 
            this.btnCruiserHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCruiserHorizontal.Location = new System.Drawing.Point(635, 43);
            this.btnCruiserHorizontal.Name = "btnCruiserHorizontal";
            this.btnCruiserHorizontal.Size = new System.Drawing.Size(75, 25);
            this.btnCruiserHorizontal.TabIndex = 2;
            this.btnCruiserHorizontal.Text = "X X X";
            this.btnCruiserHorizontal.UseVisualStyleBackColor = true;
            this.btnCruiserHorizontal.Click += new System.EventHandler(this.btnCruiserHorizontal_Click);
            // 
            // btnCruiserVertical
            // 
            this.btnCruiserVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCruiserVertical.Location = new System.Drawing.Point(697, 80);
            this.btnCruiserVertical.Name = "btnCruiserVertical";
            this.btnCruiserVertical.Size = new System.Drawing.Size(25, 75);
            this.btnCruiserVertical.TabIndex = 3;
            this.btnCruiserVertical.Text = "XXX";
            this.btnCruiserVertical.UseVisualStyleBackColor = true;
            this.btnCruiserVertical.Click += new System.EventHandler(this.btnCruiserVertical_Click);
            // 
            // btnDestroyerHorizontal
            // 
            this.btnDestroyerHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestroyerHorizontal.Location = new System.Drawing.Point(635, 74);
            this.btnDestroyerHorizontal.Name = "btnDestroyerHorizontal";
            this.btnDestroyerHorizontal.Size = new System.Drawing.Size(50, 25);
            this.btnDestroyerHorizontal.TabIndex = 4;
            this.btnDestroyerHorizontal.Text = "X X";
            this.btnDestroyerHorizontal.UseVisualStyleBackColor = true;
            this.btnDestroyerHorizontal.Click += new System.EventHandler(this.btnDestroyerHorizontal_Click);
            // 
            // btnDestroyerVertical
            // 
            this.btnDestroyerVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestroyerVertical.Location = new System.Drawing.Point(666, 105);
            this.btnDestroyerVertical.Name = "btnDestroyerVertical";
            this.btnDestroyerVertical.Size = new System.Drawing.Size(25, 50);
            this.btnDestroyerVertical.TabIndex = 5;
            this.btnDestroyerVertical.Text = "XX";
            this.btnDestroyerVertical.UseVisualStyleBackColor = true;
            this.btnDestroyerVertical.Click += new System.EventHandler(this.btnDestroyerVertical_Click);
            // 
            // btnBoat
            // 
            this.btnBoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoat.Location = new System.Drawing.Point(635, 130);
            this.btnBoat.Name = "btnBoat";
            this.btnBoat.Size = new System.Drawing.Size(25, 25);
            this.btnBoat.TabIndex = 6;
            this.btnBoat.Text = "X";
            this.btnBoat.UseVisualStyleBackColor = true;
            this.btnBoat.Click += new System.EventHandler(this.btnBoat_Click);
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(635, 167);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(54, 30);
            this.lblSelected.TabIndex = 7;
            this.lblSelected.Text = "Selected:\r\nNone.";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(13, 432);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(740, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next >>>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 467);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.btnBoat);
            this.Controls.Add(this.btnDestroyerVertical);
            this.Controls.Add(this.btnDestroyerHorizontal);
            this.Controls.Add(this.btnCruiserVertical);
            this.Controls.Add(this.btnCruiserHorizontal);
            this.Controls.Add(this.btnBattleshipVertical);
            this.Controls.Add(this.btnBattleshipHorizontal);
            this.Name = "UserForm";
            this.Text = "User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBattleshipHorizontal;
        private System.Windows.Forms.Button btnBattleshipVertical;
        private System.Windows.Forms.Button btnCruiserHorizontal;
        private System.Windows.Forms.Button btnCruiserVertical;
        private System.Windows.Forms.Button btnDestroyerHorizontal;
        private System.Windows.Forms.Button btnDestroyerVertical;
        private System.Windows.Forms.Button btnBoat;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnNext;
    }
}