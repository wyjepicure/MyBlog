namespace Wyj.Blog.Sms.ResponseParameter
{
    /// <summary>
    /// 查询余额响应
    /// </summary>
    public class GetBalanceResponseParameter
    {
        /// <summary>
        /// 查询余额请求处理结果：0：成功 非0：失败
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 计费类型：0：条数计费，单位：“条”，money默认为01：金额计费，单位：“元”，balance默认为0
        /// </summary>
        public int Chargetype { get; set; }

        /// <summary>
        /// 短信余额总条数：result非0时值为0，chargetype为1时值为0
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// 短信余额总金额：result非0时值为0，chargetype为0时值为0
        /// </summary>
        public string Money { get; set; }
    }
}