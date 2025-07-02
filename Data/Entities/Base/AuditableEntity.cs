using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Data.Entities.Base
{
    /// <summary>
    /// Base class for entities that require auditing information, such as who created or updated the entity and when.
    /// </summary>
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }   
}
