using System.Collections.Generic;

namespace Wyj.Blog.Sms.RequestParameter
{
    /// <summary>
    /// 个性化群发
    /// </summary>
    public class MultiSendRequestParameter : BaseRequestParameter
    {
        /// <summary>
        /// 个性化信息详情:最多可支持100个手机号的个性化信息
        /// </summary>
        public List<MultiMt> Multimt { get; set; }
    }

    public class MultiMt
    {
        /// <summary>
        ///  获取或设置手机号
        /// </summary>
        public string mobile = string.Empty;

        /// <summary>
        /// 获取或设置 短信内容
        /// </summary>
        public string content = string.Empty;

        /// <summary>
        /// 获取或设置 业务类型
        /// </summary>
        public string svrtype = string.Empty;

        /// <summary>
        /// 获取或设置 扩展号
        /// </summary>
        public string exno = string.Empty;

        /// <summary>
        ///  获取或设置用户自定义的消息编号
        /// </summary>
        public string custid = string.Empty;

        /// <summary>
        /// 获取或设置 自定义扩展数据
        /// </summary>
        public string exdata = string.Empty;
    }
}