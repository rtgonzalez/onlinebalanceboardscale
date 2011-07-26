using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiimoteLib;
using System.IO;

namespace OnlineBalanceBoardScale
{
    public partial class Form1 : Form
    {
        Wiimote wm = null;
        WiimoteCollection mWC;
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        double balancedWeight = 0;
        double sumWeight = 0;
        double lastWeight = 0;
        int count = 0;
        TextWriter tw = null;

        public const int CALIBRATION_FRAME = 1;
        public const int MEASURE_FRAME = 50;
        public const bool DEBUG_FILE = false;


        int FRAME = CALIBRATION_FRAME;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Unload()
        {
            wm.Disconnect();
            if (DEBUG_FILE) tw.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;
            checkRemotes();
        }
        private void checkRemotes()
        {
            mWC = new WiimoteCollection();
            

            try
            {
                mWC.FindAllWiimotes();
            }
            catch (WiimoteNotFoundException ex)
            {
                setNoExistingScale("N/A");
                //MessageBox.Show(ex.Message, "Wiimote not found error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (WiimoteException ex)
            {
                MessageBox.Show(ex.Message, "Wiimote error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            
            foreach (Wiimote each in mWC)
            {
                if (each.WiimoteState.ExtensionType == ExtensionType.BalanceBoard || each.WiimoteState.ExtensionType == ExtensionType.None)
                {
                    iniciar(each);
                }
            }
        }
        public void setNoExistingScale(string msg)
        {
            pictureBox1.Image = Imagenes.BalanzaTodoRojo;
            //label1.Text = msg;
            screen.Value = "----";
        }
        public void UpdateState(WiimoteChangedEventArgs args)
        {
            BeginInvoke(new UpdateWiimoteStateDelegate(UpdateWiimoteChanged), args);
        }
        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {
            UpdateState(e);
        }
        private void iniciar(Wiimote mote)
        {
            wm = mote;
            wm.WiimoteChanged += wm_WiimoteChanged;

            wm.Connect();
            wm.SetLEDs(true, false, false, false);
            pictureBox1.Image = Imagenes.BalanzaRojo;

            if (DEBUG_FILE)
            {
                 tw = new StreamWriter("log2.csv");
            }
        }
        private String setPeso(WiimoteState state)
        {
            double peso = state.BalanceBoardState.WeightKg;
            double pes = state.BalanceBoardState.WeightKg;
            if (DEBUG_FILE) tw.WriteLine(count + ";" + pes.ToString("N10"));
            count++;
            sumWeight += state.BalanceBoardState.WeightKg;

            if (count == FRAME)
            {
                peso = promediar();
                screen.Value = peso.ToString("00.0").Replace(',','.');
                //label1.Text = peso.ToString("00.0").Replace(',','.') + " Kg";
            }
            //Console.WriteLine(state.BalanceBoardState.CenterOfGravity.X + state.BalanceBoardState.CenterOfGravity.Y);
            
            return "";
        }
        private double promediar()
        {
            count = 0;
            double returnTmp = 0;
            if (balancedWeight == 0){ //calibration
                balancedWeight = (sumWeight / (FRAME));
                returnTmp = 0;
                FRAME = MEASURE_FRAME;
            }else //con peso
            {
                returnTmp = (sumWeight / (FRAME)) - balancedWeight;
                pictureBox1.Image = Imagenes.BalanzaVerde;
                lastWeight = returnTmp;
            }
            if (returnTmp < 0.02) returnTmp = 0;
            sumWeight = 0;
            return returnTmp;
        }
        private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
        {
            setPeso(args.WiimoteState);
        }

      
    }
}
