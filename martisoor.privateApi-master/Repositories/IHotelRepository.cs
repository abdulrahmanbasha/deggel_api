using System.Collections.Generic;
using System.Threading.Tasks;
using bknsystem.privateApi.Dtos;
using bknsystem.privateApi.Helpers;
using bknsystem.privateApi.Models;

namespace bknsystem.privateApi.Repositories
{
    public interface IHotelRepository
    {
        PagedList<HotelListSummary_Dto> GetHotelListSummaries(RequestParams requestParams = default);
        List<HotelListSummary_Dto> GetHotelSummaryList();
        

        public hotel GetHotelById(string id);
        public hotel Create(HotelCreateForm_Dto hotelCreateForm_);
        public string UpdateHotel(string id, hotel hotelUpdateForm);

        public string DeleteHotel(string id);

    }
}