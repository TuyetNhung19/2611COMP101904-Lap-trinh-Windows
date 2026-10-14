using QRCoder;

namespace InTheSinhVien
{
    /// <summary>
    /// Boc thu vien ngoai QRCoder. Co cache 1 ma gan nhat vi ham Paint
    /// duoc goi rat nhieu lan, khong nen tao lai QR o moi lan ve.
    /// </summary>
    public static class QrHelper
    {
        private static string? _noiDungCache;
        private static Bitmap? _bitmapCache;

        public static Bitmap LayQr(string noiDung)
        {
            if (_bitmapCache != null && _noiDungCache == noiDung)
                return _bitmapCache;

            using QRCodeGenerator generator = new QRCodeGenerator();
            // forceUtf8 = true de tieng Viet co dau duoc ma hoa dung.
            using QRCodeData data = generator.CreateQrCode(noiDung, QRCodeGenerator.ECCLevel.M, true);
            using QRCode qr = new QRCode(data);
            Bitmap moi = qr.GetGraphic(8, Color.Black, Color.White, true);

            _bitmapCache?.Dispose();
            _bitmapCache = moi;
            _noiDungCache = noiDung;
            return moi;
        }

        public static void GiaiPhong()
        {
            _bitmapCache?.Dispose();
            _bitmapCache = null;
            _noiDungCache = null;
        }
    }
}
