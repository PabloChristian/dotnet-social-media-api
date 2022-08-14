using System;
using System.Collections.Generic;
using System.Text;

namespace Posterr.Domain.ViewModel.Post
{
    public class CreatePostViewModel
    {
        public Guid Id { get; set; }
        public string PostMessage { get; set; } = string.Empty;
        public string Created { get; set; }
    }
}
