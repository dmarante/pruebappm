﻿namespace Zoo.Api.ViewModels
{
    public class Parameter
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public string Search { get; set; }
        public int PageSize
        {
            get 
                {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
