using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Permissions;

namespace IP_configurer
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> hostelMap;
        private string ipaddress;
        private string dns;
        private string altdns;

        
        public Form1()
        {
            InitializeComponent();

            hostelMap = new Dictionary<string, int>();
            hostelMap.Add("Barak", 10);
            hostelMap.Add("Brahmaputra", 12);
           // hostelMap.Add("Dhansiri", 0);
            hostelMap.Add("Dibang", 8);
            hostelMap.Add("Dihing", 0);
            hostelMap.Add("Kameng", 9);
            hostelMap.Add("Kapili", 1);
            hostelMap.Add("Manas", 4);
            hostelMap.Add("Married Hostel", 17);
           // hostelMap.Add("New Boys Hostel", 0);
            hostelMap.Add("Siang", 3);
            hostelMap.Add("Subansiri", 16);
            hostelMap.Add("Umiam", 11);


        }
        /*   private Dictionary<Int32, int> floormap;

         public  Form2()
          {
              InitializeComponent();
              floormap = new Dictionary<int, int>();
              floormap.Add(0, 0);
              floormap.Add(1, 1);
              floormap.Add(2, 2);
              floormap.Add(3, 3);
  
          }*/

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void calculateAddress()
        {
            var comboBox1 = this.Controls["comboBox1"] as ComboBox;
            var comboBox2 = this.Controls["comboBox2"] as ComboBox;
            var textBox1 = this.Controls["textBox1"] as TextBox;
            var comboBox3 = this.Controls["comboBox3"] as ComboBox;
            string hostel = comboBox1.Text;
            string block = comboBox2.Text;
            string room = textBox1.Text;
            ipaddress = "10." + hostelMap[hostel] + "." ;
            altdns = "10." +hostelMap[hostel] + "."+"0."+"254";
            int blockno=-1,floor=-1,roomno=-1;
            if (Convert.ToInt64(hostelMap[hostel]) == 0 ||Convert.ToInt64(hostelMap[hostel]) == 1 || Convert.ToInt64(hostelMap[hostel]) == 3 ||Convert.ToInt64(hostelMap[hostel]) == 17 )
            {
                dns = "255.255.252.0";
            }
            else
            {
                dns = "255.255.192.0";

            }
             if (hostel.Equals("Barak"))
            {
                floor = Convert.ToInt32(room) / 100;
                
                if (Convert.ToChar(block) == 'A')
                {
                     blockno = 0;
                }
                else if (Convert.ToChar(block) == 'B')
                {
                     blockno = 1;
                }
                else if (Convert.ToChar(block) == 'C')
                {
                    blockno = 2;
                }

                roomno = Convert.ToInt16(room) % 100;
            }
            else if (hostel.Equals("Brahmaputra"))   //
            {
                floor = Convert.ToInt32(comboBox3.Text);

                if (Convert.ToChar(block) == 'A')
                {
                    blockno = 0;
                    
                    // This is a fucking code took hours to figure out what to do.

                }
                else if (Convert.ToChar(block) == 'B')
                {
                    blockno = 1;
                    

                }
                else if (Convert.ToChar(block) == 'C')
                {
                    blockno = 2;
                    
                }
                else if (Convert.ToChar(block) == 'D')
                {
                    blockno = 3;
                    
                }

                if (Convert.ToChar(block) == 'A' || Convert.ToChar(block) == 'B')
                {
                    roomno = Convert.ToInt32(room);
                }
                else if ((Convert.ToChar(block) == 'C' || Convert.ToChar(block) == 'D') && floor == 0)
                {
                    roomno = Convert.ToInt32(room)-134;
                }
                else if ((Convert.ToChar(block) == 'C' || Convert.ToChar(block) == 'D') && floor == 1)
                {
                    roomno = Convert.ToInt32(room)-119;
                }
                else if ((Convert.ToChar(block) == 'C' || Convert.ToChar(block) == 'D') && floor == 2)
                {
                    roomno = Convert.ToInt32(room)-133;
                }
                else if ((Convert.ToChar(block) == 'C' || Convert.ToChar(block) == 'D') && floor == 3)
                {
                    roomno = Convert.ToInt32(room)-131;
                }
            }
            else if (hostel.Equals("Dhansiri"))
            {

            }
            else if (hostel.Equals("Dibang"))    // Done
            {

                floor = Convert.ToInt32(comboBox3.Text);
                if (Convert.ToChar(block) == 'A' || Convert.ToChar(block) == 'B' || Convert.ToChar(block) == 'C')
                {
                    blockno = 0;
                }
                if (Convert.ToChar(block) == 'D' || Convert.ToChar(block) == 'E' || Convert.ToChar(block) == 'F')
                {
                    blockno = 1;
                }
                if (Convert.ToChar(block) == 'G' || Convert.ToChar(block) == 'H' || Convert.ToChar(block) == 'I')
                {
                    blockno = 2;
                }
                if (Convert.ToChar(block) == 'J' || Convert.ToChar(block) == 'K' || Convert.ToChar(block) == 'K')
                {
                    blockno = 3;
                }

                if (Convert.ToChar(block) == 'A' || Convert.ToChar(block) == 'D' || Convert.ToChar(block) == 'G' || Convert.ToChar(block) == 'J')
                {
                    roomno = Convert.ToInt32(room);
                }
                else if (Convert.ToChar(block) == 'B' || Convert.ToChar(block) == 'E' || Convert.ToChar(block) == 'H' || Convert.ToChar(block) == 'K')
                {
                    roomno = 12+ Convert.ToInt32(room);
                }
                else if (Convert.ToChar(block) == 'C' || Convert.ToChar(block) == 'F' || Convert.ToChar(block) == 'I' || Convert.ToChar(block) == 'L')
                {
                    roomno = 18+ Convert.ToInt32(room);
                }
            }
            else if (hostel.Equals("Dihing"))           // Done.
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToChar(block) == 'A')
                {
                    blockno = 0;
                }


                roomno = Convert.ToInt16(room) % 100;
            }
            else if (hostel.Equals("Kameng"))                // Done
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToString(block).Equals("B1"))
                {
                    blockno = 0;
                }
                else if (Convert.ToString(block).Equals("B2"))
                {
                    blockno = 1;
                }
                else if (Convert.ToString(block).Equals("B3"))
                {
                    blockno = 2;
                }
                else if (Convert.ToString(block).Equals("B4"))
                {
                    blockno = 3;
                }
                else if (Convert.ToString(block).Equals("c"))
                {
                    blockno = 4;
                }
                roomno = Convert.ToInt16(room) % 100;
            }

            else if (hostel.Equals("Kapili"))               // Done.
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToChar(block) == 'A')
                {
                    blockno = 0;
                }
                

                roomno = Convert.ToInt16(room) % 100;
            }
            else if (hostel.Equals("Manas"))            // Done
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToString(block).Equals("A"))
                {
                    blockno = 0;
                }
                else if (Convert.ToString(block).Equals("B"))
                {
                    blockno = 1;
                }
                else if (Convert.ToString(block).Equals("C"))
                {
                    blockno = 2;
                }
                else if (Convert.ToString(block).Equals("D"))
                {
                    blockno = 3;
                }
                roomno = Convert.ToInt16(room) % 100;
            }
            else if (hostel.Equals("Married Hostel"))           // Done
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToChar(block) == 'A')
                {
                    blockno = 0;
                }

                roomno = Convert.ToInt16(room) % 100;
            }
            else if (hostel.Equals("New Boys Hostel"))
            {

            }
            else if (hostel.Equals("Siang"))            // Done
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToChar(block) == 'A')
                {
                    blockno = 0;
                }


                roomno = Convert.ToInt16(room) % 100;
            }
            else if (hostel.Equals("Subansiri"))           // Done
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToChar(block) == 'A')
                {
                    blockno = 0;
                }
                else if (Convert.ToChar(block) == 'B')
                {
                    blockno = 1;
                }
                else if (Convert.ToChar(block) == 'C')
                {
                    blockno = 2;
                }
                else if (Convert.ToChar(block) == 'D')
                {
                    blockno = 3;
                }

                roomno = Convert.ToInt16(room) % 100;
            }

            else if (hostel.Equals("Umiam"))              // Done
            {
                floor = Convert.ToInt32(room) / 100;

                if (Convert.ToChar(block) == 'A')
                {
                    blockno = 0;
                }
                else if (Convert.ToChar(block) == 'B')
                {
                    blockno = 1;
                }
                else if (Convert.ToChar(block) == 'C')
                {
                    blockno = 2;
                }

                roomno = Convert.ToInt16(room) % 100;
            }

            ipaddress += blockno + "" + floor + "." + roomno;
            
        }
        
        // This is for the EXIT button.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        // Check box for Entering proxy and port.
        
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Do_Checked();
        }
        
        
        // This is for Entering the proxy and port details.
        
        
        private void Do_Checked()
        {
            textBox2.Enabled = checkBox1.Checked;
            //textBox2. .DoubleClick
            textBox3.Enabled = checkBox1.Checked;
            var textbox = this.Controls["textBox2"] as TextBox;
            textbox.Focus();
        }


        //This is the proxy textbox.

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
        
        
        // This is the configure button.

        private void validateForm()
        {
            var comboBox1 = this.Controls["comboBox1"] as ComboBox;
            if (textBox1.Enabled == true && textBox1.Text.Length <= 0 && checkBox1.Checked == false)
            {
                MessageBox.Show("Enter your room number.","ERROR");
                return;
            }
            else if (comboBox1.Text.Length <= 0 && checkBox1.Checked == false)
            {
                MessageBox.Show("Select something Dude!!!", "ERROR");
                return;
            }
            else if(comboBox2.Text.Length <= 0 && comboBox2.Enabled == true)
            {
                MessageBox.Show("Select your Block", "ERROR");
                return;
            }
            else if ((comboBox3.Visible == true && comboBox3.Text.Length <= 0) && checkBox1.Checked == false)
            {
                MessageBox.Show("Enter your floor.", "ERROR");
                return;
            }
            else if (checkBox1.Checked == true && (textBox2.Text.Length <= 0) || (textBox3.Text.Length <= 0))
            {
                if (textBox2.Text.Length <= 0)
                {
                    MessageBox.Show("Enter Proxy Address.", "ERROR");
                    var textBox = this.Controls["textBox2"] as TextBox;
                    textBox2.Focus();
                    return;
                }

            }
                int proxybuffer;
                if (textBox3.Text.Length <= 0 || !int.TryParse(textBox3.Text, out proxybuffer))
                {
                    MessageBox.Show("Enter the Port Number.", "ERROR'S");
                    return;
                }
            

            int roomBuffer;

            //check if room no is valid
            if ((!int.TryParse(textBox1.Text, out roomBuffer) || roomBuffer > 380 || roomBuffer <= 0 )&& textBox1.Enabled == true)
            {
                MessageBox.Show("Enter a valid room number", "ERROR'S");
                return;
            }

            if (checkBox1.Checked == true)
            {
                ProxySettings();


            }
            if (textBox1.Enabled == true)
            {
                calculateAddress();
                ipSettings();
            }
            if (checkBox1.Checked == true && textBox1.Enabled == false) { 
           this.Close();
            }

        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
                 validateForm();
        }
        

        private void ProxySettings()
        {
            String proxy = textBox2.Text + ":" + textBox3.Text;
            try
            {
                String script = "Const HKEY_CURRENT_USER = &H80000001\r\nConst HKEY_LOCAL_MACHINE = &H80000002\r\n\r\nstrComputer = \".\"\r\n \r\nSet ScriptMe=GetObject(\"winmgmts:{impersonationLevel=impersonate}!\\\\\" & _ \r\n    strComputer & \"\\root\\default:StdRegProv\")\r\n \r\nstrKeyPath = \"Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\"\r\nstrKeyPath1 = \"Software\\Microsoft\\Internet Explorer\\Main\"\r\n\r\nstrValueName = \"ProxyEnable\"\r\ndwValue = 1\r\nScriptMe.SetDWORDValue HKEY_CURRENT_USER,strKeyPath,strValueName,dwValue\r\n\r\nstrValueName = \"ProxyServer\"\r\nstValue = \"" 
                    + proxy + "\"\r\nScriptMe.SetStringValue HKEY_CURRENT_USER,strKeyPath,strValueName,stValue\r\n\r\nstrValueName = \"ProxyOverride\"\r\nstValue = \"*.iitg.ernet.in;*.iitg.ac.in;202.141.80.*;202.141.81.*;192.168.100.1;172.16.32.*;10.9.20.2;192.168.0.101;10.9.1.20;172.16.28.65;192.168.100.1;<local>\"\r\nScriptMe.SetStringValue HKEY_CURRENT_USER,strKeyPath,strValueName,stValue\r\n\r\nstrValueName = \"Default_Page_URL\"\r\nstValue = \"http://www.google.co.uk\"\r\nScriptMe.SetStringValue HKEY_LOCAL_MACHINE,strKeyPath1,strValueName,stValue";

            //    string path = "proxy_set.vbs";
                using (StreamWriter writer = new StreamWriter("proxy_set.vbs"))
                {
                    writer.Write(script);
                }

                Process scriptProc = new Process();
                scriptProc.StartInfo.FileName = @".\proxy_set.vbs";
                scriptProc.Start();
                scriptProc.WaitForExit();
                scriptProc.Close();
                if (File.Exists(@".\proxy_set.vbs"))
                {
                    File.Delete(@".\proxy_set.vbs");
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            var firefoxPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles");
            if(Directory.Exists(firefoxPath)) {

                  try
            {
                String script = "cd /D \"%APPDATA%\\Mozilla\\Firefox\\Profiles\"\r\ncd *.default\r\nset ffile=%cd%\r\necho user_pref(\"network.proxy.http\", \"" +textBox2.Text+ "\");>>\"%ffile%\\prefs.js\"\r\necho user_pref(\"network.proxy.http_port\", " +textBox3.Text+ " );>>\"%ffile%\\prefs.js\"\r\necho user_pref(\"network.proxy.type\", 1);>>\"%ffile%\\prefs.js\"\r\necho user_pref(\"network.proxy.no_proxies_on\",\"*.iitg.ernet.in;*.iitg.ac.in;202.141.80.*;202.141.81.*;192.168.100.1;172.16.32.*;10.9.20.2;192.168.0.101;10.9.1.20;172.16.28.65;192.168.100.1\");>>\"%ffile%\\prefs.js\"\r\nset ffile=\r\ncd %windir%";

            //    string path = "proxy_set.vbs";
                using (StreamWriter writer = new StreamWriter("mozilla.bat"))
                {
                    writer.Write(script);
                }

                Process scriptProc = new Process();
                scriptProc.StartInfo.FileName = @".\mozilla.bat";
                scriptProc.Start();
                scriptProc.WaitForExit();
                scriptProc.Close();
                if (File.Exists(@".\mozilla.bat"))
                {
                    File.Delete(@".\mozilla.bat");
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            }
        }       
        private void ipSettings()
        {
              try
            {
                String script = ":checkPrivileges\r\nNET FILE 1>NUL 2>NUL\r\nif '%errorlevel%' == '0' ( goto gotPrivileges ) else ( goto getPrivileges)\r\n:getPrivileges \r\nif '%1'=='ELEV' (shift & goto gotPrivileges) \r\n setlocal DisableDelayedExpansion\r\nset \"batchPath=%~0\"\r\nsetlocal EnableDelayedExpansion\r\nECHO Set UAC = CreateObject^(\"Shell.Application\"^) > \"%temp%\\OEgetPrivileges.vbs\" \r\nECHO UAC.ShellExecute \"!batchPath!\", \"ELEV\", \"\", \"runas\", 1 >> \"%temp%\\OEgetPrivileges.vbs\" \r\n\"%temp%\\OEgetPrivileges.vbs\" \r\nexit /B \r\n:gotPrivileges\r\nsetlocal & pushd\r\nnetsh interface ip set address name=\"Ethernet\" static "+ipaddress+" "+dns+" "+altdns+"\r\nnetsh interface ipv4 add dnsserver \"Ethernet\" address=202.141.81.2 index=1\r\nnetsh interface ipv4 add dnsserver \"Ethernet\" address=202.141.80.9 index=2\r\npause";
               // string path = "ipconfig.bat";

                using (StreamWriter writer = new StreamWriter("ipconfig.bat"))
                {
                    writer.Write(script);
                }

                Process scriptProc = new Process();
                scriptProc.StartInfo.FileName = @".\ipconfig.bat";
                scriptProc.Start();
                scriptProc.WaitForExit();
                scriptProc.Close();
                this.Close();
                if (File.Exists(@".\ipconfig.bat"))
                {
                    File.Delete(@".\ipconfig.bat");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        //This is the port textbox.
        
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           // var textbox = this.Controls["testBox3"] as TextBox;
            
           
        }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            var textbox = this.Controls["textBox1"] as TextBox;
            textbox.Focus();
            textBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var room = this.Text;

        }

        private void comboBox1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
           
        }
        // This is for dropping down comboBox2 when the mouse is hovered.
        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            var comboBox2 = sender as ComboBox;
            comboBox2.DroppedDown = true;
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                validateForm();
            }
        }

   

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // var button1_Click = sender as Button;
                validateForm();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            var textbox = this.Controls["textBox3"] as TextBox;

            if (e.KeyCode == Keys.Enter)
            {
                textbox.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox1 = sender as ComboBox;
            var comboBox2 = this.Controls["comboBox2"] as ComboBox;
            var selectedItem = comboBox1.SelectedItem as string;
            if (selectedItem == null) return;
           comboBox2.DroppedDown = false;
           
                comboBox2.Enabled = true;

                comboBox2.Items.Clear();
                
                List<string> blocks = new List<string>();


                if (selectedItem.Equals("Barak"))
                {
                   // comboBox2.AllowDrop = true;
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("A");
                    blocks.Add("B");
                    blocks.Add("C");

                }

                if (selectedItem.Equals("Brahmaputra"))
                {
                    comboBox3.Visible = true;
                    label6.Visible = true;
                    comboBox3.Enabled = true;
                    label6.Enabled = true;
                    blocks.Add("A");
                    blocks.Add("B");
                    blocks.Add("C");
                    blocks.Add("D");

                }

                if (selectedItem.Equals("Dhansiri"))
                {
                    
                  

                    MessageBox.Show("Please select obtain IP address automatically.\n Please select obtain DNS automatically.");
                    textBox1.Enabled = false;
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    comboBox2.Enabled = false;
                }

                if (selectedItem.Equals("Dibang"))
                {

                    label6.Visible = true;
                    textBox3.Visible = true;
                    comboBox3.Enabled = true;
                    comboBox3.Visible = true;
                    label6.Enabled = true;
                    blocks.Add("A");
                    blocks.Add("B");
                    blocks.Add("C");
                    blocks.Add("D");
                    blocks.Add("E");
                    blocks.Add("F");
                    blocks.Add("G");
                    blocks.Add("H");
                    blocks.Add("I");
                    blocks.Add("J");
                    blocks.Add("K");
                    blocks.Add("L");
                }

                if (selectedItem.Equals("Dihing"))
                {
                    
                    blocks.Add("A");
                    comboBox3.Visible = false;
                    label6.Visible = false;
                }

                if (selectedItem.Equals("Kameng"))
                {
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("B1");
                    blocks.Add("B2");
                    blocks.Add("B3");
                    blocks.Add("B4");
                    blocks.Add("C");
                }

                if (selectedItem.Equals("Kapili"))
                {
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("A");
                }

                if (selectedItem.Equals("Manas"))
                {
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("A");
                    blocks.Add("B");
                    blocks.Add("C");
                    blocks.Add("D");
                }

                if (selectedItem.Equals("Married Hostel"))
                {
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("A");
                }

                if (selectedItem.Equals("New Boys Hostel"))
                {
                    
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    MessageBox.Show("Please select obtain IP address automatically.\n Please select obtain DNS automatically.");
                    textBox1.Enabled = false;
                    comboBox2.Enabled = false;
                }

                if (selectedItem.Equals("Siang"))
                {
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("A");
                }

                if (selectedItem.Equals("Subansiri"))
                {
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("A");
                    blocks.Add("B");
                    blocks.Add("C");
                    blocks.Add("D");
                }

                if (selectedItem.Equals("Umiam"))
                {
                    comboBox3.Visible = false;
                    label6.Visible = false;
                    blocks.Add("A");
                    blocks.Add("B");
                    blocks.Add("C");
                }

                foreach (string s in blocks)
                {
                    comboBox2.Items.Add(s);
                }
            if(!selectedItem.Equals("Dhansiri") && !selectedItem.Equals("New Boys Hostel")) {
                comboBox2.DroppedDown = true;
            }
            
        
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
