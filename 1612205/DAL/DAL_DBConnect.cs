using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Xml;

namespace DAL
{
    public class  DAL_DBConnect
    {               
            protected SqlConnection _conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyBanHang;Integrated Security=True");
    }
}

