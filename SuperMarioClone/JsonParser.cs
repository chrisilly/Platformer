using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Xna.Framework;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    internal class JsonParser
    {
        static JObject wholeObj;
        static string currentFileName; //För att göra klassen användbar för olika nivåer

        public static void GetJObjectFromFile(string fileName)
            {
                currentFileName = fileName;
                StreamReader file = File.OpenText(@"..\..\..\Content\" + fileName);
                JsonTextReader reader = new JsonTextReader(file);
                //string s=File.ReadAllText(fileName);
                wholeObj = JObject.Load(reader);
            }

        public static Rectangle GetRectangle(string fileName, string propertyName)
            {
                if (wholeObj == null || currentFileName == null || currentFileName != fileName)
                {
                    GetJObjectFromFile(fileName);
                }
                JObject obj = (JObject)wholeObj.GetValue(propertyName);
                return GetRectangle(obj);
            }

        public static List<Rectangle> GetRectangleList(string fileName, string propertyName)
            {
                if (wholeObj == null || currentFileName == null || currentFileName != fileName)
                {
                    GetJObjectFromFile(fileName);
                }
                List<Rectangle> rectList = new List<Rectangle>();
                JArray arrayObj = (JArray)wholeObj.GetValue(propertyName);
                for (int i = 0; i < arrayObj.Count; i++)
                {
                    JObject obj = (JObject)arrayObj[i];
                    Rectangle rect = GetRectangle(obj);
                    rectList.Add(rect);
                }
                return rectList;
            }

        private static Rectangle GetRectangle(JObject obj)
            {
                int x = Convert.ToInt32(obj.GetValue("positionX"));
                int y = Convert.ToInt32(obj.GetValue("positionY"));
                int height = Convert.ToInt32(obj.GetValue("height"));
                int width = Convert.ToInt32(obj.GetValue("width"));
                Rectangle rectangle = new Rectangle(x, y, width, height);
                return rectangle;
            }

        public static void WriteJsonToFile(string filename, List<GameObject> objectList)
        {
            JArray enemyArray = new JArray();
            JArray solidArray = new JArray();
            JObject bigobj = new JObject();

            JArray array = new JArray();
            for (int i = 0; i < objectList.Count; i++)
            {
                if (objectList[i] is Enemy)
                {
                    JObject obj = CreateObject(objectList[i].Hitbox);
                    enemyArray.Add(obj);
                }
                else if (objectList[i] is Solid)
                {
                    JObject obj = CreateObject(objectList[i].Hitbox);
                    solidArray.Add(obj);
                }
                else if (objectList[i] is Player)
                {
                    JObject obj = CreateObject(objectList[i].Hitbox);
                    bigobj.Add("player", obj);
                }
            }
            bigobj.Add("enemy", enemyArray);
            bigobj.Add("solid", solidArray);
            System.Diagnostics.Debug.WriteLine(bigobj.ToString());
            File.WriteAllText(filename, bigobj.ToString());
        }

        private static JObject CreateObject(Rectangle rect)
            {
                JObject obj = new JObject();
                obj.Add("positionX", rect.X);
                obj.Add("positionY", rect.Y);
                obj.Add("height", rect.Height);
                obj.Add("width", rect.Width);
                return obj;
            }
    }
}
