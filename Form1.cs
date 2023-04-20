using findSerialPorts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace zmelecDemo {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
        }
        class ComRecv_Class {
            public int MaxLength = 60000;
            public int pWrite = 0;
            public int pRead = 0;
            public byte[] Buf = new byte[60000];
        }
        ComRecv_Class c_comReceive = new ComRecv_Class();
        private void btn_SerialPortOperate(object sender, EventArgs e)
        {
            Button btn_SerialPortOperate = (Button)sender;
            switch (btn_SerialPortOperate.Tag.ToString()) {
                case "Open/Close":  // 打开/关闭串口
                    switch (btn_SerialPortOpen.Text) {
                        case "打开串口":
                            try {
                                string ComPortName = null;   // 我总感觉下面的总可以优化
                                { // 找串口号
                                    if (cmb_SerialPortIndex.Text[4] == ' ')  // COMn 形式
                                        ComPortName = cmb_SerialPortIndex.Text.Substring(0, 4);  // 表示从0开始，获取4个字符！
                                    else if (cmb_SerialPortIndex.Text[5] == ' ')  // COMnn 形式
                                        ComPortName = cmb_SerialPortIndex.Text.Substring(0, 5);
                                    else if (cmb_SerialPortIndex.Text[6] == ' ')  // COMnnn 形式
                                        ComPortName = cmb_SerialPortIndex.Text.Substring(0, 6);
                                    else if (cmb_SerialPortIndex.Text[7] == ' ')  // COMnnnn 形式
                                        ComPortName = cmb_SerialPortIndex.Text.Substring(0, 7);
                                }
                                serialPort1.PortName = ComPortName;
                                serialPort1.Open();
                                btn_SerialPortOpen.Text = "关闭串口";
                                cmb_SerialPortIndex.Enabled = false;
                                btn_SerialPortRefresh.Enabled = false;
                                lablel_SerialPortStatus.Text = "串口状态:已打开";
                            }
                            catch {
                                MessageBox.Show("错误001:串口打开失败,请检查", "提示");
                            }
                            break;
                        case "关闭串口":
                            try {
                                serialPort1.Close();
                                btn_SerialPortOpen.Text = "打开串口";
                                cmb_SerialPortIndex.Enabled = true;
                                btn_SerialPortRefresh.Enabled = true;
                                lablel_SerialPortStatus.Text = "串口状态:已关闭";
                            }
                            catch {
                                MessageBox.Show("错误002:串口关闭失败,请检查", "提示");
                            }
                            break;
                        default: break;
                    }
                    break;
                case "Fresh":  // 刷新串口
                    SerialPortFresh();
                    break;
                default:
                    break;
            }
        }

        public void SerialPortFresh()  // 刷新串口函数
        {
            if (cmb_SerialPortIndex.Enabled == false) {
                return;
            }
            cmb_SerialPortIndex.Items.Clear();
            cmb_SerialPortIndex.Text = string.Empty;
            string[] ports = Win32api_findSerialPorts.MulGetHardwareInfo(Win32api_findSerialPorts.HardwareEnum.Win32_PnPEntity, "Name"); // 使用WPI接口
            if (ports != null) {
                string[] rebuildPorts = new string[ports.Length];
                for (byte i = 0; i < ports.Length; i++)  // 下面的我也感觉到也可以优化
                {
                    for (byte j = 0; j < ports[i].Length; j++) {
                        if ((ports[i][j] == '(') && ports[i][j + 1] == 'C' && (ports[i][j + 2] == 'O') && ports[i][j + 3] == 'M') {
                            if (ports[i][j + 5] == ')') {// (COMn) 形式 
                                rebuildPorts[i] = "COM" + ports[i][j + 4] + " " + ports[i].Substring(0, j - 1);
                            }
                            else if (ports[i][j + 6] == ')') {// (COMnn) 形式 
                                rebuildPorts[i] = "COM" + ports[i][j + 4] + ports[i][j + 5] + " " + ports[i].Substring(0, j - 1);
                            }
                            else if (ports[i][j + 7] == ')') {// (COMnnn) 形式 
                                rebuildPorts[i] = "COM" + ports[i][j + 4] + ports[i][j + 5] + ports[i][j + 6] + " " + ports[i].Substring(0, j - 1);
                            }
                            else if (ports[i][j + 8] == ')') {// (COMnnnn) 形式 
                                rebuildPorts[i] = "COM" + ports[i][j + 4] + ports[i][j + 5] + ports[i][j + 6] + ports[i][j + 7] + " " + ports[i].Substring(0, j - 1);
                            }
                            else {
                                rebuildPorts[i] = "错误的串口号";
                            }
                        }
                    }
                }
                for (byte i = 0; i < ports.Length; i++) {// 仅给使用包含CH340芯片的。日后只用CH340了！
                    if (rebuildPorts[i].Contains("CH340"))
                        cmb_SerialPortIndex.Items.Add(rebuildPorts[i]);
                }
                cmb_SerialPortIndex.SelectedIndex = cmb_SerialPortIndex.Items.Count > 0 ? 0 : -1;
            }
            else {// 几乎不会出现这种错误
                MessageBox.Show("寻找COM口出错！");
                cmb_SerialPortIndex.Text = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            SerialPortFresh();
            { // 串口处理函数，使用多线程处理！
                // 还是看了别人的代码比较有效果，尤其优秀工程的。之前一直不明白。
                // 当然：日后想要C#成为大神，还是得比较注意！
                Thread thread = new Thread(new ThreadStart(ComProcess));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int n = serialPort1.BytesToRead;
            if (c_comReceive.pWrite + n > c_comReceive.MaxLength) {
                serialPort1.Read(c_comReceive.Buf, c_comReceive.pWrite, c_comReceive.MaxLength - c_comReceive.pWrite);
                serialPort1.Read(c_comReceive.Buf, 0, c_comReceive.pWrite + n - c_comReceive.MaxLength);
            }
            else {
                serialPort1.Read(c_comReceive.Buf, c_comReceive.pWrite, n);
            }
            c_comReceive.pWrite = (c_comReceive.pWrite + n);
            c_comReceive.pWrite %= c_comReceive.MaxLength;
        }
        void ComProcess(  )
        { // 关键处理函数，非定长报文处理方法！
            byte[] tmpBuf = new byte[255]; // 最大处理报文：64，使用全局变量！
            int bufferValidDataLen; // 串口数据中有效数据 这个定义为byte的话，可能会产生问题：就是数据量大没得及处理，会超过byte长度！
            byte frameLen; // 解析当前帧数据长度
            byte checkValue;
            byte isDataOK = 0;
            while (true) {
                Thread.Sleep(10); // 不要一直启动，否则I9-9900K的CPU占用率都有5%左右！如果睡眠10ms，则显示CPU占用：0%。看来效果明显！
                do { // 第一步找最小的数据长度：55 AA nLen 是否需要检验 命令字 校验 0x5A 也就是长度最少：7 
                     // nLen：为这一帧的总长度：这样程序方面也比较好操作！
                     // 校验字：为0x55开头到校验字之前的异或校验，也就是除了最后2个字节之前的校验！
                    bufferValidDataLen = (((c_comReceive.pWrite + c_comReceive.MaxLength) - c_comReceive.pRead) % c_comReceive.MaxLength); // buffer中有效数据长度
                    if (bufferValidDataLen >= 7) {
                        if (((c_comReceive.Buf[(c_comReceive.pRead)]) == 0x55) && ((c_comReceive.Buf[(c_comReceive.pRead + 1) % c_comReceive.MaxLength]) == 0xAA)) { // 符合报文头
                            frameLen = c_comReceive.Buf[(c_comReceive.pRead + 2) % c_comReceive.MaxLength]; // 这帧总的长度
                            if (frameLen <= bufferValidDataLen) { // 长度满足，可以开始解析数据
                                for (int i = 0; i < frameLen; i++) { // 其实前3个数据可以不需要了，但是为了保持一致性！还是都复制出来！
                                    tmpBuf[i] = c_comReceive.Buf[(c_comReceive.pRead + i) % c_comReceive.MaxLength];
                                }
                                { // 处理数据
                                    isDataOK = 0; // 先假定不符合校验
                                    if (tmpBuf[frameLen - 1] == 0x5A) { // 报文尾巴符合
                                        if (tmpBuf[3] != 0) { // 需要检验字
                                            checkValue = 0;
                                            for (int j = 0; j < frameLen - 2; j++) {
                                                checkValue = (byte)(checkValue ^ tmpBuf[j]);
                                            }
                                            if (checkValue == tmpBuf[frameLen - 2]) {
                                                isDataOK = 1;
                                            }
                                            else { } // 保持不变就好！ 
                                        }
                                        else {
                                            isDataOK = 1;
                                        }
                                        { // 
                                            if (isDataOK == 1) { // 可以开始正常处理数据
                                                { // 先把这一帧的数据处理掉
                                                    c_comReceive.pRead += frameLen;
                                                    c_comReceive.pRead %= c_comReceive.MaxLength;
                                                    { // 进行显示
                                                        StringBuilder str = new StringBuilder();
                                                        for (int i = 0; i < frameLen; i++) {
                                                            str.Append(tmpBuf[i].ToString("X").PadLeft(2, '0') + " ");
                                                        }
                                                        txb_DataShow.AppendText("接收数据为: " + str + "\r\n");
                                                    }
                                                }
                                                switch (tmpBuf[4]) { // 这里就可以开始处理数据了！
                                                    case 0:
                                                        break;
                                                    case 1:
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            else { // 不符合的情况下：去除掉一个会比较稳定，但是去除掉一帧，其实当然也是可以的！
                                                   // 去除掉一个，显得特别稳定，当然会存在性能的问题。关于性能可以这样考虑：出错的毕竟少，影响有限。
                                                   // 如果不专门分析和提升性能，盲目的优化性能，会带来不稳定，当前情况下，显然是不合适的！
                                                c_comReceive.pRead++; // 这里可以直接+2，因为55 aa 移动一个位置也不会是头
                                                c_comReceive.pRead %= c_comReceive.MaxLength;
                                            }
                                        }
                                    }
                                    else { // 报文尾不符合，怎么操作：应该是移动一个位置！
                                        c_comReceive.pRead++; // 这里可以直接+2，因为55 aa 移动一个位置也不会是头
                                        c_comReceive.pRead %= c_comReceive.MaxLength;
                                    }
                                }
                            }
                            else {// 长度不满足，需要继续接收数据！
                                  // 注意：此情况下，里面会一起循环，所以需要结束循环，尤其在电脑上。否则会一直卡循环！
                                  // 而作为STM32，可以等待中断数据，在里面处理。然后处理完结。
                                break; // 结束里面的循环，不用等数据全部到齐，可以有序的做其他事情！
                            }
                        }
                        else { // 不符合0x55 0xAA开头，此时移动一个位置
                            c_comReceive.pRead++;
                            c_comReceive.pRead %= c_comReceive.MaxLength;
                        }
                    }
                    else { }; // 长度不满足，需要继续接收数据！
                } while ((((c_comReceive.pWrite + c_comReceive.MaxLength) - c_comReceive.pRead) % c_comReceive.MaxLength) >= 7);
            }
        }

        private void btn_ClearData_Click(object sender, EventArgs e)
        {
            txb_DataShow.Text = "";
        }

        void caculateXORAndLen(byte[] dataBuf, byte bufLen)
        { // 更新长度值，和校验值！
            byte xorValue = 0;
            dataBuf[2] = bufLen; // 重新计算一下长度！
            for (int i = 0; i < bufLen - 2; i++) {
                xorValue ^= dataBuf[i];
            }
            dataBuf[bufLen - 2] = xorValue;
        }
        private void btn_creat_Click(object sender, EventArgs e)
        {
            byte[] sendBuf = new byte[255]; // 定义一个足够长的数组！
            byte actualLen; // 最后要生成数据的长度！
            sendBuf[0] = 0x55;
            sendBuf[1] = 0xAA;
            StringBuilder strDis = new StringBuilder();
            Button btnTmp = (Button)sender;
            try { // 解析数据，顺带解析长度，使用正则表达式！
                string inputData = txb_Data.Text;
                string str = Regex.Replace(inputData, @"[0-9a-fA-F][0-9a-fA-F]{0,1}", "$0" + " ");
                MatchCollection mc = Regex.Matches(str, @"\b[0-9a-fA-F]+\b");
                List<byte> buf = new List<byte>();
                foreach (Match m in mc) {
                    buf.Add(byte.Parse(m.Value, System.Globalization.NumberStyles.HexNumber));
                }
                actualLen = (byte)(buf.Count + 6); // 总长度！
                lb_len.Text = "报文总长度：" + actualLen.ToString() ;
                sendBuf[2] = actualLen;
                sendBuf[actualLen-1] = 0x5A;
                for( int i=0;i<buf.Count;i++) {
                    sendBuf[4+i] = buf[i];
                }
                if( chb_check.Checked == true) {
                    sendBuf[3] = 1;
                    caculateXORAndLen(sendBuf, actualLen);
                    lb_checkValue.Text = "校验值：0x"+ sendBuf[actualLen - 2].ToString("X");
                }
                else {
                    sendBuf[3] = 0;
                    sendBuf[actualLen - 2] = 0x00;
                    lb_checkValue.Text = "校验值：-";
                }
                {
                    for (int i = 0; i < actualLen; i++) {
                        strDis.Append(sendBuf[i].ToString("X").PadLeft(2, '0') + " ");
                    }
                    txb_DataShow.AppendText("生成数据为: " + strDis + "\r\n");
                }
            }
            catch {
                txb_DataShow.AppendText("长度错误" + "数据出错，请检查");
                return;
            }
            switch (byte.Parse(btnTmp.Tag.ToString())){
                case 1: {
                        try {
                            serialPort1.Write(sendBuf, 0, actualLen);
                        }
                        catch {
                            txb_DataShow.AppendText("串口发送失败，请检查串口\r\n");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void OnlyHexNumInput(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != ' '
               && e.KeyChar != 'A' && e.KeyChar != 'B' && e.KeyChar != 'C' && e.KeyChar != 'D' && e.KeyChar != 'E' && e.KeyChar != 'F'
               && e.KeyChar != 'a' && e.KeyChar != 'b' && e.KeyChar != 'c' && e.KeyChar != 'd' && e.KeyChar != 'e' && e.KeyChar != 'f') {
                e.Handled = true;  // 取消
                return;
            }
        }
    }
}
