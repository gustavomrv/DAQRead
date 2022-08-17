using System;
using System.Windows.Forms;
using NationalInstruments.DAQmx;
using Task = NationalInstruments.DAQmx.Task;

namespace DAQRead
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {}
        private void label1_Click(object sender, EventArgs e)
        {}
        private void label2_Click(object sender, EventArgs e)
        {}
        private void label3_Click(object sender, EventArgs e)
        {}
        private void label4_Click(object sender, EventArgs e)
        {}
        private void button1_Click(object sender, EventArgs e)
        {
            Task analogInTask = new Task();

            AIChannel myAIChannel;

            myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(
                "dev1/ai0",
                "myAIChannel",
                AITerminalConfiguration.Differential,
                0,
                10,
                AIVoltageUnits.Volts
                );

            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);

            double analogDataIn = reader.ReadSingleSample();

            textBox1.Text = analogDataIn.ToString("0.00");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task analogInTask2 = new Task();

            AIChannel myAIChannel2;

            myAIChannel2 = analogInTask2.AIChannels.CreateCurrentChannel(
                "dev/ai0",
                "myAIChannel",
                AITerminalConfiguration.Differential,
                0,
                20,
                AICurrentUnits.Amps
                );

            AnalogSingleChannelReader reader2 = new AnalogSingleChannelReader(analogInTask2.Stream);

            double analogDataIn2 = reader2.ReadSingleSample();

            textBox2.Text = analogDataIn2.ToString("0.00");
        }
    }
}