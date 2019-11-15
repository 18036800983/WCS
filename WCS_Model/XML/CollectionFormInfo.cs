using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.XML
{
    public class CollectionFormInfo : Attribute
    {
        public string name { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public CollectionFormInfo(string _name, int _width, int _height)
        {
            name = _name;
            width = _width;
            height = _height;
        }
    }
    public class ReportName : Attribute
    {
        public string name { get; set; }
        public int width { get; set; }
        public ReportName(string _name, int _width)
        {
            name = _name;
            width = _width;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class OPCItem : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class OPCAddress : Attribute
    {
        public string name { get; set; }
        public bool useNameProperty { get; set; }

        public OPCAddress(string _name, bool _useNameProperty)
        {
            name = _name;
            useNameProperty = _useNameProperty;
        }
        public OPCAddress(string _name)
        {
            name = _name;
            useNameProperty = false;
        }
    }
}
