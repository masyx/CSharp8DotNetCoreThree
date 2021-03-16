using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Packt.Shared
{
    [Table("Order Details")]
    [Index(nameof(OrderId), Name = "OrderID")]
    [Index(nameof(OrderId), Name = "OrdersOrder_Details")]
    [Index(nameof(ProductId), Name = "ProductID")]
    [Index(nameof(ProductId), Name = "ProductsOrder_Details")]
    public partial class OrderDetail
    {
        [Key]
        [Column("OrderID", TypeName = "int")]
        public long OrderId { get; set; }
        [Key]
        [Column("ProductID", TypeName = "int")]
        public long ProductId { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public byte[] UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public long Quantity { get; set; }
        [Column(TypeName = "real")]
        public double Discount { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
    }
}
