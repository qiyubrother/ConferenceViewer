using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace zntbkt
{
    public class ConferenceRoomManagement
    {
        private string _conferenceId { get; set; }
        private string _serverAddress { get; set; }
        private string _serverPort { get; set; }

        public ConferenceRoomManagement(string conferenceId, string serverAddress, string serverPort)
        {
            _conferenceId = conferenceId;
            _serverAddress = serverAddress;
            _serverPort = serverPort;
        }

        /// <summary>
        /// 获取会议室用户清单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConferenceRoomUser> GetConferenceRoomUserList()
        {
            var lst = new List<ConferenceRoomUser>();
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20list";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            var lines = result.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                Console.WriteLine($"RTN:{line}");
                if (line.StartsWith("-ERR"))
                {
                    throw new Exception(line);
                }
                var cu = new ConferenceRoomUser();
                var arr = line.Split(';');
                cu.UserCode = arr[0];
                cu.IsPrimarySpeaker = line.Contains("vid-floor;");
                cu.UserId = arr[3];
                cu.AudioStatus = line.Contains("speak") ? EnumAudioStatus.Speak : EnumAudioStatus.Mute;
                lst.Add(cu);
            }

            return lst;
        }

        /// <summary>
        /// 设置主讲
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public bool SetConferenceRoomPrimarySpeaker(string userCode, out string errorMessage)
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20vid-floor%20{userCode}%20force";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            errorMessage = result;
            Console.WriteLine($"RTN:{result}");

            return result.StartsWith("+OK");
        }

        /// <summary>
        /// 整个会议室静音
        /// </summary>
        /// <param name="errorMessage">响应字符串</param>
        /// <returns></returns>
        public bool SetConferenceMute(out string errorMessage)
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20mute%20all";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            errorMessage = result;
            Console.WriteLine($"RTN:{result}");
            return result.StartsWith("+OK");
        }
        /// <summary>
        /// 会议室某个人取消静音
        /// </summary>
        /// <param name="userCode">会议室成员ID</param>
        /// <param name="errorMessage">响应字符串</param>
        /// <returns></returns>
        public bool UnmuteConferenceUser(string userCode, out string errorMessage)
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20unmute%20{userCode}";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            errorMessage = result;
            Console.WriteLine($"RTN:{result}");
            return result.StartsWith("+OK");
        }

        /// <summary>
        /// 会议室某个人静音
        /// </summary>
        /// <param name="userCode">会议室成员ID</param>
        /// <param name="errorMessage">响应字符串</param>
        /// <returns></returns>
        public bool MuteConferenceUser(string userCode, out string errorMessage)
        {

            var oldList = GetConferenceRoomUserList();
            var _CancelMuteList = oldList.Where(x => x.AudioStatus == EnumAudioStatus.Speak && x.UserCode != userCode);

            if (!SetConferenceMute(out errorMessage))
            {
                errorMessage = "设置[整个会议室静音]失败！";
                return false;
            }
            foreach (var item in _CancelMuteList)
            {
                if (!UnmuteConferenceUser(item.UserCode, out errorMessage))
                {
                    errorMessage = "设置[会议室某个人取消静音]失败！";
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 取得会议室主播ID
        /// </summary>
        /// <param name="errorMessage">响应字符串</param>
        /// <returns></returns>
        public string GetConferencePrimarySpeaker(out string errorMessage)
        {
            //var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20mute%20all";
            //var result = GetResponse(url, out string statusCode);
            //errorMessage = result;

            //return result.StartsWith("+OK");
            errorMessage = "OK";
            return "3547";
        }
        /// <summary>
        /// 强制挂断会议中指定成员
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public bool HupUser(string userId, out string errorMessage)
        {
            IEnumerable<ConferenceRoomUser> usrList = null;
            try
            {
                usrList = GetConferenceRoomUserList();
            }
            catch (Exception ex)
            {
                if (ex.Message == $"-ERR Conference {_conferenceId}-{_serverAddress} not found")
                {
                    // 会议室不存在，认为执行成功
                    errorMessage = string.Empty;
                    return true;
                }
                else
                {
                    errorMessage = ex.Message;
                    return false;
                }
            }

            var usrs = usrList.Where(x => x.UserId == userId);
            if (usrs.Any())
            {
                var hasError = false;
                var detail = string.Empty;
                foreach (var usr in usrs)
                {
                    var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20hup%20%20{usr.UserCode}";
                    Console.WriteLine($"CMD:{url}");
                    var result = GetResponse(url, out string statusCode);
                    Console.WriteLine($"RTN:{result}");
                    detail += $"{usr.UserCode}, {result}{System.Environment.NewLine}";
                    if (!result.StartsWith("+OK"))
                    {
                        hasError = true;
                    }
                }
                if (hasError)
                {
                    errorMessage = detail;
                }
                else
                {
                    errorMessage = string.Empty;
                }
                return hasError;
            }
            else
            {
                // 如果输入UserId不存在，则无需强制挂断，故而认为执行成功。
                errorMessage = "Invalid userId.";
                return true;
            }
        }
        /// <summary>
        /// 强制会议中所有成员
        /// </summary>
        /// <returns></returns>
        public bool HupAll()
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20hup%20%20all";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            Console.WriteLine($"RTN:{result}");
            return result.StartsWith("+OK");
        }

        /// <summary>
        /// 获取会议室成员的输出音量（MicPhone volume）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public bool GetMicPhoneVolume(int userCode, out int volume)
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20volume_in%20{userCode}";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            Console.WriteLine($"RTN:{result}");
            if (result.StartsWith("+OK"))
            {
                var pos = result.IndexOf('=') + 1;
                volume = Convert.ToInt32(result.Substring(pos + 1)); // -4, -3, -2, -1, 0, 1, 2, 3, 4
            }
            else
            {
                volume = -5; // Invalid value
            }

            return result.StartsWith("+OK");
        }
        /// <summary>
        /// 获取会议室成员的输入音量（Speaker volume）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public bool GetSpeakerVolume(int userCode, out int volume)
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20volume_out%20{userCode}";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            Console.WriteLine($"RTN:{result}");
            if (result.StartsWith("+OK"))
            {
                var pos = result.IndexOf('=') + 1;
                volume = Convert.ToInt32(result.Substring(pos + 1)); // -4, -3, -2, -1, 0, 1, 2, 3, 4
            }
            else
            {
                volume = -5; // Invalid value
            }

            return result.StartsWith("+OK");
        }
        /// <summary>
        /// 设置会议室成员的输出音量（MicPhone volume）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public bool SetMicPhoneVolume(int userCode, int volume)
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20volume_in%20{userCode}%20{volume}";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            Console.WriteLine($"RTN:{result}");

            return result.StartsWith("+OK");
        }

        /// <summary>
        /// 获取会议室成员的输入音量（Speaker volume）
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public bool SetSpeakerVolume(int userCode, int volume)
        {
            var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20volume_out%20{userCode}%20{volume}";
            Console.WriteLine($"CMD:{url}");
            var result = GetResponse(url, out string statusCode);
            Console.WriteLine($"RTN:{result}");

            return result.StartsWith("+OK");
        }


        //public bool SetConferenceRoomPrimarySpeaker(string userId, IEnumerable<ConferenceRoomUser> userList, out string errorMessage)
        //{
        //    var u = userList.FirstOrDefault(x => x.UserId == userId);
        //    if (u == null)
        //    {
        //        errorMessage = "Invalid UserId.";
        //        return false;
        //    }
        //    var url = $"http://{_serverAddress}:{_serverPort}/api/conference?{_conferenceId}-{_serverAddress}%20vid-floor%20{u.UserCode}%20force";
        //    var result = GetResponse(url, out string statusCode);
        //    errorMessage = result;

        //    return result.StartsWith("+OK");
        //}

        /// <summary>
        /// Get方法读取Http响应
        /// </summary>
        /// <param name="url"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        private static string GetResponse(string url, out string statusCode)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Accept.Add(
            //  new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            try
            {
                response = httpClient.GetAsync(url).Result;
                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    //WriteLine(result);
                    return result;
                }
                return string.Empty;
            }
            catch
            {
                statusCode = response == null ? string.Empty : response.StatusCode.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 会议室全体静音
        /// </summary>

    }

    public class ConferenceRoomUser
    {
        public string UserCode { get; set; }
        public string UserId { get; set; }

        public EnumAudioStatus AudioStatus { get; set; }
        public bool IsPrimarySpeaker { get; set; }
    }

    public enum EnumAudioStatus
    {
        Speak,
        Mute,
    }

    public class CompareConferenceRoomUser : IEqualityComparer<ConferenceRoomUser>
    {
        public bool Equals(ConferenceRoomUser x, ConferenceRoomUser y)
        {
            return x.UserCode == y.UserCode;
        }

        int GetHashCode(ConferenceRoomUser obj) => obj.UserCode.GetHashCode();

        int IEqualityComparer<ConferenceRoomUser>.GetHashCode(ConferenceRoomUser obj) => obj.UserCode.GetHashCode();
    }
}
