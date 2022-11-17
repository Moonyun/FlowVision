using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.common;
using System.Windows.Media;

namespace WpfApp1.model
{
    public class ImagesModel:NotifyBase
    {

        private List<ImgType> listImg = new List<ImgType>();      //构建list存储img

        
    }
    //定义图像数据类型
    public class ImgType
    {
        public ImageSource ImgSource { get; set; }
    }

}
