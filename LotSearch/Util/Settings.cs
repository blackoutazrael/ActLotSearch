using System;
using System.Collections.Generic;

namespace LotSearch.Util
{
    [Serializable]
    public class Settings 
    {
        #region Singleton

        private static Settings instance;
        private static object singletonLocker = new object();

        public static Settings Default
        {
            get
            {
                lock (singletonLocker)
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        public bool RemoveTooltipSymbols { get; set; }

        public Settings()
        {
            RemoveTooltipSymbols = true;
        }


        #region Load & Save
        /*
        private readonly object locker = new object();

        public void Load()
        {
            lock (this.locker)
            {
                this.Reset();

                if (!File.Exists(this.FileName))
                {
                    this.Save();
                    return;
                }

                var fi = new FileInfo(this.FileName);
                if (fi.Length <= 0)
                {
                    this.Save();
                    return;
                }

                using (var sr = new StreamReader(this.FileName, new UTF8Encoding(false)))
                {
                    if (sr.BaseStream.Length > 0)
                    {
                        var xs = new XmlSerializer(this.GetType());
                        var data = xs.Deserialize(sr) as Settings;
                        if (data != null)
                        {
                            instance = data;
                        }
                    }
                }
            }
        }

        public void Save()
        {
            lock (this.locker)
            {
                var directoryName = Path.GetDirectoryName(this.FileName);

                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                var buffer = new StringBuilder();
                using (var sw = new StringWriter(buffer))
                {
                    var xs = new XmlSerializer(this.GetType());
                    xs.Serialize(sw, this, ns);
                }

                buffer.Replace("utf-16", "utf-8");
                File.WriteAllText(
                    this.FileName,
                    buffer.ToString() + Environment.NewLine,
                    new UTF8Encoding(false));
            }
        }
        */
        #endregion Load & Save

        #region Default Values & Reset

        public static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>()
        {
            { nameof(Settings.RemoveTooltipSymbols), true },
        };

        /*
        /// <summary>
        /// Clone
        /// </summary>
        /// <returns>
        /// このオブジェクトのクローン</returns>
        public Settings Clone() => (Settings)this.MemberwiseClone();

        public void Reset()
        {
            lock (this.locker)
            {
                var pis = this.GetType().GetProperties();
                foreach (var pi in pis)
                {
                    try
                    {
                        var defaultValue =
                            DefaultValues.ContainsKey(pi.Name) ?
                            DefaultValues[pi.Name] :
                            null;

                        if (defaultValue != null)
                        {
                            pi.SetValue(this, defaultValue);
                        }
                    }
                    catch
                    {
                        Debug.WriteLine($"Settings Reset Error: {pi.Name}");
                    }
                }
            }
        }
        */

        #endregion Default Values & Reset
    }
}
