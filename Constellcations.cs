using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace constellations
{
    public static class Constellcations
    {
        [FunctionName("Function1")]
        public static async System.Threading.Tasks.Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req, ILogger log)
        {
            //POSTされたJSONをStringに変換
            var data = await req.Content.ReadAsAsync<DialogFlowRequest>();
            var Birthday = data.queryResult.parameters.Birthday;

            //シリアライズしたものから誕生日を取得。
            var seiza = Seizahantei(Birthday);

            //レスポンスJSONを生成
            var ResponceObject = new DialogFlowResponce();
            ResponceObject.fulfillmentText = "あなたの星座は" + seiza + "です。";
            string json = JsonConvert.SerializeObject(ResponceObject);

            //JSONでリターン
            var ReturnObject = new ObjectResult(json);
            return ReturnObject;
        }

        /// <summary>
        /// 誕生日から12星座を返します
        /// </summary>
        public static string Seizahantei(DateTime Birthday)
        {
            var Borned_Month = Birthday.Month;
            var Borned_Day = Birthday.Day;
            switch (Borned_Month)
            {
                case 1:
                    if (Borned_Day >= 20) return "みずがめ座";
                    if (Borned_Day <= 19) return "やぎ座";
                    break;
                case 2:
                    if (Borned_Day >= 19) return "うお座";
                    if (Borned_Day <= 18) return "みずがめ座";
                    break;
                case 3:
                    if (Borned_Day >= 21) return "おひつじ座";
                    if (Borned_Day <= 20) return "うお座";
                    break;
                case 4:
                    if (Borned_Day >= 20) return "おうし座";
                    if (Borned_Day <= 19) return "おひつじ座";
                    break;
                case 5:
                    if (Borned_Day >= 21) return "ふたご座";
                    if (Borned_Day <= 20) return "おうし座";
                    break;
                case 6:
                    if (Borned_Day >= 22) return "かに座";
                    if (Borned_Day <= 21) return "ふたご座";
                    break;
                case 7:
                    if (Borned_Day >= 23) return "しし座";
                    if (Borned_Day <= 22) return "かに座";
                    break;
                case 8:
                    if (Borned_Day >= 23) return "おとめ座";
                    if (Borned_Day <= 22) return "しし座";
                    break;
                case 9:
                    if (Borned_Day >= 23) return "てんびん座";
                    if (Borned_Day <= 22) return "おとめ座";
                    break;
                case 10:
                    if (Borned_Day >= 24) return "さそり座";
                    if (Borned_Day <= 23) return "てんびん座";
                    break;
                case 11:
                    if (Borned_Day >= 23) return "いて座";
                    if (Borned_Day <= 22) return "さそり座";
                    break;
                case 12:
                    if (Borned_Day >= 22) return "やぎ座";
                    if (Borned_Day <= 21) return "いて座";
                    break;
            }
            return "エラーです";
        }

    }
}
