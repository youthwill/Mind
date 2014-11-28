using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mind
{
    class MindAPI
    {
        #region 统计后二位形态
        public static string aHouEr(string kaiJiangHao)
        {
            string myType = "";
            int Num0 = 0, Num1 = 0, Num2 = 0, Num3 = 0, Num4 = 0;
            string[] NUM = kaiJiangHao.Split(new string[] { "," }, StringSplitOptions.None);
            Num0 = Int32.Parse(NUM[0]);
            Num1 = Int32.Parse(NUM[1]);
            Num2 = Int32.Parse(NUM[2]);
            Num3 = Int32.Parse(NUM[3]);
            Num4 = Int32.Parse(NUM[4]);

            if (Num3 == Num4)
            {
                myType = "对子";
            }
            else if (Math.Abs(Num3 - Num4) == 1)
            {
                myType = "";
            }

            return myType;
        }
        #endregion

        #region 判断后三位形态
        public static string aHouSan(string kaiJiangHao)
        {
            string myType = "";
            int Num0 = 0, Num1 = 0, Num2 = 0, Num3 = 0, Num4 = 0;
            string[] NUM = kaiJiangHao.Split(new string[] { "," }, StringSplitOptions.None);
            Num0 = Int32.Parse(NUM[0]);
            Num1 = Int32.Parse(NUM[1]);
            Num2 = Int32.Parse(NUM[2]);
            Num3 = Int32.Parse(NUM[3]);
            Num4 = Int32.Parse(NUM[4]);

            if (Num3 == Num4 && Num2 == Num3)
            {
                myType = "豹子";
            }
            else if (Num2 != Num3 && Num3 != Num4 && Num2 != Num4)
            {
                myType = "";
            }
            else
            {
                myType = "组三";
            }

            return myType;
        }
        #endregion

        #region 判断前三位形态
        public static string aQianSan(string kaiJiangHao)
        {
            string myType = "";
            int Num0 = 0, Num1 = 0, Num2 = 0, Num3 = 0, Num4 = 0;
            string[] NUM = kaiJiangHao.Split(new string[] { "," }, StringSplitOptions.None);
            Num0 = Int32.Parse(NUM[0]);
            Num1 = Int32.Parse(NUM[1]);
            Num2 = Int32.Parse(NUM[2]);
            Num3 = Int32.Parse(NUM[3]);
            Num4 = Int32.Parse(NUM[4]);

            if (Num0 == Num1 && Num1 == Num2)
            {
                myType = "豹子";
            }
            else if (Num0 != Num1 && Num1 != Num2 && Num0 != Num2)
            {
                myType = "";
            }
            else
            {
                myType = "组三";
            }

            return myType;
        }
        #endregion

        #region 判断中间三位形态
        public static string aZhongSan(string kaiJiangHao)
        {
            string myType = "";
            int Num0 = 0, Num1 = 0, Num2 = 0, Num3 = 0, Num4 = 0;
            string[] NUM = kaiJiangHao.Split(new string[] { "," }, StringSplitOptions.None);
            Num0 = Int32.Parse(NUM[0]);
            Num1 = Int32.Parse(NUM[1]);
            Num2 = Int32.Parse(NUM[2]);
            Num3 = Int32.Parse(NUM[3]);
            Num4 = Int32.Parse(NUM[4]);

            if (Num1 == Num2 && Num2 == Num3)
            {
                myType = "豹子";
            }
            else if (Num1 != Num2 && Num2 != Num3 && Num1 != Num3)
            {
                myType = "";
            }
            else
            {
                myType = "组三";
            }

            return myType;
        }
        #endregion

        #region 判断开奖号码中是否存在顺子
        public static string isShunzi(string kaiJiangHao)
        {
            string myType = "";
            int Num0 = 0, Num1 = 0, Num2 = 0, Num3 = 0, Num4 = 0;
            string[] NUM = kaiJiangHao.Split(new string[] { "," }, StringSplitOptions.None);
            Array.Sort(NUM);
            Num0 = Int32.Parse(NUM[0]);
            Num1 = Int32.Parse(NUM[1]);
            Num2 = Int32.Parse(NUM[2]);
            Num3 = Int32.Parse(NUM[3]);
            Num4 = Int32.Parse(NUM[4]);

            if ((Num4 - Num3 == 1 && Num3 - Num2 == 1) || (Num3 - Num2 == 1 && Num2 - Num1 == 1) || (Num2 - Num1 == 1 && Num1 - Num0 == 1))
            {
                myType = "顺子";
            }
            
            return myType;
        }
        #endregion

        #region 获取数字0所在的位置
        /// <summary>
        /// 获取数字0所在的位置
        /// </summary>
        /// <param name="kaiJiangHao"></param>
        /// <returns></returns>
        public static string whereZero(string kaiJiangHao)
        {
            string myType = "";
            int Num0 = 0, Num1 = 0, Num2 = 0, Num3 = 0, Num4 = 0;
            string[] NUM = kaiJiangHao.Split(new string[] { "," }, StringSplitOptions.None);
            //Array.Sort(NUM);
            Num0 = Int32.Parse(NUM[0]);
            Num1 = Int32.Parse(NUM[1]);
            Num2 = Int32.Parse(NUM[2]);
            Num3 = Int32.Parse(NUM[3]);
            Num4 = Int32.Parse(NUM[4]);

            if (Num0==0)
            {
                myType = "万";
            }
            if (Num1 == 0)
            {
                myType += "千";
            }
            if (Num2 == 0)
            {
                myType += "百";
            }
            if (Num3 == 0)
            {
                myType += "十";
            }
            if (Num4 == 0)
            {
                myType += "个";
            }

            return myType;
        }
        #endregion

        #region 预测未来
        public static string compute(StreamReader sr,int range, int number)
        {
            string upNum = "", downNum = "", leftNum = "", rightNum = "";
            string line = "";
            string strResult = "", kaiJiangHao = "";
            int limit = 0;
            

            while ((line = sr.ReadLine()) != null)
            {
                string[] stringSeparators = new string[] { "-" };
                string[] temp = new string[] { "" };
                strResult = line.ToString();
                temp = strResult.Split(stringSeparators, StringSplitOptions.None)[1].ToString().Split(new string[] { "\t" }, StringSplitOptions.None);
                kaiJiangHao += temp[1].ToString() + ",";
                limit++;
                if (limit == range)
                {
                    break;
                }
            }
            string[] allNum = kaiJiangHao.Split(new string[] { "," }, StringSplitOptions.None);
            try
            {
                for (int i = 0; i < range * 5 - 1; i++)
                {
                    int tempNum = Int32.Parse(allNum[i]);
                    if (tempNum == number)
                    {
                        if (i > 4)
                        {
                            downNum += allNum[i - 5] + ",";
                        }
                        if (i + 5 < allNum.Length)
                        {
                            upNum += allNum[i + 5] + ",";
                        }
                        if (i > 0)
                        {
                            leftNum += allNum[i - 1] + ",";
                        }
                        if (i + 1 < allNum.Length)
                        {
                            rightNum += allNum[i + 1] + ",";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return upNum + ";\r\n" + downNum + ";\r\n" + leftNum + ";\r\n" + rightNum;
        }

        #endregion

    }
}
