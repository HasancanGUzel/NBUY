﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApi.API.Model
{
    public class ProductDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public int[] SelectedCategoryIds { get; set; }
    }
}
