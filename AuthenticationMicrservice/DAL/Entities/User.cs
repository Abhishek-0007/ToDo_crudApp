using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AuthenticationMicrservice.DAL.Entities
{
    [Table("userTbl")]
    public class User
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public Byte[] Password { get; set; }
        [JsonIgnore]
        public bool? isLogin { get; set; } = false;

    }
}
