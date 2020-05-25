namespace Wyj.Blog.Sms.ResponseParameter
{
    public class SendResponseParameter
    {
        /// <summary>
        /// 短信发送请求处理结果：0：成功 非0：失败
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 平台流水号：非0，64位整型,result非0时，msgid为0
        /// </summary>
        public long Type1 { get; set; }

        /// <summary>
        /// 用户自定义流水号：默认与请求报文中的custid保持一致，若请求报文中没有custid参数或值为空，则返回由梦网生成的代表本批短信的唯一编号result非0时，custid为空
        /// </summary>
        public string Type2 { get; set; }
    }
}