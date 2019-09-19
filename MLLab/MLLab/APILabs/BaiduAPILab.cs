using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MLLab.APILabs
{
	class BaiduAPILab
	{
		public static BaiduAPILab Instance;
		string token = "";
		Dictionary<string, string> dicUrls = new Dictionary<string, string>();
		static BaiduAPILab()
		{
			Instance = new BaiduAPILab();

			Instance.dicUrls["通用文字识别"] = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic";
		}


		public void Test()
		{
			TokenClass tokenClass = new TokenClass() { access_token = "24.f304dd4eb740dbe986261b22c89efba0.2592000.1571466449.282335-17279220" };
			//string token = AccessToken.getAccessToken();
			//TokenClass tokenClass = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenClass>(token);

			//"{\"refresh_token\":\"25.dc0006400b6736146b2520c38f2a873a.315360000.1884233538.282335-17279220\",\"expires_in\":2592000,\"session_key\":\"9mzdCKct+czl2LWxlBqejOaeH1ABvoFSkJJy590P5h4gYGRoeTYGM1ZZ\\/D41bDN\\/BdhWB2pfcRW1x+eZTDwkM8o5JS7Nqw==\",\"access_token\":\"24.3c97756aaa583891bfd95c1efab05ff2.2592000.1571465538.282335-17279220\",\"scope\":\"public vis-ocr_ocr vis-antiporn_antiporn_v2 vis-classify_watermark brain_ocr_scope brain_gif_antiporn brain_ocr_general brain_ocr_general_basic vis-classify_terror vis-ocr_business_license brain_ocr_webimage brain_all_scope vis-starface_public_person solution_face brain_ocr_idcard brain_ocr_driving_license brain_ocr_vehicle_license brain_antiporn brain_antiterror vis-classify_\\u6076\\u5fc3\\u56fe\\u8bc6\\u522b\\u670d\\u52a1 vis-ocr_plate_number brain_politician brain_imgquality_general brain_solution brain_ocr_plate_number brain_watermark brain_ocr_accurate brain_ocr_accurate_basic brain_ocr_receipt brain_ocr_business_license brain_solution_iocr brain_public brain_disgust brain_ocr_handwriting brain_antispam_spam brain_ocr_passport brain_ocr_vat_invoice brain_numbers brain_ocr_train_ticket brain_ocr_taxi_receipt vis-ocr_household_register vis-ocr_vis-classify_birth_certificate vis-ocr_\\u53f0\\u6e7e\\u901a\\u884c\\u8bc1 vis-ocr_\\u6e2f\\u6fb3\\u901a\\u884c\\u8bc1 vis-ocr_\\u673a\\u52a8\\u8f66\\u68c0\\u9a8c\\u5408\\u683c\\u8bc1\\u8bc6\\u522b vis-ocr_\\u8f66\\u8f86vin\\u7801\\u8bc6\\u522b vis-ocr_\\u5b9a\\u989d\\u53d1\\u7968\\u8bc6\\u522b brain_ocr_vin brain_ocr_quota_invoice brain_ocr_birth_certificate brain_ocr_household_register brain_ocr_HK_Macau_pass brain_ocr_taiwan_pass brain_ocr_vehicle_certificate wise_adapt lebo_resource_base lightservice_public hetu_basic lightcms_map_poi kaidian_kaidian ApsMisTest_Test\\u6743\\u9650 vis-classify_flower lpq_\\u5f00\\u653e cop_helloScope ApsMis_fangdi_permission smartapp_snsapi_base iop_autocar oauth_tp_app smartapp_smart_game_openapi oauth_sessionkey smartapp_swanid_verify smartapp_opensource_openapi smartapp_opensource_recapi fake

			while (true)
			{
				string apiUrl = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=" + tokenClass.access_token;
				Dictionary<string, string> body = new Dictionary<string, string>();

				string imgurl = "http://www.xiaobaixitong.com/d/file/help/2018-08-06/f15ce5d652d8da38e9e0e384f35b39d7.png";
				imgurl = "https://p2.ssl.qhimgs1.com/sdr/400__/t016e337e5d39d7bcd8.jpg";
				imgurl = "https://p1.ssl.qhimgs1.com/sdr/400__/t01d59387202fbc0c91.jpg";
				List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
				paraList.Add(new KeyValuePair<string, string>("url", imgurl));


				string result = GetPostResult(apiUrl, paraList);
				Result res = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(result);
				//"{\"log_id\": 4161902717780911763, \"words_result_num\": 1, \"words_result\": [{\"words\": \"7364\"}]}"
			}


		}

		// 通用文字识别
		//public static string general()
		//{
		//	string token = "#####调用鉴权接口获取的token#####";
		//	//string strbaser64 = FileUtils.getFileBase64("/work/ai/images/ocr/general.jpeg"); // 图片的base64编码
		//	string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general?access_token=" + token;
		//	Encoding encoding = Encoding.Default;
		//	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
		//	request.Method = "post";
		//	request.ContentType = "application/x-www-form-urlencoded";
		//	request.KeepAlive = true;
		//	String str = "image=" + HttpUtility.UrlEncode(strbaser64);
		//	byte[] buffer = encoding.GetBytes(str);
		//	request.ContentLength = buffer.Length;
		//	request.GetRequestStream().Write(buffer, 0, buffer.Length);
		//	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		//	StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
		//	string result = reader.ReadToEnd();
		//	Console.WriteLine("通用文字识别:");
		//	Console.WriteLine(result);
		//	return result;
		//}
		public static String GetPostResult(string url, List<KeyValuePair<String, String>> paraList)
		{
			//String authHost = "https://aip.baidubce.com/oauth/2.0/token";
			HttpClient client = new HttpClient();
			//List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
			//paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
			//paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
			//paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

			HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(paraList)).Result;
			String result = response.Content.ReadAsStringAsync().Result;
			Console.WriteLine(result);
			return result;
		}
	}

	class TokenClass
	{
		public string refresh_token;
		public string access_token;
		public string session_key;
		public int expires_in;
	}
	class Result
	{
		public string log_id;
		public int words_result_num;

		public List<object> words_result;
	}
	public static class AccessToken

	{
		// 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
		// 返回token示例
		public static String TOKEN = "24.adda70c11b9786206253ddb70affdc46.2592000.1493524354.282335-1234567";

		// 百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务
		private static String clientId = "hBMc3g5c65bbnxKX6W5KIEii";
		// 百度云中开通对应服务应用的 Secret Key
		private static String clientSecret = "yeGhDoXE3GACNXKYOQGNdpOH6cF9guiG";

		public static String getAccessToken()
		{
			String authHost = "https://aip.baidubce.com/oauth/2.0/token";
			HttpClient client = new HttpClient();
			List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
			paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
			paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
			paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

			HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
			String result = response.Content.ReadAsStringAsync().Result;
			Console.WriteLine(result);
			return result;
		}

	}
}
