using Dentest.UI.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentest.UI.Helpers
{
    public class Shared
    {
        public static User OnlineUser { get; set; }

        public static List<SimpleModel> houres { get; } = new List<SimpleModel>
            {
                new SimpleModel(0, "00"),
                new SimpleModel(1, "01"),
                new SimpleModel(2, "02"),
                new SimpleModel(3, "03"),
                new SimpleModel(4, "04"),
                new SimpleModel(5, "05"),
                new SimpleModel(6, "06"),
                new SimpleModel(7, "07"),
                new SimpleModel(8, "08"),
                new SimpleModel(9, "09"),
                new SimpleModel(10, "10"),
                new SimpleModel(11, "11"),
                new SimpleModel(12, "12"),
                new SimpleModel(13, "13"),
                new SimpleModel(14, "14"),
                new SimpleModel(15, "15"),
                new SimpleModel(16, "16"),
                new SimpleModel(17, "17"),
                new SimpleModel(18, "18"),
                new SimpleModel(19, "19"),
                new SimpleModel(20, "20"),
                new SimpleModel(21, "21"),
                new SimpleModel(22, "22"),
                new SimpleModel(23, "23"),
                new SimpleModel(24, "24"),
            };

        public static List<SimpleModel> types { get; } = new List<SimpleModel>
            {
                new SimpleModel(0, "Diş Çekimi"),
                new SimpleModel(1, "Dolgu"),
            };


    }


}
