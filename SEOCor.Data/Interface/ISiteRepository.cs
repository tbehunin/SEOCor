using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEOCor.Domain.Entities;

namespace SEOCor.Data.Interface
{
    public interface ISiteRepository
    {
        IList<Site> GetSitesByUser(string userId);
    }
}
