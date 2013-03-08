﻿using System;
using System.Collections;
using System.Collections.Generic;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.Gridhelper
{
    public class GridComponent<T> : ISushiComponent, ISushiSkinnable, ISushiScriptable where T : IList
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public ISushiSkin Skin { get; set; }
        public List<GridStyle> Style { get; set; }
        public GridSize Size { get; set; }
        public List<GridColumn> Columns { get; set; } 
        public T Items { get; set; }
        public String Action { get; set; }
        public GridOptions Options { get; set; }
        public ISushiScript Scripts { get; set; }
        public GridPagination Pagination { get; set; }
        public GridSearch Search { get; set; } 
        #endregion
       
    }
}