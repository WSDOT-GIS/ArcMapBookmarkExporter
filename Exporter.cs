/*
 * Copyright (c) 2011 Washington State Department of Transportation
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 *
 */
using System;
using System.IO;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;

namespace BookmarkExporterAddIn
{
    /// <summary>Used to export ArcMap documents to other formats.</summary>
    /// <remarks>This is a singleton object.</remarks>
    public class Exporter
    {
        IApplication _app;

        /// <summary>
        /// Creates a new instance of <see cref="Exporter"/>.
        /// </summary>
        public Exporter(IApplication app)
        {
            if (app == null) throw new ArgumentNullException("app");
            _app = app;
        }

        /// <summary>Exports all bookmarks to PDF files.</summary>
        /// <param name="directory">The directory that the exported files will be written to.</param>
        /// <param name="dpi">The resolution of the output files.</param>
        /// <param name="exportFormat">The format of the exported files.</param>
        public void ExportBookmarksToFiles(string directory, long dpi, ExportFormat exportFormat)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException("Directory not found: " + directory);
            }
            IMouseCursor mc = new MouseCursorClass();
            const int hourglass = 2;
            mc.SetCursor(hourglass);

            IMxDocument mxDoc = _app.Document as IMxDocument;
            IMapBookmarks bookmarks = (IMapBookmarks)mxDoc.FocusMap;

            IEnumSpatialBookmark enumBM = bookmarks.Bookmarks;
            enumBM.Reset();
            ISpatialBookmark sbm = enumBM.Next();


            ProgressDialogFactoryClass dialogFactory = new ProgressDialogFactoryClass();
            var cancelTracker = new CancelTrackerClass();
            IStepProgressor stepProgressor = dialogFactory.Create(cancelTracker, _app.hWnd);
            IProgressDialog2 progDialog = stepProgressor as IProgressDialog2;
            progDialog.CancelEnabled = true;

            progDialog.ShowDialog();
            stepProgressor.Hide();
            stepProgressor.Message = "Exporting...";

