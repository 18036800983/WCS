using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.XML
{
    class XmlConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context,
                                   System.Type destinationType)
        {
            if (destinationType.Name.StartsWith("Xml_"))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(System.String) &&
                 value.GetType().Name.StartsWith("Xml_"))
            {
                return "属性(" + value.GetType().GetProperties().Count().ToString() + ")";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    class ListConverter : CollectionConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType.IsGenericType)
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(System.String) && value != null &&
                 value.GetType().IsGenericType)
            {
                IEnumerable<object> listObjects = (value as IEnumerable<object>);
                return "集合(" + listObjects.Count().ToString() + ")";
            }
            else if (destinationType == typeof(System.String) && value != null &&
                 value.GetType().IsArray)
            {
                object[] arryObj = value as object[];
                return "集合(" + arryObj.Count().ToString() + ")";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    class ArrayConverter : CollectionConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType.IsArray)
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(System.String) && value != null &&
                 value.GetType().IsArray)
            {
                IEnumerable<object> listObjects = (value as IEnumerable<object>);
                return "字符串";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class ComboConverter : StringConverter
    {
        public delegate string[] CartypeNamelist();
        public static CartypeNamelist _CartypeNamelist;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(_CartypeNamelist());
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }

    public class PasswordStringConverter : StringConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType.GetType() == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value.GetType() == typeof(string))
            {
                int stringSize;
                string retVal = "";
                Random randomString = new Random();

                if (value != null)
                    stringSize = ((string)value).Length;
                else
                    stringSize = randomString.Next(10);

                for (int i = 0; i < stringSize; i++)
                    retVal += "*";

                return retVal;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return false;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] standardValues = new string[1];
            int stringSize;
            string retVal = "*";
            Random randomString = new Random();


            stringSize = randomString.Next(10);

            for (int i = 0; i < stringSize; i++)
                retVal += "*";

            standardValues[0] = retVal;

            return new StandardValuesCollection(standardValues);
        }
    }
}
