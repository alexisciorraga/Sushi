﻿using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Helpers.Extensions;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class ButtonGroupTest
    {
         [Test]
         public void TestDefault()
         {
             HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
             var comparer = SushiExtension.Sushi(htmlHelper).ButtonGroup().ToString();
             Assert.AreEqual(comparer, "<div class=\"btn-group\"></div>");
         }

         [Test]
         public void TestAddButton()
         {  
             HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
             var ButtonElement = SushiExtension.Sushi(htmlHelper).Button();
             var comparer = SushiExtension.Sushi(htmlHelper).ButtonGroup().AddButton(ButtonElement).ToString();
             Assert.AreEqual(comparer, "<div class=\"btn-group\"><input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" /></div>");
         }

    }

}