            // Create a formatting string with the proper extension.  (E.g., "{0}.pdf" for PDF files".)
            string fnFmt = string.Format("{{0}}.{0}", Enum.GetName(typeof(ExportFormat), exportFormat));
            try
            {
                while (sbm != null)
                {
                    sbm.ZoomTo(mxDoc.FocusMap);
                    string filename = System.IO.Path.Combine(directory, string.Format(fnFmt, sbm.Name));
                    ExportPageLayoutToFile(mxDoc.PageLayout, filename, dpi, exportFormat);
                    sbm = enumBM.Next();
                }
            }
            finally
            {
                if (progDialog != null)
                {
                    progDialog.HideDialog();
                    ComReleaser.ReleaseCOMObject(progDialog);
                }
            }
        }

        /// <summary>Exports the page layout to a file.</summary>
        /// <param name="pageLayout">The page layout.</param>
        /// <param name="exportPath">The name of the output file.</param>
        /// <param name="exportFormat">The format of the output.</param>
        /// <param name="dpi">The resolution of the output files.</param>
        void ExportPageLayoutToFile(IPageLayout pageLayout, string exportPath, long dpi, ExportFormat exportFormat)
        {
            IExport export = null;

            // Get the color of the backgrounds for formats that support transparent backgrounds.
            IColor bgColor = null;
            switch (exportFormat)
            {
                case ExportFormat.GIF:
                case ExportFormat.PNG:
                    IPage page = pageLayout.Page;
                    bgColor = page.BackgroundColor;
                    break;
            }


            // Set "export" to the proper type of Export*Class, and set parameters specific to that image type.
            switch (exportFormat)
            {
                case ExportFormat.AI:
                    export = new ExportAIClass();
                    var ai = export as IExportAI2;
                    //ai.EmbedFonts = true;
                    break;
                case ExportFormat.EMF:
                    export = new ExportEMFClass();
                    var xEmf = export as IExportEMF;
                    //xEmf.Description = 
                    break;
                case ExportFormat.PS:
                    export = new ExportPSClass();
                    var xPs = export as IExportPS;
                    xPs.EmbedFonts = true;
                    //xPs.Emulsion = 
                    //xPs.Image = 
                    //xPs.ImageCompression = esriExportImageCompression.esriExportImageCompressionNone
                    //xPs.LanguageLevel = esriExportPSLanguageLevel.esriExportPSLevel3
                    break;
                case ExportFormat.SVG:
                    export = new ExportSVGClass();
                    var xSvg = export as IExportSVG;
                    //xSvg.Compressed = true;
                    //xSvg.EmbedFonts = true;
                    break;
                case ExportFormat.PDF:
                    export = new ExportPDFClass();
                    var xPdf = export as IExportPDF;
                    //xPdf.Compressed = true;
                    //xPdf.EmbedFonts = true;
                    //xPdf.ImageCompression = esriExportImageCompression.esriExportImageCompressionNone
                    break;

                case ExportFormat.GIF:
                    export = new ExportGIFClass();
                    IExportGIF xGif = export as IExportGIF;
                    xGif.TransparentColor = bgColor;
                    //xGif.BiLevelThreshold = 
                    //xGif.CompressionType = esriGIFCompression.esriGIFCompressionNone;
                    //xGif.InterlaceMode = false;
                    break;
                case ExportFormat.PNG:
                    export = new ExportPNGClass();
                    IExportPNG xPng = export as IExportPNG;
                    //xPng.BiLevelThreshold =
                    //xPng.InterlaceMode = false;
                    xPng.TransparentColor = bgColor;
                    break;
                case ExportFormat.BMP:
                    export = new ExportBMPClass();
                    IExportBMP xBmp = export as IExportBMP;
                    //xBmp.BiLevelThreshold = 
                    //xBmp.RLECompression = true;
                    break;
                case ExportFormat.JPEG:
                    export = new ExportJPEGClass();
                    IExportJPEG xJpg = export as IExportJPEG;
                    //xJpg.ProgressiveMode = false;
                    //xJpg.Quality = 80;  //The JPEG compression / image quality. Range (0..100). Default is 100 (no compression / best quality).
                    break;
                case ExportFormat.TIFF:
                    export = new ExportTIFFClass();
                    IExportTIFF xTif = export as IExportTIFF;
                    //xTif.BiLevelThreshold =
                    //xTif.CompressionType = 
                    //xTif.GeoTiff = true;
                    //The JPEG or Deflate (depending on the Compression type) compression / image quality. Range (0..100). Default is 100 (no compression / best quality).     
                    //xTif.JPEGOrDeflateQuality = 100; 
                    break;
                default:
                    const string MSG_FMT = "Support for \"{0}\" export is not yet implemented.";
                    string message = string.Format(MSG_FMT, Enum.GetName(typeof(ExportFormat), exportFormat));
                    throw new NotImplementedException(message);
            }

            IEnvelope pixelEnv = new EnvelopeClass();
            IEnvelope pageExt = GetPageExtent(pageLayout);
            IPoint upperRight = pageExt.UpperRight;
            pixelEnv.PutCoords(0, 0, dpi * upperRight.X, dpi * upperRight.Y);
            export.PixelBounds = pixelEnv;
            export.Resolution = dpi;
            export.ExportFileName = exportPath;
            //    
            //(device coordinates origin is upper left, ypositive is down)
            tagRECT expRect;
            expRect.left = (int)export.PixelBounds.LowerLeft.X;
            expRect.bottom = (int)export.PixelBounds.UpperRight.Y;
            expRect.right = (int)export.PixelBounds.UpperRight.X;
            expRect.top = (int)export.PixelBounds.LowerLeft.Y;

            _app.StatusBar.set_Message(0, string.Format("exporting \"{0}\"", exportPath));
            long hdc = export.StartExporting();
            IActiveView av = (IActiveView)pageLayout;
            av.Output((int)hdc, (int)dpi, ref expRect, null, null);
            export.FinishExporting();
            export.Cleanup();
        }

        /// <summary>Gets the extent of the page.</summary>
        private static IEnvelope GetPageExtent(IPageLayout pageLayout)
        {
            double width, height;
            pageLayout.Page.QuerySize(out width, out height);
            IEnvelope env = new EnvelopeClass();
            env.PutCoords(0, 0, width, height);
            return env;
        }

    }
}
