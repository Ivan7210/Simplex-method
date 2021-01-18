using System.Drawing;

namespace Simplex_method
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public override System.Drawing.Size MinimumSize { get; set; } = new Size(990, 490);

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.clearButton = new System.Windows.Forms.Button();
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
            this.hideBasisColunmsChek = new System.Windows.Forms.CheckBox();
            this.numberOfStep = new System.Windows.Forms.Label();
            this.nextStepButton = new System.Windows.Forms.Button();
            this.prevStepButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.coordinates = new System.Windows.Forms.Label();
            this.schedule = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).BeginInit();
            this.SuspendLayout();
            // 
            // Matrix
            // 
            this.Matrix.AllowUserToAddRows = false;
            this.Matrix.AllowUserToDeleteRows = false;
            this.Matrix.AllowUserToResizeRows = false;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Matrix.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Matrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Matrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.basis,
            this.x1,
            this.x2,
            this.x3,
            this.b});
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Matrix.DefaultCellStyle = dataGridViewCellStyle34;
            this.Matrix.Location = new System.Drawing.Point(455, 7);
            this.Matrix.MultiSelect = false;
            this.Matrix.Name = "Matrix";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Matrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle35;
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
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.Black;
            this.basis.DefaultCellStyle = dataGridViewCellStyle33;
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
            this.addUnknownButton.Location = new System.Drawing.Point(349, 68);
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
            this.textNumberOfUnknown.Location = new System.Drawing.Point(256, 66);
            this.textNumberOfUnknown.Name = "textNumberOfUnknown";
            this.textNumberOfUnknown.Size = new System.Drawing.Size(87, 26);
            this.textNumberOfUnknown.TabIndex = 3;
            this.textNumberOfUnknown.Text = "3";
            this.textNumberOfUnknown.TextChanged += new System.EventHandler(this.textNumberOfUnknown_TextChanged);
            // 
            // subtractUnknownButton
            // 
            this.subtractUnknownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.subtractUnknownButton.Location = new System.Drawing.Point(381, 68);
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
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество неизвестных:";
            // 
            // addLimitButton
            // 
            this.addLimitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addLimitButton.Location = new System.Drawing.Point(349, 100);
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
            this.subtractLimitButton.Location = new System.Drawing.Point(381, 100);
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
            this.textNumberOfLimits.Location = new System.Drawing.Point(256, 100);
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
            this.label2.Location = new System.Drawing.Point(13, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество ограничений:";
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.solveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.solveButton.Location = new System.Drawing.Point(846, 350);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(110, 31);
            this.solveButton.TabIndex = 6;
            this.solveButton.Text = "Решить";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solve_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.clearButton.Location = new System.Drawing.Point(455, 350);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(110, 31);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clear_Click);
            // 
            // minMaxBox
            // 
            this.minMaxBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minMaxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.minMaxBox.FormattingEnabled = true;
            this.minMaxBox.Items.AddRange(new object[] {
            "min",
            "max"});
            this.minMaxBox.Location = new System.Drawing.Point(256, 132);
            this.minMaxBox.Name = "minMaxBox";
            this.minMaxBox.Size = new System.Drawing.Size(151, 28);
            this.minMaxBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(13, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Задача оптимизации:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(13, 204);
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
            this.label5.Location = new System.Drawing.Point(13, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Вид дробей:";
            // 
            // solutionMethodBox
            // 
            this.solutionMethodBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.solutionMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solutionMethodBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.solutionMethodBox.FormattingEnabled = true;
            this.solutionMethodBox.Items.AddRange(new object[] {
            "Симплекс",
            "Иск. базиса",
            "Графический"});
            this.solutionMethodBox.Location = new System.Drawing.Point(256, 200);
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
            this.fractionViewBox.Location = new System.Drawing.Point(256, 166);
            this.fractionViewBox.Name = "fractionViewBox";
            this.fractionViewBox.Size = new System.Drawing.Size(151, 28);
            this.fractionViewBox.TabIndex = 13;
            this.fractionViewBox.SelectedIndexChanged += new System.EventHandler(this.fractionViewBox_SelectedIndexChanged);
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
            this.baseSolution.Location = new System.Drawing.Point(17, 269);
            this.baseSolution.MultiSelect = false;
            this.baseSolution.Name = "baseSolution";
            this.baseSolution.RowHeadersVisible = false;
            this.baseSolution.RowHeadersWidth = 51;
            this.baseSolution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.baseSolution.Size = new System.Drawing.Size(390, 75);
            this.baseSolution.TabIndex = 14;
            this.baseSolution.Visible = false;
            this.baseSolution.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.baseSolution_CellValueChanged);
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
            this.label6.Location = new System.Drawing.Point(13, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Задать начальную угловую точку:";
            // 
            // bschek
            // 
            this.bschek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bschek.AutoSize = true;
            this.bschek.Location = new System.Drawing.Point(389, 246);
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
            this.label7.Location = new System.Drawing.Point(13, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Скрыть базисные столбцы?";
            // 
            // hideBasisColunmsChek
            // 
            this.hideBasisColunmsChek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hideBasisColunmsChek.AutoSize = true;
            this.hideBasisColunmsChek.Checked = true;
            this.hideBasisColunmsChek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideBasisColunmsChek.Location = new System.Drawing.Point(389, 361);
            this.hideBasisColunmsChek.Name = "hideBasisColunmsChek";
            this.hideBasisColunmsChek.Size = new System.Drawing.Size(18, 17);
            this.hideBasisColunmsChek.TabIndex = 18;
            this.hideBasisColunmsChek.UseVisualStyleBackColor = true;
            this.hideBasisColunmsChek.CheckedChanged += new System.EventHandler(this.hideBasisColunmsChek_CheckedChanged);
            // 
            // numberOfStep
            // 
            this.numberOfStep.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numberOfStep.AutoSize = true;
            this.numberOfStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numberOfStep.Location = new System.Drawing.Point(658, 350);
            this.numberOfStep.Name = "numberOfStep";
            this.numberOfStep.Size = new System.Drawing.Size(88, 29);
            this.numberOfStep.TabIndex = 23;
            this.numberOfStep.Text = "Ввод...";
            // 
            // nextStepButton
            // 
            this.nextStepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nextStepButton.Location = new System.Drawing.Point(775, 350);
            this.nextStepButton.Name = "nextStepButton";
            this.nextStepButton.Size = new System.Drawing.Size(65, 31);
            this.nextStepButton.TabIndex = 6;
            this.nextStepButton.Text = ">>";
            this.toolTip.SetToolTip(this.nextStepButton, "Следующий шаг решения");
            this.nextStepButton.UseVisualStyleBackColor = true;
            this.nextStepButton.Click += new System.EventHandler(this.nextStepButton_Click);
            // 
            // prevStepButton
            // 
            this.prevStepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevStepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.prevStepButton.Location = new System.Drawing.Point(571, 350);
            this.prevStepButton.Name = "prevStepButton";
            this.prevStepButton.Size = new System.Drawing.Size(65, 31);
            this.prevStepButton.TabIndex = 7;
            this.prevStepButton.Text = "<<";
            this.toolTip.SetToolTip(this.prevStepButton, "Предыдущий шаг решения");
            this.prevStepButton.UseVisualStyleBackColor = true;
            this.prevStepButton.Click += new System.EventHandler(this.prevStepButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(17, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(92, 48);
            this.saveButton.TabIndex = 26;
            this.toolTip.SetToolTip(this.saveButton, "Сохранить текущую матрицу в файл");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.Location = new System.Drawing.Point(115, 7);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(92, 48);
            this.loadButton.TabIndex = 28;
            this.toolTip.SetToolTip(this.loadButton, "Загрузить матрицу из файла");
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.Location = new System.Drawing.Point(217, 7);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(92, 48);
            this.helpButton.TabIndex = 29;
            this.toolTip.SetToolTip(this.helpButton, "Справка");
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.Location = new System.Drawing.Point(315, 7);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(92, 48);
            this.infoButton.TabIndex = 30;
            this.toolTip.SetToolTip(this.infoButton, "О программе");
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // Log
            // 
            this.Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log.Cursor = System.Windows.Forms.Cursors.Default;
            this.Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Log.Location = new System.Drawing.Point(-2, 420);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.Size = new System.Drawing.Size(977, 30);
            this.Log.TabIndex = 32;
            this.Log.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // coordinates
            // 
            this.coordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coordinates.AutoSize = true;
            this.coordinates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coordinates.Location = new System.Drawing.Point(956, 316);
            this.coordinates.Name = "coordinates";
            this.coordinates.Size = new System.Drawing.Size(31, 22);
            this.coordinates.TabIndex = 33;
            this.coordinates.Text = "    ";
            this.coordinates.Visible = false;
            // 
            // schedule
            // 
            this.schedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.schedule.Location = new System.Drawing.Point(950, 7);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(10, 337);
            this.schedule.TabIndex = 31;
            this.schedule.TabStop = false;
            this.schedule.Visible = false;
            this.schedule.SizeChanged += new System.EventHandler(this.schedule_SizeChanged);
            this.schedule.MouseEnter += new System.EventHandler(this.schedule_MouseEnter);
            this.schedule.MouseLeave += new System.EventHandler(this.schedule_MouseLeave);
            this.schedule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.schedule_MouseMove);
            this.schedule.Resize += new System.EventHandler(this.schedule_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(972, 443);
            this.Controls.Add(this.coordinates);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.schedule);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.numberOfStep);
            this.Controls.Add(this.hideBasisColunmsChek);
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
            this.Controls.Add(this.clearButton);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Simplex method";
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).EndInit();
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
        private System.Windows.Forms.Button clearButton;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox hideBasisColunmsChek;
        private System.Windows.Forms.Label numberOfStep;
        private System.Windows.Forms.Button nextStepButton;
        private System.Windows.Forms.Button prevStepButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.DataGridViewTextBoxColumn basis;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2;
        private System.Windows.Forms.DataGridViewTextBoxColumn x3;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label coordinates;
        private System.Windows.Forms.PictureBox schedule;
    }
}

