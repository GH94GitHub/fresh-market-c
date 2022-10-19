using System.ComponentModel.DataAnnotations.Schema;

namespace FreshMarket.Models
{
    public class Payment
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nickname")]
        public string Nickname { get; set; }

        [Column("name_on_card")]
        public string NameOnCard { get; set; }

        [Column("card_no")]
        public string CardNumber { get; set; }

        [Column("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        [Column("cvc_number")]
        public string CvcNumber { get; set; }

        [Column("zipcode")]
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Nickname)}: {Nickname}, {nameof(NameOnCard)}: {NameOnCard}, {nameof(CardNumber)}: {CardNumber}, {nameof(ExpirationDate)}: {ExpirationDate}, {nameof(CvcNumber)}: {CvcNumber}, {nameof(ZipCode)}: {ZipCode}";
        }
    }
}
