﻿namespace NetBike.Xml.Tests.Converters.Basics
{
    using System;
    using System.Collections.Generic;
    using NetBike.Xml.Contracts;
    using NetBike.Xml.Converters;
    using NetBike.Xml.Converters.Basics;
    using NetBike.XmlUnit.NUnitAdapter;
    using NUnit.Framework;

    [TestFixture]
    public class XmlTimeOnlyConverterTests
    {
        [Test]
        public void CanReadTest()
        {
            Assert.IsTrue(GetConverter().CanRead(typeof(TimeOnly)));
        }

        [Test]
        public void CanWriteTest()
        {
            Assert.IsTrue(GetConverter().CanWrite(typeof(TimeOnly)));
        }

        [Test, TestCaseSource(nameof(Samples))]
        public void WriteElementTest(BasicSample sample)
        {
            var expected = $"<xml>{sample.StringValue}</xml>";
            var actual = GetConverter().ToXml(sample.Value);
            Assert.That(actual, IsXml.Equals(expected));
        }

        [Test, TestCaseSource(nameof(Samples))]
        public void WriteAttributeTest(BasicSample sample)
        {
            var expected = $"<xml value=\"{sample.StringValue}\" />";
            var actual = GetConverter().ToXml(sample.Value, member: GetAttributeMember());
            Assert.That(actual, IsXml.Equals(expected));
        }

        [Test, TestCaseSource(nameof(Samples))]
        public void ReadElementTest(BasicSample sample)
        {
            var xml = $"<xml>{sample.StringValue}</xml>";
            var actual = GetConverter().ParseXml<TimeOnly>(xml);
            Assert.AreEqual(sample.Value, actual);
        }

        [Test, TestCaseSource(nameof(Samples))]
        public void ReadAttributeTest(BasicSample sample)
        {
            var xml = $"<xml value=\"{sample.StringValue}\" />";
            var actual = GetConverter().ParseXml<TimeOnly>(xml, member: GetAttributeMember());
            Assert.AreEqual(sample.Value, actual);
        }

        private static XmlMember GetAttributeMember()
        {
            return new XmlMember(typeof(TimeOnly), new XmlName("value"), XmlMappingType.Attribute);
        }

        private static IXmlConverter GetConverter()
        {
            return new XmlTimeOnlyConverter();
        }

        private static IEnumerable<BasicSample> Samples =>
        new[]
        {
            new BasicSample("PT0S", TimeOnly.MinValue),
            new BasicSample("PT2M34S", new TimeOnly(0, 2, 34)),
        };
    }
}