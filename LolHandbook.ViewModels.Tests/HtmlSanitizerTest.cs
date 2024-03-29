﻿using NUnit.Framework;

namespace LolHandbook.ViewModels
{
    [TestFixture]
    public class HtmlSanitizerTest
    {
        [Test]
        public void SanitizesHtmlTags()
        {
            string html = "<b>foo</b><br><i>bar</i><br />baz";
            Assert.That(HtmlSanitizer.Sanitize(html), Is.EqualTo("foo\nbar\nbaz"));
        }
    }
}
