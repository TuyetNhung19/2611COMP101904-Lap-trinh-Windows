using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    public class KetQuaDAL
    {
        public DataTable GetLop() => ExecuteProcedureToTable("sp_Lop_GetAll");

        public DataTable GetMonHoc() => ExecuteProcedureToTable("sp_MonHoc_GetAll");

        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            return ExecuteProcedureToTable(
                "sp_KetQua_GetByLopMon",
                CreateParameter("@MaLop", SqlDbType.NVarChar, 20, maLop),
                CreateParameter("@MaMon", SqlDbType.NVarChar, 20, maMon));
        }

        /// <summary>
        /// Lưu toàn bộ DataTable trong MỘT transaction.
        /// Tất cả thành công -> Commit. Có lỗi -> Rollback rồi ném lỗi ra cho Form.
        /// </summary>
        /// <returns>Số dòng đã lưu.</returns>
        public int SaveAll(string maMon, DataTable table)
        {
            ArgumentNullException.ThrowIfNull(table);

            using SqlConnection conn = Database.CreateConnection();
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();

            try
            {
                // Mọi command phải dùng CHUNG conn và CHUNG trans
                using SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pMaSV = cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20);
                SqlParameter pMaMon = cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20);
                SqlParameter pDiem = cmd.Parameters.Add("@Diem", SqlDbType.Float);
                SqlParameter pGhiChu = cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255);

                int count = 0;
                foreach (DataRow row in table.Rows)
                {
                    pMaSV.Value = row["MaSV"].ToString() ?? "";
                    pMaMon.Value = maMon;
                    pDiem.Value = Convert.ToDouble(row["Diem"]);
                    pGhiChu.Value = row["GhiChu"] is DBNull ? "" : row["GhiChu"].ToString() ?? "";

                    cmd.ExecuteNonQuery();
                    count++;
              
                }

                trans.Commit();          
                return count;
            }
            catch
            {
                SafeRollback(trans);
                throw;                   // giữ nguyên lỗi gốc để Form hiển thị
            }
        }

        // ---------- hàm dùng chung ----------
        private static DataTable ExecuteProcedureToTable(string procedureName, params SqlParameter[] parameters)
        {
            using SqlConnection conn = Database.CreateConnection();
            using SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;      // bắt buộc khi gọi SP
            cmd.Parameters.AddRange(parameters);

            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);                                // tự mở và đóng kết nối
            return table;
        }

        private static SqlParameter CreateParameter(string name, SqlDbType type, int size, object value)
        {
            return new SqlParameter(name, type, size) { Value = value };
        }

        private static void SafeRollback(SqlTransaction trans)
        {
            try { trans.Rollback(); }
            catch (InvalidOperationException) { }
        }
    }
}