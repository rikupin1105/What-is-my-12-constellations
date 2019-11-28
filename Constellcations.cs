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
            //POST���ꂽJSON��String�ɕϊ�
            var data = await req.Content.ReadAsAsync<DialogFlowRequest>();
            var Birthday = data.queryResult.parameters.Birthday;

            //�V���A���C�Y�������̂���a�������擾�B
            var seiza = Seizahantei(Birthday);

            //���X�|���XJSON�𐶐�
            var ResponceObject = new DialogFlowResponce();
            ResponceObject.fulfillmentText = "���Ȃ��̐�����" + seiza + "�ł��B";
            string json = JsonConvert.SerializeObject(ResponceObject);

            //JSON�Ń��^�[��
            var ReturnObject = new ObjectResult(json);
            return ReturnObject;
        }

        /// <summary>
        /// �a��������12������Ԃ��܂�
        /// </summary>
        public static string Seizahantei(DateTime Birthday)
        {
            var Borned_Month = Birthday.Month;
            var Borned_Day = Birthday.Day;
            switch (Borned_Month)
            {
                case 1:
                    if (Borned_Day >= 20) return "�݂����ߍ�";
                    if (Borned_Day <= 19) return "�€��";
                    break;
                case 2:
                    if (Borned_Day >= 19) return "������";
                    if (Borned_Day <= 18) return "�݂����ߍ�";
                    break;
                case 3:
                    if (Borned_Day >= 21) return "���Ђ���";
                    if (Borned_Day <= 20) return "������";
                    break;
                case 4:
                    if (Borned_Day >= 20) return "��������";
                    if (Borned_Day <= 19) return "���Ђ���";
                    break;
                case 5:
                    if (Borned_Day >= 21) return "�ӂ�����";
                    if (Borned_Day <= 20) return "��������";
                    break;
                case 6:
                    if (Borned_Day >= 22) return "���ɍ�";
                    if (Borned_Day <= 21) return "�ӂ�����";
                    break;
                case 7:
                    if (Borned_Day >= 23) return "������";
                    if (Borned_Day <= 22) return "���ɍ�";
                    break;
                case 8:
                    if (Borned_Day >= 23) return "���Ƃߍ�";
                    if (Borned_Day <= 22) return "������";
                    break;
                case 9:
                    if (Borned_Day >= 23) return "�Ă�т��";
                    if (Borned_Day <= 22) return "���Ƃߍ�";
                    break;
                case 10:
                    if (Borned_Day >= 24) return "�������";
                    if (Borned_Day <= 23) return "�Ă�т��";
                    break;
                case 11:
                    if (Borned_Day >= 23) return "���č�";
                    if (Borned_Day <= 22) return "�������";
                    break;
                case 12:
                    if (Borned_Day >= 22) return "�€��";
                    if (Borned_Day <= 21) return "���č�";
                    break;
            }
            return "�G���[�ł�";
        }

    }
}
