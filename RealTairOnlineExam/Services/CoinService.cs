using EasyTwoJuetengApp.Helpers.JdsClientTool;
using RealTairOnlineExam.Helpers;
using RealTairOnlineExam.Interface;
using RealTairOnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealTairOnlineExam.Services
{
    public class CoinService : IGetAll<JdsMultiResponse<Coin>>,IGet<JdsSingleResponse<Coin>>
    {
        public async Task<JdsSingleResponse<Coin>> Get(string id)
        {
            return await JdsClient.GetAsync<Coin>(AppConstants.GetCoinsByIdEndpoint(id));
        }

        public async Task<JdsMultiResponse<Coin>> GetAll()
        {
            return await JdsClient.GetManyAsync<Coin>(AppConstants.GetAllCoinsEndpoint);
        }

    }
}
