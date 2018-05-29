namespace OthelloWindows
{
    partial class OthelloForm
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
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.board = new System.Windows.Forms.TableLayoutPanel();
            this.pieces = new System.Windows.Forms.Label();
            this.instruction = new System.Windows.Forms.Label();
            this.turn = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.ColumnCount = 3;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panel.Controls.Add(this.board, 0, 0);
            this.panel.Controls.Add(this.instruction, 1, 1);
            this.panel.Controls.Add(this.turn, 0, 1);
            this.panel.Controls.Add(this.pieces, 2, 1);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.RowCount = 2;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.2F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.8F));
            this.panel.Size = new System.Drawing.Size(500, 500);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // board
            // 
            this.board.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.board.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.board.ColumnCount = 8;
            this.panel.SetColumnSpan(this.board, 3);
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.board.Location = new System.Drawing.Point(3, 3);
            this.board.Name = "board";
            this.board.RowCount = 8;
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.Size = new System.Drawing.Size(494, 479);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.board_Paint);
            // 
            // pieces
            // 
            this.pieces.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pieces.AutoSize = true;
            this.pieces.Location = new System.Drawing.Point(408, 486);
            this.pieces.Name = "pieces";
            this.pieces.Size = new System.Drawing.Size(89, 13);
            this.pieces.TabIndex = 0;
            this.pieces.Text = "Black: 2 White: 2";
            this.pieces.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // instruction
            // 
            this.instruction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instruction.AutoSize = true;
            this.instruction.Location = new System.Drawing.Point(211, 486);
            this.instruction.Name = "instruction";
            this.instruction.Size = new System.Drawing.Size(76, 13);
            this.instruction.TabIndex = 1;
            this.instruction.Text = "Click To Move";
            // 
            // turn
            // 
            this.turn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.turn.AutoSize = true;
            this.turn.Location = new System.Drawing.Point(3, 486);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(66, 13);
            this.turn.TabIndex = 2;
            this.turn.Text = "Black\'s Turn";
            // 
            // OthelloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.panel);
            this.Name = "OthelloForm";
            this.Text = "OthelloForm";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.TableLayoutPanel board;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button[,] buttons;
        private System.Windows.Forms.Label pieces;
        private System.Windows.Forms.Label instruction;
        private System.Windows.Forms.Label turn;
    }
}

