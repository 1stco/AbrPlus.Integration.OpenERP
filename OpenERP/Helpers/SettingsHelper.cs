using AbrPlus.Integration.OpenERP.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    /// <summary>
    /// The settings helper.
    /// contains methods to Create or convert setting from object.
    /// </summary>

    public class SettingsHelper
    {
        /// <summary>Converts an obj to the settings list. </summary>
        /// <param name="obj">  The object. </param>
        /// <returns>   The given data converted to the settings list. </returns>
		public static List<Setting> ConvertToSettingsList(object obj)
        {
            List<Setting> settings = new List<Setting>();
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var setting = new Setting()
                {
                    Key = prop.Name,
                    Value = Convert.ChangeType(prop.GetValue(obj), typeof(string)) as string
                };
                DisplayAttribute attr = (DisplayAttribute)Attribute.GetCustomAttribute(prop, typeof(DisplayAttribute));
                if (attr != null)
                {
                    setting.Title = attr.Name;
                    setting.Description = attr.Description;

                    setting.GroupName = attr.GroupName;
                }
                UIHintAttribute attrUiHint = (UIHintAttribute)Attribute.GetCustomAttribute(prop, typeof(UIHintAttribute));
                if (attrUiHint != null)
                {
                    setting.Type = attrUiHint.UIHint;
                }

                settings.Add(setting);
            }

            return settings;
        }

        /// <summary>   Sets the properties. </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="settings"> Options for controlling the operation. </param>
        /// <returns>   A T. </returns>
		public static T SetProperties<T>(List<Setting> settings) where T : new()
        {
            T obj = new T();

            foreach (var setting in settings)
            {
                PropertyInfo prop = typeof(T).GetProperty(setting.Key);
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
    }
}
