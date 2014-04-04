using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Threading;
using Intermec.DataCollection.RFID;

namespace THOK.WES
{
    public class ReadRfid
    {
        public BRIReader brdr = null;

        /// <summary>
        /// 读取数据 达州
        /// </summary>
        /// <param name="strPort"></param>
        /// <param name="nBaudrate"></param>
        /// <param name="errString"></param>
        /// <returns></returns>
        //public List<string> LoadTagList(string strPort, int nBaudrate, out string errString)
        //{
        //    List<string> listRfid = new List<string>();
        //    errString = string.Empty;
        //    string[] MyTagList = new string[100];
        //    try
        //    {
        //        brdr = new BRIReader(null, "SERIAL://" + strPort);
        //        DateTime now = DateTime.Now;
        //        do
        //        {
        //            bool state = brdr.Read();
        //            if (brdr.TagCount > 0)
        //            {
        //                foreach (Tag tt in brdr.Tags)
        //                {
        //                    listRfid.Add(tt.ToString());
        //                    //MyTagList[++iTagCount] = tt.ToString();
        //                    //if (tt.TagFields.ItemCount > 0)
        //                    //{
        //                    //    foreach (TagField tf in tt.TagFields.FieldArray)
        //                    //    {
        //                    //        if (tf.Status < 0)
        //                    //        {
        //                    //            //code to handle read or write error on this field
        //                    //        }
        //                    //        else
        //                    //        {
        //                    //            //get field data such as ANT, COUNT, TIME, AFI, etc.
        //                    //            MyTagList[iTagCount] += " " + tf.ToString();
        //                    //        }
        //                    //    }
        //                    //}
        //                    //listRfid.Add(MyTagList[iTagCount]);
        //                }
        //            }
        //            if (listRfid.Count != 0)//读取到数据就跳出
        //            {
        //                break;
        //            }
        //        } while (((TimeSpan)(DateTime.Now - now)).TotalSeconds < 8);//5秒后无数据就返回
        //        brdr.Dispose();
        //        // this.CloseCom();
        //        return listRfid;
        //    }
        //    catch (Exception e)
        //    {
        //        brdr.Dispose();
        //        throw new Exception("错误：" + e.Message + "," + errString + "，数据：" + listRfid.ToArray());
        //    }
        //}
        
        public List<string> LoadTagList(string strPort, int nBaudrate, out string errString)
        {
            List<string> listRfid = new List<string>();
            errString = string.Empty;
            string[] MyTagList = new string[100];
            try
            {
                brdr = new BRIReader(null, "SERIAL://" + strPort);
            }
            catch (Exception ex)
            {
                THOKUtil.ShowError("BRIReader读取串口 [ " + strPort + " ] 失败！" + "内部：" + ex.Message);
                //throw new Exception("BRI读取串口:" + ex.Message);
                return null;
            }
            try
            {
                DateTime now = DateTime.Now;
                do
                {
                    bool state = brdr.Read();
                    if (brdr.TagCount > 0)
                    {
                        foreach (Tag tt in brdr.Tags)
                        {
                            listRfid.Add(tt.ToString());
                        }
                    }
                    if (listRfid.Count != 0)//读取到数据就跳出
                    {
                        break;
                    }
                }
                while (((TimeSpan)(DateTime.Now - now)).TotalSeconds < 8);//5秒后无数据就返回
                brdr.Dispose();
                return listRfid;
            }
            catch (Exception e)
            {
                brdr.Dispose();
                THOKUtil.ShowError("方法LoadTagList错误：" + e.Message + "," + errString + "，数据：" + listRfid.ToArray());
                return null;
            }
        }
    }
}
