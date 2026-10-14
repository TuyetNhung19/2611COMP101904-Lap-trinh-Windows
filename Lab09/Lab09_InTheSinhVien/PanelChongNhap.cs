namespace InTheSinhVien
{
    /// <summary>
    /// Panel bat DoubleBuffered de preview ve lai khong bi nhap nhay.
    /// </summary>
    public class PanelChongNhap : Panel
    {
        public PanelChongNhap()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}
