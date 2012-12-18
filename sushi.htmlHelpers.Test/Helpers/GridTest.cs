﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Extensions;
using Sushi.Gridhelper;
using sushi.htmlHelpers.Test.Html;
using sushi.htmlHelpers.Test.Model;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class GridTest
    {
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Grid().ToHtmlString();
            Assert.AreEqual(comparer, "<table class=\"span1\"><thead><tr></tr></thead><tbody></tbody></table>");
        }

        [Test]
        public void TestDefaultBinding10Records()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var resultObtained = SushiExtension.Sushi(htmlHelper).Grid().Bind(ModelFactories.GetPeople10Collection()).ToHtmlString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid10);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestDefaultStronglyTyped()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(new List<Person>());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelper();
            var comparer = SushiExtension.Sushi(htmlHelper).Grid(x => x).ToHtmlString();
            Assert.AreEqual(comparer, "<table class=\"span1\"><thead><tr></tr></thead><tbody></tbody></table>");
        }

        [Test]
        public void TestDefaultStronglyTyped10RecordsModel()
        {
            var ListModel = ModelFactories.GetPeople10Collection();
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ListModel);
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelper();
            var resultObtained = SushiExtension.Sushi(htmlHelper).Grid(x => x).ToHtmlString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid10);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestDefaultStronglyTyped20RecordsModel()
        {
            var ListModel = ModelFactories.GetPeople20Collection();
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ListModel);
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelper();
            var resultObtained = SushiExtension.Sushi(htmlHelper).Grid(x => x).ToHtmlString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestLoadStronglyTyped20RecordsModelPaginating10RecordsPerPage()
        {
            var ListModel = ModelFactories.GetPeople20Collection();
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ListModel);
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelper();
            var resultObtained = SushiExtension.Sushi(htmlHelper).Grid(x => x).Filter( new GridFilter { Pagination = true, ResultsPerPage=10, ShowTotalResults=true }).ToHtmlString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid10);
            Assert.AreEqual(resultExpected, resultObtained);
        }
    }
}