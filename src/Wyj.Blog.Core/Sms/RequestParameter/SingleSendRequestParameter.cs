using System.ComponentModel.DataAnnotations;

namespace Wyj.Blog.Sms.RequestParameter
{
    public class SingleSendRequestParameter
    {
        /// <summary>
        /// 短信接收的手机号,多个手机号请用英文逗号分隔，最大1000个号码。
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 短信内容：最大支持1000个字(含签名)，发送时请预留至少10个字符的签名长度，一个字母或一个汉字都视为一个字符。编码方式:urlencode（GBK明文）
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 业务类型：最大可支持10个长度的英文字母、数字组合的字符串
        /// </summary>
        public string Svrtype { get; set; }

        /// <summary>
        /// 扩展号：注意通道号+扩展号的总长度不能超过20位，若超出则exno无效，如不需要扩展号则不用提交此字段或填空
        /// </summary>
        [MaxLength(6)]
        public string Exno { get; set; }

        /// <summary>
        /// 用户自定义流水号：该条短信在您业务系统内的ID，比如订单号或者短信发送记录的流水号。填写后发送状态返回值内将包含用户自定义流水号。最大可支持64位的ASCII字符串：字母、数字、下划线、减号，如不需要则不用提交此字段或填空
        /// </summary>
        public string Custid { get; set; }

        /// <summary>
        /// 自定义扩展数据：额外提供的最大64个长度的ASCII字符串：字母、数字、下划线、减号，作为自定义扩展数据，填写后，状态报告返回时将会包含这部分数据，如不需要则不用提交此字段或填空
        /// </summary>
        public string Exdata { get; set; }
    }
}