using System;
using System.Collections.Generic;
using System.Text;

namespace Posterr.Domain.ViewModel.Post
{
    public class CreatePostViewModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Date { get; set; }
    }
}
