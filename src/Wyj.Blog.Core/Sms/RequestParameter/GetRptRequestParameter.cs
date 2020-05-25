namespace Wyj.Blog.Sms.RequestParameter
{
    /// <summary>
    /// 获取状态报告
    /// </summary>
    public class GetRptRequestParameter : BaseRequestParameter
    {
        /// <summary>
        /// 本次请求想要获取的状态报告最大条数。最大500，超过500按500返回。小于等于0或不填时，系统返回默认条数，默认500条
        /// </summary>
        public int Retsize { get; set; }
    }
}