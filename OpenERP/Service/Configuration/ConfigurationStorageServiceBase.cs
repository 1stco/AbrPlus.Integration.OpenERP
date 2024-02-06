using AbrPlus.Integration.OpenERP.Settings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace AbrPlus.Integration.OpenERP.Service.Configuration
{
    public abstract class ConfigurationStorageServiceBase<TFinancialSystemSpecificModel> : IConfigurationStorageServiceBase<TFinancialSystemSpecificModel> where TFinancialSystemSpecificModel : class, new()
    {
        private const string FinancialSystemFile = "configuration.xml";
        private readonly static object SettingsSyncLock = new object();

        private ILogger _logger;
        public ConfigurationStorageServiceBase(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType().Name);
        }


        private static FinancialSystemConfig _cache = null;
        private FinancialSystemConfig Cache
        {
            get
            {
#if DEBUG
                lock (SettingsSyncLock)
                {
                    var f = GetConfigFilePath(true);
                    if (File.Exists(f))
                        return ReadFromFile<FinancialSystemConfig>(f);
                    return null;
                }
#endif

                if (_cache == null)
                {
                    lock (SettingsSyncLock)
                    {
                        if (_cache == null)
                        {
                            var f = GetConfigFilePath(true);
                            if (File.Exists(f))
                                _cache = ReadFromFile<FinancialSystemConfig>(f);
                        }
                    }
                }

                return _cache;
            }
        }

        private static void InvalidateCache()
        {
            _cache = null;
        }

        protected abstract string StoragePath { get; }

        protected string GetConfigFilePath(bool backwardCompatible = false)
        {
            var filePath = Path.Combine(StoragePath, FinancialSystemFile);
            if (backwardCompatible && !File.Exists(filePath))
            {
                var oldPath = Environment.ExpandEnvironmentVariables(@"%ProgramData%\Septa\integration");
                var oldConfigFile = Path.Combine(oldPath, FinancialSystemFile);
                if (File.Exists(oldConfigFile))
                {
                    return oldConfigFile;
                }
            }
            return filePath;
        }

        private void SaveToFile<T>(string fileName, T obj) where T : class, new()
        {
            try
            {

                string dir = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(dir))
                {
                    _logger.LogInformation($"Directory {dir} not exist. creating...");
                    Directory.CreateDirectory(dir);
                }

                var serializer = new XmlSerializer(typeof(T));
                using (var file = new FileStream(fileName, FileMode.Create))
                {
                    _logger.LogInformation("Serializing configuration data...");
                    serializer.Serialize(file, obj);
                }

                _logger.LogInformation($"Serializing configuration completed successfully. Storage:{fileName}");

                InvalidateCache();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to save configuration in file: {fileName}");
            }
        }

        private static T ReadFromFile<T>(string fileName) where T : class, new()
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var file = new FileStream(fileName, FileMode.Open))
                return serializer.Deserialize(file) as T;
        }

        public FinancialSystemConfig GetConfig()
        {
            return Cache ?? new FinancialSystemConfig();
            //lock (SettingsSyncLock)
            //{
            //    var fileName = ConfigFilePath;
            //    if (File.Exists(fileName))
            //        return ReadFromFile<FinancialSystemConfig>(fileName);
            //    else
            //        return new FinancialSystemConfig();
            //}
        }

        public void SetConfig(FinancialSystemConfig config)
        {
            lock (SettingsSyncLock)
            {
                var fileName = GetConfigFilePath();
                if (File.Exists(fileName))
                {
                    _logger.LogInformation("configuration file exist.");
                    var existing = ReadFromFile<FinancialSystemConfig>(fileName);
                    if (config.Id == existing.Id)
                    {
                        existing.Title = config.Title;
                        existing.DbAddress = config.DbAddress;
                        existing.DbPassword = config.DbPassword;
                        existing.DbUserName = config.DbUserName;

                        for (int i = 0; i < config.CompanyConfigs.Count; i++)
                        {
                            var newConfig = config.CompanyConfigs[i];
                            var oldConfig = existing.CompanyConfigs.FirstOrDefault(p => p.Id == newConfig.Id);
                            if (oldConfig != null)
                            {
                                existing.CompanyConfigs.Remove(oldConfig);
                            }
                            existing.CompanyConfigs.Add(newConfig);
                        }

                        config = existing;
                    }
                }
                else
                {
                    _logger.LogInformation($"configuration file not exist. Creating new {fileName}");
                }

                SaveToFile(fileName, config);
            }
        }

        public void RemoveFinancialSystem()
        {
            lock (SettingsSyncLock)
            {
                var fileName = GetConfigFilePath();
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }

            InvalidateCache();
        }

        public CompanyConfig GetCompanyConfig(int companyId)
        {
            var financialSystemConfig = GetConfig();
            var result = financialSystemConfig.CompanyConfigs.Find(company => company.Id == companyId);
            return result;
        }

        public void SetCompanyConfig(CompanyConfig companyConfig)
        {
            try
            {
                lock (SettingsSyncLock)
                {
                    var fileName = GetConfigFilePath();
                    var financialSystemConfig = ReadFromFile<FinancialSystemConfig>(fileName);
                    if (companyConfig.Id != 0)
                    {
                        _logger.LogInformation("Updating company information in configuration file.");

                        List<FinancialSystemSpecificConfig> specificConfigs = null;
                        var existingCompanyConfig = financialSystemConfig.CompanyConfigs.Find(company => company.Id == companyConfig.Id);
                        if (existingCompanyConfig != null)
                        {
                            specificConfigs = existingCompanyConfig.SpecificSettings;
                            financialSystemConfig.CompanyConfigs.Remove(existingCompanyConfig);
                        }
                        if (specificConfigs != null)
                            companyConfig.SpecificSettings.AddRange(specificConfigs);
                    }
                    else
                    {
                        _logger.LogInformation("Adding new company information in configuration file.");
                    }

                    financialSystemConfig.CompanyConfigs.Add(companyConfig);
                    SaveToFile(fileName, financialSystemConfig);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SetCompanyConfig");
            }
        }

        public void DeleteCompany(int companyId)
        {
            lock (SettingsSyncLock)
            {
                var fileName = GetConfigFilePath();

                var financialSystemConfig = ReadFromFile<FinancialSystemConfig>(fileName);
                var existingCompanyConfig = financialSystemConfig.CompanyConfigs.Find(company => company.Id == companyId);
                if (existingCompanyConfig != null)
                    financialSystemConfig.CompanyConfigs.Remove(existingCompanyConfig);

                SaveToFile(fileName, financialSystemConfig);
            }
        }

        public FinancialSystemSpecificConfig[] GetSpecificConfigs()
        {
            return GetSpecificConfigs(new TFinancialSystemSpecificModel());
        }

        private FinancialSystemSpecificConfig[] GetSpecificConfigs(TFinancialSystemSpecificModel obj)
        {
            var configs = new List<FinancialSystemSpecificConfig>();
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var config = new FinancialSystemSpecificConfig()
                {
                    Key = prop.Name,
                    Value = Convert.ChangeType(prop.GetValue(obj), typeof(string)) as string
                };

                var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(prop, typeof(DisplayAttribute));
                if (displayAttribute != null)
                {
                    config.GroupName = displayAttribute.GroupName;
                    config.Name = displayAttribute.Name;
                    config.Description = displayAttribute.Description;
                }

                var attrUiHint = (UIHintAttribute)Attribute.GetCustomAttribute(prop, typeof(UIHintAttribute));
                if (attrUiHint != null)
                {
                    config.DisplayType = attrUiHint.UIHint;
                }

                configs.Add(config);
            }

            return configs.ToArray();
        }

        private TFinancialSystemSpecificModel SetProperties(List<FinancialSystemSpecificConfig> settings)
        {
            var obj = new TFinancialSystemSpecificModel();
            if (settings == null || settings.Count == 0)
                return obj;

            foreach (var setting in settings)
            {
                PropertyInfo prop = typeof(TFinancialSystemSpecificModel).GetProperty(setting.Key);
                if (prop != null)
                {
                    object val = setting.Value;
                    if (string.IsNullOrWhiteSpace(setting.Value))
                        val = null;
                    if (val != null)
                    {
                        val = Convert.ChangeType(setting.Value, prop.PropertyType);
                    }
                    prop.SetValue(obj, val);
                }
            }

            return obj;
        }

        public TFinancialSystemSpecificModel GetFinancialSpecificModel(int companyId)
        {
            var companyConfig = GetCompanyConfig(companyId);
            if (companyConfig == null)
                return SetProperties(null);

            return SetProperties(companyConfig.SpecificSettings);
        }
    }
}
