using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AcountActivation.Model
{
    public class AcountActivationInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonId { get; set; }
        public Guid ActivationToken { get; set; }

        internal void Update(AcountActivationInfo info)
        {
            PersonId = info.PersonId;
            ActivationToken = info.ActivationToken;
        }
    }
}
