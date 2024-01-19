namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myCalendar = new System.Windows.Forms.MonthCalendar();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Imp = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cb_work = new System.Windows.Forms.CheckBox();
            this.cb_study = new System.Windows.Forms.CheckBox();
            this.cb_personal = new System.Windows.Forms.CheckBox();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // myCalendar
            // 
            this.myCalendar.BackColor = System.Drawing.Color.Snow;
            this.myCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myCalendar.Location = new System.Drawing.Point(36, 47);
            this.myCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.myCalendar.MaxSelectionCount = 42;
            this.myCalendar.Name = "myCalendar";
            this.myCalendar.TabIndex = 1;
            this.myCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.Snow;
            this.checkedListBox1.ContextMenuStrip = this.contextMenu;
            this.checkedListBox1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(16)))), ((int)(((byte)(20)))));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "выберите дату"});
            this.checkedListBox1.Location = new System.Drawing.Point(313, 47);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(445, 212);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.TabStop = false;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkedListBox1_KeyDown);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Edit,
            this.Imp,
            this.Delete});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(155, 70);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // Edit
            // 
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(154, 22);
            this.Edit.Text = "Редактировать";
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Imp
            // 
            this.Imp.Checked = true;
            this.Imp.CheckOnClick = true;
            this.Imp.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Imp.Name = "Imp";
            this.Imp.Size = new System.Drawing.Size(154, 22);
            this.Imp.Text = "Важность";
            this.Imp.Click += new System.EventHandler(this.Imp_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(154, 22);
            this.Delete.Text = "Удалить";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(216, 47);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(310, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "задания";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Snow;
            this.listBox1.ContextMenuStrip = this.contextMenu;
            this.listBox1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.listBox1.Location = new System.Drawing.Point(313, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(445, 211);
            this.listBox1.TabIndex = 4;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(732, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "◩";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cb_work
            // 
            this.cb_work.AutoSize = true;
            this.cb_work.BackColor = System.Drawing.Color.Snow;
            this.cb_work.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_work.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(21)))), ((int)(((byte)(11)))));
            this.cb_work.Location = new System.Drawing.Point(313, 274);
            this.cb_work.Name = "cb_work";
            this.cb_work.Size = new System.Drawing.Size(101, 26);
            this.cb_work.TabIndex = 9;
            this.cb_work.Text = "Работа";
            this.cb_work.UseVisualStyleBackColor = false;
            this.cb_work.CheckedChanged += new System.EventHandler(this.cb_work_CheckedChanged);
            // 
            // cb_study
            // 
            this.cb_study.AutoSize = true;
            this.cb_study.BackColor = System.Drawing.Color.Snow;
            this.cb_study.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_study.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(148)))), ((int)(((byte)(24)))));
            this.cb_study.Location = new System.Drawing.Point(494, 274);
            this.cb_study.Name = "cb_study";
            this.cb_study.Size = new System.Drawing.Size(89, 26);
            this.cb_study.TabIndex = 10;
            this.cb_study.Text = "Учёба";
            this.cb_study.UseVisualStyleBackColor = false;
            this.cb_study.CheckedChanged += new System.EventHandler(this.cb_study_CheckedChanged);
            // 
            // cb_personal
            // 
            this.cb_personal.AutoSize = true;
            this.cb_personal.BackColor = System.Drawing.Color.Snow;
            this.cb_personal.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_personal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(92)))), ((int)(((byte)(136)))));
            this.cb_personal.Location = new System.Drawing.Point(656, 274);
            this.cb_personal.Name = "cb_personal";
            this.cb_personal.Size = new System.Drawing.Size(101, 26);
            this.cb_personal.TabIndex = 11;
            this.cb_personal.Text = "Личное";
            this.cb_personal.UseVisualStyleBackColor = false;
            this.cb_personal.CheckedChanged += new System.EventHandler(this.cb_personal_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(132)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(785, 325);
            this.Controls.Add(this.cb_personal);
            this.Controls.Add(this.cb_study);
            this.Controls.Add(this.cb_work);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.myCalendar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToDo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar myCalendar;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem Imp;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.CheckBox cb_work;
        private System.Windows.Forms.CheckBox cb_study;
        private System.Windows.Forms.CheckBox cb_personal;
    }
}

