﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediaApp.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool playlistShow {
            get {
                return ((bool)(this["playlistShow"]));
            }
            set {
                this["playlistShow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool filmDisplayResults {
            get {
                return ((bool)(this["filmDisplayResults"]));
            }
            set {
                this["filmDisplayResults"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection FilmDirectories {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FilmDirectories"]));
            }
            set {
                this["FilmDirectories"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool selectedFilmDetailsShow {
            get {
                return ((bool)(this["selectedFilmDetailsShow"]));
            }
            set {
                this["selectedFilmDetailsShow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool twelvehour {
            get {
                return ((bool)(this["twelvehour"]));
            }
            set {
                this["twelvehour"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Showweekday {
            get {
                return ((bool)(this["Showweekday"]));
            }
            set {
                this["Showweekday"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Showseconds {
            get {
                return ((bool)(this["Showseconds"]));
            }
            set {
                this["Showseconds"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Film")]
        public string TreeSelectionindex {
            get {
                return ((string)(this["TreeSelectionindex"]));
            }
            set {
                this["TreeSelectionindex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("362, 354")]
        public global::System.Drawing.Point FullScreenPanelLoc {
            get {
                return ((global::System.Drawing.Point)(this["FullScreenPanelLoc"]));
            }
            set {
                this["FullScreenPanelLoc"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool resultsCastEditable {
            get {
                return ((bool)(this["resultsCastEditable"]));
            }
            set {
                this["resultsCastEditable"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=|DataDirectory|\\Media.sdf")]
        public string MediaConnectionString {
            get {
                return ((string)(this["MediaConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Setting {
            get {
                return ((string)(this["Setting"]));
            }
            set {
                this["Setting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>*.avi</string>\r\n  <string>*.mkv</string>\r\n  <string>*.wmv</string>\r\n</Arra" +
            "yOfString>")]
        public global::System.Collections.Specialized.StringCollection FilmFileTypes {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FilmFileTypes"]));
            }
            set {
                this["FilmFileTypes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>xvid</string>
  <string>divx</string>
  <string>dvdrip</string>
  <string>ac3</string>
  <string>mp3</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection FilmFileFilter {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FilmFileFilter"]));
            }
            set {
                this["FilmFileFilter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool FilmEnableWatchedFolders {
            get {
                return ((bool)(this["FilmEnableWatchedFolders"]));
            }
            set {
                this["FilmEnableWatchedFolders"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Title</string>
  <string>Keywords</string>
  <string>DirectorIndexing</string>
  <string>GenreIndexing</string>
  <string>PersonIndexing</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Searchpattern {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Searchpattern"]));
            }
            set {
                this["Searchpattern"] = value;
            }
        }
    }
}
