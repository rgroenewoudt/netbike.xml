#if NET8_0_OR_GREATER

namespace NetBike.Xml.Converters.Basics
{
    using System;
    using NetBike.Xml.Utilities;

    public sealed class XmlDateOnlyConverter : XmlBasicRawConverter<DateOnly>
    {
        protected override DateOnly Parse(string value, XmlSerializationContext context)
        {
            if (DateOnly.TryParse(value, out var date))
                return date;

            return DateOnly.FromDateTime(RfcDateTime.ParseDate(value));
        }

        protected override string ToString(DateOnly value, XmlSerializationContext context)
        {
            return RfcDateTime.ToDateString(value.ToDateTime(TimeOnly.MinValue));
        }
    }
}

#endif