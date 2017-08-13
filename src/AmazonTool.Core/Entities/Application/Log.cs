using AmazonTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonTool.Core.Entities.Application
{
    [Table("Log")]
    public class Log : IEntity
    {
        public int Id { get; set; }

        [MaxLength]
        public string Message { get; set; }

        [MaxLength]
        public string MessageTemplate { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        [MaxLength]
        public string Exception { get; set; }

        [MaxLength(128)]
        public string Level { get; set; }

        [MaxLength(50)]
        public string RequestId { get; set; }

        [MaxLength(255)]
        public string UserName { get; set; }
    }
}
