using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace projekateParking.ViewModel
{
    class PrepoznavanjeTablica
    {
        private SoftwareBitmap bitmap;
        private OcrEngine ocrEngine = null;
        private string rezultat;
        private string imeSlike;

        public PrepoznavanjeTablica(string imeSlike)
        {
            this.imeSlike = imeSlike;
            rezultat = "";
        }
        public string dajTablice()
        {
            return rezultat;
        }
        public async Task prepoznajTablice()
        {
            await LoadSampleImage();
            ocrEngine = OcrEngine.TryCreateFromLanguage(OcrEngine.AvailableRecognizerLanguages[0]);
            var ocrResult = await ocrEngine.RecognizeAsync(bitmap);
            rezultat = ocrResult.Text;
        }
        private async Task LoadImage(StorageFile file)
        {
            using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                var decoder = await BitmapDecoder.CreateAsync(stream);

                bitmap = await decoder.GetSoftwareBitmapAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);

                var imgSource = new WriteableBitmap(bitmap.PixelWidth, bitmap.PixelHeight);
                bitmap.CopyToBuffer(imgSource.PixelBuffer);
            }
        }

        public async Task LoadSampleImage()
        {
            var picturesLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
            // Fall back to the local app storage if the Pictures Library is not available
            var _captureFolder = picturesLibrary.SaveFolder ?? ApplicationData.Current.LocalFolder;
            var file = await _captureFolder.GetFileAsync(imeSlike);
            await LoadImage(file);
        }
    }
}

