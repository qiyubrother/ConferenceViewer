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

            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
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
            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }

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
            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
            foreach (var usr in crm.GetConferenceRoomUserList())
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

            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
            crm.MuteConferenceUser(txtUserCode.Text, out string errorMessage);
        }

        private void btnCancelMute_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);

            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }

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

        private void btnSetMicPhoneVolume_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
            crm.SetMicPhoneVolume(Convert.ToInt32(txtUserCode.Text), (int)numericUpDown1.Value);
        }

        private void btnGetMicphoneVolume_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
            int volume;
            crm.GetMicPhoneVolume(Convert.ToInt32(txtUserCode.Text), out volume);
            txtRtnVolume.Text = volume.ToString();
        }

        private void btnSetSpeaker_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
            crm.SetSpeakerVolume(Convert.ToInt32(txtUserCode.Text), (int)numericUpDown1.Value);
        }

        private void btnGetSpeakerVolume_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);
            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
            int volume;
            crm.GetSpeakerVolume(Convert.ToInt32(txtUserCode.Text), out volume);
            txtRtnVolume.Text = volume.ToString();
        }

        private void btnQueryAll_Click(object sender, EventArgs e)
        {
            ConferenceRoomManagement crm = new ConferenceRoomManagement(txtConference.Text, txtAddress.Text, txtPort.Text);

            if (!crm.IsExistConferenceRoom())
            {
                MessageBox.Show("会议室不存在！");
                return;
            }
            var lst = query(txtConference.Text, txtAddress.Text, txtPort.Text);
            var sb = new StringBuilder();
            for (var i = 0; i < lst.Length; i++)
            {
                var arr = lst[i].Split('\t');
                var userCode = arr[0];
                var userId = arr[1];
                var isMuted = arr[2] == "Mute" ? "静音" : "正常";
                int speakerVolume;
                crm.GetSpeakerVolume(Convert.ToInt32(userCode), out speakerVolume);
                int micPhoneVolume;
                crm.GetMicPhoneVolume(Convert.ToInt32(userCode), out micPhoneVolume);
                sb.Append($"会议室ID={txtConference.Text}，用户代码={userCode}，用户ID={userId}，是否静音={isMuted}，输入={micPhoneVolume}，输出={speakerVolume}{System.Environment.NewLine}");
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
