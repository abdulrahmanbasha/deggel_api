using System.Collections.Generic;
using bknsystem.privateApi.Dtos;
using bknsystem.privateApi.Helpers;
using bknsystem.privateApi.Models;
using martisoor.privateApi_master.Dtos;

namespace martisoor.privateApi_master.Repositories
{
    public interface IGuestRepository
    {
          PagedList<GuestHouseListSummary_Dto> GetGuestHouseListSummaries(RequestParams requestParams = default);
        // List<GuestHouseListSummary_Dto> GetGuestHouseSummaryList();
        

        public guestHouse GetGuestHouseById(string id);
        public guestHouse Create(GuestHouseCreateForm_Dto hotelCreateForm_);
        public string UpdateGuest(string id, guestHouse guestHouseUpdateForm);

        public string DeleteGuestHouse(string id); 
    }
}