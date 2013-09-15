#region Using directive

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Aquapool.Models {
    [Serializable]
    public sealed class Message {
        public string Name { get; set; }
        public string Company { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string TargetAddress { get; set; }
    }
}
