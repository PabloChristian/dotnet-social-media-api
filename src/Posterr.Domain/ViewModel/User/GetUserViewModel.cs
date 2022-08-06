using System;
using System.Collections.Generic;
using System.Text;

namespace Posterr.Domain.ViewModel.User
{
    public class GetUserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
