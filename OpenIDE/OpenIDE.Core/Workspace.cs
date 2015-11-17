using DigitalRune.Windows.TextEditor;
using OpenIDE.Core.Contracts;
using OpenIDE.Core.ProjectSystem;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Telerik.WinControls.UI.Docking;

namespace OpenIDE.Core
{
    public static class Workspace
    {
        public static event EventHandler IsIdleChanged;

        private static bool _isIdle;
        public static bool IsIdle
        {
            get { return _isIdle; }
            set {
                _isIdle = value;
                IsIdleChanged?.Invoke(null, null);
            }
        }

        public static TextEditorControl CurrentEditor { get; set; }

        public static PluginManager PluginManager { get; set; }

        public static Solution Solution { get; set; }

        public static string SolutionPath { get; set; }

        public static string AppDataPath { get; set; }
        public static Project SelectedProject { get; set; }

        public static DocumentWindow CurrentDocument { get; set; }

        public static RadDock dockingManager;

        public static Settings Settings = new Settings();

        public static Debug Output { get; set; }

        public static MemoryCache Cache { get; set; }

        public static Dictionary<string, DocumentWindow> OpenedDocuments { get; set; }

        public static void AddToCache(string key, object value, DateTimeOffset duration)
        {
            Cache.Add(new CacheItem(key, value), new CacheItemPolicy() { AbsoluteExpiration = duration });
        }

        static Workspace()
        {
            Solution = new Solution();

            AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\OpenIDE\";
            SolutionPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Cache = MemoryCache.Default;
            OpenedDocuments = new Dictionary<string, DocumentWindow>();
        }
    }
}