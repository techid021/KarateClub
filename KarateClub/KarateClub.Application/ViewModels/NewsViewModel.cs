using KarateClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KarateClub.Application.ViewModels
{
    public class NewsViewModel
    {
        public int StartIndex { get; set; }
        public int Count
        {
            get
            {
                return Count;
            }
            set
            {
                if (Count > 300)
                {
                    Count = 300;
                }
                else
                {
                    Count = value;
                }
            }
        } // for paging
        public IEnumerable<News> Notification { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<News> NewsForSlider { get; set; }

    }


}
