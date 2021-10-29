
namespace Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьНовыйСчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПростойДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеДоктаСДиаграммойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new PavComponents.TreeView();
            this.excelText1 = new PavComponents.ExcelText(this.components);
            this.word_Custom_Table_Component1 = new PavComponents.Word_Custom_Table_Component(this.components);
            this.shPDFChart1 = new PavComponents.ShPDFChart(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьНовыйСчётToolStripMenuItem,
            this.редактироватьЗаписьToolStripMenuItem,
            this.удалитьЗаписьToolStripMenuItem,
            this.создатьПростойДокументToolStripMenuItem,
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem,
            this.созданиеДоктаСДиаграммойToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(418, 148);
            // 
            // создатьНовыйСчётToolStripMenuItem
            // 
            this.создатьНовыйСчётToolStripMenuItem.Name = "создатьНовыйСчётToolStripMenuItem";
            this.создатьНовыйСчётToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.создатьНовыйСчётToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.создатьНовыйСчётToolStripMenuItem.Text = "Создать новый счёт";
            this.создатьНовыйСчётToolStripMenuItem.Click += new System.EventHandler(this.создатьНовыйСчётToolStripMenuItem_Click);
            // 
            // редактироватьЗаписьToolStripMenuItem
            // 
            this.редактироватьЗаписьToolStripMenuItem.Name = "редактироватьЗаписьToolStripMenuItem";
            this.редактироватьЗаписьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.редактироватьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.редактироватьЗаписьToolStripMenuItem.Text = "Редактировать запись";
            this.редактироватьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьЗаписьToolStripMenuItem_Click);
            // 
            // удалитьЗаписьToolStripMenuItem
            // 
            this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
            this.удалитьЗаписьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись ";
            this.удалитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗаписьToolStripMenuItem_Click);
            // 
            // создатьПростойДокументToolStripMenuItem
            // 
            this.создатьПростойДокументToolStripMenuItem.Name = "создатьПростойДокументToolStripMenuItem";
            this.создатьПростойДокументToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.создатьПростойДокументToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.создатьПростойДокументToolStripMenuItem.Text = "Создать простой документ";
            this.создатьПростойДокументToolStripMenuItem.Click += new System.EventHandler(this.создатьПростойДокументToolStripMenuItem_Click);
            // 
            // создатьДоктСНастраиваемойТаблицейToolStripMenuItem
            // 
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.Name = "создатьДоктСНастраиваемойТаблицейToolStripMenuItem";
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.Text = "Создать док-т с настраиваемой таблицей";
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.Click += new System.EventHandler(this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem_Click);
            // 
            // созданиеДоктаСДиаграммойToolStripMenuItem
            // 
            this.созданиеДоктаСДиаграммойToolStripMenuItem.Name = "созданиеДоктаСДиаграммойToolStripMenuItem";
            this.созданиеДоктаСДиаграммойToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.созданиеДоктаСДиаграммойToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.созданиеДоктаСДиаграммойToolStripMenuItem.Text = "Создание док-та с диаграммой";
            this.созданиеДоктаСДиаграммойToolStripMenuItem.Click += new System.EventHandler(this.созданиеДоктаСДиаграммойToolStripMenuItem_Click);
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.Location = new System.Drawing.Point(12, 34);
            this.treeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView.Name = "treeView";
            this.treeView.SelectedNodeIndex = -1;
            this.treeView.Size = new System.Drawing.Size(514, 412);
            this.treeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 451);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.treeView);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "FormBills";
            this.Activated += new System.EventHandler(this.FormBills_Load_1);
            this.Load += new System.EventHandler(this.FormBills_Load_1);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PavComponents.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem создатьНовыйСчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПростойДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДоктСНастраиваемойТаблицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеДоктаСДиаграммойToolStripMenuItem;
        private PavComponents.ExcelText excelText1;
        private PavComponents.Word_Custom_Table_Component word_Custom_Table_Component1;
        private PavComponents.ShPDFChart shPDFChart1;
    }
}