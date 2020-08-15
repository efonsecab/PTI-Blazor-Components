using System;
using Microsoft.AspNetCore.Components;

namespace PTI.BlazorComponents.UI
{
    public partial class DataGridColumn
    {
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public string Caption { get; set; }
        [Parameter]
        public string DataType { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
