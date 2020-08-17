using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace PTI.BlazorComponents.UI
{
    /// <summary>
    /// NOTE: This Grid is not finished yet. I'm figuring out the best way to solve how to build it
    /// </summary>
    public partial class DataGrid<TItem>
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public RenderFragment<DataGridColumn> UserDefinedColumns { get; set; }
        [Parameter]
        public List<DataGridColumn> Columns { get; set; }
        [Parameter]
        public bool DisplayGridTitle { get; set; } = true;
        [Parameter]
        public bool AutogenerateColumns { get; set; } = true;
        [Parameter]
        public IQueryable<TItem> DataItems { get; set; }
        private bool ShouldRenderGrid { get; set; } = false;
        [Parameter]
        public string GridHeaderCssClass { get; set; } = "PTI-DataGrid-Header";
        [Parameter]
        public string EvenRowCssClass { get; set; } = "PTI-DataGrid-EvenRow";
        [Parameter]
        public string OddRowCssClass { get; set; } = "PTI-DataGrid-OddRow";
        [Parameter]
        public string GridPagingButtonsCssClass { get; set; } = "btn btn-primary";
        [Parameter]
        public bool AlternateRowStyles { get; set; } = true;
        [Parameter]
        public string GridTitle { get; set; }
        private int CurrentRowIndex = 0;
        [Parameter]
        public int PageSize { get; set; } = 10;
        //public TItem GH { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)System.Math.Ceiling((decimal)this.DataItems.Count() / this.PageSize);
            }
        }
        private int CurrentPage { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(() =>
            {
                if (this.AutogenerateColumns)
                {
                    this.GenerateColumns();
                }
                else
                    this.ShouldRenderGrid = true;
            });
        }

        private IQueryable<TItem> PageItems
        {
            get
            {
                return this.DataItems.Skip(this.CurrentPage * this.PageSize).Take(this.PageSize);
            }
        }



        public void PreviousPage()
        {
            this.CurrentPage--;
            this.CurrentRowIndex = 0;
        }

        public void NextPage()
        {
            this.CurrentPage++;
            this.CurrentRowIndex = 0;
        }

        private void GenerateColumns()
        {
            if (this.DataItems != null && this.DataItems.Count() > 0)
            {
                this.Columns = new List<DataGridColumn>();
                var firstItem = this.DataItems.First();
                var dataItemType = firstItem.GetType();
                var dataItemProperties = dataItemType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var singleDataItemProperty in dataItemProperties)
                {
                    this.Columns.Add(new DataGridColumn()
                    {
                        Name = singleDataItemProperty.Name,
                        DataType = singleDataItemProperty.DeclaringType.Name
                    });
                }
                this.ShouldRenderGrid = true;
            }
        }

        private string RenderProperty(object property, DataGridColumn column)
        {
            var propertyType = property.GetType();
            var data = propertyType.GetProperty(column.Name).GetValue(property);
            var result = Convert.ToString(data);
            return result;
        }

        private string GetCurrentRowStyle()
        {
            string result = string.Empty;
            if (this.CurrentRowIndex % 2 == 0)
            {
                result = this.EvenRowCssClass;
            }
            else
            {
                result = this.OddRowCssClass;
            }
            CurrentRowIndex++;
            return result;
        }
    }
}
