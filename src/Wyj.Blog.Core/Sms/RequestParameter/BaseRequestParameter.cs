using System.ComponentModel.DataAnnotations;

namespace Wyj.Blog.Sms.RequestParameter
{
    public class BaseRequestParameter
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        [MaxLength(6)]
        public string Userid { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 时间戳：24小时制格式：MMDDHHMMSS,即月日时分秒，定长10位,月、日、时、分、秒每段不足2位时左补0,示例：0803192020
        /// </summary>
        public string Timestamp { get; set; }
    }
}