using System.Collections.Generic;

namespace Wyj.Blog.Sms.ResponseParameter
{
    /// <summary>
    /// 获取上行响应
    /// </summary>
    public class GetMoResponseParameter
    {
        /// <summary>
        /// 获取上行请求处理结果：0：成功非0：失败
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// result非0时mos为空
        /// </summary>
        public List<Mo> Mos { get; set; }
    }

    public class Mo
    {
        /// <summary>
        /// 平台流水号：上行在梦网云通信平台中的唯一编号
        /// </summary>
        public long Msgid { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 完整的通道号
        /// </summary>
        public string Spno { get; set; }

        /// <summary>
        /// 下行时填写的exno
        /// </summary>
        public string Exno { get; set; }

        /// <summary>
        /// 上行返回的时间：YYYY-MM-DD HH:MM:SS
        /// </summary>
        public string Rtime { get; set; }

        /// <summary>
        /// 短信内容：最大支持1000个字(含签名),一个字母或一个汉字都视为一个字。编码方法：urlencode（UTF-8明文）
        /// </summary>
        public string Content { get; set; }
    }
}