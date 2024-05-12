using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public class chuoiketnoi
    {


        public static string sqlcon = @"Server=MSITHINGF63; Database=QLBanHang; Integrated Security=True; MultipleActiveResultSets=true";
        public static SqlConnection mycon = new SqlConnection();

        public static void taoKetNoi()
        {
            mycon.ConnectionString = sqlcon;
            try
            {
                mycon.Open();//Mở kết nối đế DATABASE
            }
            catch(Exception) 
            {
                throw;
            }
        }

        //Hàm đóng kết nối
        public static void dongKetNoi()
        {
            mycon.Close();
        }

        //Hàm đổ dữ liệu vào database
        public static DataTable getData(string query)
        {
            taoKetNoi();
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, mycon);
            da.Fill(tb);
            dongKetNoi();
            return tb;
        }



       

        
             
       
    }
}
