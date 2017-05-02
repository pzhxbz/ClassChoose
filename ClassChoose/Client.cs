using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassChoose
{
    class Client
    {
        public Client()
        {

        }

        public UserRetInfo RegisterUser(JObject json)
        {
            var nvc = new Dictionary<String, String>();
            foreach (var body in json)
            {
                nvc.Add(body.Key, body.Value.ToString());
            }
            String retInfo = Post("http://localhost:3000/api/register", nvc);
            if (retInfo.Length == 0)
            {
                return null;
            }
            //String retInfo = "{\"code\": 0,\"msg\": \"成功\"}";
            JObject retJson = JObject.Parse(retInfo);
            var result = new UserRetInfo();
            result.Code = (int)retJson["code"];
            result.Msg = (String)retJson["msg"];
            return result;
        }

        public UserRetInfo Login(JObject json)
        {
            var nvc = new Dictionary<String, String>();
            foreach (var body in json)
            {
                nvc.Add(body.Key, body.Value.ToString());
            }
            //var content = new FormUrlEncodedContent(nvc);
            //String retInfo = HttpPost("http://localhost:3000/api/login", content.ToString());
            /* var client = new HttpClient();
             var req = new HttpRequestMessage(HttpMethod.Post, "http://localhost:3000/api/login") { Content = new FormUrlEncodedContent(nvc) };
             var ret = client.SendAsync(req);
             var retInfo = ret.ToString();*/
            //var content = new FormUrlEncodedContent(nvc);
            var retInfo = Post("http://localhost:3000/api/login", nvc);

            if (retInfo.Length == 0)
            {
                return null;
            }
            //String retInfo = "{\"code\": 0,\"msg\": \"成功\"}";
            JObject retJson = JObject.Parse(retInfo);
            var result = new UserRetInfo();
            result.Code = (int)retJson["code"];
            result.Msg = (String)retJson["msg"];
            if (result.Code == 0)
            {
                result.token = (String)retJson["token"];
            }
            return result;
        }

        public List<ClassInfo> GetClassInfo()
        {
            String retInfo = HttpGet("http://localhost:3000/api/lesson_list", "");
            if (retInfo.Length == 0)
            {
                return null;
            }
            JObject retJson = JObject.Parse(retInfo);
            var listInfo = ((JArray)retJson["list"]);
            List<ClassInfo> result = new List<ClassInfo>();
            foreach (var lessonInfo in listInfo)
            {
                ClassInfo temp = new ClassInfo();
                temp.ClassNumber = (String)lessonInfo["id"];
                temp.ClassName = (String)lessonInfo["name"];
                temp.TeacherName = (String)lessonInfo["teacher"];
                temp.TotolNum = (int)lessonInfo["limit"];
                temp.RemainingNum = (int)lessonInfo["number"];
                result.Add(temp);
            }
            return result;
        }

        public UserRetInfo ChooseClass(String username, String token, String ClassNum)
        {
            JObject postInfo = new JObject();
            postInfo.Add(new JProperty("username", username));
            postInfo.Add(new JProperty("token", token));
            postInfo.Add(new JProperty("lesson_id", ClassNum));
            var nvc = new Dictionary<String, String>();
            foreach (var body in postInfo)
            {
                nvc.Add(body.Key, body.Value.ToString());
            }
            String retInfo = Post("http://localhost:3000/api/select_lesson", nvc);
            if (retInfo.Length == 0)
            {
                return null;
            }
            JObject retJson = JObject.Parse(retInfo);
            UserRetInfo result = new UserRetInfo();
            result.Code = (int)retJson["code"];
            result.Msg = (String)retJson["msg"];
            return result;

        }

        public List<String> GetChoosedClass(String token, String username)
        {
            JObject getInfo = new JObject();
            getInfo.Add(new JProperty("token", token));
            var nvc = new Dictionary<String, String>();
            foreach (var body in getInfo)
            {
                nvc.Add(body.Key, body.Value.ToString());
            }
            var retInfo = Get("http://localhost:3000/api/user_info/" + username, nvc);
            //var retInfo =
            //    "{ \"code\": 0, \"msg\": \"成功\", \"info\": {  \"lesson_list\": [\"janus\", \"has\", \"a\", \"big\", \"dick\"]}}";
            if (retInfo.Length == 0)
            {
                return null;
            }
            JObject retJson = JObject.Parse(retInfo);
            var result = new List<String>();
            if ((int)retJson["code"] != 0)
            {
                return result;
            }
            var lessonList = (JArray)((JObject)retJson["info"])["lesson_list"];

            foreach (var id in lessonList)
            {
                result.Add(id.ToString());
            }
            return result;
        }

        public UserRetInfo CancelLesson(String token, String username, String id)
        {
            JObject postInfo = new JObject();
            postInfo.Add(new JProperty("username", username));
            postInfo.Add(new JProperty("lesson_id", id));
            postInfo.Add(new JProperty("token", token));
            var nvc = new Dictionary<String, String>();
            foreach (var body in postInfo)
            {
                nvc.Add(body.Key, body.Value.ToString());
            }
            var retInfo = Post("http://localhost:3000/api/cancel_lesson", nvc);
            if (retInfo.Length == 0)
            {
                return null;
            }

            JObject retJson = JObject.Parse(retInfo);

            var result = new UserRetInfo();
            result.Code = (int)retJson["code"];
            result.Msg = (String)retJson["msg"];
            return result;

        }

        public string HttpPost(string url, string data)
        {
            try
            {
                //创建post请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                //request.ContentType = "application/json;charset=UTF-8";
                request.ContentType = "application/x-www-form-urlencoded";
                //request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] payload = Encoding.UTF8.GetBytes(data);
                request.ContentLength = payload.Length;

                //发送post的请求
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string value = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();

                return value;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string HttpGet(string url, string data)
        {
            try
            {
                //创建Get请求
                url = url + (data == "" ? "" : "?") + data;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                //request.ContentType = "text/html;charset=UTF-8";
                request.ContentType = "application/x-www-form-urlencoded";
                //request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string retString = streamReader.ReadToEnd();

                streamReader.Close();
                stream.Close();
                response.Close();

                return retString;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public String Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数  
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        public String Get(string url, Dictionary<string, string> dic)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(url);
            if (dic.Count > 0)
            {
                builder.Append("?");
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(builder.ToString());
            //添加参数  
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容  
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }
    }

    public class UserRetInfo
    {
        public int Code;
        public String Msg;
        public String token;

        public UserRetInfo()
        {

        }
    }


}
