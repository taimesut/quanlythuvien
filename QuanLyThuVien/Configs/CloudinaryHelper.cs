using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace QuanLyThuVien.Configs
{
    public class CloudinaryHelper
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryHelper(string cloudName, string apiKey, string apiSecret)
        {
            Account account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public string UploadImage(string filePath)
        {
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath)
                };

                var uploadResult = _cloudinary.Upload(uploadParams);

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return uploadResult.SecureUrl.ToString();
                }
                else
                {
                    MessageBox.Show("Upload lỗi: " + uploadResult.Error.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi upload ảnh: " + ex.Message);
                return null;
            }
        }

        public Image LoadImageFromUrl(string imageUrl)
        {
            try
            {
                WebRequest request = WebRequest.Create(imageUrl);
                using (WebResponse response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh từ URL: " + ex.Message);
                return null;
            }
        }

        public bool DownloadImage(string imageUrl, string savePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(imageUrl, savePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh về file: " + ex.Message);
                return false;
            }
        }
    }
}
