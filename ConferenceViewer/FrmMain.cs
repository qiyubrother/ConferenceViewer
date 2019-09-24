using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zntbkt;
namespace ConferenceViewer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            Icon = Properties.Resources.conference;
        }
        /// <summary>
        /// 查询会议室全体成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            listBox1.Items.AddRange(query(txtConference.Text, txtAddress.Text, txtPort.Text));
        }

        private string[] query(string conference, string address, string port)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(conference, address, port);

            var lst = crm.GetConferenceRoomUserList().Select(x => $"{x.UserCode}\t{x.UserId}\t{x.AudioStatus}\t{x.IsPrimarySpeaker}");
            return lst.ToArray();
        }

        /// <summary>
        /// 全部静音::包括主播在内都不能说。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMuteAll_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            if (!crm.SetConferenceMute(out string errorMessage))
            {
                MessageBox.Show("设置失败！");
            }
        }

        /// <summary>
        /// 全部成员允许说话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelMuteAll_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            foreach(var usr in crm.GetConferenceRoomUserList())
            {
                if (!crm.UnmuteConferenceUser(usr.UserCode, out string errorMessage))
                {
                    //MessageBox.Show("设置失败！");
                }
            }
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);

            crm.MuteConferenceUser(txtUserCode.Text, out string errorMessage);
        }

        private void btnCancelMute_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            var oldList = crm.GetConferenceRoomUserList();

            var item = oldList.FirstOrDefault(x => x.UserCode == txtUserCode.Text);
            if (item != null && item.AudioStatus == EnumAudioStatus.Mute)
            {
                if (!crm.UnmuteConferenceUser(item.UserCode, out string errorMessage))
                {
                    MessageBox.Show("设置失败！");
                }
            }
        }
    }
}
