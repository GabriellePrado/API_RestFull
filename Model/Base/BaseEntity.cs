using System.ComponentModel.DataAnnotations.Schema;
     
namespace API_RestFull.Model.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
