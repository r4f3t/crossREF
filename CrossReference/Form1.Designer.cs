namespace CrossReference
{
    partial class Form1
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
            this.TXTCode = new System.Windows.Forms.TextBox();
            this.BTNAra = new System.Windows.Forms.Button();
            this.BTNAktar = new System.Windows.Forms.Button();
            this.GridItems = new System.Windows.Forms.DataGridView();
            this.ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridGezgin = new System.Windows.Forms.DataGridView();
            this.gezginItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridGezgin)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTCode
            // 
            this.TXTCode.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXTCode.Location = new System.Drawing.Point(0, 0);
            this.TXTCode.Name = "TXTCode";
            this.TXTCode.Size = new System.Drawing.Size(491, 36);
            this.TXTCode.TabIndex = 0;
            this.TXTCode.TextChanged += new System.EventHandler(this.TXTCode_TextChanged);
            this.TXTCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTCode_KeyDown);
            this.TXTCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTCode_KeyPress);
            this.TXTCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TXTCode_KeyUp);
            // 
            // BTNAra
            // 
            this.BTNAra.Location = new System.Drawing.Point(491, 0);
            this.BTNAra.Name = "BTNAra";
            this.BTNAra.Size = new System.Drawing.Size(142, 34);
            this.BTNAra.TabIndex = 1;
            this.BTNAra.Text = "Ara";
            this.BTNAra.UseVisualStyleBackColor = true;
            this.BTNAra.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTNAktar
            // 
            this.BTNAktar.Location = new System.Drawing.Point(633, 0);
            this.BTNAktar.Name = "BTNAktar";
            this.BTNAktar.Size = new System.Drawing.Size(164, 34);
            this.BTNAktar.TabIndex = 1;
            this.BTNAktar.Text = "Excelden Aktar";
            this.BTNAktar.UseVisualStyleBackColor = true;
            this.BTNAktar.Click += new System.EventHandler(this.BTNAktar_Click);
            // 
            // GridItems
            // 
            this.GridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ITEM_CODE});
            this.GridItems.Location = new System.Drawing.Point(0, 34);
            this.GridItems.Name = "GridItems";
            this.GridItems.RowTemplate.Height = 24;
            this.GridItems.Size = new System.Drawing.Size(797, 413);
            this.GridItems.TabIndex = 2;
            // 
            // ITEM_CODE
            // 
            this.ITEM_CODE.DataPropertyName = "ITEMCODE";
            this.ITEM_CODE.HeaderText = "Ürün Kodu";
            this.ITEM_CODE.Name = "ITEM_CODE";
            this.ITEM_CODE.ReadOnly = true;
            this.ITEM_CODE.Width = 750;
            // 
            // GridGezgin
            // 
            this.GridGezgin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridGezgin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gezginItem,
            this.Class});
            this.GridGezgin.Location = new System.Drawing.Point(0, 34);
            this.GridGezgin.Name = "GridGezgin";
            this.GridGezgin.RowTemplate.Height = 24;
            this.GridGezgin.Size = new System.Drawing.Size(491, 150);
            this.GridGezgin.TabIndex = 3;
            this.GridGezgin.Visible = false;
            this.GridGezgin.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridGezgin_CellContentDoubleClick);
            this.GridGezgin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridGezgin_KeyPress);
            // 
            // gezginItem
            // 
            this.gezginItem.DataPropertyName = "ITEMCODE";
            this.gezginItem.Frozen = true;
            this.gezginItem.HeaderText = "Ürün";
            this.gezginItem.Name = "gezginItem";
            this.gezginItem.ReadOnly = true;
            this.gezginItem.Width = 448;
            // 
            // Class
            // 
            this.Class.DataPropertyName = "CLASS";
            this.Class.Frozen = true;
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            this.Class.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridGezgin);
            this.Controls.Add(this.GridItems);
            this.Controls.Add(this.BTNAktar);
            this.Controls.Add(this.BTNAra);
            this.Controls.Add(this.TXTCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Cross Reference Aktarım Modülü";
            ((System.ComponentModel.ISupportInitialize)(this.GridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridGezgin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTCode;
        private System.Windows.Forms.Button BTNAra;
        private System.Windows.Forms.Button BTNAktar;
        private System.Windows.Forms.DataGridView GridItems;
        private System.Windows.Forms.DataGridView GridGezgin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn gezginItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
    }
}

