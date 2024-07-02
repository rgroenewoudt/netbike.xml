#if NET8_0_OR_GREATER

namespace NetBike.Xml.Converters.Basics
{
    using System;
    using System.Xml;

    public sealed class XmlTimeOnlyConverter : XmlBasicRawConverter<TimeOnly>
    {
        protected override TimeOnly Parse(string value, XmlSerializationContext context)
        {
            return TimeOnly.FromTimeSpan(XmlConvert.ToTimeSpan(value));
        }

        protected override string ToString(TimeOnly value, XmlSerializationContext context)
        {
            return XmlConvert.ToString(value.ToTimeSpan());
        }
    }
}

#endif