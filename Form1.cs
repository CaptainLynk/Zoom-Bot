using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;
using WindowsInput.Native;
using WindowsInput;
using System.Media;



namespace zoomspoof
{
    public partial class Form1 : Form
    {
        public int count = 0;
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
        InputSimulator sim = new InputSimulator();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            clist.Add(new string[] { "hi", "drew", "are you there", "answer" });
            Grammar gr = new Grammar(new GrammarBuilder(clist));

            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += Sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
                //2:31 https://www.youtube.com/watch?v=xug793JfqS E
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "uh oh you did a fucky Wucky ");
               
            }
        }

        private void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            switch (e.Result.Text.ToString())
            {
                case "answer":
                    if (count >= 1)
                    {
                        yeet();
                        
                    }
                    break;

                case "hi":

                    sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_2);
                    sim.Keyboard.KeyPress(VirtualKeyCode.NUMPAD7);
                    Thread.Sleep(1000);
                    sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_1);

                    break;
                case "drew":
                    count++;
                    if (count >= 3)
                    {

                        yeet();
                

                    }
                        break;
                    
                case "are you there":
                    if (count >= 1)
                    {
                        sim.Keyboard.KeyPress(VirtualKeyCode.NUMPAD8);
                        sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_2);
                        Thread.Sleep(1000);
                        sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_1);
                        count = 0;

                    }
                    break;


            }
            txtContents.Text += e.Result.Text.ToString() + Environment.NewLine;


        }

        private void NewMethod()
        {
            count = 0;
        }
       
        private void btnStop_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
        private void yeet()
        {
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_2);
            sim.Keyboard.KeyPress(VirtualKeyCode.NUMPAD9);
            Thread.Sleep(3500);
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.VK_1);
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.F4);
        
        NewMethod();
    
        }
    }
}
