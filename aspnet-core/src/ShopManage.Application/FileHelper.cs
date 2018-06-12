using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.Text;

namespace ShopManage
{
    /// <summary>
    /// 文件操作辅助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 编码的字符串转为图片  
        /// </summary>
        /// <param name="strbase64">base64编码</param>
        /// <param name="path">图片保存路径</param>
        /// <returns></returns>
        public static string Base64StringToImage(string strbase64,string path)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                var savepath = @"C:/images/"+path;
                bmp.Save(savepath, ImageFormat.Jpeg);
                ms.Close();
                return "http://112.74.32.7:8008/" + path;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
