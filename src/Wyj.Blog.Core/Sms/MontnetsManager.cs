using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Abp.Domain.Services;
using Newtonsoft.Json;
using Wyj.Blog.Sms.RequestParameter;
using Wyj.Blog.Sms.ResponseParameter;

namespace Wyj.Blog.Sms
{
    public class MontnetsManager : DomainService
    {
        private readonly string userid = "E10D53";
        private readonly string pwd = "b0wBgL";
        private readonly string fixedStr = "00000000";
        private readonly string requestPath = "/sms/v2/std/";
        private readonly string ipport = "api01.monyun.cn:7901";

        #region MD5

        public string Md5(string content)
        {
            var md5 = new MD5CryptoServiceProvider();
            var contentBytes = Encoding.GetEncoding("UTF-8").GetBytes(content); //指定编码方式
            var bytHash = md5.ComputeHash(contentBytes);

            // 字节数组转16进制字符串
            StringBuilder sTempX = new StringBuilder(content.Length);
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTempX.Append(bytHash[i].ToString("X2"));
            }
            return sTempX.ToString().ToLower();
        }

        #endregion MD5

        #region 时间戳

        public string GetTimeStamp()
        {
            var date = DateTime.Now;
            var format = "MMddHHmmss";

            return date.ToString(format, DateTimeFormatInfo.InvariantInfo);
        }

        #endregion 时间戳

        #region 鉴权内容

        // 账号+密码的密文值进行进行用户鉴权 (账号默认鉴权模式)
        public string GetDefaultSignContent(string timestamp)
        {
            return userid + fixedStr + pwd + timestamp;
        }

        //  账号+密码的明文值进行进行用户鉴权(需申请)

        // apikey进行用户鉴权(需申请)

        #endregion 鉴权内容

        #region 通过请求接口类型+IP/PORT获取完整的接口路径

        /// <summary>
        /// 通过请求接口类型+IP/PORT获取完整的接口路径
        /// </summary>
        /// <param name="sendtype">请求类型,1:单发，2：相同内容群发，3：不同类型群发，4：获取上行，5：获取状态报告，6：获取账号余额</param>
        /// <param name="ipport">IP/PORT，格式:ip:port,例如：122.11.1.88:8888</param>
        /// <returns></returns>
        private string getUrl(int sendtype, string ipport)
        {
            string methodName = string.Empty;
            switch (sendtype)
            {
                case 1:
                    methodName = "single_send";
                    break;

                case 2:
                    methodName = "batch_send";
                    break;

                case 3:
                    methodName = "multi_send";
                    break;

                case 4:
                    methodName = "get_mo";
                    break;

                case 5:
                    methodName = "get_rpt";
                    break;

                case 6:
                    methodName = "get_balance";
                    break;

                default:
                    return null;
            }

            return string.Format("http://{0}{1}{2}", ipport, requestPath, methodName);
        }

        #endregion 通过请求接口类型+IP/PORT获取完整的接口路径

        #region Post请求

        public async Task<string> SendPost(
            string url,
            string content,
            string contentType = "application/json"

        )
        {
            HttpClient httpClient = new HttpClient();

            // 请求参数
            HttpContent httpContent = new StringContent(content);

            // ContentType
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            // post请求
            var response = httpClient.PostAsync(url, httpContent);

            return await response.Result.Content.ReadAsStringAsync();
        }

        #endregion Post请求

        #region 单条发送

        public async Task<SendResponseParameter> SingleSend(SendRequestParameter input)
        {
            input.Userid = userid;
            input.Timestamp = GetTimeStamp();
            input.Pwd = Md5(GetDefaultSignContent(input.Timestamp));
            input.Content = HttpUtility.UrlEncode(input.Content, Encoding.GetEncoding("GBK"));

            var result = await SendPost(getUrl(1, ipport), JsonConvert.SerializeObject(input).ToLower());

            return JsonConvert.DeserializeObject<SendResponseParameter>(result);
        }

        #endregion 单条发送

        #region 相同内容群发

        public async Task<SendResponseParameter> BatchSend(SendRequestParameter input)
        {
            input.Userid = userid;
            input.Timestamp = GetTimeStamp();
            input.Pwd = Md5(GetDefaultSignContent(input.Timestamp));
            input.Content = HttpUtility.UrlEncode(input.Content, Encoding.GetEncoding("GBK"));

            var result = await SendPost(getUrl(2, ipport), JsonConvert.SerializeObject(input).ToLower());

            return JsonConvert.DeserializeObject<SendResponseParameter>(result);
        }

        #endregion 相同内容群发

        #region 个性化群发

        public async Task<SendResponseParameter> MultiSend(MultiSendRequestParameter input)
        {
            input.Userid = userid;
            input.Timestamp = GetTimeStamp();
            input.Pwd = Md5(GetDefaultSignContent(input.Timestamp));
            foreach (var item in input.Multimt)
            {
                item.content = HttpUtility.UrlEncode(item.content, Encoding.GetEncoding("GBK"));
            }

            var result = await SendPost(getUrl(3, ipport), JsonConvert.SerializeObject(input).ToLower());

            return JsonConvert.DeserializeObject<SendResponseParameter>(result);
        }

        #endregion 个性化群发

        #region 获取上行

        public async Task<GetMoResponseParameter> GetMo(GetMoRequestParameter input)
        {
            input.Userid = userid;
            input.Timestamp = GetTimeStamp();
            input.Pwd = Md5(GetDefaultSignContent(input.Timestamp));

            var result = await SendPost(getUrl(4, ipport), JsonConvert.SerializeObject(input).ToLower());

            return JsonConvert.DeserializeObject<GetMoResponseParameter>(result);
        }

        #endregion 获取上行

        #region 获取状态报告

        public async Task<GetRptResponseParameter> GetRpt(GetRptRequestParameter input)
        {
            input.Userid = userid;
            input.Timestamp = GetTimeStamp();
            input.Pwd = Md5(GetDefaultSignContent(input.Timestamp));

            var result = await SendPost(getUrl(5, ipport), JsonConvert.SerializeObject(input).ToLower());

            return JsonConvert.DeserializeObject<GetRptResponseParameter>(result);
        }

        #endregion 获取状态报告

        #region 查询余额

        public async Task<GetBalanceResponseParameter> GetBalance(GetBalanceRequestParameter input)
        {
            input.Userid = userid;
            input.Timestamp = GetTimeStamp();
            input.Pwd = Md5(GetDefaultSignContent(input.Timestamp));

            var result = await SendPost(getUrl(6, ipport), JsonConvert.SerializeObject(input).ToLower());

            return JsonConvert.DeserializeObject<GetBalanceResponseParameter>(result);
        }

        #endregion 查询余额
    }
}