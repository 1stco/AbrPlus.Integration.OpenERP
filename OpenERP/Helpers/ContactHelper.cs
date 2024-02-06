using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    /// <summary>
    /// <para>The main <c>ContactHelper</c> class.</para>
    /// <para>Contains Fields, Methods and Properties.</para>
    /// <para>Contains Phone patterns, continued number pattern</para>
    /// <para>Can add phone number to list, change phone numbers to standard format and etc.</para>
    /// </summary>
    public class ContactHelper
    {
        // Fields
        public const string PhonePattern = "^[0-9]*$";
        public const string ContinuedNumberPattern = "^[0-9]*$";
        public const string CellPhonePattern = @"^(09)(01|02|03|05|10|11|12|13|14|15|16|17|18|19|20|21|22|30|31|32|33|34|35|36|37|38|39|90)(\d{7})$";

        // Methods
        /// <summary>
        /// <para>Change phone number to standard phone number.</para>
        /// <para>Adds new phone number to the contact phone list.</para>
        /// </summary>
        /// <param name="phones">Phone contact list</param>
        /// <param name="phoneType">Type of phone, like Mobile, LandLine and etc</param>
        /// <param name="phoneNumber">Phone number</param>
        /// <param name="key">Unique identifier phone number</param>
        /// <param name="isDefault">Is default number or not.</param>
        /// <see cref="ContactPhone"/>
        /// <seealso cref="PhoneType"/>
        /// <seealso cref="ContactHelper"/>
        /// <seealso cref="GetListContactFromString(string, PhoneType)"/>
        public static void AddToContactPhones(List<ContactPhone> phones, PhoneType phoneType, string phoneNumber, string key, bool isDefault = false)
        {
            foreach (ContactHelper helper in GetListContactFromString(phoneNumber, phoneType))
            {
                var phone = helper.PhoneNumber;
                if (string.IsNullOrEmpty(helper.CountryCode) && !string.IsNullOrEmpty(helper.CityCode))
                {
                    phone = helper.CityCode + phone;
                }
                else if (!string.IsNullOrEmpty(helper.CountryCode) && !string.IsNullOrEmpty(helper.CityCode))
                {
                    phone = helper.CountryCode + helper.CityCode.TrimStart('0') + phone;
                }
                else if (!string.IsNullOrEmpty(helper.CountryCode) && string.IsNullOrEmpty(helper.CityCode))
                {
                    phone = helper.CountryCode + phone;
                }


                ContactPhone item = new ContactPhone
                {
                    Type = phoneType,
                    PhonePrefix = string.Empty,
                    Number = TryMakePhoneNumberFull(phone),
                    ContinuedNumber = helper.ContinuedNumber,
                    IsDefault = isDefault,
                    Key = key
                };
                phones.Add(item);
            }
        }
        /// <summary>
        /// Gets phone number and change it to standard phone number.
        /// </summary>
        /// <remarks>
        /// If gets empty or null string, Just returns exactly the same amount.
        /// </remarks>
        /// <param name="phone">Phone number</param>
        /// <returns>Standard phone number</returns>
        /// <example>
        /// <code>
        /// phoneNumber = TryMakePhoneNumberFull("09120000000")
        /// Console.WriteLine(phoneNumber);
        /// </code>
        /// It will print: +989120000000
        /// </example>
        private static string TryMakePhoneNumberFull(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return phone;

            if (phone.StartsWith("+"))
                return phone;

            if (phone.StartsWith("00"))
                return "+" + phone.Substring(2);

            if (phone.StartsWith("0"))
                return "+98" + phone.Substring(1);

            return phone;
        }

        /// <summary>
        /// Gets city code number and change it to standard city code number.
        /// </summary>
        /// <param name="cityCode">City code number</param>
        /// <example>
        /// <code>
        /// cityNumber = FixCityCode("21")
        /// Console.WriteLine(cityNumber);
        /// </code>
        /// It will print: 021
        /// </example>
        private static void FixCityCode(ref string cityCode)
        {
            if (!cityCode.StartsWith("0"))
            {
                cityCode = "0" + cityCode;
            }
        }

        /// <summary>
        /// Gets country code number and change it to standard city code number.
        /// </summary>
        /// <param name="countryCode">Country code number</param>
        /// <example>
        /// <code>
        /// countryNumber = FixCountryCode("+98")
        /// Console.WriteLine(countryNumber);
        /// </code>
        /// It will print: 0098
        /// </example>
        /// <example>
        /// <code>
        /// countryNumber = FixCountryCode("098")
        /// Console.WriteLine(countryNumber);
        /// </code>
        /// It will print: 0098
        /// </example>
        private static void FixCountryCode(ref string countryCode)
        {
            countryCode = countryCode.Replace("+", "00");
            if (countryCode.StartsWith("0") && (from s in countryCode
                                                where s == '0'
                                                select s).Count() == 1)
            {
                countryCode = "0" + countryCode;
            }
            else if (!countryCode.StartsWith("00"))
            {
                countryCode = "00" + countryCode;
            }
            if (countryCode == "01")
            {
                countryCode = "001";
            }
        }

        /// <summary>
        /// <para>Gets contact text and change it to standard format.</para>
        /// <para>Build a contact helper and fill it with contact text parameters</para>
        /// </summary>
        /// <remarks>
        /// <para>For example if contact text does not contain country code. helper will set country code as null.</para>
        /// <para>If phone type is mobile but it is not valid number, GetContactFromString returns null</para>
        /// <para>If contact text does not like valid format. GetContactFromString returns null</para>
        /// </remarks>
        /// <param name="contactText">full phone number. Contains city code, country code and etc</param>
        /// <param name="phoneType">Type of phone, like Mobile, LandLine and etc</param>
        /// <returns>Return a contact helper.</returns>
        public static ContactHelper GetContactFromString(string contactText, PhoneType phoneType)
        {
            ContactHelper helper = new ContactHelper();
            contactText = contactText.Replace("'", "").Replace("\"", "").Replace("`", "").Replace("*", "");
            string str = contactText;
            if (contactText.StartsWith("(") && contactText.Contains(")") && (from w in contactText
                                                                             where w == '('
                                                                             select w).Count() == 2)
            {
                string countryCode = contactText.Substring(1, contactText.IndexOf(")") - 1);
                FixCountryCode(ref countryCode);
                contactText = contactText.Substring(contactText.IndexOf(")") + 1);
                helper.CountryCode = countryCode;
            }
            if (contactText.StartsWith("(") && contactText.Contains(")"))
            {
                string cityCode = contactText.Substring(1, contactText.IndexOf(")") - 1);
                FixCityCode(ref cityCode);
                contactText = contactText.Substring(contactText.IndexOf(")") + 1);
                helper.CityCode = cityCode;
            }
            if (contactText.StartsWith("0") && contactText.Contains("-") && contactText.IndexOf('-') <= 4)
            {
                string cityCode = contactText.Substring(1, contactText.IndexOf("-") - 1);
                FixCityCode(ref cityCode);
                contactText = contactText.Substring(contactText.IndexOf("-") + 1);
                helper.CityCode = cityCode;
            }
            char[] separator = new char[] { '-' };
            string[] source = contactText.Split(separator);
            helper.PhoneNumber = source[0];
            if (source.Count() == 2)
            {
                helper.ContinuedNumber = source[1];
            }
            if (phoneType == PhoneType.Mobile && !IsCellPhoneNumber(helper.PhoneNumber))
            {
                return null;
            }
            if (!IsPhoneNumber(helper.PhoneNumber))
            {
                return null;
            }
            if (!IsContinuedNumber(helper.ContinuedNumber))
            {
                helper.ContinuedNumber = string.Empty;
            }
            if (string.IsNullOrEmpty(helper.PhoneNumber) || helper.PhoneNumber.Length > 14 || helper.PhoneNumber.Length < 5)
            {
                helper.CityCode = string.Empty;
                helper.ContinuedNumber = string.Empty;
                helper.CountryCode = string.Empty;
                helper.PhoneNumber = str;
                return helper;
            }
            if (!string.IsNullOrEmpty(helper.CityCode) && helper.CityCode.Length > 5)
            {
                helper.CityCode = string.Empty;
                helper.ContinuedNumber = string.Empty;
                helper.CountryCode = string.Empty;
                helper.PhoneNumber = str;
            }
            return helper;
        }

        /// <summary>
        /// Gets text and split it. Then adds each section to the List.
        /// </summary>
        /// <remarks>
        /// If <paramref name="text"/> is null or empty, Returns a new contact helper list.
        /// </remarks>
        /// <param name="text">Contact list as text</param>
        /// <param name="phoneType">Type of phone, like Mobile, LandLine and etc</param>
        /// <returns>List of phone numbers.</returns>
        /// <see cref="GetContactFromString(string, PhoneType)"/>
        public static List<ContactHelper> GetListContactFromString(string text, PhoneType phoneType)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new List<ContactHelper>();
            }
            char[] separator = new char[] { ' ' };
            List<ContactHelper> list = new List<ContactHelper>();
            foreach (string str in text.Split(separator))
            {
                if (!string.IsNullOrEmpty(str) && str.Length >= 4)
                {
                    ContactHelper contactFromString = GetContactFromString(str.Trim(), phoneType);
                    if (contactFromString != null)
                    {
                        list.Add(contactFromString);
                    }
                }
            }
            return list;
        }

        public static string NormalizeNumber(string number)
        {
            number = number.Replace("_", "-");

            if (number.Count(x => x == '-') <= 2 && !number.Any(x => x == '+'))
            {
                var regex = new Regex("[a-z]");
                var res = number.ToLower().Where(x => !regex.IsMatch(x.ToString()));
                var normalizedNumber = string.Join("", res);
                return !normalizedNumber.StartsWith("0") ? $"0{normalizedNumber}" : normalizedNumber;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets number as stirng and checks Cell phone number is valid or not.
        /// </summary>
        /// <param name="number">Cell phone Number</param>
        /// <returns>If number is valid cell phone number, Retuns true.</returns>
        private static bool IsCellPhoneNumber(string number) =>
            !string.IsNullOrEmpty(number)
                ? long.TryParse(number, out _)
                //? Regex.Match(number, @"^(09)(01|02|03|05|10|11|12|13|14|15|16|17|18|19|20|21|22|30|31|32|33|34|35|36|37|38|39|90)(\d{7})$").Success 
                : false;

        private static bool IsContinuedNumber(string continuedNumber) =>
            !string.IsNullOrEmpty(continuedNumber) ? Regex.Match(continuedNumber, "^[0-9]*$").Success : false;

        /// <summary>
        /// Gets number as string and checks Cell phone number is valid or not.
        /// </summary>
        /// <param name="number">Phone Number</param>
        /// <returns>If number is valid phone number, Retuns true.</returns>
        private static bool IsPhoneNumber(string number) =>
            !string.IsNullOrEmpty(number) ? Regex.Match(number, "^[0-9]*$").Success : false;

        // Properties

        /// <summary>
        /// Determines country code like 0098
        /// </summary>
        /// <value>Gets and Sets the value of CountryCode.</value>
        public string CountryCode { get; set; }

        /// <summary>
        /// Determines city code like 021
        /// </summary>
        /// <value>Gets and Sets the value of CityCode.</value>
        public string CityCode { get; set; }

        /// <summary>
        /// Determines phone number like 0912000000
        /// </summary>
        /// <value>Gets and Sets the value of PhoneNumber.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Determines Continued number.
        /// </summary>
        /// <value>Gets and Sets the value of ContinuedNumber.</value>
        public string ContinuedNumber { get; set; }
    }
}
