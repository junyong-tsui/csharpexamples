using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 省市联动.Dal;
using 省市联动.Model;

namespace 省市联动.Bll
{
    public class TblAreaBll
    {
        public List<TblArea> GetAreaById(int pid)
        {
            return (new TblAreaDal()).GetTblAreaById(pid);        
        }

        public void DeleteAreaById(int id)
        {
            (new TblAreaDal()).DelTblAreaById(id);
        }
    }
}
