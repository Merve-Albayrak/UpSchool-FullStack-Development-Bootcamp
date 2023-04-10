using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.Excel
{
    public class ExcelBase64Dto
    {
        //base64 kullanmasının sebebi tüm cihazlarda kullanılabilir olması lazım
        //hafif şifreli gibi olması da artı
        public string File { get; set; }
        public ExcelBase64Dto()
        {

        }

        public ExcelBase64Dto(string file)
        {
            File = file;
        }
    }
}
