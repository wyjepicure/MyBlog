namespace Wyj.Blog.Sms.RequestParameter
{
    /// <summary>
    /// 获取上行
    /// </summary>
    public class GetMoRequestParameter : BaseRequestParameter
    {
        /// <summary>
        /// 每次请求想要获取的上行最大条数。最大200,超过200按200返回。小于等于0或不填时，系统返回默认条数，默认200条
        /// </summary>
        public int Retsize { get; set; }
    }
}