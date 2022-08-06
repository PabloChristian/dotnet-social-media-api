using System.Collections.Generic;

namespace Posterr.Shared.Kernel.Entity
{
    public class ApiBadReturn
    {
        public bool Success { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
