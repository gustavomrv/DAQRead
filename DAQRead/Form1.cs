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
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task analogInTask = new Task();

            AIChannel myAIChannel;
            AIChannel myAIChannel2;

            myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(
                "dev1/ai0",
                "myAIChannel",
                AITerminalConfiguration.Differential,
                0,
                10,
                AIVoltageUnits.Volts
                );

            myAIChannel2 = analogInTask.AIChannels.CreateCurrentChannel(
                "dev/ai0",
                "myAIChannel",
                AITerminalConfiguration.Differential,
                0,
                20,
                AICurrentUnits.Amps
                );

            myAIChannel2 = analogInTask.AIChannels.CreateCurrentChannel(
                "dev/ai0",
                "myAIChannel",
                AITerminalConfiguration.Differential,
                0,
                20,
                AICurrentUnits.Amps
                );

            //myAIChannel2 = analogInTask.AIChannels.CreateResistanceChannel(
            //    "dev/ai0",
            //    "myAIChannel",
            //    AITerminalConfiguration.Differential,
            //    0,
            //    20,
            //    AIResistanceUnits.Ohms,
            //    );

            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);

            double analogDataIn = reader.ReadSingleSample();

            textBox1.Text = analogDataIn.ToString("0.00");
        }

    }
}