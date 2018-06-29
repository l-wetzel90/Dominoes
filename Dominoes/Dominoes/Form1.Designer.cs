namespace Dominoes
{
    partial class frmDominoes
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.txtMessageArea = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.lstAvailiblePlayers = new System.Windows.Forms.ListBox();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(12, 173);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(360, 280);
            this.pnlBoard.TabIndex = 0;
            // 
            // txtMessageArea
            // 
            this.txtMessageArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageArea.ForeColor = System.Drawing.Color.Red;
            this.txtMessageArea.Location = new System.Drawing.Point(12, 128);
            this.txtMessageArea.Name = "txtMessageArea";
            this.txtMessageArea.Size = new System.Drawing.Size(360, 26);
            this.txtMessageArea.TabIndex = 1;
            this.txtMessageArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(157, 84);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New Game";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lstAvailiblePlayers
            // 
            this.lstAvailiblePlayers.FormattingEnabled = true;
            this.lstAvailiblePlayers.Location = new System.Drawing.Point(12, 12);
            this.lstAvailiblePlayers.Name = "lstAvailiblePlayers";
            this.lstAvailiblePlayers.Size = new System.Drawing.Size(125, 95);
            this.lstAvailiblePlayers.TabIndex = 0;
            this.lstAvailiblePlayers.SelectedIndexChanged += new System.EventHandler(this.lstAvailiblePlayers_SelectedIndexChanged);
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(247, 12);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(125, 95);
            this.lstPlayers.TabIndex = 1;
            // 
            // frmDominoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(386, 482);
            this.Controls.Add(this.lstAvailiblePlayers);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtMessageArea);
            this.Controls.Add(this.pnlBoard);
            this.Name = "frmDominoes";
            this.Text = "Dominoes";
            this.Load += new System.EventHandler(this.frmDominoes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.TextBox txtMessageArea;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListBox lstAvailiblePlayers;
        private System.Windows.Forms.ListBox lstPlayers;
    }
}

