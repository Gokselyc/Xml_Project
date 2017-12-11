using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjectDefinition.Models
{
    public class Project
    {
        [DisplayName("ProjectCode")]
        public int ProjectCode { get; set; }

        [DisplayName("Takma Ad")]
        public string NickName { get; set; }

    }
}