using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    public enum LogType: short
    {
        Error,
        Authorization,
        System
    }

    [Table("Logs")]
    public partial class Log: GenericId
    {
        public int? userId { get; set; }

        public LogType logType { get; set; }
        public DateTime logDate { get; set; }


        [StringLength(40)]
        public string ipAddress { get; set; }

        public string userAgent { get; set; }

        public string exception { get; set; }

        public string message { get; set; }

        public string everything { get; set; }

        [StringLength(500)]
        public string httpReferer { get; set; }

        [StringLength(500)]
        public string pathAndQuery { get; set; }
    }
}
