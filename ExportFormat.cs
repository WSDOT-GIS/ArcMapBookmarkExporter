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

namespace BookmarkExporterAddIn
{
    /// <summary>
    /// An enumeration of possible export formats.
    /// </summary>
    public enum ExportFormat {
        /// <summary>None</summary>
        None = 0,
        /// <summary>used to export maps to AI (Adobe Illustrator) format.</summary>
        AI, 
        /// <summary>used to export maps to BMP (Windows Bitmap) format.</summary>
        BMP, 
        /// <summary>used to export maps to EMF (Windows Enhanced Metafile) format.</summary>
        EMF, 
        /// <summary>used to export maps to GIF (Graphics Interchange Format).</summary>
        GIF, 
        /// <summary>used to export maps to JPEG (Joint Photographic Experts Group) format.</summary>
        JPEG, 
        /// <summary>used to export maps to PDF (Portable Document Format) format.</summary>
        PDF, 
        /// <summary>used to export maps to PNG (Portable Network Graphics) format.</summary>
        PNG, 
        /// <summary>used to export maps to PS (PostScript) and EPS (Encapsulated PostScript) format.</summary>
        PS, 
        /// <summary>used to export maps to SVG (Scalable Vector Graphics) format.</summary>
        SVG, 
        /// <summary>used to export maps to TIFF (Tagged Image File Format).</summary>
        TIFF
    }
}