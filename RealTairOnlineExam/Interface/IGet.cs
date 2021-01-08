using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealTairOnlineExam.Interface
{
    public interface IGet<TResult>
    {
        Task<TResult> Get(string id);
    }
}
