using System.Drawing;

namespace Simplex_method
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public override System.Drawing.Size MinimumSize { get; set; } = new Size(990, 450);

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Matrix = new System.Windows.Forms.DataGridView();
            this.basis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addUnknownButton = new System.Windows.Forms.Button();
            this.textNumberOfUnknown = new System.Windows.Forms.TextBox();
            this.subtractUnknownButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addLimitButton = new System.Windows.Forms.Button();
            this.subtractLimitButton = new System.Windows.Forms.Button();
            this.textNumberOfLimits = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.minMaxBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.solutionMethodBox = new System.Windows.Forms.ComboBox();
            this.fractionViewBox = new System.Windows.Forms.ComboBox();
            this.baseSolution = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.bschek = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.displayBasisColunmsChek = new System.Windows.Forms.CheckBox();
            this.numberOfStep = new System.Windows.Forms.Label();
            this.nextStepButton = new System.Windows.Forms.Button();
            this.prevStepButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSolution)).BeginInit();
            this.SuspendLayout();
            // 
            // Matrix
            // 
            this.Matrix.AllowUserToAddRows = false;
            this.Matrix.AllowUserToDeleteRows = false;
            this.Matrix.AllowUserToResizeRows = false;
            this.Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Matrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.basis,
            this.x1,
            this.x2,
            this.x3,
            this.b});
            this.Matrix.Location = new System.Drawing.Point(454, 10);
            this.Matrix.MultiSelect = false;
            this.Matrix.Name = "Matrix";
            this.Matrix.RowHeadersVisible = false;
            this.Matrix.RowHeadersWidth = 51;
            this.Matrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Matrix.Size = new System.Drawing.Size(501, 337);
            this.Matrix.TabIndex = 0;
            this.Matrix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Matrix_CellContentClick);
            this.Matrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Matrix_CellValueChanged);
            // 
            // basis
            // 
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            this.basis.DefaultCellStyle = dataGridViewCellStyle2;
            this.basis.Frozen = true;
            this.basis.HeaderText = "";
            this.basis.MinimumWidth = 6;
            this.basis.Name = "basis";
            this.basis.ReadOnly = true;
            this.basis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.basis.Width = 25;
            // 
            // x1
            // 
            this.x1.HeaderText = "x1";
            this.x1.MinimumWidth = 6;
            this.x1.Name = "x1";
            this.x1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.x1.Width = 50;
            // 
            // x2
            // 
            this.x2.HeaderText = "x2";
            this.x2.MinimumWidth = 6;
            this.x2.Name = "x2";
            this.x2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.x2.Width = 50;
            // 
            // x3
            // 
            this.x3.HeaderText = "x3";
            this.x3.MinimumWidth = 6;
            this.x3.Name = "x3";
            this.x3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.x3.Width = 50;
            // 
            // b
            // 
            this.b.HeaderText = "b";
            this.b.MinimumWidth = 6;
            this.b.Name = "b";
            this.b.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.b.Width = 50;
            // 
            // addUnknownButton
            // 
            this.addUnknownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addUnknownButton.Location = new System.Drawing.Point(348, 71);
            this.addUnknownButton.Name = "addUnknownButton";
            this.addUnknownButton.Size = new System.Drawing.Size(26, 26);
            this.addUnknownButton.TabIndex = 2;
            this.addUnknownButton.Text = "+";
            this.addUnknownButton.UseVisualStyleBackColor = true;
            this.addUnknownButton.Click += new System.EventHandler(this.addUnknown_Click);
            // 
            // textNumberOfUnknown
            // 
            this.textNumberOfUnknown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textNumberOfUnknown.Location = new System.Drawing.Point(255, 69);
            this.textNumberOfUnknown.Name = "textNumberOfUnknown";
            this.textNumberOfUnknown.Size = new System.Drawing.Size(87, 26);
            this.textNumberOfUnknown.TabIndex = 3;
            this.textNumberOfUnknown.Text = "3";
            this.textNumberOfUnknown.TextChanged += new System.EventHandler(this.textNumberOfUnknown_TextChanged);
            // 
            // subtractUnknownButton
            // 
            this.subtractUnknownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.subtractUnknownButton.Location = new System.Drawing.Point(380, 71);
            this.subtractUnknownButton.Name = "subtractUnknownButton";
            this.subtractUnknownButton.Size = new System.Drawing.Size(26, 26);
            this.subtractUnknownButton.TabIndex = 2;
            this.subtractUnknownButton.Text = "-";
            this.subtractUnknownButton.UseVisualStyleBackColor = true;
            this.subtractUnknownButton.Click += new System.EventHandler(this.subtractUnknown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество неизвестных:";
            // 
            // addLimitButton
            // 
            this.addLimitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addLimitButton.Location = new System.Drawing.Point(348, 103);
            this.addLimitButton.Name = "addLimitButton";
            this.addLimitButton.Size = new System.Drawing.Size(26, 26);
            this.addLimitButton.TabIndex = 2;
            this.addLimitButton.Text = "+";
            this.addLimitButton.UseVisualStyleBackColor = true;
            this.addLimitButton.Click += new System.EventHandler(this.addLimit_Click);
            // 
            // subtractLimitButton
            // 
            this.subtractLimitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.subtractLimitButton.Location = new System.Drawing.Point(380, 103);
            this.subtractLimitButton.Name = "subtractLimitButton";
            this.subtractLimitButton.Size = new System.Drawing.Size(26, 26);
            this.subtractLimitButton.TabIndex = 2;
            this.subtractLimitButton.Text = "-";
            this.subtractLimitButton.UseVisualStyleBackColor = true;
            this.subtractLimitButton.Click += new System.EventHandler(this.subtractLimit_Click);
            // 
            // textNumberOfLimits
            // 
            this.textNumberOfLimits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textNumberOfLimits.Location = new System.Drawing.Point(255, 103);
            this.textNumberOfLimits.Name = "textNumberOfLimits";
            this.textNumberOfLimits.Size = new System.Drawing.Size(87, 26);
            this.textNumberOfLimits.TabIndex = 3;
            this.textNumberOfLimits.Text = "3";
            this.textNumberOfLimits.TextChanged += new System.EventHandler(this.textNumberOfLimits_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество ограничений:";
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.solveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.solveButton.Location = new System.Drawing.Point(845, 353);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(110, 31);
            this.solveButton.TabIndex = 6;
            this.solveButton.Text = "Решить";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solve_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.backButton.Location = new System.Drawing.Point(454, 353);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(110, 31);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Очистить";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.back_Click);
            // 
            // minMaxBox
            // 
            this.minMaxBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minMaxBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minMaxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.minMaxBox.FormattingEnabled = true;
            this.minMaxBox.Items.AddRange(new object[] {
            "min",
            "max"});
            this.minMaxBox.Location = new System.Drawing.Point(255, 135);
            this.minMaxBox.Name = "minMaxBox";
            this.minMaxBox.Size = new System.Drawing.Size(151, 28);
            this.minMaxBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Задача оптимизации:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Метод решения:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Вид дробей:";
            // 
            // solutionMethodBox
            // 
            this.solutionMethodBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.solutionMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solutionMethodBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.solutionMethodBox.FormattingEnabled = true;
            this.solutionMethodBox.Items.AddRange(new object[] {
            "Симплекс",
            "Иск. базиса",
            "Графический"});
            this.solutionMethodBox.Location = new System.Drawing.Point(255, 203);
            this.solutionMethodBox.Name = "solutionMethodBox";
            this.solutionMethodBox.Size = new System.Drawing.Size(151, 28);
            this.solutionMethodBox.TabIndex = 12;
            this.solutionMethodBox.SelectedIndexChanged += new System.EventHandler(this.solutionMethodBox_SelectedIndexChanged);
            // 
            // fractionViewBox
            // 
            this.fractionViewBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fractionViewBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fractionViewBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fractionViewBox.FormattingEnabled = true;
            this.fractionViewBox.Items.AddRange(new object[] {
            "Обычные",
            "Десятичные"});
            this.fractionViewBox.Location = new System.Drawing.Point(255, 169);
            this.fractionViewBox.Name = "fractionViewBox";
            this.fractionViewBox.Size = new System.Drawing.Size(151, 28);
            this.fractionViewBox.TabIndex = 13;
            // 
            // baseSolution
            // 
            this.baseSolution.AllowUserToAddRows = false;
            this.baseSolution.AllowUserToDeleteRows = false;
            this.baseSolution.AllowUserToResizeRows = false;
            this.baseSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.baseSolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.baseSolution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.baseSolution.Location = new System.Drawing.Point(16, 272);
            this.baseSolution.MultiSelect = false;
            this.baseSolution.Name = "baseSolution";
            this.baseSolution.RowHeadersVisible = false;
            this.baseSolution.RowHeadersWidth = 51;
            this.baseSolution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.baseSolution.Size = new System.Drawing.Size(390, 75);
            this.baseSolution.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "x1";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "x2";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "x3";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(12, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Задать начальную угловую точку:";
            // 
            // bschek
            // 
            this.bschek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bschek.AutoSize = true;
            this.bschek.Checked = true;
            this.bschek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bschek.Location = new System.Drawing.Point(388, 249);
            this.bschek.Name = "bschek";
            this.bschek.Size = new System.Drawing.Size(18, 17);
            this.bschek.TabIndex = 16;
            this.bschek.UseVisualStyleBackColor = true;
            this.bschek.CheckedChanged += new System.EventHandler(this.bschek_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(12, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(284, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Отображать базисные столбцы?";
            // 
            // displayBasisColunmsChek
            // 
            this.displayBasisColunmsChek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.displayBasisColunmsChek.AutoSize = true;
            this.displayBasisColunmsChek.Checked = true;
            this.displayBasisColunmsChek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayBasisColunmsChek.Location = new System.Drawing.Point(388, 364);
            this.displayBasisColunmsChek.Name = "displayBasisColunmsChek";
            this.displayBasisColunmsChek.Size = new System.Drawing.Size(18, 17);
            this.displayBasisColunmsChek.TabIndex = 18;
            this.displayBasisColunmsChek.UseVisualStyleBackColor = true;
            // 
            // numberOfStep
            // 
            this.numberOfStep.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numberOfStep.AutoSize = true;
            this.numberOfStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numberOfStep.Location = new System.Drawing.Point(657, 353);
            this.numberOfStep.Name = "numberOfStep";
            this.numberOfStep.Size = new System.Drawing.Size(88, 29);
            this.numberOfStep.TabIndex = 23;
            this.numberOfStep.Text = "Ввод...";
            // 
            // nextStepButton
            // 
            this.nextStepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nextStepButton.Location = new System.Drawing.Point(774, 353);
            this.nextStepButton.Name = "nextStepButton";
            this.nextStepButton.Size = new System.Drawing.Size(65, 31);
            this.nextStepButton.TabIndex = 6;
            this.nextStepButton.Text = ">>";
            this.nextStepButton.UseVisualStyleBackColor = true;
            this.nextStepButton.Click += new System.EventHandler(this.nextStepButton_Click);
            // 
            // prevStepButton
            // 
            this.prevStepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.prevStepButton.Location = new System.Drawing.Point(570, 353);
            this.prevStepButton.Name = "prevStepButton";
            this.prevStepButton.Size = new System.Drawing.Size(65, 31);
            this.prevStepButton.TabIndex = 7;
            this.prevStepButton.Text = "<<";
            this.prevStepButton.UseVisualStyleBackColor = true;
            this.prevStepButton.Click += new System.EventHandler(this.prevStepButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(16, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(92, 48);
            this.saveButton.TabIndex = 26;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.Location = new System.Drawing.Point(114, 10);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(92, 48);
            this.loadButton.TabIndex = 28;
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.Location = new System.Drawing.Point(216, 10);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(92, 48);
            this.helpButton.TabIndex = 29;
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // infoButton
            // 
            this.infoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.Location = new System.Drawing.Point(314, 10);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(92, 48);
            this.infoButton.TabIndex = 30;
            this.infoButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(972, 403);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.numberOfStep);
            this.Controls.Add(this.displayBasisColunmsChek);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bschek);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.baseSolution);
            this.Controls.Add(this.fractionViewBox);
            this.Controls.Add(this.solutionMethodBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minMaxBox);
            this.Controls.Add(this.prevStepButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.nextStepButton);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textNumberOfLimits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subtractLimitButton);
            this.Controls.Add(this.textNumberOfUnknown);
            this.Controls.Add(this.addLimitButton);
            this.Controls.Add(this.subtractUnknownButton);
            this.Controls.Add(this.addUnknownButton);
            this.Controls.Add(this.Matrix);
            this.Name = "Form1";
            this.Text = "Simplex method";
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Matrix;
        private System.Windows.Forms.Button addUnknownButton;
        private System.Windows.Forms.TextBox textNumberOfUnknown;
        private System.Windows.Forms.Button subtractUnknownButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addLimitButton;
        private System.Windows.Forms.Button subtractLimitButton;
        private System.Windows.Forms.TextBox textNumberOfLimits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox minMaxBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox solutionMethodBox;
        private System.Windows.Forms.ComboBox fractionViewBox;
        private System.Windows.Forms.DataGridView baseSolution;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox bschek;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn basis;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2;
        private System.Windows.Forms.DataGridViewTextBoxColumn x3;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox displayBasisColunmsChek;
        private System.Windows.Forms.Label numberOfStep;
        private System.Windows.Forms.Button nextStepButton;
        private System.Windows.Forms.Button prevStepButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button infoButton;
    }
}

