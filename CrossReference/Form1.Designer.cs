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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem2 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.TXTCode = new System.Windows.Forms.TextBox();
            this.BTNAra = new System.Windows.Forms.Button();
            this.BTNAktar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.GRPLoader = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BTNSil = new System.Windows.Forms.Button();
            this.GridItems = new Telerik.WinControls.UI.RadGridView();
            this.GRPLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridItems.MasterTemplate)).BeginInit();
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
            this.BTNAra.Size = new System.Drawing.Size(57, 34);
            this.BTNAra.TabIndex = 1;
            this.BTNAra.Text = "Ara";
            this.BTNAra.UseVisualStyleBackColor = true;
            this.BTNAra.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTNAktar
            // 
            this.BTNAktar.Location = new System.Drawing.Point(548, 0);
            this.BTNAktar.Name = "BTNAktar";
            this.BTNAktar.Size = new System.Drawing.Size(164, 34);
            this.BTNAktar.TabIndex = 1;
            this.BTNAktar.Text = "Excelden Aktar";
            this.BTNAktar.UseVisualStyleBackColor = true;
            this.BTNAktar.Click += new System.EventHandler(this.BTNAktar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 18);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(308, 36);
            this.progressBar1.TabIndex = 4;
            // 
            // GRPLoader
            // 
            this.GRPLoader.Controls.Add(this.progressBar1);
            this.GRPLoader.Location = new System.Drawing.Point(548, 392);
            this.GRPLoader.Name = "GRPLoader";
            this.GRPLoader.Size = new System.Drawing.Size(317, 55);
            this.GRPLoader.TabIndex = 5;
            this.GRPLoader.TabStop = false;
            this.GRPLoader.Text = "Loader";
            this.GRPLoader.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(711, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Yeni Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BTNSil
            // 
            this.BTNSil.Location = new System.Drawing.Point(790, 0);
            this.BTNSil.Name = "BTNSil";
            this.BTNSil.Size = new System.Drawing.Size(80, 34);
            this.BTNSil.TabIndex = 7;
            this.BTNSil.Text = "Sil";
            this.BTNSil.UseVisualStyleBackColor = true;
            this.BTNSil.Visible = false;
            this.BTNSil.Click += new System.EventHandler(this.BTNSil_Click);
            // 
            // GridItems
            // 
            this.GridItems.BackColor = System.Drawing.SystemColors.Control;
            this.GridItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridItems.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridItems.Location = new System.Drawing.Point(0, 34);
            this.GridItems.Margin = new System.Windows.Forms.Padding(8);
            // 
            // 
            // 
            this.GridItems.MasterTemplate.AllowAddNewRow = false;
            this.GridItems.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Id";
            gridViewTextBoxColumn6.MinWidth = 12;
            gridViewTextBoxColumn6.Name = "Id";
            gridViewTextBoxColumn6.Width = 122;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "OENormal";
            gridViewTextBoxColumn7.HeaderText = "OEM";
            gridViewTextBoxColumn7.MinWidth = 12;
            gridViewTextBoxColumn7.Name = "OEM";
            gridViewTextBoxColumn7.Width = 375;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Marka";
            gridViewTextBoxColumn8.HeaderText = "Marka";
            gridViewTextBoxColumn8.MinWidth = 12;
            gridViewTextBoxColumn8.Name = "Marka";
            gridViewTextBoxColumn8.Width = 312;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "ProductNumber";
            gridViewTextBoxColumn9.HeaderText = "Ürün Kodu";
            gridViewTextBoxColumn9.MinWidth = 12;
            gridViewTextBoxColumn9.Name = "UrunKodu";
            gridViewTextBoxColumn9.Width = 312;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "CatalogName";
            gridViewTextBoxColumn10.HeaderText = "Katalog Adı";
            gridViewTextBoxColumn10.MinWidth = 12;
            gridViewTextBoxColumn10.Name = "CatalogName";
            gridViewTextBoxColumn10.Width = 188;
            this.GridItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.GridItems.MasterTemplate.EnableFiltering = true;
            gridViewSummaryItem2.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Count;
            gridViewSummaryItem2.AggregateExpression = null;
            gridViewSummaryItem2.FormatString = "{0}";
            gridViewSummaryItem2.Name = "RecordCount";
            this.GridItems.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem2}));
            this.GridItems.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GridItems.Name = "GridItems";
            this.GridItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridItems.Size = new System.Drawing.Size(1377, 517);
            this.GridItems.TabIndex = 8;
            this.GridItems.Text = "radGridView1";
            this.GridItems.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridItems_CellFormatting);
            this.GridItems.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GridItems_CellEndEdit);
            this.GridItems.UserAddingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.GridItems_UserAddingRow);
            this.GridItems.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.GridItems_UserAddedRow);
            this.GridItems.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GridItems_CellClick);
            this.GridItems.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GridItems_CellDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 568);
            this.Controls.Add(this.GridItems);
            this.Controls.Add(this.BTNSil);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GRPLoader);
            this.Controls.Add(this.BTNAktar);
            this.Controls.Add(this.BTNAra);
            this.Controls.Add(this.TXTCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cross Reference Aktarım Modülü";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.GRPLoader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTCode;
        private System.Windows.Forms.Button BTNAra;
        private System.Windows.Forms.Button BTNAktar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox GRPLoader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BTNSil;
        private Telerik.WinControls.UI.RadGridView GridItems;
    }
}

