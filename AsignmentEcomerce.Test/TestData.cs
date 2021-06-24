using AsignmentEcomerce.Models;
using AsignmentEcomerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Test
{
    public static class TestData
    {
        public static Category CateTestData() => new Category
        {
            NameCategory = "Name Category Test"
        };

        public static CategoryCreateRequest CateCreateTestData() => new CategoryCreateRequest
        {
            NameCategory = "Name Category Test New",
        };

        public static Product ProductTestData() => new Product
        {
            NameProduct = "Name Product Test",
            Description = "Description Product Test",
            Image = "noimage.png",
            UnitPrice = 100000,
            CreateDate = DateTime.Now.Date,
            UpdateDate = DateTime.Now.Date,
        };

        public static ProductVm ProductVmTestData() => new ProductVm
        {
            NameProduct = "Name Product Test",
            Description = "Description Product Test",
            ImageUrl = "noimage.png",
            UnitPrice = 100000,
            NameCategory = "Name Category Test",
        };

        public static ProductCreateRequest ProductCreateTestData() => new ProductCreateRequest
        {
            NameProduct = "Name Product Test",
            Description = "Description Product Test",
            UnitPrice = 100000,
            ImageUrl = null,
            NameCategory = "IdCategory"
        };
    }
}
