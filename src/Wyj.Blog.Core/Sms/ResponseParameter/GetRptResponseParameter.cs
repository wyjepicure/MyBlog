using System.Collections.Generic;

namespace Wyj.Blog.Sms.ResponseParameter
{
    public class GetRptResponseParameter
    {
        /// <summary>
        /// 获取状态报告请求处理结果：0：成功非0：失败
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// result非0时rpts为空
        /// </summary>
        public List<Rpt> Rpts { get; set; }
    }

    public class Rpt
    {
        /// <summary>
        /// 平台流水号：对应下行请求返回结果中的msgid
        /// </summary>
        public long Msgid { get; set; }

        /// <summary>
        /// 用户自定义流水号：对应下行请求时填写的custid
        /// </summary>
        public string Custid { get; set; }

        /// <summary>
        /// 当前条数
        /// </summary>
        public int Pknum { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int Pktotal { get; set; }

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
        /// 状态报告对应的下行发送时间:YYYY-MM-DD HH:MM:SS
        /// </summary>
        public string Stime { get; set; }

        /// <summary>
        /// 状态报告返回时间:YYYY-MM-DD HH:MM:SS
        /// </summary>
        public string Rtime { get; set; }

        /// <summary>
        /// 接收状态：0:成功非0:失败
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 状态报告错误代码
        /// </summary>
        public string Errcode { get; set; }

        /// <summary>
        /// 状态报告错误代码的描述
        /// </summary>
        public string Errdesc { get; set; }

        /// <summary>
        /// 下行时填写的exdata
        /// </summary>
        public string Exdata { get; set; }
    }
}