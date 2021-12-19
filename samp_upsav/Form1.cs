using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Media;
using Common;
using MemoryEdit;
using FileConfigManager;

namespace samp_upsav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const string cfgfile = "samp_upsav.ini";

        string[] authname = { "r", "K", "i", "s", "u", "t" };

        Memory mem;
        GlobalKeyboardHook gkh = new GlobalKeyboardHook();
        Keys hotkey;
        FCM cfg = new FCM();
        SoundPlayer snd = new SoundPlayer(Properties.Resources.snd);

        bool isattached = false;
        bool iskeydown = false;
        double px = 0;
        double py = 0;
        double pz = 0;
        double angle = 0;

        double mx = 0;
        double my = 0;
        double mz = 0;

        string tmpstr = null;

        [Flags]
        enum CheckboxData
        {
            dt1 = 1,
            dt2 = 2,
            dt3 = 4,
            dt4 = 8,
            dt5 = 16,
            dt6 = 32
        }
        CheckboxData bits;

        FileStream fs;
        StreamWriter sw;
        uint tmp;

        private void data_rad_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = data_rad.Checked;
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Program written by " +
            authname[1] + authname[4] + authname[0] + authname[5] + authname[2] + authname[3] +
            " (2013)\n\n\n" +
            "HU\n" +
            "Lényege a következő: gombnyomásra lementi a jelenlegi koordinátát, előre\n" +
            "megformázottan lementhető formátumban, ahogy a felhasználó szeretné.\n\n" +
            "EN\n" +
            "Essence is the following: can save current coordinates by pressing a button\n" +
            "and with pre-formatted format, as the user likes.\n\n" +
            "Written in Visual C# 2008 Express Edition (.NET 3.5)",
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_attach_Click(object sender, EventArgs e)
        {
            if (!isattached && IsProcessOpen("gta_sa"))
            {
                mem = new Memory("gta_sa",0x10);
                isattached = true;
                bt_attach.Text = "Attached to San Andreas";
                bt_attach.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("samp_upsav.ini"))
            {
                MessageBox.Show("samp_upsav.ini not found, generating a new one.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                fs = new FileStream("samp_upsav.ini",FileMode.CreateNew,FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.Write(Properties.Resources.samp_upsav);
                sw.Close();
                fs.Close();
            }
            bits = (CheckboxData)Convert.ToInt32(cfg.ReadData(cfgfile, "checkboxes"));
            data_x.Checked = ((bits & ((CheckboxData)Math.Pow(2, 0))) == ((CheckboxData)Math.Pow(2, 0)));
            data_y.Checked = ((bits & ((CheckboxData)Math.Pow(2, 1))) == ((CheckboxData)Math.Pow(2, 1)));
            data_z.Checked = ((bits & ((CheckboxData)Math.Pow(2, 2))) == ((CheckboxData)Math.Pow(2, 2)));
            data_ang.Checked = ((bits & ((CheckboxData)Math.Pow(2, 3))) == ((CheckboxData)Math.Pow(2, 3)));
            data_rad.Checked = ((bits & ((CheckboxData)Math.Pow(2, 4))) == ((CheckboxData)Math.Pow(2, 4)));
            data_snd.Checked = ((bits & ((CheckboxData)Math.Pow(2, 5))) == ((CheckboxData)Math.Pow(2, 5)));
            hotkey = (Keys)Enum.Parse(typeof(Keys), cfg.ReadData(cfgfile,"hotkey"));
            text_start.Text = cfg.ReadData(cfgfile, "start");
            text_end.Text = cfg.ReadData(cfgfile, "end");
            text_sep.Text = cfg.ReadData(cfgfile, "separator");
            double.TryParse(cfg.ReadData(cfgfile, "minusX").Replace(".", ","), out mx);
            double.TryParse(cfg.ReadData(cfgfile, "minusY").Replace(".", ","), out my);
            double.TryParse(cfg.ReadData(cfgfile, "minusZ").Replace(".", ","), out mz); 
            gkh.Hook();
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            bits = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bits = 0;
            bits |= (CheckboxData)FlagIfTrue(data_x.Checked, 1);
            bits |= (CheckboxData)FlagIfTrue(data_y.Checked, 2);
            bits |= (CheckboxData)FlagIfTrue(data_z.Checked, 3);
            bits |= (CheckboxData)FlagIfTrue(data_ang.Checked, 4);
            bits |= (CheckboxData)FlagIfTrue(data_rad.Checked, 5);
            bits |= (CheckboxData)FlagIfTrue(data_snd.Checked, 6);

            //Save Checkboxes
            if (cfg.CheckData(cfgfile, "checkboxes"))
                cfg.ChangeData(cfgfile, "checkboxes", cfg.ReadData(cfgfile, "checkboxes"), Convert.ToInt32(bits).ToString());
            else
                cfg.WriteData(cfgfile, "checkboxes", Convert.ToInt32(bits).ToString());
            //Save Separator
            if (cfg.CheckData(cfgfile, "separator"))
                cfg.ChangeData(cfgfile, "separator", cfg.ReadData(cfgfile, "separator"), text_sep.Text);
            else
                cfg.WriteData(cfgfile, "separator", text_sep.Text);

            //Save Start End
            if (cfg.CheckData(cfgfile, "start"))
                cfg.ChangeData(cfgfile, "start", cfg.ReadData(cfgfile, "start"), text_start.Text);
            else
                cfg.WriteData(cfgfile, "start", text_sep.Text);

            if (cfg.CheckData(cfgfile, "end"))
                cfg.ChangeData(cfgfile, "end", cfg.ReadData(cfgfile, "end"), text_end.Text);
            else
                cfg.WriteData(cfgfile, "end", text_sep.Text);
        }

        private void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            iskeydown = false;
        }

        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (!iskeydown && isattached)
            {
                if (e.KeyCode == hotkey)
                {
                    if(data_snd.Checked) snd.Play();
                    if (mem.ReadBytePointer(0xB6F5F0, 0x530, 1) != 50)
                    {
                        px = Math.Round(mem.ReadFloat(0x008CCC3C), 3);
                        py = Math.Round(mem.ReadFloat(0x008CCC40), 3);
                        pz = Math.Round(mem.ReadFloat(0x008CCC44), 3);
                        angle = Math.Round(mem.ReadFloatPointer(0xB6F5F0, 0x558) * (180 / Math.PI), 3);
                        if (angle < 0) angle = 360 + angle;
                    }
                    else
                    {
                        tmp = (uint)mem.Read(0xBA18FC) + 0x14;
                        px = Math.Round(mem.ReadFloatPointer(tmp, 0x30), 3);
                        py = Math.Round(mem.ReadFloatPointer(tmp, 0x34), 3);
                        pz = Math.Round(mem.ReadFloatPointer(tmp, 0x38), 3);
                        angle = Math.Round(mem.ReadFloatPointer(tmp, 0x8) * (180 / Math.PI), 3);
                        if (angle < 0) angle = 360 + angle;
                    }
                    if (mx != 0) px += mx;
                    if (my != 0) py += my;
                    if (mz != 0) pz += mz;

                    tmpstr = (data_x.Checked ? px.ToString().Replace(",", ".") + text_sep.Text : null) +
                        (data_y.Checked ? py.ToString().Replace(",", ".") + text_sep.Text : null) +
                        (data_z.Checked ? pz.ToString().Replace(",", ".") + text_sep.Text : null) +
                        (data_ang.Checked ? angle.ToString().Replace(",",".") + text_sep.Text : null) +
                        (data_rad.Checked ? numericUpDown1.Value.ToString() : null);

                    if (tmpstr.EndsWith(text_sep.Text))
                        tmpstr = tmpstr.Substring(0, tmpstr.Length - 1);

                    fs = new FileStream("samp_upsavedpos.txt",
                        (File.Exists("samp_upsavedpos.txt")) ? FileMode.Append : FileMode.CreateNew, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine(
                        text_start.Text +
                        tmpstr +
                        text_end.Text
                        );
                    sw.Close();
                    fs.Close();
                    angle = 0;
                    tmpstr = null;
                    iskeydown = true;
                }
            }
        }
        public bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName == name)
                {
                    return true;
                }
            }
            return false;
        }

        private int PowOfTwo(int pow)
        {
            return (int)Math.Pow(2,pow);
        }

        private int FlagIfTrue(bool cond, int flag)
        {
            if (cond) return (int)Math.Pow(2, (double)flag - 1);
            else return 0;
        }
    }
}
