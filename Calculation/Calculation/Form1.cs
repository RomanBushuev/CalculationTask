using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculationOneDay incrementalAlgorithm =
                new IncrementalAlgorithm();

            incrementalAlgorithm.CalculationLogger.HandleMessage+= new EventHandler(OnHandleMessage);

            Task task = new Task(() =>
            {
                incrementalAlgorithm.Run();
            });

            task.Start();
        }
        private delegate void OnHandleMessageDelegate(object sender, EventArgs args);

        public void OnHandleMessage(object sender, EventArgs args)
        {
            var messageEvent = args as MessageEventArgs;
            if (messageEvent != null)
            {
                string message = messageEvent.Message;
                if(richTextBox1.InvokeRequired)
                {
                    richTextBox1.Invoke(new OnHandleMessageDelegate(OnHandleMessage), new object[] { sender, args });
                }
                else
                {
                    richTextBox1.Text = message + "\n" + richTextBox1.Text;
                }
            }
        }
    }
}
