namespace Lab08_Simplepaint
{
    /// <summary>Panel bật DoubleBuffered để vẽ không bị nhấp nháy.</summary>
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;   // resize thì tự vẽ lại
        }
    }
}
