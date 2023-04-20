namespace zmelecDemo {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_SerialPortRefresh = new System.Windows.Forms.Button();
            this.btn_SerialPortOpen = new System.Windows.Forms.Button();
            this.cmb_SerialPortIndex = new System.Windows.Forms.ComboBox();
            this.label162 = new System.Windows.Forms.Label();
            this.lablel_SerialPortStatus = new System.Windows.Forms.Label();
            this.txb_DataShow = new System.Windows.Forms.TextBox();
            this.btn_ClearData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_len = new System.Windows.Forms.Label();
            this.chb_check = new System.Windows.Forms.CheckBox();
            this.lb_checkValue = new System.Windows.Forms.Label();
            this.txb_Data = new System.Windows.Forms.TextBox();
            this.btn_creat = new System.Windows.Forms.Button();
            this.btn_creatAndSend = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btn_SerialPortRefresh);
            this.groupBox4.Controls.Add(this.btn_SerialPortOpen);
            this.groupBox4.Controls.Add(this.cmb_SerialPortIndex);
            this.groupBox4.Controls.Add(this.label162);
            this.groupBox4.Controls.Add(this.lablel_SerialPortStatus);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(690, 38);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            // 
            // btn_SerialPortRefresh
            // 
            this.btn_SerialPortRefresh.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SerialPortRefresh.Location = new System.Drawing.Point(359, 10);
            this.btn_SerialPortRefresh.Name = "btn_SerialPortRefresh";
            this.btn_SerialPortRefresh.Size = new System.Drawing.Size(75, 23);
            this.btn_SerialPortRefresh.TabIndex = 3;
            this.btn_SerialPortRefresh.Tag = "Fresh";
            this.btn_SerialPortRefresh.Text = "刷新串口";
            this.btn_SerialPortRefresh.UseVisualStyleBackColor = true;
            this.btn_SerialPortRefresh.Click += new System.EventHandler(this.btn_SerialPortOperate);
            // 
            // btn_SerialPortOpen
            // 
            this.btn_SerialPortOpen.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SerialPortOpen.Location = new System.Drawing.Point(278, 10);
            this.btn_SerialPortOpen.Name = "btn_SerialPortOpen";
            this.btn_SerialPortOpen.Size = new System.Drawing.Size(75, 23);
            this.btn_SerialPortOpen.TabIndex = 2;
            this.btn_SerialPortOpen.Tag = "Open/Close";
            this.btn_SerialPortOpen.Text = "打开串口";
            this.btn_SerialPortOpen.UseVisualStyleBackColor = true;
            this.btn_SerialPortOpen.Click += new System.EventHandler(this.btn_SerialPortOperate);
            // 
            // cmb_SerialPortIndex
            // 
            this.cmb_SerialPortIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SerialPortIndex.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SerialPortIndex.FormattingEnabled = true;
            this.cmb_SerialPortIndex.Location = new System.Drawing.Point(64, 11);
            this.cmb_SerialPortIndex.Name = "cmb_SerialPortIndex";
            this.cmb_SerialPortIndex.Size = new System.Drawing.Size(208, 21);
            this.cmb_SerialPortIndex.TabIndex = 1;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(5, 15);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(53, 12);
            this.label162.TabIndex = 0;
            this.label162.Text = "串口号：";
            // 
            // lablel_SerialPortStatus
            // 
            this.lablel_SerialPortStatus.AutoSize = true;
            this.lablel_SerialPortStatus.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lablel_SerialPortStatus.Location = new System.Drawing.Point(440, 15);
            this.lablel_SerialPortStatus.Name = "lablel_SerialPortStatus";
            this.lablel_SerialPortStatus.Size = new System.Drawing.Size(111, 13);
            this.lablel_SerialPortStatus.TabIndex = 4;
            this.lablel_SerialPortStatus.Text = "串口状态：已关闭";
            // 
            // txb_DataShow
            // 
            this.txb_DataShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txb_DataShow.Font = new System.Drawing.Font("宋体", 9F);
            this.txb_DataShow.Location = new System.Drawing.Point(9, 184);
            this.txb_DataShow.Margin = new System.Windows.Forms.Padding(0);
            this.txb_DataShow.MaxLength = 0;
            this.txb_DataShow.Multiline = true;
            this.txb_DataShow.Name = "txb_DataShow";
            this.txb_DataShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_DataShow.Size = new System.Drawing.Size(609, 257);
            this.txb_DataShow.TabIndex = 44;
            // 
            // btn_ClearData
            // 
            this.btn_ClearData.Location = new System.Drawing.Point(621, 418);
            this.btn_ClearData.Name = "btn_ClearData";
            this.btn_ClearData.Size = new System.Drawing.Size(75, 20);
            this.btn_ClearData.TabIndex = 45;
            this.btn_ClearData.Tag = "0";
            this.btn_ClearData.Text = "清空数据";
            this.btn_ClearData.UseVisualStyleBackColor = true;
            this.btn_ClearData.Click += new System.EventHandler(this.btn_ClearData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "报文头：55 AA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_creatAndSend);
            this.groupBox1.Controls.Add(this.btn_creat);
            this.groupBox1.Controls.Add(this.txb_Data);
            this.groupBox1.Controls.Add(this.lb_checkValue);
            this.groupBox1.Controls.Add(this.chb_check);
            this.groupBox1.Controls.Add(this.lb_len);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 104);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送报文设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "报文尾：5A";
            // 
            // lb_len
            // 
            this.lb_len.AutoSize = true;
            this.lb_len.Location = new System.Drawing.Point(318, 33);
            this.lb_len.Name = "lb_len";
            this.lb_len.Size = new System.Drawing.Size(83, 12);
            this.lb_len.TabIndex = 48;
            this.lb_len.Text = "报文总长度：-";
            // 
            // chb_check
            // 
            this.chb_check.AutoSize = true;
            this.chb_check.Location = new System.Drawing.Point(418, 33);
            this.chb_check.Name = "chb_check";
            this.chb_check.Size = new System.Drawing.Size(72, 16);
            this.chb_check.TabIndex = 49;
            this.chb_check.Text = "增加校验";
            this.chb_check.UseVisualStyleBackColor = true;
            // 
            // lb_checkValue
            // 
            this.lb_checkValue.AutoSize = true;
            this.lb_checkValue.Location = new System.Drawing.Point(241, 71);
            this.lb_checkValue.Name = "lb_checkValue";
            this.lb_checkValue.Size = new System.Drawing.Size(59, 12);
            this.lb_checkValue.TabIndex = 50;
            this.lb_checkValue.Text = "校验值：-";
            // 
            // txb_Data
            // 
            this.txb_Data.Location = new System.Drawing.Point(19, 48);
            this.txb_Data.Name = "txb_Data";
            this.txb_Data.Size = new System.Drawing.Size(665, 21);
            this.txb_Data.TabIndex = 51;
            this.txb_Data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyHexNumInput);
            // 
            // btn_creat
            // 
            this.btn_creat.Location = new System.Drawing.Point(443, 75);
            this.btn_creat.Name = "btn_creat";
            this.btn_creat.Size = new System.Drawing.Size(75, 23);
            this.btn_creat.TabIndex = 52;
            this.btn_creat.Tag = "0";
            this.btn_creat.Text = "生成";
            this.btn_creat.UseVisualStyleBackColor = true;
            this.btn_creat.Click += new System.EventHandler(this.btn_creat_Click);
            // 
            // btn_creatAndSend
            // 
            this.btn_creatAndSend.Location = new System.Drawing.Point(528, 75);
            this.btn_creatAndSend.Name = "btn_creatAndSend";
            this.btn_creatAndSend.Size = new System.Drawing.Size(75, 23);
            this.btn_creatAndSend.TabIndex = 53;
            this.btn_creatAndSend.Tag = "1";
            this.btn_creatAndSend.Text = "生成并发送";
            this.btn_creatAndSend.UseVisualStyleBackColor = true;
            this.btn_creatAndSend.Click += new System.EventHandler(this.btn_creat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(557, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "串口波特率：460800";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 460800;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ClearData);
            this.Controls.Add(this.txb_DataShow);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "志明电子二次开发参考DEMO配视频";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_SerialPortRefresh;
        private System.Windows.Forms.Button btn_SerialPortOpen;
        private System.Windows.Forms.ComboBox cmb_SerialPortIndex;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.Label lablel_SerialPortStatus;
        public System.Windows.Forms.TextBox txb_DataShow;
        private System.Windows.Forms.Button btn_ClearData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_len;
        private System.Windows.Forms.CheckBox chb_check;
        private System.Windows.Forms.Label lb_checkValue;
        private System.Windows.Forms.TextBox txb_Data;
        private System.Windows.Forms.Button btn_creat;
        private System.Windows.Forms.Button btn_creatAndSend;
        private System.Windows.Forms.Label label6;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

