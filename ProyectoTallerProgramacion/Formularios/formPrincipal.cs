using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Clases;
using SmtPop;
using Limilabs;

namespace formPrincipal
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new formEnvioCorreo();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            Pop
            pop3.Connect("mail.host.com");      
            pop3.Login("user", "password");
            foreach (string uid in pop3.GetAll())
            {
                IMail email = new MailBuilder()
                    .CreateFromEml(pop3.GetMessageByUID(uid));
                Console.WriteLine(email.Subject);
            }
            pop3.Close(false);   
            */


            /*
            SmtPop.POP3Client pop = new SmtPop.POP3Client ();
            pop.ReceiveTimeout = 3 * 60000;
            pop.Open("pop.gmail.com",110,"santiagotommasi92","marlou1006");
            SmtPop.POPMessageId[] messages = pop.GetMailList();
            */

            /*if (messages != null)
            {
                // Walk attachment list
                foreach (SmtPop.POPMessageId id in messages)
                {
                    SmtPop.POPReader reader = pop.GetMailReader(id);
                    SmtPop.MimeMessage msg = new SmtPop.MimeMessage ();
 
                    // read message
                    msg.Read(reader);
                    if (msg.Attachments != null)
                    {
                        // do something with first attachment
                        SmtPop.MimeAttachment attach = msg.Attachments[0];
                        if (attach.Filename == "data")
                        {
                            // read data from attachment
                            Byte[] b = Convert.FromBase64String (attach.Body);
                            System.IO.MemoryStream mem = new System.IO.MemoryStream (b, false);
                            BinaryFormatter f = new BinaryFormatter ();
                            DataClass data = (DataClass) f.Deserialize(mem); 
                            mem.Close();
                         }                          
                        //delete message
                        pop.Dele (id.Id);
                    }
                }
            }*/

            /*if (messages != null)
            {
                // run through available messages in POP3 server
                foreach (POPMessageId id in messages)
                {
                    POPReader reader = pop.GetMailReader(id);
                    MimeMessage msg = new MimeMessage();

                    // read the message
                    msg.Read(reader);
                    if (msg.Attachments != null)
                    {
                        // retrieve attachements
                        foreach (MimeAttachment attach in msg.Attachments)
                        {
                            if (attach.Filename != "")
                            {
                                // read data from attachment
                                Byte[] b = Convert.FromBase64String(attach.Body);
                                // save attachment to disk
                                System.IO.MemoryStream mem = new System.IO.MemoryStream(b, false);
                                FileStream outStream = File.OpenWrite(attach.Filename);
                                mem.WriteTo(outStream);
                                mem.Close();
                                outStream.Flush();
                                outStream.Close();
                            }
                        }
                    }
                    //delete message
                    pop.Dele(id.Id);
                }
            }
            //close the connection to POP3 server
            pop.Quit();  */

        } 
    }
}
