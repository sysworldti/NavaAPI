using System.ComponentModel.DataAnnotations;

namespace Nava.Api.Model
{
    /// <summary>
    /// Entidade base
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
