namespace OpenIDE.Core
{
    /// <summary>
    /// Helper methods.
    /// </summary>
    static internal class Helpers
    {

        #region " Public methods "

        /// <summary>
        /// Returns the specified filter as a filter string.
        /// </summary>
        /// <param name="filter">
        /// The filter to return.
        /// </param>
        /// <returns>
        /// The string representation of the filter.
        /// </returns>
        public static string ReturnFilterAsString(FilterBuilder.Filters filter)
        {

            //Return the correct filter string for the filter items
            switch (filter)
            {

                case FilterBuilder.Filters.WordDocuments:

                    return "Microsoft Word Documents (*.doc)|*.doc";
                case FilterBuilder.Filters.WordOpenXMLDocuments:

                    return "Microsoft Word Open XML Documents (*.docx)|*.docx";
                case FilterBuilder.Filters.LogFiles:

                    return "Log Files (*.log)|*.log";
                case FilterBuilder.Filters.MailMessages:

                    return "Mail Messages (*.msg)|*.msg";
                case FilterBuilder.Filters.PagesDocuments:

                    return "Pages Documents (*.pages)|*.pages";
                case FilterBuilder.Filters.RichTextFiles:

                    return "Rich Text Files (*.rtf)|*.rtf";
                case FilterBuilder.Filters.TextFiles:

                    return "Plain Text Files (*.txt)|*.txt";
                case FilterBuilder.Filters.WordPerfectDocuments:

                    return "WordPerfect Documents (*.wpd)|*.wpd";
                case FilterBuilder.Filters.WorksWordProcessorDocuments:

                    return "Microsoft Works Word Processor Documents (*.wps)|*.wps";
                case FilterBuilder.Filters.Lotus123Spreadsheets:

                    return "Lotus 1-2-3 Spreadsheets (*.123)|*.123";
                case FilterBuilder.Filters.Access2007DatabaseFiles:

                    return "Access 2007 Database Files (*.accdb)|*.accdb";
                case FilterBuilder.Filters.CSV_Files:

                    return "Comma Separated Values Files (*.csv)|*.csv";
                case FilterBuilder.Filters.DataFiles:

                    return "Data Files (*.dat)|*.dat";
                case FilterBuilder.Filters.DatabaseFiles:

                    return "Database Files (*.db)|*.db";
                case FilterBuilder.Filters.DLL_Files:

                    return "Dynamic Link Library Files (*.dll)|*.dll";
                case FilterBuilder.Filters.AccessDatabaseFiles:

                    return "Microsoft Access Database Files (*.mdb)|*.mdb";
                case FilterBuilder.Filters.PowerPointSlideShows:

                    return "PowerPoint Slide Shows (*.pps)|*.pps";
                case FilterBuilder.Filters.PowerPointPresentations:

                    return "PowerPoint Presentations (*.ppt)|*.ppt";
                case FilterBuilder.Filters.PowerPointOpenXMLDocuments:

                    return "Microsoft PowerPoint Open XML Documents (*.pptx)|*.pptx";
                case FilterBuilder.Filters.OpenOfficeBaseDatabaseFiles:

                    return "OpenOffice.org Base Database Files (*.sdb)|*.sdb";
                case FilterBuilder.Filters.SQLDataFiles:

                    return "SQL Data Files (*.sql)|*.sql";
                case FilterBuilder.Filters.vCardFiles:

                    return "vCard Files (*.vcf)|*.vcf";
                case FilterBuilder.Filters.UCConversionFiles:

                    return "Universal Converter Conversion Files (*.ucv)|*.ucv";
                case FilterBuilder.Filters.WorksSpreadsheets:

                    return "Microsoft Works Spreadsheets (*.wks)|*.wks";
                case FilterBuilder.Filters.ExcelSpreadsheets:

                    return "Microsoft Excel Spreadsheets (*.xls)|*.xls";
                case FilterBuilder.Filters.ExcelOpenXMLDocuments:

                    return "Microsoft Excel Open XML Documents (*.xlsx)|*.xlsx";
                case FilterBuilder.Filters.XML_Files:

                    return "XML Files (*.xml)|*.xml";
                case FilterBuilder.Filters.BMP_ImageFiles:

                    return "Bitmap Image Files (*.bmp)|*.bmp";
                case FilterBuilder.Filters.GIF_ImageFiles:

                    return "Graphical Interchange Format Files (*.gif)|*.gif";
                case FilterBuilder.Filters.JPEG_ImageFiles:

                    return "JPEG Image Files (*.jpg,*.jpeg)|*.jpg;*.jpeg";
                case FilterBuilder.Filters.PNG_ImageFiles:

                    return "Portable Network Graphic Files (*.png)|*.png";
                case FilterBuilder.Filters.AllImageFiles:

                    return "All Supported Image Files|*.bmp;*.gif;*.jpg" + ";*.jpeg;*.png;*.tif;*.tiff";
                case FilterBuilder.Filters.PhotoshopDocuments:

                    return "Photoshop Documents (*.psd)|*.psd";
                case FilterBuilder.Filters.PaintShopProImageFiles:

                    return "Paint Shop Pro Image Files (*.psp)|*.psp";
                case FilterBuilder.Filters.ThumbnailImageFiles:

                    return "Thumbnail Image Files (*.thm)|*.thm";
                case FilterBuilder.Filters.TIFF_ImageFiles:

                    return "Tagged Image Files (*.tif,*.tiff)|*.tif;*.tiff";
                case FilterBuilder.Filters.AdobeIllustratorFiles:

                    return "Adobe Illustrator Files (*.ai)|*.ai";
                case FilterBuilder.Filters.DrawingFiles:

                    return "Drawing Files (*.drw)|*.drw";
                case FilterBuilder.Filters.DrawingExchangeFormatFiles:

                    return "Drawing Exchange Format Files (*.dxf)|*.dxf";
                case FilterBuilder.Filters.EncapsulatedPostScriptFiles:

                    return "Encapsulated PostScript Files (*.eps)|*.eps";
                case FilterBuilder.Filters.PostScriptFiles:

                    return "PostScript Files (*.ps)|*.ps";
                case FilterBuilder.Filters.SVG_Files:

                    return "Scalable Vector Graphics Files (*.svg)|*.svg";
                case FilterBuilder.Filters.Rhino3DModels:

                    return "Rhino 3D Models (*.3dm)|*.3dm";
                case FilterBuilder.Filters.AutoCADDrawingDatabaseFiles:

                    return "AutoCAD Drawing Database Files (*.dwg)|*.dwg";
                case FilterBuilder.Filters.ArchiCADProjectFiles:

                    return "ArchiCAD Project Files (*.pln)|*.pln";
                case FilterBuilder.Filters.AdobeInDesignFiles:

                    return "Adobe InDesign Files (*.indd)|*.indd";
                case FilterBuilder.Filters.PDF_Files:

                    return "Portable Document Format Files (*.pdf)|*.pdf";
                case FilterBuilder.Filters.AAC_Files:

                    return "Advanced Audio Coding Files (*.aac)|*.aac";
                case FilterBuilder.Filters.AIF_Files:

                    return "Audio Interchange File Format Files (*.aif)|*.aif";
                case FilterBuilder.Filters.IIF_Files:

                    return "Interchange File Format Files (*.iif)|*.iif";
                case FilterBuilder.Filters.MediaPlaylistFiles:

                    return "Media Playlist Files (*.m3u)|*.m3u";
                case FilterBuilder.Filters.MIDI_Files:

                    return "MIDI Files (*.mid,*.midi)|*.mid;*.midi";
                case FilterBuilder.Filters.MP3_AudioFiles:

                    return "MP3 Audio Files (*.mp3)|*.mp3";
                case FilterBuilder.Filters.MPEG2_AudioFiles:

                    return "MPEG-2 Audio Files (*.mpa)|*.mpa";
                case FilterBuilder.Filters.RealAudioFiles:

                    return "Real Audio Files (*.ra)|*.ra";
                case FilterBuilder.Filters.WAVE_AudioFiles:

                    return "WAVE Audio Files (*.wav)|*.wav";
                case FilterBuilder.Filters.WindowsMediaAudioFiles:

                    return "Windows Media Audio Files (*.wma)|*.wma";
                case FilterBuilder.Filters._3GPP2MultimediaFiles:

                    return "3GPP2 Multimedia Files (*.3g2)|*.3g2";
                case FilterBuilder.Filters._3GPPMultimediaFiles:

                    return "3GPP Multimedia Files (*.3gp)|*.3gp";
                case FilterBuilder.Filters.AVI_Files:

                    return "Audio Video Interleave Files (*.avi)|*.avi";
                case FilterBuilder.Filters.FlashVideoFiles:

                    return "Flash Video Files (*.flv)|*.flv";
                case FilterBuilder.Filters.MatroskaVideoFiles:

                    return "Matroska Video Files (*.mkv)|*.mkv";
                case FilterBuilder.Filters.AppleQuickTimeMoviesMov:

                    return "Apple QuickTime Movie Files (*.mov)|*.mov";
                case FilterBuilder.Filters.MPEG4_VideoFiles:

                    return "MPEG-4 Video Files (*.mp4)|*.mp4";
                case FilterBuilder.Filters.MPEG_VideoFiles:

                    return "MPEG Video Files (*.mpg)|*.mpg";
                case FilterBuilder.Filters.AppleQuickTimeMoviesQT:

                    return "Apple QuickTime Movie Files (*.qt)|*.qt";
                case FilterBuilder.Filters.RealMediaFiles:

                    return "Real Media Files (*.rm)|*.rm";
                case FilterBuilder.Filters.FlashMovies:

                    return "Flash Movies (*.swf)|*.swf";
                case FilterBuilder.Filters.DVDVideoObjectFiles:

                    return "DVD Video Object Files (*.vob)|*.vob";
                case FilterBuilder.Filters.WindowsMediaVideoFiles:

                    return "Windows Media Video Files (*.wmv)|*.wmv";
                case FilterBuilder.Filters.ActiveServerPages:

                    return "Active Server Pages (*.asp)|*.asp";
                case FilterBuilder.Filters.CascadingStyleSheets:

                    return "Cascading Style Sheets (*.css)|*.css";
                case FilterBuilder.Filters.HTML_Files:

                    return "HTML Files (*.htm,*.html)|*.htm;*.html";
                case FilterBuilder.Filters.JavaScriptFiles:

                    return "JavaScript Files (*.js)|*.js";
                case FilterBuilder.Filters.JavaServerPages:

                    return "Java Server Pages (*.jsp)|*.jsp";
                case FilterBuilder.Filters.PHP_Files:

                    return "Hypertext Preprocessor Files (*.php)|*.php";
                case FilterBuilder.Filters.RichSiteSummaryFiles:

                    return "Rich Site Summary Files (*.rss)|*.rss";
                case FilterBuilder.Filters.XHTML_Files:

                    return "XHTML Files (*.xhtml)|*.xhtml";
                case FilterBuilder.Filters.WindowsFontFiles:

                    return "Windows Font Files (*.fnt)|*.fnt";
                case FilterBuilder.Filters.GenericFontFiles:

                    return "Generic Font Files (*.fon)|*.fon";
                case FilterBuilder.Filters.OpenTypeFonts:

                    return "OpenType Fonts (*.otf)|*.otf";
                case FilterBuilder.Filters.TrueTypeFonts:

                    return "TrueType Fonts (*.ttf)|*.ttf";
                case FilterBuilder.Filters.ExcelAddInFiles:

                    return "Excel Add-In Files (*.xll)|*.xll";
                case FilterBuilder.Filters.WindowsCabinetFiles:

                    return "Windows Cabinet Files (*.cab)|*.cab";
                case FilterBuilder.Filters.WindowsControlPanel:

                    return "Windows Control Panel (*.cpl)|*.cpl";
                case FilterBuilder.Filters.WindowsCursors:

                    return "Windows Cursors (*.cur)|*.cur";
                case FilterBuilder.Filters.WindowsMemoryDumps:

                    return "Windows Memory Dumps (*.dmp)|*.dmp";
                case FilterBuilder.Filters.DeviceDrivers:

                    return "Device Drivers (*.drv)|*.drv";
                case FilterBuilder.Filters.SecurityKeys:

                    return "Security Keys (*.key)|*.key";
                case FilterBuilder.Filters.FileShortcuts:

                    return "File Shortcuts (*.lnk)|*.lnk";
                case FilterBuilder.Filters.WindowsSystemFiles:

                    return "Windows System Files (*.sys)|*.sys";
                case FilterBuilder.Filters.ConfigurationFiles:

                    return "Configuration Files (*.cfg)|*.cfg";
                case FilterBuilder.Filters.INI_Files:

                    return "Windows Initialization Files (*.ini)|*.ini";
                case FilterBuilder.Filters.OutlookProfileFiles:

                    return "Outlook Profile Files (*.prf)|*.prf";
                case FilterBuilder.Filters.MacOSXApplications:

                    return "Mac OS X Applications (*.app)|*.app";
                case FilterBuilder.Filters.DOSBatchFiles:

                    return "DOS Batch Files (*.bat)|*.bat";
                case FilterBuilder.Filters.CGI_Files:

                    return "Common Gateway Interface Scripts (*.cgi)|*.cgi";
                case FilterBuilder.Filters.DOSCommandFiles:

                    return "DOS Command Files (*.com)|*.com";
                case FilterBuilder.Filters.WindowsExecutableFiles:

                    return "Windows Executable File (*.exe)|*.exe";
                case FilterBuilder.Filters.WindowsScripts:

                    return "Windows Scripts (*.ws)|*.ws";
                case FilterBuilder.Filters._7ZipCompressedFiles:

                    return "7-Zip Compressed Files (*.7z)|*.7z";
                case FilterBuilder.Filters.DebianSoftwarePackages:

                    return "Debian Software Packages (*.deb)|*.deb";
                case FilterBuilder.Filters.GnuZippedFile:

                    return "Gnu Zipped Files (*.gz)|*.gz";
                case FilterBuilder.Filters.MacOSXInstallerPackages:

                    return "Mac OS X Installer Packages (*.pkg)|*.pkg";
                case FilterBuilder.Filters.WinRARCompressedArchives:

                    return "WinRAR Compressed Archives (*.rar)|*.rar";
                case FilterBuilder.Filters.SelfExtractingArchives:

                    return "Self-Extractingd Archives (*.sea)|*.sea";
                case FilterBuilder.Filters.StuffitArchives:

                    return "Stuffit Archives (*.sit)|*.sit";
                case FilterBuilder.Filters.StuffitXArchives:

                    return "Stuffit X Archives (*.sitx)|*.sitx";
                case FilterBuilder.Filters.ZippedFiles:

                    return "Zipped Files (*.zip)|*.zip";
                case FilterBuilder.Filters.ExtendedZipFiles:

                    return "Extended Zip Files (*.zipx)|*.zipx";
                case FilterBuilder.Filters.BinHex4EncodedFiles:

                    return "BinHex 4.0 Encoded Files (*.hqx)|*.hqx";
                case FilterBuilder.Filters.MultiPurposeInternetMailMessages:

                    return "Multi-Purpose Internet Mail Messages (*.mim)|*.mim";
                case FilterBuilder.Filters.UuencodedFiles:

                    return "Uuencoded Files (*.uue)|*.uue";
                case FilterBuilder.Filters.C_CPlusPlus_SourceCodeFiles:

                    return "C/C++ Source Code Files (*.c)|*.c";
                case FilterBuilder.Filters.CPlusPlus_SourceCodeFiles:

                    return "C++ Source Code Files (*.cpp)|*.cpp";
                case FilterBuilder.Filters.Java_SourceCodeFiles:

                    return "Java Source Code Files (*.java)|*.java";
                case FilterBuilder.Filters.PerlScripts:

                    return "Perl Scripts (*.pl)|*.pl";
                case FilterBuilder.Filters.VB_SourceCodeFiles:

                    return "VB Source Code Files (*.vb)|*.vb";
                case FilterBuilder.Filters.VisualStudioSolutionFiles:

                    return "Visual Studio Solution Files (*.sln)|*.sln";
                case FilterBuilder.Filters.CSharp_SourceCodeFiles:

                    return "C# Source Code Files (*.cs)|*.cs";
                case FilterBuilder.Filters.BackupFiles_BAK:

                    return "Backup Files (*.bak)|*.bak";
                case FilterBuilder.Filters.BackupFiles_BUP:

                    return "Backup Files (*.bup)|*.bup";
                case FilterBuilder.Filters.NortonGhostBackupFiles:

                    return "Norton Ghost Backup Files (*.gho)|*.gho";
                case FilterBuilder.Filters.OriginalFiles:

                    return "Original Files (*.ori)|*.ori";
                case FilterBuilder.Filters.TemporaryFiles:

                    return "Temporary Files (*.tmp)|*.tmp";
                case FilterBuilder.Filters.DiscImageFiles:

                    return "Disc Image Files (*.iso)|*.iso";
                case FilterBuilder.Filters.ToastDiscImages:

                    return "Toast Disc Images (*.toast)|*.toast";
                case FilterBuilder.Filters.Virtual_CDs:

                    return "Virtual CDs (*.vcd)|*.vcd";
                case FilterBuilder.Filters.WindowsInstallerPackages:

                    return "Windows Installer Packages (*.msi)|*.msi";
                case FilterBuilder.Filters.PartiallyDownloadedFiles:

                    return "Partially Downloaded Files (*.part)|*.part";
                case FilterBuilder.Filters.BitTorrentFiles:

                    return "BitTorrent Files (*.torrent)|*.torrent";
                case FilterBuilder.Filters.YahooMessengerDataFiles:

                    return "Yahoo! Messenger Data Files (*.yps)|*.yps";
                case FilterBuilder.Filters.AllFiles:

                    return "All Files (*.*)|*.*";
                case FilterBuilder.Filters.WindowsIcons:

                    return "Windows Icons (*.ico)|*.ico";
                case FilterBuilder.Filters.EXIF_ImageFiles:

                    return "Exchangeable Image Format Files (*.exif)|*.exif";
                default:

                    return null;
            }

        }

        #endregion

    }
}