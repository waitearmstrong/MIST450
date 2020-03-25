using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WVHSMVCAppArmstrong.Models
{
    public interface ISchoolRepo
    {
        List<School> ListAllSchools();

        //determine region and classification: based on coachID
        //remove voting coaches school
        List<School> ListSchoolsForRegionalVoting(string classification,int region,int schoolIDofvotingcoach);
    }
}
