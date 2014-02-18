using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEOCor.Services.DTO;

namespace SEOCor.Services.Interfaces
{
    public interface ISiteService
    {
        IList<SiteDTO> GetSites(string userId);
    }
}
