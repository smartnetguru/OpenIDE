using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenIDE.Core;

namespace OpenIDE.Core_Tests
{
    [TestClass]
    public class MarkupExtensionTest
    {
        [TestMethod]
        public void Parser_Should_Pass()
        {
            var p = MarkupExtensionParser.Parse("{guid 123}");

            Assert.AreEqual("guid", p.Name);
            Assert.AreEqual(1, p.Arguments.Count);
        }

        [TestMethod]
        public void Resolver_Should_Pass()
        {
            JsonExtensionResolver.Init();

            var r = JsonExtensionResolver.Resolve<string>("{guid}");

            Assert.AreEqual(false, string.IsNullOrEmpty(r));
        }
    }
}
