﻿
namespace Views
{
    partial class FormBills
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
            this.treeView = new PavlovaComponents.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьНовыйСчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПростойДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеДоктаСДиаграммойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.Location = new System.Drawing.Point(12, 43);
            this.treeView.Name = "treeView";
            this.treeView.SelectedNodeIndex = -1;
            this.treeView.Size = new System.Drawing.Size(514, 395);
            this.treeView.TabIndex = 0;
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
            this.contextMenuStrip.Size = new System.Drawing.Size(418, 176);
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
            // 
            // удалитьЗаписьToolStripMenuItem
            // 
            this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
            this.удалитьЗаписьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись ";
            // 
            // создатьПростойДокументToolStripMenuItem
            // 
            this.создатьПростойДокументToolStripMenuItem.Name = "создатьПростойДокументToolStripMenuItem";
            this.создатьПростойДокументToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.создатьПростойДокументToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.создатьПростойДокументToolStripMenuItem.Text = "Создать простой документ";
            // 
            // создатьДоктСНастраиваемойТаблицейToolStripMenuItem
            // 
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.Name = "создатьДоктСНастраиваемойТаблицейToolStripMenuItem";
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.создатьДоктСНастраиваемойТаблицейToolStripMenuItem.Text = "Создать док-т с настраиваемой таблицей";
            // 
            // созданиеДоктаСДиаграммойToolStripMenuItem
            // 
            this.созданиеДоктаСДиаграммойToolStripMenuItem.Name = "созданиеДоктаСДиаграммойToolStripMenuItem";
            this.созданиеДоктаСДиаграммойToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.созданиеДоктаСДиаграммойToolStripMenuItem.Size = new System.Drawing.Size(417, 24);
            this.созданиеДоктаСДиаграммойToolStripMenuItem.Text = "Создание док-та с диаграммой";
            // 
            // FormBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 450);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.treeView);
            this.KeyPreview = true;
            this.Name = "FormBills";
            this.Text = "FormBills";
            this.Activated += new System.EventHandler(this.FormBills_Load_1);
            this.Load += new System.EventHandler(this.FormBills_Load_1);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PavlovaComponents.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem создатьНовыйСчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПростойДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДоктСНастраиваемойТаблицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеДоктаСДиаграммойToolStripMenuItem;
    }
}