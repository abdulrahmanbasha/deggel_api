namespace bknsystem.privateApi.Models.logs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class system_exceptions
    {
        public int Id { get; set; }

        public string ErrorType { get; set; }

        public string Source { get; set; }

        public string StackTrace { get; set; }

        public string Message { get; set; }

        public string User { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
    }
}
