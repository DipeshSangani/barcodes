﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Mobile;


namespace Acr.BarCodes {

    public class BarCodesImpl : AbstractBarCodesImpl {

        protected override Stream ToImageStream(BarcodeWriter writer, BarCodeCreateConfiguration cfg) {
            var ms = new MemoryStream();
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                var bitmap = writer.Write(cfg.BarCode);
                bitmap.SaveJpeg(ms, cfg.Width, cfg.Height, 0, 100);
                ms.Seek(0, SeekOrigin.Begin);
            });
            return ms;
        }


        protected override MobileBarcodeScanner GetInstance() {
            return new MobileBarcodeScanner(Deployment.Current.Dispatcher) { UseCustomOverlay = false };

        }
    }
}
