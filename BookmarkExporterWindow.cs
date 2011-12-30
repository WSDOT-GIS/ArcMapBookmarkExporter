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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ESRI.ArcGIS.Framework;

namespace BookmarkExporterAddIn
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class BookmarkExporterWindow : UserControl
    {
        Exporter _exporter;

        public BookmarkExporterWindow(object hook)
        {
            InitializeComponent();
            this.Hook = hook;
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private BookmarkExporterWindow m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new BookmarkExporterWindow(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        private void BookmarkExporterWindow_Load(object sender, EventArgs e)
        {
            // Populates the combo box with the possible output formats.
            exportFormatComboBox.DataSource = (from fmt in (ExportFormat[])Enum.GetValues(typeof(ExportFormat))
                                               where fmt != ExportFormat.None
                                               select fmt).ToArray();
        }

        private void _directoryButton_Click(object sender, EventArgs e)
        {


            string path;
            using (var dialog = new FolderBrowserDialog
            {
                Description = "Select the directory where the exported images will go.",
                ShowNewFolderButton = false
            })
            {
                var result = dialog.ShowDialog();
                path = result == DialogResult.OK ? dialog.SelectedPath : null;
            }
            if (!string.IsNullOrEmpty(path))
            {
                _directoryTextBox.Text = path;
            }
        }

        private void _exportButton_Click(object sender, EventArgs e)
        {
            if (_exporter == null)
            {
                _exporter = new Exporter((IApplication)this.Hook);
            }
            _exporter.ExportBookmarksToFiles(_directoryTextBox.Text, Convert.ToInt64(_dpiNud.Value), (ExportFormat)exportFormatComboBox.SelectedValue);
        }
    }
}
